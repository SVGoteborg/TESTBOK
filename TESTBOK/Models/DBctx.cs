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
            //modelBuilder.Entity<Unit>()
            //    .HasMany(r => r.Resources)
            //    .WithOne(u => u.Unit)
            //    .HasForeignKey(r => r.ResId);

            modelBuilder.Entity<Resource>()
                .HasOne(u => u.Unit)
                .WithMany(r => r.Resources)
                .HasForeignKey(u => u.UnitId);


            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 1, UnitName = "Redbergsskolan", ShortName = "RES", Address = "Örngatan 6," });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 2, UnitName = "Ånässkolan", ShortName = "ÅNÄS", Address = "Falkgatan 8" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 3, UnitName = "Redbergsteatern", ShortName = "RET", Address = "Örngatan 6," });

            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 1, ResName = "Sal 11", Info = "Lektionssal", Activity = "Teorisal", Size = 15, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 2, ResName = "Sal 13", Info = "Lektionssal", Activity = "Teorisal", Size = 10, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 3, ResName = "Stor sal", Info = "Aula", Activity = "Mötessal", Size = 40, Bookable = true, UnitId = 2 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 4, ResName = "Teatersal", Info = "Stor sal", Activity = "Teater", Size = 40, Bookable = true, UnitId = 3 });
        }
    }
}
