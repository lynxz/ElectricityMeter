namespace Simulator;

using System;
using System.Text;

public class ElectricalMeter
{
    private readonly string _serialNumber;
    private readonly string _manufacturer;
    private readonly Random _random;
    private double _meterReadingActiveEnergyConsumption;
    private double _meterReadingActiveEnergyProduction;
    private double _meterReadingReactiveEnergyConsumption;
    private double _meterReadingReactiveEnergyProduction;
    private double _activePowerConsumption;
    private double _activePowerProduction;
    private double _reactivePowerConsumption;
    private double _reactivePowerProduction;
    private double _currentL1;
    private double _currentL2;
    private double _currentL3;
    private double _voltageL1;
    private double _voltageL2;
    private double _voltageL3;
    private double _activePowerConsumptionL1;
    private double _activePowerConsumptionL2;
    private double _activePowerConsumptionL3;
    private double _activePowerProductionL1;
    private double _activePowerProductionL2;
    private double _activePowerProductionL3;
    private double _reactivePowerConsumptionL1;
    private double _reactivePowerConsumptionL2;
    private double _reactivePowerConsumptionL3;
    private double _reactivePowerProductionL1;
    private double _reactivePowerProductionL2;
    private double _reactivePowerProductionL3;
    private double _meanConsumption;
    private double _stdDeviationConsumption;

    private ElectricalMeter(string serialNumber, string manufacturer, double yearsOld, double squareMeter)
    {
        var yearlyConsumption = 120.0 * squareMeter;
        _serialNumber = serialNumber;
        _manufacturer = manufacturer;
        _meanConsumption = yearlyConsumption / 8760.0;
        _stdDeviationConsumption = _meanConsumption / 5.0;
        _random = new Random(Guid.NewGuid().GetHashCode());
        _meterReadingActiveEnergyConsumption = GenerateRandomInBellCurve(yearlyConsumption, yearlyConsumption / 10) * yearsOld;
    }

    public static ElectricalMeter Create(string serialNumber, string manufacturer, double yearsOld = 10.0, double squareMeter = 100.0) =>
        new ElectricalMeter(serialNumber, manufacturer, yearsOld, squareMeter);

