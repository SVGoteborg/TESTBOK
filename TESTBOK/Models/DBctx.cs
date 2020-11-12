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


            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 1, UnitName = "Redbergsskolan", ShortName = "RES", Address = "Örngatan 6", Description ="" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 2, UnitName = "Ånässkolan", ShortName = "ÅNÄS", Address = "Ånäsvägen 33", Description = "" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 3, UnitName = "Redbergsteatern", ShortName = "RET", Address = "Örngatan 6", Description = "Teatern" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 4, UnitName = "Karl Gustavsgatan", ShortName = "KGG", Address = "Karl Gustavsgatan 15-17", Description = "Vasastan" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 5, UnitName = "Bilar", ShortName = "BIL", Address = "Örngatan 6", Description = "" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 6, UnitName = "Mötesrum", ShortName = "MÖT", Address = "Örngatan 6", Description = "" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 7, UnitName = "Annat bokningsbart", ShortName = "ÖVR", Address = "Örngatan 6", Description = "Bokningsbara resurser såsom mobila datasalen eller liknande" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 8, UnitName = "Lillatorpsgatan 10", ShortName = "LL10", Address = "Lillatorpsgatan 10", Description = "" });
            modelBuilder.Entity<Unit>().HasData(new Unit { UnitId = 9, UnitName = "HipHopAkademi", ShortName = "HHA", Address = "Brahegatan 11", Description = "" });

            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 1, ResName = "Sal 11", Info = "Lektionssal", Activity = "Teorisal", Size = 10, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 2, ResName = "Sal 13", Info = "Lektionssal", Activity = "Teorisal", Size = 8, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 3, ResName = "Sal 17", Info = "Lektionssal", Activity = "Teorisal", Size = 25, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 4, ResName = "Sal 18", Info = "Lektionssal", Activity = "Teorisal", Size = 20, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 5, ResName = "Sal 25", Info = "Lektionssal", Activity = "Teorisal", Size = 15, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 6, ResName = "Stor sal", Info = "Stor sal", Activity = "Mötessal", Size = 10, Bookable = true, UnitId = 2 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 7, ResName = "Teater", Info = "Stor sal", Activity = "Teater", Size = 0, Bookable = true, UnitId = 3 });
        }
    }
}
