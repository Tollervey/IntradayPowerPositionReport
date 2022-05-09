using IntradayPowerPositionReport.ExtensionMethods;
using IntradayPowerPositionReport.Interfaces;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace IntradayPowerPositionReport
{
    public class IntradayReport<T1, T2> where T1 : ITradePositionAggregator, new() where T2 : ILocalTimeVolumeGenerator, new()
    {
        private readonly ILogger<IntradayReport<T1, T2>> log;

        public string FilePath { get; private set; }

        private ITradePositionAggregator TradePositionAggregator { get; set; }

        private ILocalTimeVolumeGenerator LocalTimeVolumeFileGenerator { get; set; }

        private readonly PowerService _powerService;

        private readonly DateTime _businessDate;

        public IntradayReport(string path, DateTime businessDate, ILogger<IntradayReport<T1, T2>> logger)
        {
            log = logger;
            if (businessDate.IsHoliday())
            {
                log.LogWarning("Running intraday report for a non-business day");
            }

            // Ideally would be injected but there is no interface
            _powerService = new PowerService();
            TradePositionAggregator = new T1();
            LocalTimeVolumeFileGenerator = new T2();
            _businessDate = businessDate;

            log.LogDebug($"Instanciating IntradayReportFileGenerator with path {path}");
            if (string.IsNullOrWhiteSpace(path))
            {
                var exception = new ArgumentNullException(nameof(path));
                log.LogError($"Invalid path value provided: '{path}'", exception);
                throw exception;
            }

            this.FilePath = path;
        }

        public async Task<bool> GenerateAsync()
        {

            log.LogInformation("Starting intraday report async generation.");
            log.LogInformation($"Getting source trade data for business date {_businessDate}");
            string fullPath;
            try
            {
                var businessDateFromBeginningOfDay = new DateTime(_businessDate.Year, _businessDate.Month, _businessDate.Day);
                var sourceTradeData = await _powerService.GetTradesAsync(businessDateFromBeginningOfDay);
                log.LogDebug($"Total source trade data count = {sourceTradeData.Count()}");

                log.LogInformation("Starting local trade volume aggregation");
                var aggregatedLocalTradeVolumes = TradePositionAggregator.Aggregate(sourceTradeData, businessDateFromBeginningOfDay);
                log.LogDebug($"Aggregated local trade volume count = {aggregatedLocalTradeVolumes.Count()}");

                log.LogInformation($"Generating file in {FilePath}");
                fullPath = LocalTimeVolumeFileGenerator.Generate(aggregatedLocalTradeVolumes, FilePath, _businessDate);

            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Error generating file. {ex.Message}");
                throw; // preserve original stack trace
            }

            log.LogInformation($"File generated to path '{fullPath}'");

            return true;
            
        }
    }
}
