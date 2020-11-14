using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTBOK.ViewModels;

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

            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 1, ResName = "Café", Info = "*Ej angett", Activity = "", Size = 0, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 2, ResName = "Keramik", Info = "Keramik", Activity = "Keramik", Size = 0, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 3, ResName = "Sal 11", Info = "Teorisal", Activity = "Tyst läsrum våning 1", Size = 10, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 4, ResName = "Sal 13", Info = "Teorisal", Activity = "Lektionssal", Size = 8, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 5, ResName = "Sal 17", Info = "Teorisal", Activity = "Föreläsningssal (40p bio)", Size = 25, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 6, ResName = "Sal 18", Info = "Teorisal", Activity = "Lektionssal", Size = 20, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 7, ResName = "Sal 25", Info = "Teorisal", Activity = "Lektionssal", Size = 15, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 8, ResName = "Silver", Info = "Silversmide", Activity = "Silversmide", Size = 10, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 9, ResName = "Träslöjd", Info = "Träslöjd", Activity = "Träslöjd", Size = 10, Bookable = true, UnitId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 10, ResName = "Stor sal", Info = "Stor sal", Activity = "Mötessal", Size = 10, Bookable = true, UnitId = 2 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 11, ResName = "Teater", Info = "Stor sal", Activity = "Teater", Size = 0, Bookable = true, UnitId = 3 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 12, ResName = "Mötesrum", Info = "Mötesrum på 3e vån i Redbergsskolan", Activity = "Mötesrum", Size = 0, Bookable = true, UnitId = 6 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 13, ResName = "VW E-UP", Info = "Lilla bilen", Activity = "Resursbil", Size = 0, Bookable = true, UnitId = 5 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 13, ResName = "sal 1", Info = "Lektionssal", Activity = "Teorisal", Size = 15, Bookable = true, UnitId = 4 });
        }

        public DbSet<TESTBOK.ViewModels.UnitResViewModel> UnitResViewModel { get; set; }
    }
}
