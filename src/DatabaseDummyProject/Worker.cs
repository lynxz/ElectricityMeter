using Database;

namespace DatabaseDummyProject;

public class Worker : BackgroundService
{
    private readonly IotContext _context;
    private readonly ILogger<Worker> _logger;

    public Worker(IotContext context, ILogger<Worker> logger)
    {
        _context = context;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
