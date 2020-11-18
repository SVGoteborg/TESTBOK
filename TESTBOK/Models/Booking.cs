using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Booking
    {
        [Key]
        public int BookId { get; set; }
        public string Time { get; set; }
        public string Activity { get; set; }
        public string Ansvarig { get; set; }
        public int? Size { get; set; }
        public int ResId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
