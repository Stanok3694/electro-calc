using System;

namespace ElectricityPayments
{
    internal class Program
    {
        private static void Main()
        {
            var serviceData = new ServiceCalc();
            var tarifs = new Tarifs();

            var june = new Month(2342, 1625);
            var may = new Month(2160, 1521);

            var dayDeltaBtwMonths = serviceData.CreateDelta(june.DayTop, may.DayTop);
            var nightDeltaBtwMonths = serviceData.CreateDelta(june.NightTop, may.NightTop);

            var daySummary = serviceData.FindPhaseSummary(dayDeltaBtwMonths, (int) SocialNormEnum.Day,
                tarifs.SocialNormEqualDay, tarifs.SocialNormNotEqualDay);

            var nightSumary = serviceData.FindPhaseSummary(nightDeltaBtwMonths, (int) SocialNormEnum.Night,
                tarifs.SocialNormEqualNight, tarifs.SocialNormNotEqualNight);

            june.Summary = serviceData.ResultSummary(daySummary, nightSumary);

            Console.WriteLine("Your result is: " + june.Summary);
            Console.ReadKey();
        }
    }
}
