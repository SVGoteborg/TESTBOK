using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESTBOK.Models
{
    public class DBctx : DbContext
    {
        public DBctx(DbContextOptions<DBctx> options)
              : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Unit>  Units { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }

    }
}
