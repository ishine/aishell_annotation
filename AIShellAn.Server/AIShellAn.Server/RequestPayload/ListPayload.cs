

using System.Collections.Generic;
using System.Linq;

namespace AIShellAn.Server
{
    /// <summary>
    /// 请求参数实体,可继承后扩展 比如添加关键字查询,根据某字段排序等
    /// </summary>
    public class ListPayload
    {
        public ListPayload()
        {
            
        }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int Page { get; set; }
    
    }
}
