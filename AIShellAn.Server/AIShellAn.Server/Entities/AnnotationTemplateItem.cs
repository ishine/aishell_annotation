using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    public class AnnotationTemplateItem
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 模板项名称
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 模板项类型
        /// </summary>
        public TemplateType TemplateType { get; set; }

        /// <summary>
        /// 模板项内容
        /// </summary>
        [MaxLength(200)]
        public string Content { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Necessary { get; set; } = true;

        /// <summary>
        /// 有效还是无效的选项
        /// </summary>
        public bool Effect { get; set; } = true;  

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        [MaxLength(200)]
        public string Default { get; set; }

        public Guid AnnotationTemplateId { get; set; }
      
        public AnnotationTemplate AnnotationTemplate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }
    }

    public enum TemplateItemType
    {
        单选,
        多选,
        文本框
    }
}