    public byte[] GetState()
    {
        _activePowerConsumption = GenerateRandomInBellCurve(_meanConsumption, _stdDeviationConsumption);
        _meterReadingActiveEnergyConsumption += _activePowerConsumption / 360.0;
        _meterReadingActiveEnergyProduction += _random.NextDouble();
        _meterReadingReactiveEnergyConsumption += _random.NextDouble();
        _meterReadingReactiveEnergyProduction += _random.NextDouble();
        _activePowerProduction = _random.NextDouble();
        _reactivePowerConsumption = _random.NextDouble();
        _reactivePowerProduction = _random.NextDouble();
        _currentL1 = _random.NextDouble();
        _currentL2 = _random.NextDouble();
        _currentL3 = _random.NextDouble();
        _voltageL1 = _random.NextDouble();
        _voltageL2 = _random.NextDouble();
        _voltageL3 = _random.NextDouble();
        _activePowerConsumptionL1 = _random.NextDouble();
        _activePowerConsumptionL2 = _random.NextDouble();
        _activePowerConsumptionL3 = _random.NextDouble();
        _activePowerProductionL1 = _random.NextDouble();
        _activePowerProductionL2 = _random.NextDouble();
        _activePowerProductionL3 = _random.NextDouble();
        _reactivePowerConsumptionL1 = _random.NextDouble();
        _reactivePowerConsumptionL2 = _random.NextDouble();
        _reactivePowerConsumptionL3 = _random.NextDouble();
        _reactivePowerProductionL1 = _random.NextDouble();
        _reactivePowerProductionL2 = _random.NextDouble();
        _reactivePowerProductionL3 = _random.NextDouble();
        var currentTime = DateTime.Now.ToString("yyMMddHHmmss");

        var sb = new StringBuilder();
        sb.Append($"/{_manufacturer}\\{_serialNumber}\r\n\r\n");
        sb.Append($"0-0:1.0.0({currentTime}W)\r\n");
        sb.Append($"1-0:1.8.0({Math.Round(_meterReadingActiveEnergyConsumption, 3)}*kWh)\r\n");
        sb.Append($"1-0:2.8.0({Math.Round(_meterReadingActiveEnergyProduction, 3)}*kWh)\r\n");
        sb.Append($"1-0:3.8.0({Math.Round(_meterReadingReactiveEnergyConsumption, 3)}*kvarh)\r\n");
        sb.Append($"1-0:4.8.0({Math.Round(_meterReadingReactiveEnergyProduction, 3)}*kvarh)\r\n");
        sb.Append($"1-0:1.7.0({Math.Round(_activePowerConsumption, 3)}*kW)\r\n");
        sb.Append($"1-0:2.7.0({Math.Round(_activePowerProduction, 3)}*kW)\r\n");
        sb.Append($"1-0:3.7.0({Math.Round(_reactivePowerConsumption, 3)}*kvar)\r\n");
        sb.Append($"1-0:4.7.0({Math.Round(_reactivePowerProduction, 3)}*kvar)\r\n");
        sb.Append($"1-0:21.7.0({Math.Round(_activePowerConsumptionL1, 3)}*kW)\r\n");
        sb.Append($"1-0:22.7.0({Math.Round(_activePowerProductionL1, 3)}*kW)\r\n");
        sb.Append($"1-0:41.7.0({Math.Round(_activePowerConsumptionL2, 3)}*kW)\r\n");
        sb.Append($"1-0:42.7.0({Math.Round(_activePowerProductionL2, 3)}*kW)\r\n");
        sb.Append($"1-0:61.7.0({Math.Round(_activePowerConsumptionL3, 3)}*kW)\r\n");
        sb.Append($"1-0:62.7.0({Math.Round(_activePowerProductionL3, 3)}*kW)\r\n");
        sb.Append($"1-0:23.7.0({Math.Round(_reactivePowerConsumptionL1, 3)}*kvar)\r\n");
        sb.Append($"1-0:24.7.0({Math.Round(_reactivePowerProductionL1, 3)}*kvar)\r\n");
        sb.Append($"1-0:43.7.0({Math.Round(_reactivePowerConsumptionL2, 3)}*kvar)\r\n");
        sb.Append($"1-0:44.7.0({Math.Round(_reactivePowerProductionL2, 3)}*kvar)\r\n");
        sb.Append($"1-0:63.7.0({Math.Round(_reactivePowerConsumptionL3, 3)}*kvar)\r\n");
        sb.Append($"1-0:64.7.0({Math.Round(_reactivePowerProductionL3, 3)}*kvar)\r\n");
        sb.Append($"1-0:32.7.0({Math.Round(_voltageL1, 3)}*V)\r\n");
        sb.Append($"1-0:52.7.0({Math.Round(_voltageL2, 3)}*V)\r\n");
        sb.Append($"1-0:72.7.0({Math.Round(_voltageL3, 3)}*V)\r\n");
        sb.Append($"1-0:31.7.0({Math.Round(_currentL1, 3)}*A)\r\n");
        sb.Append($"1-0:51.7.0({Math.Round(_currentL2, 3)}*A)\r\n");
        sb.Append($"1-0:71.7.0({Math.Round(_currentL3, 3)}*A)\r\n!");

        var data = Encoding.ASCII.GetBytes(sb.ToString());
        var result = new byte[data.Length + 4];
        Array.Copy(data, 0, result, 0, data.Length);
        var crc = Crc16.ComputeChecksumBytes(data);
        Array.Copy(crc, 0, result, data.Length, crc.Length);
        result[result.Length - 2] = 0x0D;
        result[result.Length - 1] = 0x0A;

        return result;
    }

    private double GenerateRandomNumber()
    {
        double u1 = 1.0 - _random.NextDouble();
        double u2 = 1.0 - _random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return randStdNormal;
    }

    private double GenerateRandomInBellCurve(double mean, double standardDeviation)
    {
        double randomValue = mean + standardDeviation * GenerateRandomNumber();
        return randomValue;
    }
}
