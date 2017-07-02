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

        private sealed class Tarifs
        {
            public double SocialNormEqualDay { get; } = 3.41;
            public double SocialNormEqualNight { get; } = 1.67;
            public double SocialNormNotEqualDay { get; } = 6.59;
            public double SocialNormNotEqualNight { get; } = 3.44;
        }

        internal enum SocialNormEnum
        {
            Day = 53, Night = 32
        }

        public interface IMonth
        {
            int DayTop { get; set; }
            int NightTop { get; set; }
        }

        public class CurrentMonth : IMonth
        {
            public int DayTop { get; set; }
            public int NightTop { get; set; }
            public double Summary { get; set; }

            public CurrentMonth(int dayTop, int nightTop)
            {
                DayTop = dayTop;
                NightTop = nightTop;
            }
        }

        public class PrevMonth:IMonth
        {
            public int DayTop { get; set; }
            public int NightTop { get; set; }

            public PrevMonth(int dayTop, int nightTop)
            {
                DayTop = dayTop;
                NightTop = nightTop;
            }
        }
    }
}
