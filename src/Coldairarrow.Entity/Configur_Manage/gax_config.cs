using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Configur_Manage
{
    /// <summary>
    /// gax_config
    /// </summary>
    [Table("gax_config")]
    public class gax_config
    {

        /// <summary>
        /// 雪花ID
        /// </summary>
        [Key, Column(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string confname { get; set; }

        /// <summary>
        /// 配置內容，字符或是json
        /// </summary>
        public string confvalue { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创造者
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string notes { get; set; }

    }
}