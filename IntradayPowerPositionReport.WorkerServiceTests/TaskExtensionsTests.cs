using IntradayPowerPositionReport.WorkerService.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace IntradayPowerPositionReport.WorkerServiceTests
{
    [TestClass]
    public class TaskExtensionsTests
    {
        [TestMethod]
        public async Task TimeoutAfter_With2SecondTimeout_ThrowsTimeoutException()
        {
            // Arrange
            var twoSecondTimeSpan = (int)TimeSpan.FromSeconds(2).TotalMilliseconds;
            var threeSecondTimeSpan = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;

            // Act and Assert
            var dummyDelayTask = Task.Run(async () => { await Task.Delay(threeSecondTimeSpan); }).TimeoutAfter(twoSecondTimeSpan);
            Assert.ThrowsException<AggregateException>(dummyDelayTask.Wait);
        }

        [TestMethod]
        public async Task TimeoutAfter_With3SecondTimeout_DoesNotThrowException()
        {
            // Arrange
            var twoSecondTimeSpan = (int)TimeSpan.FromSeconds(2).TotalMilliseconds;
            var threeSecondTimeSpan = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;

            //Act
            var dummyDelayTask = Task.Run(async () => { await Task.Delay(twoSecondTimeSpan); }).TimeoutAfter(threeSecondTimeSpan);
            dummyDelayTask.Wait();

            // Assert
            Assert.IsFalse(dummyDelayTask.IsFaulted);
            Assert.IsTrue(dummyDelayTask.IsCompletedSuccessfully);
        }
    }
}
