using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Oper_Manage
{
    /// <summary>
    /// gax_turntable_userprize
    /// </summary>
    [Table("gax_turntable_userprize")]
    public class gax_turntable_userprize
    {

        /// <summary>
        /// 自动ID
        /// </summary>
        [Key, Column(Order = 1)]
        public Int64 id { get; set; }

        /// <summary>
        /// userid
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        /// 转盘商品ID
        /// </summary>
        public string turnid { get; set; }

        /// <summary>
        /// 是否领取
        /// </summary>
        public bool haspull { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public Int64? createtime { get; set; }

    }
}