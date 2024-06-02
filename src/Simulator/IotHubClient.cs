using Microsoft.Azure.Devices.Client;

namespace Simulator;

public class IotHubClient : IDisposable
{

    private readonly string _connectionString;
    private bool _disposed = false;
    private DeviceClient? _deviceClient;

    public IotHubClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task ConnectAsync()
    {
        _deviceClient = DeviceClient.CreateFromConnectionString(_connectionString, TransportType.Mqtt);
        await _deviceClient.OpenAsync();
    }

    public async Task SendTelemetryAsync(byte[] payload, CancellationToken cancellationToken = default)
    {
        if (_deviceClient == null)
            throw new InvalidOperationException("Not connected to IoT Hub.");
        
        var message = new Message(payload);
        await _deviceClient.SendEventAsync(message, cancellationToken);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            if (_deviceClient != null)
            {
                _deviceClient.CloseAsync().GetAwaiter().GetResult();
                _deviceClient.Dispose();
                _disposed = true;
            }

        }
    }

}