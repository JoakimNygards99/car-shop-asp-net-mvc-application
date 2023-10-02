﻿// <auto-generated />
using CarShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230814143133_SeedCarTable")]
    partial class SeedCarTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarShop.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<string>("MotorFuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Colour = "red",
                            Description = "fin bil",
                            GearBox = "Manual",
                            HorsePower = 499,
                            Mileage = 13000L,
                            Model = "AudiRS6",
                            ModelYear = 2007,
                            MotorFuel = "Disel",
                            Path = "jucke/jucke",
                            Price = 599999
                        },
                        new
                        {
                            Id = 2,
                            Colour = "Blue",
                            Description = "fin a3 bil",
                            GearBox = "Automat",
                            HorsePower = 200,
                            Mileage = 20000L,
                            Model = "AudiA3",
                            ModelYear = 1999,
                            MotorFuel = "Bensin",
                            Path = "jucke/jucke",
                            Price = 90000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
