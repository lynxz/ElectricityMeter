using CommandLine;

namespace Simulator;

internal class Parameter
{

    [Option(
            'c',
            "ConnectionString",
            Required = true,
            HelpText = "The IoT hub device connection string. This is available by clicking any existing device under the 'Devices' blade in the Azure portal.")]
    public string ConnectionString { get; set; } = "";
    [Option(
            'd',
            "Device Id",
            Required = true,
            HelpText = "ID of the current electrical meter being simulated.")]
    public string DeviceId { get; set; } = "";
    [Option(
            'm',
            "Manufacturer",
            Required = true,
            HelpText = "Manufacturer electrical meter being simulated.")]
    public string Manufacturer { get; set; } = "";
}