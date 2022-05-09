using IntradayPowerPositionReport.WorkerService.ExtensionMethods;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntradayPowerPositionReport.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IOptions<ServiceOptions> _serviceOption;

        public Worker(ILogger<Worker> logger, IOptions<ServiceOptions> serviceOptions)
        {
            _logger = logger;
            _serviceOption = serviceOptions;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var millisecondsToUse = GetMillisecondsFromMinutes(_serviceOption.Value.IntervalInMinutes);

            IHost host = Host.CreateDefaultBuilder().Build();
            var logger = host.Services.GetRequiredService<ILogger<IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>>>();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {                    
                    var intradayReport = new IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>(_serviceOption.Value.ExportFilePath, DateTime.UtcNow, logger);
                    
                    // Not using await as I do not wish to impact the subsiquent Task.Delay that controlls the polling schedule 
                    // Throw exception if task takes longer than the specified polling schedule.
                    Task.Run(() => intradayReport.GenerateAsync(), stoppingToken).TimeoutAfter(millisecondsToUse);

                    await Task.Delay(millisecondsToUse, stoppingToken);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }            

            }
        }

        private int GetMillisecondsFromMinutes(int minutes)
        {
            return (int)TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }
    }
}
