using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KommunensFordon.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatestService = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Reported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reporter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "LatestService", "LicencePlate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC123" },
                    { 2, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "DEF456" },
                    { 3, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHI789" },
                    { 4, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "JKL135" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Description", "Done", "Reported", "Reporter", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Punktering höger fram", false, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann-Charlotte Stenkil", 1 },
                    { 2, "Inslaget i paketpapper", true, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobias Carlsson", 1 },
                    { 3, "Bakspegel trasig", false, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeanette Qvist", 2 },
                    { 4, "Går ej att starta", true, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karl Gunnar Svensson", 3 },
                    { 5, "Bromsarna gnisslar", true, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cecilia Strömer", 4 },
                    { 6, "Nersprayad med grafitti", false, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Björn Johansson", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_VehicleId",
                table: "Reports",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
