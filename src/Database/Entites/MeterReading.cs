namespace Database.Entities;

public class MeterReading
{
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public string Manufacturer { get; set; }
    public DateTime Timestamp { get; set; }
    public double ActiveEnergyConsumed { get; set; }
    public double ActiveEnergyProduced { get; set; }
    public double ReactiveEnergyConsumed { get; set; }
    public double ReactiveEnergyProduced { get; set; }
    public double ActivePowerConsumption { get; set; }
    public double ActivePowerProduction { get; set; }
    public double ReactivePowerConsumption { get; set; }
    public double ReactivePowerProduction { get; set; }
    public double CurrentL1 { get; set; }
    public double CurrentL2 { get; set; }
    public double CurrentL3 { get; set; }
    public double VoltageL1 { get; set; }
    public double VoltageL2 { get; set; }
    public double VoltageL3 { get; set; }
    public double ActivePowerConsumptionL1 { get; set; }
    public double ActivePowerConsumptionL2 { get; set; }
    public double ActivePowerConsumptionL3 { get; set; }
    public double ActivePowerProductionL1 { get; set; }
    public double ActivePowerProductionL2 { get; set; }
    public double ActivePowerProductionL3 { get; set; }
    public double ReactivePowerConsumptionL1 { get; set; }
    public double ReactivePowerConsumptionL2 { get; set; }
    public double ReactivePowerConsumptionL3 { get; set; }
    public double ReactivePowerProductionL1 { get; set; }
    public double ReactivePowerProductionL2 { get; set; }
    public double ReactivePowerProductionL3 { get; set; }

}
