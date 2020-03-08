using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Oper_Manage
{
    /// <summary>
    /// gax_notify
    /// </summary>
    [Table("gax_notify")]
    public class gax_notify
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// 管理员发布或为空
        /// </summary>
        public string senderid { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime createdat { get; set; }

        /// <summary>
        /// 详情内容网址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string imgurl { get; set; }

        /// <summary>
        /// 如果空表示全體，或者是指定用戶ID
        /// </summary>
        public string recipienter { get; set; }

        /// <summary>
        /// 是否公開官方消息
        /// </summary>
        public bool haspublic { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创造者
        /// </summary>
        public string CreatorId { get; set; }

    }
}