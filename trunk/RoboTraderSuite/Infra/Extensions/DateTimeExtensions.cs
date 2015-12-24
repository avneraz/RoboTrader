using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Global.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the quarter:
        /// Jan to March   - Q1
        /// April to June  - Q2
        /// July to Sep    - Q3
        /// Oct to Dec     - Q4
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static int GetQuarter(this DateTime dateTime)
        {
            if (dateTime.Month <= 3)
                return 1;

            if (dateTime.Month <= 6)
                return 2;

            if (dateTime.Month <= 9)
                return 3;

            return 4;
        }
        /// <summary>
        ///  Quarter 1 in 2016 ==> "1-16".
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetQuarterName(this DateTime dateTime)
        {
            string quarterName =
                 string.Format("{0}-{1:yy}", dateTime.GetQuarter(), dateTime);
            return quarterName;
        }
    }
}
