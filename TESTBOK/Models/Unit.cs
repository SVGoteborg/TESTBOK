using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Unit
    {

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        // Shortname 3 letters
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<Resource> Resources { get; set; }
    }
}
