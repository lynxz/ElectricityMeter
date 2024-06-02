using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class IotContext : DbContext
{
    public IotContext(DbContextOptions<IotContext> options)
        : base(options)
    {
    }

    public DbSet<MeterReading> MeterReadings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeterReading>()
            .HasIndex(m => m.SerialNumber)
            .HasDatabaseName("IX_MeterReadings_SerialNumber");

        modelBuilder.Entity<MeterReading>()
            .HasIndex(m => new { m.Timestamp, m.SerialNumber })
            .HasDatabaseName("IX_MeterReadings_TimeAndSerialNumber");

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.SerialNumber)
            .IsRequired()
            .HasMaxLength(100);
        
        modelBuilder.Entity<MeterReading>()
            .Property(m => m.Manufacturer)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActiveEnergyConsumed)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActiveEnergyProduced)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactiveEnergyConsumed)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactiveEnergyProduced)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerConsumption)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerProduction)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerConsumption)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerProduction)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.CurrentL1)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.CurrentL2)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.CurrentL3)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.VoltageL1)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.VoltageL2)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.VoltageL3)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerConsumptionL1)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerConsumptionL2)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerConsumptionL3)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerProductionL1)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerProductionL2)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ActivePowerProductionL3)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerConsumptionL1)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerConsumptionL2)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerConsumptionL3)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerProductionL1)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerProductionL2)
            .HasPrecision(18, 3);

        modelBuilder.Entity<MeterReading>()
            .Property(m => m.ReactivePowerProductionL3)
            .HasPrecision(18, 3);
    }


}
