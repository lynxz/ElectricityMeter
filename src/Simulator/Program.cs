// See https://aka.ms/new-console-template for more information

using Simulator;
using CommandLine;

Parameter? parameter = null;
ParserResult<Parameter> result = Parser.Default.ParseArguments<Parameter>(args)
    .WithParsed(p => parameter = p)
    .WithNotParsed(e => Environment.Exit(1));

using var client = new IotHubClient(parameter!.ConnectionString);
var meter = ElectricalMeter.Create(parameter!.DeviceId, parameter!.Manufacturer);

Console.WriteLine($"Simulating Electrical Meter and sending result to IoT Hub.");

using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) =>
{
    e.Cancel = true;
    cts.Cancel();
    Console.WriteLine("Exiting...");
};

await client.ConnectAsync();
Console.WriteLine("Connected to IoT Hub.");

while (cts.Token.IsCancellationRequested == false) {
    var payload = meter.GetState();
    await client.SendTelemetryAsync(payload, cts.Token);
    Console.WriteLine($"Sent telemetry!");
    await Task.Delay(10*1000);
}