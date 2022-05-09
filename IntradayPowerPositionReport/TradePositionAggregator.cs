using IntradayPowerPositionReport.ExtensionMethods;
using IntradayPowerPositionReport.Interfaces;
using IntradayPowerPositionReport.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntradayPowerPositionReport
{
    public class TradePositionAggregator : ITradePositionAggregator
    {
        public IEnumerable<LocalTimeVolume> Aggregate(IEnumerable<PowerTrade> trades, DateTime businessDate)
        {
            var result = trades.SelectMany(_ => _.Periods).GroupBy(_ => _.Period).Select(_ => new LocalTimeVolume { LocalTime = _.Key.ConvertIntToLocalTime(businessDate), Volume = _.Sum(x => x.Volume) }).ToList();
            return result;
        }
    }
}
