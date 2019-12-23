using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 数据包的 长语音数据（一个任务包包含一个或多个数据）
    /// </summary>
    public class LongSpeechItem
    {

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 关联的标注任务,不配置外键
        /// </summary>
        public Guid AnnotationTaskId { get; set; }


        public Guid PackageId { get; set; }
        public DataPackage Package { get; set; }
        /// <summary>
        /// 数据序号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 音频地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 标注用户
        /// </summary>
        public Guid? AnnotationUserId { get; set; }

        public User AnnotationUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 标注时间
        /// </summary>
        public DateTime? AnnotationTime { get; set; }

        /// <summary>
        /// 数据项状态
        /// </summary>
        public ItemStatus ItemStatus { get; set; }

        /// <summary>
        /// 数据是否有效
        /// </summary>
        public bool? Effective { get; set; }

        /// <summary>
        /// 语音的原始文本
        /// </summary>
        public List<LongSpeechText> Texts { get; set; }
    }
}
