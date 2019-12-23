using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 任务数据包（一个任务包含一个或多个数据包）
    /// </summary>
    public class DataPackage
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 关联的任务id
        /// </summary>
        public Guid AnnotationTaskId { get; set; }
        public AnnotationTask AnnotationTask { get; set; }
        /// <summary>
        /// 任务包序号
        /// </summary>
        public int Number { get; set; }

        public Guid? AnnotationUserId { get; set; }

        /// <summary>
        /// 领取的标注用户
        /// </summary>
        public User AnnotationUser { get; set; }

        /// <summary>
        /// 领取的团队,不配置外键
        /// </summary>
        public Guid? TeamId { get; set; }

        [MaxLength(20)]
        public string TeamName { get; set; }


        /// <summary>
        /// 质检的用户,不配置外键
        /// </summary>
        public Guid? InspectionUserId { get; set; }

        /// <summary>
        /// 质检用户的姓名
        /// </summary>
        public string InspectionUser_Name { get; set; }



        /// <summary>
        /// 数据包状态
        /// </summary>
        public PackageStatus PackageStatus { get; set; }


        /// <summary>
        /// 数据包领取时间
        /// </summary>
        public DateTime? RecevieTime { get; set; }

        /// <summary>
        /// 数据包完成时间
        /// </summary>
        public DateTime? FinishTime { get; set; }


        public ICollection<ShortSpeechItem> ShortSpeechItems { get; set; }

        public ICollection<LongSpeechItem> LongSpeechItems { get; set; }

        public ICollection<InspectionPackageRecord> InspectionPackageRecords { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

    }

    public enum PackageStatus
    {
        待领取,
        已领取,
        已完成
    }

    public enum ItemStatus
    {
        待领取,
        已领取,
        已完成
    }


}
