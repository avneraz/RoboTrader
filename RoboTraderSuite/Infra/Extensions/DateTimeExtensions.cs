using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
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
                $"{dateTime.GetQuarter()}-{dateTime:yy}";
            return quarterName;
        }

        /// <summary>
        /// Get the left days from now to the expiry date in 'Eastern Standard Time' - USA .
        /// </summary>
        /// <param name="expiryDate"></param>
        /// <returns></returns>
        public static int DaysLeftInUSA(this  DateTime expiryDate)
        {
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");//Israel Standard Time
            DateTime dateTimeInUsa = TimeZoneInfo.ConvertTime(DateTime.Now, est);

            return (int)expiryDate.Subtract(dateTimeInUsa).TotalDays;
        }

        /// <summary>
        /// Gets the expiration date. of the specific date.
        /// Return the last Thursday that the option will be expired
        /// </summary>
        /// <param name="theMonth">The month.</param>
        /// <returns></returns>
        public static DateTime GetExpirationDate(this DateTime theMonth)
        {
            var days = GetDaysToExpired(theMonth);
            DateTime expiredDate = theMonth.AddDays(days);
            return expiredDate;
        }
        /// <summary>
        /// Gets the last Friday of month.
        /// </summary>
        /// <param name="theMonth">The month.</param>
        /// <returns></returns>
        public static DateTime GetLastFridayOfMonth(this DateTime theMonth)
        {
            DateTime dtMaxValue = DateTime.MaxValue;
            DateTime dtLastDayOfMonth = new DateTime(theMonth.Year, theMonth.Month,
                DateTime.DaysInMonth(theMonth.Year, theMonth.Month));

            // while (dtMaxValue == DateTime.MaxValue)
            while (true)
            {
                // Returns if the decremented day is the first Friday from last(IE our last Friday)
                if (dtMaxValue == DateTime.MaxValue && dtLastDayOfMonth.DayOfWeek == DayOfWeek.Friday)
                    return dtLastDayOfMonth;

                // Decrements last day by one
                dtLastDayOfMonth = dtLastDayOfMonth.AddDays(-1.0);
            }
        }

        public static DateTime GetThirdFridayOfMonth(this DateTime theMonth)
        {
            DateTime tempDate = new DateTime(theMonth.Year, theMonth.Month, 1);
            // find first friday
            while (tempDate.DayOfWeek != DayOfWeek.Friday)
                tempDate = tempDate.AddDays(1);

            // add two weeks
            tempDate = tempDate.AddDays(14);
            return tempDate;
        }
        /// <summary>
        /// Gets the days to expired. 
        /// calculates the number of days from the date to the last Friday of the month minus 1.
        /// </summary>
        /// <param name="theMonth">The month.</param>
        /// <returns></returns>
        public static int GetDaysToExpired(this DateTime theMonth)
        {
            DateTime dtLastDayOfMonth = theMonth.GetLastFridayOfMonth();
            var days = dtLastDayOfMonth.Subtract(theMonth).TotalDays;
            if (days > 0)
                return (int)days;

            //Find the first day of next month
            DateTime theNextMonth = theMonth.AddMonths(1);
            theNextMonth = new DateTime(theNextMonth.Year, theNextMonth.Month, 1);
            days = theNextMonth.Subtract(theMonth).TotalDays + theNextMonth.GetDaysToExpired();
            return (int)days;
        }
    }
}
