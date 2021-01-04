using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class Permission
    {

        public int PermId { get; set; }

        // Userpermission No - X, Read - R, Write - W
        public char PermissionName { get; set; }
    }
}
