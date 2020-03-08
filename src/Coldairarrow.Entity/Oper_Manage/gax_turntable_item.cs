using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Oper_Manage
{
    /// <summary>
    /// gax_turntable_item
    /// </summary>
    [Table("gax_turntable_item")]
    public class gax_turntable_item
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// 1=积分抽奖
        /// </summary>
        public Int32? mold { get; set; }

        /// <summary>
        /// 1=GAX 2=算力 3=其他
        /// </summary>
        public Int32? type { get; set; }

        /// <summary>
        /// 资金
        /// </summary>
        public decimal? amount { get; set; }

        /// <summary>
        /// 中奖率
        /// </summary>
        public decimal? scale { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool hasdelete { get; set; }

        /// <summary>
        /// 奖品名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 创造者
        /// </summary>
        public string CreatorId { get; set; }

    }
}