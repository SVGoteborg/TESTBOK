using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TESTBOK.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResName = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: true),
                    Bookable = table.Column<bool>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResId);
                    table.ForeignKey(
                        name: "FK_Resources_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserPermission = table.Column<int>(nullable: true),
                    UserRoleId = table.Column<int>(nullable: false),
                    SingleColor = table.Column<string>(nullable: true),
                    PeriodicColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    StopTime = table.Column<DateTime>(nullable: false),
                    Leader = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    PeriodicId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    NumberOfWeeks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "Address", "Description", "ShortName", "UnitName" },
                values: new object[,]
                {
                    { 1, "Örngatan 6", "", "RES", "Redbergsskolan" },
                    { 2, "Ånäsvägen 33", "", "ÅNÄS", "Ånässkolan" },
                    { 3, "Örngatan 6", "Teatern", "RET", "Redbergsteatern" },
                    { 4, "Karl Gustavsgatan 15-17", "Vasastan", "KGG", "Karl Gustavsgatan" },
                    { 5, "Örngatan 6", "", "BIL", "Bilar" },
                    { 6, "Örngatan 6", "", "MÖT", "Mötesrum" },
                    { 7, "Örngatan 6", "Bokningsbara resurser såsom mobila datasalen eller liknande", "ÖVR", "Annat bokningsbart" },
                    { 8, "Lillatorpsgatan 10", "", "LL10", "Lillatorpsgatan 10" },
                    { 9, "Brahegatan 11", "", "HHA", "HipHopAkademi" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResId", "Activity", "Bookable", "Info", "ResName", "Size", "UnitId" },
                values: new object[,]
                {
                    { 1, "", true, "*Ej angett", "Café", 0, 1 },
                    { 12, "Mötesrum", true, "Mötesrum på 3e vån i Redbergsskolan", "Mötesrum", 0, 6 },
                    { 13, "Resursbil", true, "Lilla bilen", "VW E-UP", 0, 5 },
                    { 14, "Teorisal", true, "Lektionssal", "sal 1", 15, 4 },
                    { 11, "Teater", true, "Stor sal", "Teater", 0, 3 },
                    { 10, "Mötessal", true, "Stor sal", "Stor sal", 10, 2 },
                    { 8, "Silversmide", true, "Silversmide", "Silver", 10, 1 },
                    { 9, "Träslöjd", true, "Träslöjd", "Träslöjd", 10, 1 },
                    { 6, "Lektionssal", true, "Teorisal", "Sal 18", 20, 1 },
                    { 5, "Föreläsningssal (40p bio)", true, "Teorisal", "Sal 17", 25, 1 },
                    { 4, "Lektionssal", true, "Teorisal", "Sal 13", 8, 1 },
                    { 3, "Tyst läsrum våning 1", true, "Teorisal", "Sal 11", 10, 1 },
                    { 2, "Keramik", true, "Keramik", "Keramik", 0, 1 },
                    { 7, "Lektionssal", true, "Teorisal", "Sal 25", 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName", "PeriodicColor", "SingleColor", "UserName", "UserPermission", "UserRoleId" },
                values: new object[,]
                {
                    { 2, "Normal", null, "#ED2B0E", "#960981", "User", null, 2 },
                    { 1, "Christian", null, "#E2DA38", "#AC7244", "Admin", null, 1 },
                    { 3, "Booker", null, "#172DEF", "#3ABC12", "Booker", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "Activity", "BookingDate", "Leader", "NumberOfWeeks", "PeriodicId", "ResourceId", "StartDate", "StartTime", "StopTime", "UserId" },
                values: new object[,]
                {
                    { 1, "Lektion", new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arne", 1, 0, 4, new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 29, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 29, 15, 15, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Musik", new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berit", 3, 1, 4, new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Musik", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berit", 3, 1, 4, new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Musik", new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berit", 3, 1, 4, new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Dans", new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clas", 3, 1, 4, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Dans", new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clas", 3, 1, 4, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Dans", new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clas", 3, 1, 4, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Lektion", new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berit", 1, 0, 3, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 12, 15, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, "Workshop", new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berit", 1, 0, 3, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 15, 15, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_UnitId",
                table: "Resources",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
