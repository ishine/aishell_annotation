using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIShellAn.Server.Entities;
using AIShellAn.Server.IServices;
using AIShellAn.Server.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIShellAn.Server.Controllers.v1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AIShellAnContext _db;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(AIShellAnContext dbContext, IMapper mapper,IUserService userService)
        {
            _db = dbContext;
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid id)
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult Add([FromBody]UserModel model)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult List(ListPayload payload)
        {
            return Ok();
        }



        [HttpPost]
        public IActionResult Update([FromBody]UserModel model)
        {
            return Ok();
        }

        
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }





    }
}