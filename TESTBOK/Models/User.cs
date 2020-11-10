using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserPermission { get; set; }
        public int UserRole { get; set; }
        public int Color { get; set; }
    }
}
