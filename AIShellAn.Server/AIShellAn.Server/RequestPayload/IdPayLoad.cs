using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server
{
    /// <summary>
    /// 请求参数实体, 前端POST数据时 发送{id:'xxxx'}的JSON对象,需要用一个类来接收
    /// </summary>
    public class IdPayLoad
    {
        public Guid Id { get; set; }
    }
}
