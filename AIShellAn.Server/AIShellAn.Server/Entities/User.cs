using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [MaxLength(20)]
        public string RealName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public Guid? CreatorId { get; set; }

        public User Creator { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// /该用户是否激活
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [MaxLength(100)]
        public string NativePlace { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 角色，为了简化，直接存储角色名称，多角色直接存储为【标注用户,质检用户】，用逗号分隔.系统包含以下角色：
        ///标注用户,
        ///质检用户,
        ///团队管理员,
        ///项目经理,
        ///系统管理员
        /// </summary>
        [MaxLength(50)]
        public string Role { get; set; }

        /// <summary>
        /// 该用户创建的成员
        /// </summary>
        public ICollection<User> Members { get; set; }


        /// <summary>
        /// 该用户创建的团队
        /// </summary>
        public ICollection<Team> Teams { get; set; }


        /// <summary>
        /// 该用户所在的团队
        /// </summary>
        public ICollection<TeamUser> TeamUser { get; set; }

        /// <summary>
        /// 该用户管理的任务
        /// </summary>
        public ICollection<AnnotationTask> AnnotationTasks { get; set; }


       public ICollection<DataPackage> DataPackages { get; set; }

        /// <summary>
        /// 该用户创建的质检任务
        /// </summary>
        public ICollection<InspectionTask> InspectionTasks { get; set; }

        /// <summary>
        /// 该用户的质检记录
        /// </summary>
        public ICollection<InspectionItemRecord> InspectionItemRecords { get; set; }
    }


    public enum Sex
    {
        男,
        女
    }

   
}
