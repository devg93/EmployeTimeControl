
//******************************** Service WorkerCommand **************************************//
// The WorkerCommand class is a background service that continuously executes tasks in a loop
namespace Modules.Break.Module.Core.BreakWorker.Command;
public class BreakWorkerCommand : BackgroundService
{
    private readonly ILogger<BreakWorkerCommand> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    // private readonly dynamic? param=1000;

    public BreakWorkerCommand(ILogger<BreakWorkerCommand> logger, IServiceScopeFactory serviceScopeFactory)
    => (_logger, _serviceScopeFactory) = (logger ?? throw new ArgumentNullException(nameof(logger))
     , serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory)));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("WorkerCommand started.");

        while (!stoppingToken.IsCancellationRequested)
        {
             try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var workerHandler = scope.ServiceProvider.GetRequiredService<IWorkerHenlde>();

          //   await workerHandler.AsyncMethodBreake();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception in WorkerCommand.");
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }

        _logger.LogInformation("WorkerCommand stopped.");
    }

}
