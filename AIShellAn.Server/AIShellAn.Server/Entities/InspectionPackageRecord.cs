using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 质检数据包的记录
    /// </summary>
    public class InspectionPackageRecord
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PackageId { get; set; }

        /// <summary>
        /// 关联的数据包
        /// </summary>
        public DataPackage Package { get; set; }

        /// <summary>
        /// 关联的标注任务,不配置外键
        /// </summary>
        public Guid AnnotationTaskId { get; set; }
        

        /// <summary>
        /// 关联的质检任务
        /// </summary>
        public Guid InspectionTaskId { get; set; }

        public InspectionTask InspectionTask { get; set; }


        /// <summary>
        /// 数据包序号
        /// </summary>
        public int PackageNumber { get; set; }

        /// <summary>
        /// 质检结束时间
        /// </summary>
        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 质检包状态
        /// </summary>
        public InspectionPackageStatus InspectionPackageStatus { get; set; }

        /// <summary>
        /// 记录是第几次质检
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 记录质检该数据包的用户的团队,不配置外键
        /// </summary>
        public Guid? TeamId { get; set; }

        /// <summary>
        /// 质检人员
        /// </summary>
        public Guid? InspectionUserId { get; set; }
        
        public string InspectionUserName { get; set; }


        public ICollection<InspectionItemRecord> InspectionItemRecords { get; set; }

    }


    public enum InspectionPackageStatus
    {
        未质检,
        质检中,
        不合格,
        合格
    }




}
