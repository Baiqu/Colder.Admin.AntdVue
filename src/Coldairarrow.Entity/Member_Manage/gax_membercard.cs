using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Member_Manage
{
    /// <summary>
    /// gax_membercard
    /// </summary>
    [Table("gax_membercard")]
    public class gax_membercard
    {

        /// <summary>
        /// 雪花ID
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public String memberid { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// 会员卡名称
        /// </summary>
        public String notes { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public Decimal amount { get; set; }

        /// <summary>
        /// 单位月份
        /// </summary>
        public Int32 mcycle { get; set; }

        /// <summary>
        /// 创作者
        /// </summary>
        public String CreatorId { get; set; }

    }
}