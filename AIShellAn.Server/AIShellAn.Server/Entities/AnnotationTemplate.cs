using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    public class AnnotationTemplate
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 模板类型
        /// </summary>
        public TemplateType Type { get; set; } //类别

        public  ICollection<AnnotationTemplateItem> TemplateItems { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        public ICollection<AnnotationTask> AnnotationTasks { get; set; }
    }

    public enum TemplateType
    {
        音频,
        图像
    }
}
