using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTBOK.Models;

namespace TESTBOK.ViewModels
{
    public class UnitResViewModel
    {

        public int Id { get; set; }
        public string UnitName { get; set; }
        public string ResName { get; set; }
        public Unit Unit { get; set; }
        public IEnumerable<Unit> UnitsList { get; set; }
        public IEnumerable<Unit> FilteredUnitsList { get; set; }
        public Resource Resource { get; set; }
        public IEnumerable<Resource> ResourcesList { get; set; }
        public IEnumerable<Resource> FilteredResourceList { get; set; }
        public IEnumerable<Booking> BookingList { get; set; }
        public IEnumerable<User> UserList { get; set; }

    }
}
