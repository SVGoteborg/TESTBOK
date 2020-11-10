using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Resource
    {
        public int ResId { get; set; }

        // Lokal, Rum, Bil, P-plats, Mötesrum
        public string ResName { get; set; }
        public string Info { get; set; }
        public string Activity { get; set; }
        public int Size { get; set; }
        public bool Bookable { get; set; }
    }
}
