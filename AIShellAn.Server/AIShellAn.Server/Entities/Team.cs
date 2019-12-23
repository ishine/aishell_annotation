using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 团队
    /// </summary>
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 关联项目经理ID
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// 团队名称
        /// </summary>
        [MaxLength(20)]
        public string TeamName { get; set; }

        /// <summary>
        /// 团队说明介绍
        /// </summary>
        [MaxLength(1000)]
        public string Describe { get; set; }

        public  ICollection<TeamUser> TeamUser { get; set; }

        public ICollection<TeamAnnotationTask> TeamTask { get; set; }

        /// <summary>
        /// 创建该团队的项目经理
        /// </summary>
        public  User Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }
    }
}
