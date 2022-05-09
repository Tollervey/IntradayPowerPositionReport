using IntradayPowerPositionReport.Models;
using Services;
using System;
using System.Collections.Generic;

namespace IntradayPowerPositionReport.Interfaces
{
    public interface ITradePositionAggregator
    {
        IEnumerable<LocalTimeVolume> Aggregate(IEnumerable<PowerTrade> trades, DateTime businessDate);
    }
}
