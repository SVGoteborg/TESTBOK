using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public static class Dates
    {
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
    
    }
}
