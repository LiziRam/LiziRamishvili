using EventsManagement.Application.Events;

namespace EventsManagement.ArchiveWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            _serviceProvider = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var eventService = scope.ServiceProvider.GetRequiredService<IEventService>();

                    await eventService.ArchivePastEventsAsync(stoppingToken).ConfigureAwait(false);

                    await Task.Delay(TimeSpan.FromHours(24), stoppingToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex, "An error occurred while archiving events.");
                }
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
