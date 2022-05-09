using IntradayPowerPositionReport;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace IntradayPowerPositionReportTests
{
    [TestClass]
    public class IntradayReportTests
    {
        [TestMethod]
        public void Constructor_WithFilePath_InstantiatedWithoutException()
        {
            // Arrange
            string anyPath = "Any_Path";
            var logger = NullLogger<IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>>.Instance;
            DateTime anyDate = DateTime.Now;
            var intradayReportFileGenerator = new IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>(anyPath, anyDate, logger);

            //Act
            var filePathSet = intradayReportFileGenerator.FilePath;

            // Assert
            Assert.AreEqual(anyPath, filePathSet);
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow(null)]
        public void Constructor_WithInvalidFilePath_InstantiatedWithException(string path)
        {
            // Arrange, Act and Assert
            DateTime anyDate = DateTime.Now;
            var logger = NullLogger<IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>>.Instance;
            Assert.ThrowsException<ArgumentNullException>(() => new IntradayReport<TradePositionAggregator, CsvTimeVolumeFileGenerator>(path, anyDate, logger));
        }
    }
}
