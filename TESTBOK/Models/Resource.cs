using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Resource
    {
        
        [Key]
        public int ResId { get; set; }

        // Lokal, Rum, Bil, P-plats, Mötesrum
        public string ResName { get; set; }
        public string Info { get; set; }
        public string Activity { get; set; }
        public int? Size { get; set; }
        public bool Bookable { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }

    
}
