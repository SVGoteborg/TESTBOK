using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string Leader { get; set; }
        public string Activity { get; set; }
        public int PeriodicId { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfWeeks { get; set; }

    }
}
