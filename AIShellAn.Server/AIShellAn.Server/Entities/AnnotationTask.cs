using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 任务，标注任务，质检任务，采集任务等
    /// </summary>
    public class AnnotationTask
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 关联的项目经理,不配置外键
        /// </summary>
        public Guid ManagerId { get; set; }

        public User Manager { get; set; }
        /// <summary>
        /// 关联的标注模板
        /// </summary>
        public Guid? TemplateId { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [MaxLength(100)]
        public string TaskCode { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        [MaxLength(100)]
        public string TaskName { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        [MaxLength(5000)]
        public string TaskDescribe { get; set; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public TaskType TaskType { get; set; }

        /// <summary>
        /// 标注类型
        /// </summary>
        public AnnotationType AnnotationType { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public TaskStatus TaskStatus { get; set; }

        /// <summary>
        /// 任务完成时间
        /// </summary>
        public DateTime? FinshedTime { get; set; }

        /// <summary>
        /// 任务紧急程度
        /// </summary>
        public Urgency Urgency { get; set; }


        /// <summary>
        /// 标注任务的模板
        /// </summary>
        public AnnotationTemplate AnnotationTemplate { get; set; }

        /// <summary>
        /// 任务范围
        /// </summary>
        public TaskScope TaskScope { get; set; }


        

        public ICollection<TeamAnnotationTask> TeamTask { get; set; }

        public ICollection<DataPackage> Packages { get; set; }


        public ICollection<InspectionTask> InspectionTasks { get; set; }

    }

    public enum TaskType
    {
        标注任务,
        采集任务
    }

    public enum AnnotationType
    {
        短语音标注,
        长语音标注,
        图像矩形标注,
        图像多边形标注
    }


    public enum TaskStatus
    {
        未发布,
        进行中,
        暂停,
        已完成
    }

    public enum Urgency
    {
        普通,
        紧急,
        特急
    }

    public enum TaskScope
    {
        私有,//私有任务只能由项目经理分配给团队
        
        公开 //公开任务可以由个人自己领取
    }


}
