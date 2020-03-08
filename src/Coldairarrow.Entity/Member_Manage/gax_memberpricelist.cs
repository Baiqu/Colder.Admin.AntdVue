using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Member_Manage
{
    /// <summary>
    /// gax_memberpricelist
    /// </summary>
    [Table("gax_memberpricelist")]
    public class gax_memberpricelist
    {

        /// <summary>
        /// 雪花ID
        /// </summary>
        [Key, Column(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public string memberid { get; set; }

        /// <summary>
        /// 价格金额
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 会员卡数量
        /// </summary>
        public Int32 quantity { get; set; }

        /// <summary>
        /// 描述内容
        /// </summary>
        public string notes { get; set; }

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