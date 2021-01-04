using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public static class Dates
    {
        private static DateTime tempDate;

        public static DateTime Today { get; set; }
        public static DateTime TempDate { get => tempDate; set => tempDate = value; }


        public static IEnumerable EachDay(this DateTime start, DateTime end)
        {
            // Remove time info from start date (we only care about day). 
            DateTime currentDay = new DateTime(start.Year, start.Month, start.Day);
            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(1);
            }
        }

        public static IEnumerable EachWeek(this DateTime start, DateTime end)
        {
            // Remove time info from start date (we only care about day). 
            DateTime currentDay = new DateTime(start.Year, start.Month, start.Day);
            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(7);
            }
        }

        //    DateTime start = DateTime.Now;
        //    DateTime end = start.AddDays(20);
        //    foreach (var day in start.EachDay(end))
        //    {
        //        ...
        //    }

        public static int LastWeekOfYear(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            var year = cal.GetYear(date);

            DateTime lastDate = new DateTime(year, 12, 31);
            var lastWeek = cal.GetWeekOfYear(lastDate, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
            //List<int> weeksOfYear = new List<int>();
            //for (int i = 1; i <= lastWeek; i++)
            //{
            //    weeksOfYear.Add(cal.GetWeekOfYear(date.AddDays(i * 7), dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
            //}
            return lastWeek;
        }

        public static List<int> Get30Weeks(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            List<int> weeks = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                weeks.Add(cal.GetWeekOfYear(date.AddDays(i * 7), dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
            }
            return weeks;
        }




        // Få fram datum för måndag i veckan
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        //DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);


    }
}
