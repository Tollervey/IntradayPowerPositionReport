using IntradayPowerPositionReport;
using IntradayPowerPositionReport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntradayPowerPositionReportTests
{
    [TestClass]
    public class TradePositionAggregatorTests
    {
        /// <summary>
        /// Tests the scenorio defined in the spec
        /// </summary>
        [TestMethod]
        public void Aggregate_WithValidValuesFromSpec_ReturnsExpectedAsDefinedInSpec()
        {
            // Arrange
            TradePositionAggregator tradePositionAggregator = new TradePositionAggregator();
            DateTime businessDate = new DateTime(2015, 4, 1);

            // Act
            var actual = tradePositionAggregator.Aggregate(GetPowerTradesPositionsAsDefinedInSpec(businessDate), businessDate).ToList();

            // Assert
            var expected = GetExpectedLocalTimeVolumesAsDefinedInSpec(businessDate).ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));

        }

        [TestMethod]
        public void Aggregate_WithOneTradePosition_ReturnsExpected()
        {
            // Arrange
            TradePositionAggregator tradePositionAggregator = new TradePositionAggregator();
            DateTime businessDate = new DateTime(2015, 4, 1);

            // Act
            var actual = tradePositionAggregator.Aggregate(GetSingleTestPowerTradePosition(businessDate), businessDate).ToList();

            // Assert
            var expected = GetExpectedLocalTimeVolumesForSingleTradePosition(businessDate).ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));

        }

        [TestMethod]
        public void Aggregate_WithThreeTradePosition_ReturnsExpected()
        {
            // Arrange
            TradePositionAggregator tradePositionAggregator = new TradePositionAggregator();
            DateTime businessDate = new DateTime(2015, 4, 1);

            // Act
            var actual = tradePositionAggregator.Aggregate(GetThreeTestPowerTradePositions(businessDate), businessDate).ToList();

            // Assert
            var expected = GetExpectedLocalTimeVolumesForThreeTradePosition(businessDate).ToList();

            Assert.IsTrue(expected.SequenceEqual(actual));

        }

        [TestMethod]
        public void Aggregate_WithNoTradePosition_ReturnsExpected()
        {
            // Arrange
            TradePositionAggregator tradePositionAggregator = new TradePositionAggregator();
            DateTime businessDate = new DateTime(2015, 4, 1);
            var emptyList = new List<PowerTrade>();

            // Act


            var actual = tradePositionAggregator.Aggregate(emptyList, businessDate).ToList();

            // Assert
            var expected = new List<LocalTimeVolume>();

            Assert.IsTrue(expected.SequenceEqual(actual));

        }



        private IEnumerable<LocalTimeVolume> GetExpectedLocalTimeVolumesAsDefinedInSpec(DateTime businessDate)
        {
            var expected = new List<LocalTimeVolume>()
            {
                CreateLocalTimeVolume(23, 150, businessDate.AddHours(-1)),
                CreateLocalTimeVolume(0, 150, businessDate),
                CreateLocalTimeVolume(1, 150, businessDate),
                CreateLocalTimeVolume(2, 150, businessDate),
                CreateLocalTimeVolume(3, 150, businessDate),
                CreateLocalTimeVolume(4, 150, businessDate),
                CreateLocalTimeVolume(5, 150, businessDate),
                CreateLocalTimeVolume(6, 150, businessDate),
                CreateLocalTimeVolume(7, 150, businessDate),
                CreateLocalTimeVolume(8, 150, businessDate),
                CreateLocalTimeVolume(9, 150, businessDate),
                CreateLocalTimeVolume(10, 80, businessDate),
                CreateLocalTimeVolume(11, 80, businessDate),
                CreateLocalTimeVolume(12, 80, businessDate),
                CreateLocalTimeVolume(13, 80, businessDate),
                CreateLocalTimeVolume(14, 80, businessDate),
                CreateLocalTimeVolume(15, 80, businessDate),
                CreateLocalTimeVolume(16, 80, businessDate),
                CreateLocalTimeVolume(17, 80, businessDate),
                CreateLocalTimeVolume(18, 80, businessDate),
                CreateLocalTimeVolume(19, 80, businessDate),
                CreateLocalTimeVolume(20, 80, businessDate),
                CreateLocalTimeVolume(21, 80, businessDate),
                CreateLocalTimeVolume(22, 80, businessDate)
            };

            return expected;
        }

        private IEnumerable<LocalTimeVolume> GetExpectedLocalTimeVolumesForSingleTradePosition(DateTime businessDate)
        {
            var expected = new List<LocalTimeVolume>()
            {
                CreateLocalTimeVolume(23,   100, businessDate.AddHours(-1)),
                CreateLocalTimeVolume(0,    100, businessDate),
                CreateLocalTimeVolume(1,    100, businessDate),
                CreateLocalTimeVolume(2,    100, businessDate),
                CreateLocalTimeVolume(3,    100, businessDate),
                CreateLocalTimeVolume(4,    100, businessDate),
                CreateLocalTimeVolume(5,    100, businessDate),
                CreateLocalTimeVolume(6,    100, businessDate),
                CreateLocalTimeVolume(7,    100, businessDate),
                CreateLocalTimeVolume(8,    100, businessDate),
                CreateLocalTimeVolume(9,    100, businessDate),
                CreateLocalTimeVolume(10,   100, businessDate),
                CreateLocalTimeVolume(11,   100, businessDate),
                CreateLocalTimeVolume(12,   100, businessDate),
                CreateLocalTimeVolume(13,   100, businessDate),
                CreateLocalTimeVolume(14,   100, businessDate),
                CreateLocalTimeVolume(15,   100, businessDate),
                CreateLocalTimeVolume(16,   100, businessDate),
                CreateLocalTimeVolume(17,   100, businessDate),
                CreateLocalTimeVolume(18,   100, businessDate),
                CreateLocalTimeVolume(19,   100, businessDate),
                CreateLocalTimeVolume(20,   100, businessDate),
                CreateLocalTimeVolume(21,   100, businessDate),
                CreateLocalTimeVolume(22,   100, businessDate)
            };

            return expected;
        }

        private IEnumerable<LocalTimeVolume> GetExpectedLocalTimeVolumesForThreeTradePosition(DateTime businessDate)
        {
            var expected = new List<LocalTimeVolume>()
            {
                CreateLocalTimeVolume(23,   250, businessDate.AddHours(-1)),
                CreateLocalTimeVolume(0,    250, businessDate),
                CreateLocalTimeVolume(1,    250, businessDate),
                CreateLocalTimeVolume(2,    250, businessDate),
                CreateLocalTimeVolume(3,    250, businessDate),
                CreateLocalTimeVolume(4,    250, businessDate),
                CreateLocalTimeVolume(5,    250, businessDate),
                CreateLocalTimeVolume(6,    250, businessDate),
                CreateLocalTimeVolume(7,    250, businessDate),
                CreateLocalTimeVolume(8,    250, businessDate),
                CreateLocalTimeVolume(9,    250, businessDate),
                CreateLocalTimeVolume(10,   180, businessDate),
                CreateLocalTimeVolume(11,   180, businessDate),
                CreateLocalTimeVolume(12,   180, businessDate),
                CreateLocalTimeVolume(13,   180, businessDate),
                CreateLocalTimeVolume(14,   180, businessDate),
                CreateLocalTimeVolume(15,   180, businessDate),
                CreateLocalTimeVolume(16,   180, businessDate),
                CreateLocalTimeVolume(17,   180, businessDate),
                CreateLocalTimeVolume(18,   180, businessDate),
                CreateLocalTimeVolume(19,   180, businessDate),
                CreateLocalTimeVolume(20,   180, businessDate),
                CreateLocalTimeVolume(21,   180, businessDate),
                CreateLocalTimeVolume(22,   180, businessDate)
            };

            return expected;
        }

        private static LocalTimeVolume CreateLocalTimeVolume(int hour, double volume, DateTime businessDate)
        {
            return new LocalTimeVolume() { LocalTime = new DateTime(businessDate.Year, businessDate.Month, businessDate.Day, hour, 0, 0, DateTimeKind.Utc), Volume = volume };
        }

        private PowerPeriod[] GetFirstPowerTradePeriods()
        {
            var result = new PowerPeriod[24];
            for (int i = 0; i < 24; i++)
            {
                result[i] = new PowerPeriod() { Period = i + 1, Volume = 100 };
            }

            return result;
        }

        private PowerPeriod[] GetSecondPowerTradePeriods()
        {
            var result = new PowerPeriod[24];
            for (int i = 0; i < 24; i++)
            {
                result[i] = new PowerPeriod() { Period = i + 1, Volume = i < 11 ? 50 : -20 };
            }

            return result;
        }

        private IEnumerable<PowerTrade> GetPowerTradesPositionsAsDefinedInSpec(DateTime date)
        {
            PowerPeriod[] firstPowerTradePeriods = GetFirstPowerTradePeriods();
            PowerPeriod[] secondPowerTradePeriods = GetSecondPowerTradePeriods();


            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Unspecified).Date.AddHours(-1.0);
            DateTime dateTime2 = dateTime.AddDays(1.0);
            DateTime dateTime3 = TimeZoneInfo.ConvertTimeToUtc(dateTime);
            DateTime t = TimeZoneInfo.ConvertTimeToUtc(dateTime2);
            int numberOfPeriods = (int)t.Subtract(dateTime3).TotalHours;
            int count = 2;
            PowerTrade[] array = Enumerable.ToArray(Enumerable.Select(Enumerable.Range(0, count), (int _) => PowerTrade.Create(date, numberOfPeriods)));
            int num = 0;
            DateTime t2 = dateTime3;
            while (t2 < t)
            {
                PowerTrade[] array2 = array;

                array2[0].Periods[num].Volume = firstPowerTradePeriods[num].Volume;
                array2[1].Periods[num].Volume = secondPowerTradePeriods[num].Volume;



                num++;
                t2 = t2.AddHours(1.0);
            }

            return array;
        }

        private IEnumerable<PowerTrade> GetSingleTestPowerTradePosition(DateTime date)
        {
            PowerPeriod[] firstPowerTradePeriods = GetFirstPowerTradePeriods();
            //PowerPeriod[] secondPowerTradePeriods = GetSecondPowerTradePeriods();


            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Unspecified).Date.AddHours(-1.0);
            DateTime dateTime2 = dateTime.AddDays(1.0);
            DateTime dateTime3 = TimeZoneInfo.ConvertTimeToUtc(dateTime);
            DateTime t = TimeZoneInfo.ConvertTimeToUtc(dateTime2);
            int numberOfPeriods = (int)t.Subtract(dateTime3).TotalHours;
            int count = 2;
            PowerTrade[] array = Enumerable.ToArray(Enumerable.Select(Enumerable.Range(0, count), (int _) => PowerTrade.Create(date, numberOfPeriods)));
            int num = 0;
            DateTime t2 = dateTime3;
            while (t2 < t)
            {
                PowerTrade[] array2 = array;

                array2[0].Periods[num].Volume = firstPowerTradePeriods[num].Volume;
                //array2[1].Periods[num].Volume = secondPowerTradePeriods[num].Volume;



                num++;
                t2 = t2.AddHours(1.0);
            }

            return array;
        }

        private IEnumerable<PowerTrade> GetThreeTestPowerTradePositions(DateTime date)
        {
            return GetPowerTradesPositionsAsDefinedInSpec(date).Concat(GetSingleTestPowerTradePosition(date));
        }
    }
}
