using System;
using System.Collections.Generic;
using System.Text;

namespace Coldairarrow.Util.Helper
{
    public static class DatetimeHelper
    {
        /// <summary>
        /// 10位的秒时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime ConvertLongToDateTime(long d)
        {
            DateTime dtStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long lTime = long.Parse(d + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }

        public static double NowUnixMillis()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var seconds = (DateTime.UtcNow - origin).TotalSeconds;
            return seconds;
        }
    }
}
