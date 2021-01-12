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

        public DbSet<User> Users { get; set; }
        public DbSet<Unit>  Units { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        //public DbSet<PermissionGroup> PermissionGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Unit)
                .WithMany(u => u.Resources)
                .HasForeignKey(r => r.UnitId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithMany(ur => ur.Users)
                .HasForeignKey(u => u.UserRoleId);

            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Resource)
                .WithMany(b => b.Bookings)
                .HasForeignKey(i => i.ResourceId);


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
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 14, ResName = "sal 1", Info = "Lektionssal", Activity = "Teorisal", Size = 15, Bookable = true, UnitId = 4 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 15, ResName = "Höger 1", Info = "h1", Activity = "Teorisal", Size = 5, Bookable = true, UnitId = 8 });
            modelBuilder.Entity<Resource>().HasData(new Resource { ResId = 16, ResName = "Storsal", Info = "För Dans och större möten", Activity = "Teorisal", Size = 0, Bookable = true, UnitId = 9 });

            modelBuilder.Entity<UserRole>().HasData(new UserRole { RoleId = 1, RoleName = "Admin" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { RoleId = 2, RoleName = "User" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, UserName = "Admin", FirstName = "Christian", UserRoleId = 1, SingleColor = "#AC7244", PeriodicColor = "#E2DA38" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, UserName = "User", FirstName = "Normal", UserRoleId = 2, SingleColor = "#960981", PeriodicColor = "#ED2B0E" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, UserName = "Booker", FirstName = "Booker", UserRoleId = 2, SingleColor = "#3ABC12", PeriodicColor = "#172DEF" });

            // Bookings
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 1,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-05"),
                StartTime = new DateTime(2021, 01, 12, 13, 15, 00),
                StopTime = new DateTime(2021, 01, 12, 15, 15, 00),
                Leader = "Arne",
                Activity = "Lektion",
                PeriodicId = 0,
                StartDate = DateTime.Parse("2021-01-12"),
                NumberOfWeeks = 1
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 2,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-05"),
                StartTime = new DateTime(2021, 01, 12, 10, 00, 00),
                StopTime = new DateTime(2021, 01, 12, 12, 00, 00),
                Leader = "Berit",
                Activity = "Musik",
                PeriodicId = 1,
                StartDate = DateTime.Parse("2021-01-12"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 3,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-05"),
                StartTime = new DateTime(2021, 01, 19, 10, 00, 00),
                StopTime = new DateTime(2021, 01, 19, 12, 00, 00),
                Leader = "Berit",
                Activity = "Musik",
                PeriodicId = 1,
                StartDate = DateTime.Parse("2021-01-12"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 4,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-05"),
                StartTime = new DateTime(2021, 01, 26, 10, 00, 00),
                StopTime = new DateTime(2021, 01, 26, 12, 00, 00),
                Leader = "Berit",
                Activity = "Musik",
                PeriodicId = 1,
                StartDate = DateTime.Parse("2021-01-12"),
                NumberOfWeeks = 3
            });
             modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 5,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-11"),
                StartTime = new DateTime(2021, 01, 13, 10, 00, 00),
                StopTime = new DateTime(2021, 01, 13, 12, 00, 00),
                Leader = "Clas",
                Activity = "Dans",
                PeriodicId = 2,
                StartDate = DateTime.Parse("2021-01-13"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 6,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-05"),
                StartTime = new DateTime(2021, 01, 20, 10, 00, 00),
                StopTime = new DateTime(2021, 01, 20, 12, 00, 00),
                Leader = "Clas",
                Activity = "Dans",
                PeriodicId = 2,
                StartDate = DateTime.Parse("2021-01-13"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 7,
                UserId = 1,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-05"),
                StartTime = new DateTime(2021, 01, 27, 10, 00, 00),
                StopTime = new DateTime(2021, 01, 27, 12, 00, 00),
                Leader = "Clas",
                Activity = "Dans",
                PeriodicId = 2,
                StartDate = DateTime.Parse("2021-01-13"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 8,
                UserId = 3,
                ResourceId = 5,
                BookingDate = DateTime.Parse("2021-01-11"),
                StartTime = new DateTime(2021, 01, 13, 10, 15, 00),
                StopTime = new DateTime(2021, 01, 13, 12, 15, 00),
                Leader = "Berit",
                Activity = "Lektion",
                PeriodicId = 0,
                StartDate = DateTime.Parse("2021-01-13"),
                NumberOfWeeks = 1
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 9,
                UserId = 3,
                ResourceId = 5,
                BookingDate = DateTime.Parse("2021-01-11"),
                StartTime = new DateTime(2021, 01, 13, 13, 15, 00),
                StopTime = new DateTime(2021, 01, 13, 15, 15, 00),
                Leader = "Berit",
                Activity = "Workshop",
                PeriodicId = 0,
                StartDate = DateTime.Parse("2021-01-13"),
                NumberOfWeeks = 1
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 10,
                UserId = 3,
                ResourceId = 9,
                BookingDate = DateTime.Parse("2021-01-11"),
                StartTime = new DateTime(2021, 01, 13, 13, 15, 00),
                StopTime = new DateTime(2021, 01, 13, 15, 15, 00),
                Leader = "Danne",
                Activity = "Woodchop",
                PeriodicId = 0,
                StartDate = DateTime.Parse("2021-01-13"),
                NumberOfWeeks = 1
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 11,
                UserId = 3,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-08"),
                StartTime = new DateTime(2021, 01, 11, 15, 15, 00),
                StopTime = new DateTime(2021, 01, 11, 17, 15, 00),
                Leader = "Elsy",
                Activity = "Keramik",
                PeriodicId = 3,
                StartDate = DateTime.Parse("2021-01-11"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 12,
                UserId = 3,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-08"),
                StartTime = new DateTime(2021, 01, 18, 15, 15, 00),
                StopTime = new DateTime(2021, 01, 18, 17, 15, 00),
                Leader = "Elsy",
                Activity = "Keramik",
                PeriodicId = 3,
                StartDate = DateTime.Parse("2021-01-11"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 13,
                UserId = 3,
                ResourceId = 4,
                BookingDate = DateTime.Parse("2021-01-08"),
                StartTime = new DateTime(2021, 01, 25, 15, 15, 00),
                StopTime = new DateTime(2021, 01, 25, 17, 15, 00),
                Leader = "Elsy",
                Activity = "Keramik",
                PeriodicId = 3,
                StartDate = DateTime.Parse("2021-01-11"),
                NumberOfWeeks = 3
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                BookingId = 14,
                UserId = 3,
                ResourceId = 9,
                BookingDate = DateTime.Parse("2021-01-08"),
                StartTime = new DateTime(2021, 01, 11, 9, 00, 00),
                StopTime = new DateTime(2021, 01, 11, 11, 00, 00),
                Leader = "Gunnar",
                Activity = "Dans",
                PeriodicId = 0,
                StartDate = DateTime.Parse("2021-01-11"),
                NumberOfWeeks = 1
            });
        }

    }
}
