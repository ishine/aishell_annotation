using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 质检任务
    /// </summary>
    public class InspectionTask
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 质检类型
        /// </summary>
        public InspectionType InspectionType { get; set; }


        [MaxLength(50)]
        public string TaskName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 创建质检任务的用户
        /// </summary>
        public Guid CreatorId { get; set; }

        public User Creator { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>

        public DateTime? FinishTime { get; set; }


        /// <summary>
        /// 关联的标注任务
        /// </summary>
        public Guid? AnnotationTaskId { get; set; }

        public AnnotationTask AnnotationTask { get; set; }

        /// <summary>
        /// 质检用户,可以是多个 ,用逗号分隔
        /// </summary>

        public string InspectionUserIds { get; set; }

        /// <summary>
        /// 质检抽取多少个数据包
        /// </summary>
        public int? DrawPackageCount { get; set; }

        /// <summary>
        /// 每个数据包抽取多少百分比的数据
        /// </summary>
        public int? DrawPackagePercent { get; set; }

        /// <summary>
        /// 质检时间段内的数据-开始时间
        /// </summary>
        public DateTime? InspectionTimeRangeStart { get; set; }

        /// <summary>
        /// 质检时间段内的数据-结束时间
        /// </summary>
        public DateTime? InspectionTimeRangeEnd { get; set; }

        /// <summary>
        /// 质检哪些标注人员的数据,可以是多个标注人员,逗号分隔
        /// </summary>
        public string AnnotationUserIds { get; set; }

        /// <summary>
        /// 紧急程度
        /// </summary>
        public Urgency Urgency { get; set; } 

        /// <summary>
        /// 质检结果说明
        /// </summary>
        [MaxLength(1000)]
        public string ResultContent { get; set; }


        /// <summary>
        /// 质检版本-用于记录是第几次复检
        /// </summary>
        public int Version { get; set; }


        /// <summary>
        /// 质检任务状态
        /// </summary>
        public InspectionTaskStatus InspectionTaskStatus { get; set; }



        public ICollection<InspectionPackageRecord> InspectionPackageRecords { get; set; }


    }


    public enum InspectionType
    {
        普通质检,
        复检,
        验收
    }

    public enum InspectionTaskStatus
    {
        未开始,
        质检中,
        暂停,
        已完成
    }

  
}
