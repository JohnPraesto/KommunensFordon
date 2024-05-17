using KommunensFordon.Models;
using Microsoft.EntityFrameworkCore;

namespace KommunensFordon.DataContext
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fyller databasen med initial testdata, seed, FORDON

            modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle {VehicleId = 1, LicencePlate = "ABC123", LatestService = new DateTime(2023, 05, 15)},
            new Vehicle {VehicleId = 2, LicencePlate = "DEF456", LatestService = new DateTime(2023, 11, 11)},
            new Vehicle {VehicleId = 3, LicencePlate = "GHI789", LatestService = new DateTime(2024, 03, 20)},
            new Vehicle {VehicleId = 4, LicencePlate = "JKL135", LatestService = new DateTime(2021, 01, 09)});

            // Fyller databasen med initial testdata, seed, FELRAPPORTER

            modelBuilder.Entity<Report>().HasData(
            new Report { ReportId = 1, VehicleId = 1, Reported = new DateTime(2024, 04, 02), Description = "Punktering höger fram", Reporter = "Ann-Charlotte Stenkil", Done = false },
            new Report { ReportId = 2, VehicleId = 1, Reported = new DateTime(2023, 12, 24), Description = "Inslaget i paketpapper", Reporter = "Tobias Carlsson", Done = true },
            new Report { ReportId = 3, VehicleId = 2, Reported = new DateTime(2024, 01, 27), Description = "Bakspegel trasig", Reporter = "Jeanette Qvist", Done = false },
            new Report { ReportId = 4, VehicleId = 3, Reported = new DateTime(2024, 02, 10), Description = "Går ej att starta", Reporter = "Karl Gunnar Svensson", Done = true },
            new Report { ReportId = 5, VehicleId = 4, Reported = new DateTime(2022, 10, 01), Description = "Bromsarna gnisslar", Reporter = "Cecilia Strömer", Done = true },
            new Report { ReportId = 6, VehicleId = 4, Reported = new DateTime(2023, 03, 08), Description = "Nersprayad med grafitti", Reporter = "Björn Johansson", Done = false }
            );
        }
    }
}
