using System;

namespace IntradayPowerPositionReport.Models
{
    public struct LocalTimeVolume
    {
        public DateTime LocalTime { get; set; }
        public double Volume { get; set; }
    }
}
