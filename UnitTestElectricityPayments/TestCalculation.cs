using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectricityPayments;
namespace UnitTestElectricityPayments
{
    [TestClass]
    public class TestCalculation
    {
        [TestMethod]
        public void TestDayPhaseSummary()
        {
            var firstData = 2034;
            var secondData = 2160;
            var firstTarif = 3.41;
            var secondTarif = 6.59;
            var socialNorm = 53;

            var serviceData = new ServiceCalc();

            var dayDelta = serviceData.CreateDelta(secondData, firstData);
            var actualResult = serviceData.FindPhaseSummary(dayDelta, socialNorm, firstTarif, secondTarif);
            var expectedResult = 661.8;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
