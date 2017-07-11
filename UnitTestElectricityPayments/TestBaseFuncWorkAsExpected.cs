using Newtonsoft.Json;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectricityPayments;

namespace UnitTestElectricityPayments
{
    [TestClass]
    public class TestBaseFuncWorkAsExpected
    {
        [TestMethod]
        public void TestDayPhaseSummary()
        {
            const int previousMonthDay = 2160;
            const int currentMonthDay = 2342;
            const double socialNormEqualTarif = 3.41;
            const double socialNormNotEqualTarif = 6.59;
            const int daySocialNorm = 54;

            var serviceData = new ServiceCalc();
            var dayDelta = serviceData
                .CreateDelta(currentMonthDay, previousMonthDay);
            var actualResult = serviceData
                .FindPhaseSummary(dayDelta, daySocialNorm, socialNormEqualTarif, socialNormNotEqualTarif);
            const double expectedResult = 1027.66;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestNightPhaseSummary()
        {
            const int previousMonthDay = 1521;
            const int currentMonthDay = 1625;
            const double socialNormEqualTarif = 1.67;
            const double socialNormNotEqualTarif = 3.44;
            const int daySocialNorm = 31;

            var serviceData = new ServiceCalc();

            var dayDelta = serviceData
                .CreateDelta(currentMonthDay, previousMonthDay);

            var actualResult = serviceData
                .FindPhaseSummary(dayDelta, daySocialNorm, socialNormEqualTarif, socialNormNotEqualTarif);
            const double expectedResult = 302.89;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAllCircle()
        {
            var calculator = new ServiceCalc();
            var june = new Month(2342, 1625);
            var may = new Month(2160, 1521);

            const double expectedResult = 1330.55;
            var actualResult = calculator.SummaryResult(june, may);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestClass]
    public class TestFileSystemFuncWorkAsExpected
    {
        [TestMethod]
        public void TestGetDayDataFromFile()
        {
            // smth about get day?...
        }
    }
}   