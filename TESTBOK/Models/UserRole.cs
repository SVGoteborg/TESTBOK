using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        // Admin, User, "Bokare"
        public string RoleName { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
