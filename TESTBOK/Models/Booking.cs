using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ResourceId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public int PeriodicId { get; set; }
        public int NumberOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        // Behövs den?
        public DateTime EndDate { get; set; }
        // För vilka veckodagar som bokas. Hjälpfält? Skall det vara här. Troligen inte utan vid bokningen.
        //public List<DateTime> Weekdays { get; set; }
    }
}
