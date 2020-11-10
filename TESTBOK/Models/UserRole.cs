using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class UserRole
    {

        public int RoleId { get; set; }

        // Admin, User, "Bokare"
        public string RoleName { get; set; }
    }
}
