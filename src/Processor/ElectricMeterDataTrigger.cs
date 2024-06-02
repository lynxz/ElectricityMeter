using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Processor
{
    public static class ElectricMeterDataTrigger
    {
        [FunctionName("ElectricMeterDataTrigger")]
        public static async Task Run(
            [EventHubTrigger("default-iot-hub", Connection = "HubConnectionString")] EventData[] events,
            [Sql("dbo.MeterReadings", "SqlConnectionString")] IAsyncCollector<MeterReading> readings,
            ILogger log)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    // Replace these two lines with your processing logic.
                    log.LogInformation($"C# Event Hub trigger function processed a message");
                    var rawData = eventData.EventBody.ToArray();
                    var messageBytes = new byte[rawData.Length - 4];
                    Array.Copy(rawData, 0, messageBytes, 0, messageBytes.Length);
                    var message = Encoding.ASCII.GetString(messageBytes);
                    log.LogInformation($"Message: {message}");


                    var reading = new MeterReading();
                    foreach (var line in message.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
                    {
                        AddLineToReading(reading, line);
                    }
                    await readings.AddAsync(reading);
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            await readings.FlushAsync();
            log.LogInformation($"Stored telemetry");

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }

        private static void AddLineToReading(MeterReading reading, string line)
        {
            if (line.StartsWith("/"))
            {
                var manufacturer = line.Substring(1, line.IndexOf("\\") - 1);
                var serialNumber = line.Substring(line.IndexOf("\\") + 1);
                reading.SerialNumber = serialNumber;
                reading.Manufacturer = manufacturer;
                return;
            }

            var start = line.IndexOf("(") + 1;
            var length = line.IndexOf("*") - start;
            line = line.Replace(',', '.');
            if (line.StartsWith("0-0:1.0"))
            {
                var timestamp = line.Substring(start, 12);
                reading.Timestamp = DateTime.ParseExact(timestamp, "yyMMddHHmmss", null);
            }
            else if (line.StartsWith("1-0:1.8"))
            {
                var activeEnergyConsumed = line.Substring(start, length);
                reading.ActiveEnergyConsumed = double.Parse(activeEnergyConsumed, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:2.8"))
            {
                var activeEnergyProduced = line.Substring(start, length);
                reading.ActiveEnergyProduced = double.Parse(activeEnergyProduced, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:3.8"))
            {
                var reactiveEnergyConsumed = line.Substring(start, length);
                reading.ReactiveEnergyConsumed = double.Parse(reactiveEnergyConsumed, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:4.8"))
            {
                var reactiveEnergyProduced = line.Substring(start, length);
                reading.ReactiveEnergyProduced = double.Parse(reactiveEnergyProduced, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:1.7"))
            {
                var activePowerConsumption = line.Substring(start, length);
                reading.ActivePowerConsumption = double.Parse(activePowerConsumption, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:2.7"))
            {
                var activePowerProduction = line.Substring(start, length);
                reading.ActivePowerProduction = double.Parse(activePowerProduction, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:3.7"))
            {
                var reactivePowerConsumption = line.Substring(start, length);
                reading.ReactivePowerConsumption = double.Parse(reactivePowerConsumption, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:4.7"))
            {
                var reactivePowerProduction = line.Substring(start, length);
                reading.ReactivePowerProduction = double.Parse(reactivePowerProduction, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:21.7"))
            {
                var activePowerConsumptionL1 = line.Substring(start, length);
                reading.ActivePowerConsumptionL1 = double.Parse(activePowerConsumptionL1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:22.7"))
            {
                var activePowerProductionL1 = line.Substring(start, length);
                reading.ActivePowerProductionL1 = double.Parse(activePowerProductionL1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:41.7"))
            {
                var activePowerConsumptionL2 = line.Substring(start, length);
                reading.ActivePowerConsumptionL2 = double.Parse(activePowerConsumptionL2, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:42.7"))
            {
                var activePowerProductionL2 = line.Substring(start, length);
                reading.ActivePowerProductionL2 = double.Parse(activePowerProductionL2, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:61.7"))
            {
                var activePowerConsumptionL3 = line.Substring(start, length);
                reading.ActivePowerConsumptionL3 = double.Parse(activePowerConsumptionL3, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:62.7"))
            {
                var activePowerProductionL3 = line.Substring(start, length);
                reading.ActivePowerProductionL3 = double.Parse(activePowerProductionL3, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:23.7"))
            {
                var reactivePowerConsumptionL1 = line.Substring(start, length);
                reading.ReactivePowerConsumptionL1 = double.Parse(reactivePowerConsumptionL1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:24.7"))
            {
                var reactivePowerProductionL1 = line.Substring(start, length);
                reading.ReactivePowerProductionL1 = double.Parse(reactivePowerProductionL1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:43.7"))
            {
                var reactivePowerConsumptionL2 = line.Substring(start, length);
                reading.ReactivePowerConsumptionL2 = double.Parse(reactivePowerConsumptionL2, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:44.7"))
            {
                var reactivePowerProductionL2 = line.Substring(start, length);
                reading.ReactivePowerProductionL2 = double.Parse(reactivePowerProductionL2, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:63.7"))
            {
                var reactivePowerConsumptionL3 = line.Substring(start, length);
                reading.ReactivePowerConsumptionL3 = double.Parse(reactivePowerConsumptionL3, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:64.7"))
            {
                var reactivePowerProductionL3 = line.Substring(start, length);
                reading.ReactivePowerProductionL3 = double.Parse(reactivePowerProductionL3, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:32.7"))
            {
                var voltageL1 = line.Substring(start, length);
                reading.VoltageL1 = double.Parse(voltageL1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:52.7"))
            {
                var voltageL2 = line.Substring(start, length);
                reading.VoltageL2 = double.Parse(voltageL2, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:72.7"))
            {
                var voltageL3 = line.Substring(start, length);
                reading.VoltageL3 = double.Parse(voltageL3, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:31.7"))
            {
                var currentL1 = line.Substring(start, length);
                reading.CurrentL1 = double.Parse(currentL1, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:51.7"))
            {
                var currentL2 = line.Substring(start, length);
                reading.CurrentL2 = double.Parse(currentL2, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (line.StartsWith("1-0:71.7"))
            {
                var currentL3 = line.Substring(start, length);
                reading.CurrentL3 = double.Parse(currentL3, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}
