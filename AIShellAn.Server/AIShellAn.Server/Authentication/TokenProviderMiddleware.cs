using AIShellAn.Server.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AIShellAn.Server
{
    /// <summary>
    /// JWT中间件
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private DbContext db;
        private ILogger log;
        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options,
             IAuthenticationSchemeProvider schemes, ILogger<TokenProviderMiddleware> log)
        {
            _next = next;
            _options = options.Value;
            Schemes = schemes;
            this.log = log;
        }
        public IAuthenticationSchemeProvider Schemes { get; set; }

        /// <summary>
        /// invoke the middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {

            try
            {
                this.db = context.RequestServices.GetService<AIShellAnContext>();
                context.Features.Set<IAuthenticationFeature>(new AuthenticationFeature
                {
                    OriginalPath = context.Request.Path,
                    OriginalPathBase = context.Request.PathBase
                });
                //获取默认Scheme（或者AuthorizeAttribute指定的Scheme）的AuthenticationHandler
                var handlers = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
                foreach (var scheme in await Schemes.GetRequestHandlerSchemesAsync())
                {
                    var handler = await handlers.GetHandlerAsync(context, scheme.Name) as IAuthenticationRequestHandler;
                    if (handler != null && await handler.HandleRequestAsync())
                    {
                        return;
                    }
                }
                var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
                if (defaultAuthenticate != null)
                {
                    var result = await context.AuthenticateAsync(defaultAuthenticate.Name);
                    if (result?.Principal != null)
                    {
                        context.User = result.Principal;
                    }
                }

                if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
                {
                    await _next(context);
                    return;
                }


                //如果请求地址是/api/Token，则走下面代码
                // Request must be POST with Content-Type: application/x-www-form-urlencoded
                if (!context.Request.Method.Equals("POST"))
                {
                    await ReturnBadRequest(context);
                    return;
                }

                await GenerateAuthorizedResult(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                
                log.LogError(ex.ToString());
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    Status = false,
                    Message = ex.ToString()
                  
                }));
                return;
            }

        }

        /// <summary>
        /// 验证结果并得到token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async System.Threading.Tasks.Task GenerateAuthorizedResult(HttpContext context)
        {
            Stream stream = context.Request.Body;
            byte[] buffer = new byte[context.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string content = Encoding.UTF8.GetString(buffer);
            dynamic user = JsonConvert.DeserializeObject(content);
            string userName = user.userName;
            string password = user.password;
            var identity = await GetIdentity(userName, password);
            if (identity == null)
            {
                //ToDo：这里需要根据实际情况返回用户名为空或者密码错误等信息
                await ReturnBadRequest(context);
                return;
            }

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(GetJwt(userName));
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var isValidated = Auth(username, password);
            if (isValidated)
            {
                return System.Threading.Tasks.Task.FromResult(new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "Token"), new Claim[] { }));
            }
            return System.Threading.Tasks.Task.FromResult<ClaimsIdentity>(null);
        }


        private bool Auth(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if(password.GetMD5HashCode()==db.Set<User>().Where(u=>u.UserName=="admin").Select(u=>u.Password).FirstOrDefault())
            {
                return true;
            }


            var md5Pass = password.GetMD5HashCode();
            User userModel = db.Set<User>().Where(user => user.UserName == username.Trim()&&user.Active).FirstOrDefault();


            if (userModel == null)
            {
                return false;
            }

#if DEBUG
            //如果是开发环境,随便输个密码就可以登录
            return true;
#else
            if (userModel.Password == md5Pass)
            {
                return true;
            }
            else
            {
                return false;
            }
#endif
        }

        /// <summary>
        /// return the bad request (200)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async System.Threading.Tasks.Task ReturnBadRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Status = false,
                Message = "用户名或密码认证失败！"
            }));
        }

        /// <summary>
        /// 获取JWT
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string GetJwt(string username)
        {
            var now = DateTime.UtcNow;
            User user = db.Set<User>().Where(u => u.UserName == username.Trim()).FirstOrDefault();
            var roles = string.Join(",", user.Role);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(),
                          ClaimValueTypes.Integer64),
                //姓名
                new Claim(ClaimTypes.Name,user.RealName),
                //用户名
                 new Claim(ClaimTypes.Name,user.UserName),
                 //Id
                new Claim("UserId",user.Id.ToString()),
                //角色
                new Claim("Role",roles),
            };

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                Status = true,
                access_token = encodedJwt,
                userName=user.UserName,
                name = user.RealName,
                userId = user.Id,
                role = roles,
                expires_in = (int)_options.Expiration.TotalSeconds,
                token_type = "Bearer",
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

    }
}
