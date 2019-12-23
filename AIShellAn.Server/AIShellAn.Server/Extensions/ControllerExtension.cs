using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AIShellAn.Server.Entities;

namespace AIShellAn.Server
{
    public static class ControllerExtension
    {
        public static Guid GetCurrentUserId(this ControllerBase controller)
        {
            string userId = controller.HttpContext.User.FindFirst("UserId").Value;
            return Guid.Parse(userId);
        }

        public static string GetCurrentUserName(this ControllerBase controller)
        {
            string userName = controller.HttpContext.User.FindFirst("UserName").Value;
            return userName;
        }

        public static bool IsInRole(this ControllerBase controller, DbContext db,string role)
        {
            string userId = controller.HttpContext.User.FindFirst("UserId").Value;
            string[] roles = role.Split(',');
            for(int i=0;i<roles.Length;i++)
            {
                var user = db.Set<User>().Where(u => u.Id == Guid.Parse(userId) && u.Role.Contains(roles[i])).Count();
                if (user > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
