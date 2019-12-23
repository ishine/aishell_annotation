using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 团队-任务关系表
    /// </summary>
    public class TeamAnnotationTask
    {
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public Guid AnnotationTaskId { get; set; }
        public AnnotationTask AnnotationTask { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
