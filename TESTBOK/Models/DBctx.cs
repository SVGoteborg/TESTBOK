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

        //public DbSet<User> Users { get; set; }
        public DbSet<Unit>  Units { get; set; }
        public DbSet<Resource> Resources { get; set; }
        //public DbSet<Booking> Bookings { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        //public DbSet<PermissionGroup> PermissionGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasMany(r => r.Resources)
                .WithOne(u => u.Unit)
                .HasForeignKey(r => r.ResId);


            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 1, UnitName = "Redbergsskolan", ShortName = "RES", Address ="Redbergsplatsen" });

            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 1, ResName = "Sal 1", Info = "Lektionssal", Activity = "Teorisal", Size = 15, Bookable = true });
        }
    }
}
