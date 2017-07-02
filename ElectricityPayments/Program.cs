using System;

namespace ElectricityPayments
{
    internal class Program
    {
        private static void Main()
        {
            var serviceData = new ServiceFuncData();
            var tarifs = new Tarifs();

            var juneMonth = new CurrentMonth(2160, 1521);
            var mayMonth = new PrevMonth(2034, 1446);

            var dayDeltaBtwMonths = serviceData.CreateDelta(juneMonth.DayTop, mayMonth.DayTop);
            var nightDeltaBtwMonths = serviceData.CreateDelta(juneMonth.NightTop, mayMonth.NightTop);

            var daySummary = serviceData.FindPhaseSummary(dayDeltaBtwMonths, (int) SocialNormEnum.Day,
                tarifs.SocialNormEqualDay, tarifs.SocialNormNotEqualDay);

            var nightSumary = serviceData.FindPhaseSummary(nightDeltaBtwMonths, (int) SocialNormEnum.Night,
                tarifs.SocialNormEqualNight, tarifs.SocialNormNotEqualNight);

            juneMonth.Summary = serviceData.ResultSummary(daySummary, nightSumary);

            Console.WriteLine("Your result is: " + juneMonth.Summary);
            Console.ReadKey();
        }
    }
}
