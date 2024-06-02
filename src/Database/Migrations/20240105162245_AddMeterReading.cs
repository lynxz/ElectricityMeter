using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMeterReading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterReadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveEnergyConsumed = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActiveEnergyProduced = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactiveEnergyConsumed = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactiveEnergyProduced = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerConsumption = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerProduction = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerConsumption = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerProduction = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    CurrentL1 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    CurrentL2 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    CurrentL3 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    VoltageL1 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    VoltageL2 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    VoltageL3 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerConsumptionL1 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerConsumptionL2 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerConsumptionL3 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerProductionL1 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerProductionL2 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ActivePowerProductionL3 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerConsumptionL1 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerConsumptionL2 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerConsumptionL3 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerProductionL1 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerProductionL2 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false),
                    ReactivePowerProductionL3 = table.Column<double>(type: "float(18)", precision: 18, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_SerialNumber",
                table: "MeterReadings",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_TimeAndSerialNumber",
                table: "MeterReadings",
                columns: new[] { "Timestamp", "SerialNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterReadings");
        }
    }
}
