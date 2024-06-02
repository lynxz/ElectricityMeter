﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(IotContext))]
    [Migration("20240105162245_AddMeterReading")]
    partial class AddMeterReading
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.Entities.MeterReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ActiveEnergyConsumed")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActiveEnergyProduced")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerConsumption")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerConsumptionL1")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerConsumptionL2")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerConsumptionL3")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerProduction")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerProductionL1")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerProductionL2")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ActivePowerProductionL3")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("CurrentL1")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("CurrentL2")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("CurrentL3")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("ReactiveEnergyConsumed")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactiveEnergyProduced")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerConsumption")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerConsumptionL1")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerConsumptionL2")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerConsumptionL3")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerProduction")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerProductionL1")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerProductionL2")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("ReactivePowerProductionL3")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<double>("VoltageL1")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("VoltageL2")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.Property<double>("VoltageL3")
                        .HasPrecision(18, 3)
                        .HasColumnType("float(18)");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .HasDatabaseName("IX_MeterReadings_SerialNumber");

                    b.HasIndex("Timestamp", "SerialNumber")
                        .HasDatabaseName("IX_MeterReadings_TimeAndSerialNumber");

                    b.ToTable("MeterReadings");
                });
#pragma warning restore 612, 618
        }
    }
}
