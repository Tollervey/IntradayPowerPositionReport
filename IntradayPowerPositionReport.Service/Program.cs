using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntradayPowerPositionReport.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.Configure<ServiceOptions>(configuration.GetSection(nameof(ServiceOptions)));


                    services.AddHostedService<Worker>();

                    var serviceProvider = services.BuildServiceProvider();
                    var logger = serviceProvider.GetService<ILogger<IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>>>();
                    services.AddSingleton(typeof(ILogger), logger);
                });
    }
}
