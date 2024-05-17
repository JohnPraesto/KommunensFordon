﻿// <auto-generated />
using System;
using KommunensFordon.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KommunensFordon.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    partial class VehicleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KommunensFordon.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Reported")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reporter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Reports");

                    b.HasData(
                        new
                        {
                            ReportId = 1,
                            Description = "Punktering höger fram",
                            Done = false,
                            Reported = new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reporter = "Ann-Charlotte Stenkil",
                            VehicleId = 1
                        },
                        new
                        {
                            ReportId = 2,
                            Description = "Inslaget i paketpapper",
                            Done = true,
                            Reported = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reporter = "Tobias Carlsson",
                            VehicleId = 1
                        },
                        new
                        {
                            ReportId = 3,
                            Description = "Bakspegel trasig",
                            Done = false,
                            Reported = new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reporter = "Jeanette Qvist",
                            VehicleId = 2
                        },
                        new
                        {
                            ReportId = 4,
                            Description = "Går ej att starta",
                            Done = true,
                            Reported = new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reporter = "Karl Gunnar Svensson",
                            VehicleId = 3
                        },
                        new
                        {
                            ReportId = 5,
                            Description = "Bromsarna gnisslar",
                            Done = true,
                            Reported = new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reporter = "Cecilia Strömer",
                            VehicleId = 4
                        },
                        new
                        {
                            ReportId = 6,
                            Description = "Nersprayad med grafitti",
                            Done = false,
                            Reported = new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reporter = "Björn Johansson",
                            VehicleId = 4
                        });
                });

            modelBuilder.Entity("KommunensFordon.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<DateTime>("LatestService")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            LatestService = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LicencePlate = "ABC123"
                        },
                        new
                        {
                            VehicleId = 2,
                            LatestService = new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LicencePlate = "DEF456"
                        },
                        new
                        {
                            VehicleId = 3,
                            LatestService = new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LicencePlate = "GHI789"
                        },
                        new
                        {
                            VehicleId = 4,
                            LatestService = new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LicencePlate = "JKL135"
                        });
                });

            modelBuilder.Entity("KommunensFordon.Models.Report", b =>
                {
                    b.HasOne("KommunensFordon.Models.Vehicle", "Vehicle")
                        .WithMany("Reports")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("KommunensFordon.Models.Vehicle", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
