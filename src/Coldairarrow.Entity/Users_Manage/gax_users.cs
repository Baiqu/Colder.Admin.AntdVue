using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Users_Manage
{
    /// <summary>
    /// gax_users
    /// </summary>
    [Table("gax_users")]
    public class gax_users
    {

        /// <summary>
        /// 自增长数字
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// userid
        /// </summary>
        [Key, Column(Order = 2)]
        public String userid { get; set; }

        /// <summary>
        /// fundpassword
        /// </summary>
        public String fundpassword { get; set; }

        /// <summary>
        /// headurl
        /// </summary>
        public String headurl { get; set; }

        /// <summary>
        /// nick
        /// </summary>
        public String nick { get; set; }

        /// <summary>
        /// 0=女 1=男
        /// </summary>
        public Int32 sex { get; set; }

        /// <summary>
        /// 用戶稱號
        /// </summary>
        public String usertypeid { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public String invitecode { get; set; }

        /// <summary>
        /// 推广用户ID
        /// </summary>
        public String refuserid { get; set; }

        /// <summary>
        /// 創建日期
        /// </summary>
        public DateTime? created { get; set; }

        /// <summary>
        /// 自動標識
        /// </summary>
        public Int64? usernumid { get; set; }

        /// <summary>
        /// 開戶地址
        /// </summary>
        public String openarea { get; set; }

    }
}