using IntradayPowerPositionReport.Models;
using System;
using System.Collections.Generic;

namespace IntradayPowerPositionReport.Interfaces
{
    public interface ILocalTimeVolumeGenerator
    {
        string Generate(IEnumerable<LocalTimeVolume> localTimeVolume, string path, DateTime businessDate);
    }
}
