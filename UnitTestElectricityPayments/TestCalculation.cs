using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectricityPayments;
using System.Math;

namespace UnitTestElectricityPayments
{
    [TestClass]
    public class TestCalculation
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
            var june = new Month(2342, 1625);
            var may = new Month(2160, 1521);

            const double expectedResult = 1330.55;
            var actualResult = SummaryResult(june, may);

            Assert.AreEqual(expectedResult, actualResult);
        }

        public double SummaryResult(Month currentMonth, Month previousMonth)
        {
            var serviceData = new ServiceCalc();
            var tarifs = new Tarifs();

            var dayDelta = serviceData
                .CreateDelta(currentMonth.DayTop, previousMonth.DayTop);
            var nightDelta = serviceData.CreateDelta(currentMonth.NightTop, previousMonth.NightTop);

            var daySummary = serviceData
                .FindPhaseSummary(dayDelta, (int) SocialNormEnum.Day, tarifs.SocialNormEqualDay, tarifs.SocialNormNotEqualDay);
            var nightSummary = serviceData.FindPhaseSummary(nightDelta, (int) SocialNormEnum.Night,
                tarifs.SocialNormEqualNight, tarifs.SocialNormNotEqualNight);

            var summary = daySummary + nightSummary;

            return summary;
        }

}
}
