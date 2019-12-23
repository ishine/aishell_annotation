using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    /// <summary>
    /// 标注结果记录, 每个数据只有一条正式标注结果,每质检一次会保存一次标注结果快照
    /// </summary>
    public class AnnotationResult
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 关联的数据项,不配置外键
        /// </summary>

        public Guid ItemId { get; set; }

        public AnnotationResultType AnnotationResultType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }


        /// <summary>
        /// 花费时间 (记录该标注结果花费了多长时间) 单位秒
        /// </summary>

        public float SpendTime { get; set; }


        /// <summary>
        /// 记录资源加载花费时间单位秒
        /// </summary>
        public float LoadingTime { get; set; }


        /// <summary>
        /// 标注人员  ,不配置外键
        /// </summary>
        public Guid UserId { get; set; }


        /// <summary>
        /// 该字段在postgresql数据库中会以json形式存储
        /// </summary>
        [Column(TypeName = "jsonb")]
        public string Content { get; set; }

    }

    public enum AnnotationResultType
    {
        普通,
        快照
    }
}
