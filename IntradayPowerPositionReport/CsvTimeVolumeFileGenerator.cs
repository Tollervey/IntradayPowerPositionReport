using IntradayPowerPositionReport.Interfaces;
using IntradayPowerPositionReport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntradayPowerPositionReport
{
    public class CsvTimeVolumeFileGenerator : ILocalTimeVolumeGenerator
    {
        public string Generate(IEnumerable<LocalTimeVolume> localTimeVolumes, string path, DateTime businessDate)
        {            
            var dateFormatted = businessDate.ToString("yyyyMMdd_HHmm");
            var fileName = $"PowerPosition_{dateFormatted}.csv";
            var fullPath = Path.Combine(path, fileName);

            using (var file = File.CreateText(fullPath))
            {
                var header = "Local Time,Volume";
                file.WriteLine(header);
                var count = localTimeVolumes.Count();
                
                foreach (var item in localTimeVolumes)
                {
                    var localTimeFormatted = item.LocalTime.ToString("HH:mm");
                    var lineToWrite = $"{localTimeFormatted},{item.Volume}";
                    file.WriteLine(lineToWrite);
                }
            }
            return fullPath;
        }
    }
}
