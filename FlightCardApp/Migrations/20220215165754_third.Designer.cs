﻿// <auto-generated />
using System;
using FlightCardApp.libs.persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightCardApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220215165754_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightCardApp.libs.domain.Airport", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirPorts");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.Flight", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightCompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightPlaningId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ToId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FlightCompanyId");

                    b.HasIndex("FlightPlaningId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.FlightPlaning", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ConnectionFlight")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FlightPlanings");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.FlightTypePrice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlightPlaningId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlightPlaningId");

                    b.ToTable("FlightTypePrice");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.Flight", b =>
                {
                    b.HasOne("FlightCardApp.libs.domain.Company", "FlightCompany")
                        .WithMany()
                        .HasForeignKey("FlightCompanyId");

                    b.HasOne("FlightCardApp.libs.domain.FlightPlaning", null)
                        .WithMany("Flights")
                        .HasForeignKey("FlightPlaningId");

                    b.HasOne("FlightCardApp.libs.domain.Airport", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("FlightCardApp.libs.domain.Airport", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.Navigation("FlightCompany");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.FlightTypePrice", b =>
                {
                    b.HasOne("FlightCardApp.libs.domain.FlightPlaning", null)
                        .WithMany("Prices")
                        .HasForeignKey("FlightPlaningId");
                });

            modelBuilder.Entity("FlightCardApp.libs.domain.FlightPlaning", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
