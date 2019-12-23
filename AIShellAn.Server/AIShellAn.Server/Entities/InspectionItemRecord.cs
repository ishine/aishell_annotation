using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 质检数据项的记录
    /// </summary>
    public class InspectionItemRecord
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 关联的数据项
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// 关联的标注任务
        /// </summary>
        public Guid AnnotationTaskId { get; set; }
        public AnnotationTask AnnotationTask { get; set; }

        /// <summary>
        /// 关联的质检任务 不配置外键
        /// </summary>
        public Guid InspectionTaskId { get; set; }
     
        

        /// <summary>
        /// 关联的质检包
        /// </summary>
        public Guid? InspectionPackageRecordId { get; set; }

        public InspectionPackageRecord InspectionPackageRecord { get; set; }

        public DateTime? InspectionTime { get; set; }

        /// <summary>
        /// 质检状态
        /// </summary>
        public InspectionStatus InspectionStatus { get; set; }

        /// <summary>
        /// 质检错误类型
        /// </summary>
        public InspectionErrorType ErrorType { get; set; }

        /// <summary>
        /// 质检意见
        /// </summary>
        [MaxLength(1000)]
        public string Suggestion { get; set; }

        /// <summary>
        /// 质检用户
        /// </summary>
        public Guid? InspectionUserId { get; set; }
        public  User InspectionUser { get; set; }

        public int Version { get; set; } 

        /// <summary>
        /// 标注结果的快照
        /// </summary>
        public Guid AnnotationResultId { get; set; }

        public AnnotationResult AnnotationResult { get; set; }


        /// <summary>
        /// 花费时间 (记录该质检记录花费了多长时间)
        /// </summary>

        public float SpendTime { get; set; }
    }



    /// <summary>
    /// 质检错误类型
    /// </summary>
    [System.Flags]
    public enum InspectionErrorType
    {
        无 = 0,
        有效性错误 = 2,
        性别错误 = 4,
        文本错误 = 8,
        截取错误 = 16,
        噪音错误 = 32,
        口音错误 = 64,
        其它 = 128
    }

    public enum InspectionStatus
    {
        未质检,
        质检不合格,
        质检合格,
    }
}
