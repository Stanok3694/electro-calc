using static System.Math;

namespace ElectricityPayments
{
    public class ServiceCalc
    {
        public int CreateDelta(int a, int b)
        {
            return a - b;
        }

        private static double SimpleSummary(int deltaBtwMonths, double socialNormEqualTarif)
        {
            return deltaBtwMonths * socialNormEqualTarif;
        }

        private static double DifficultSummary(int deltaBtwNorms, double socialNormEqualTarif, int socialNorm,
            double socialNormNotEqualTarif)
        {
            return deltaBtwNorms * socialNormNotEqualTarif + socialNorm * socialNormEqualTarif;
        }

        public double FindPhaseSummary(int deltaBtwMonths, int socialNorm, double socialNormEqualTarif, double socialNormNotEqualTarif)
        {
            var deltaBtwNorms = CreateDelta(deltaBtwMonths, socialNorm);

            return deltaBtwNorms <= 0 
                ? SimpleSummary(deltaBtwMonths, socialNormEqualTarif) 
                : DifficultSummary(deltaBtwNorms, socialNormEqualTarif, socialNorm, socialNormNotEqualTarif);
        }

        public double ResultSummary(double daySummary, double nightSummary)
        {
            return daySummary + nightSummary;
        }

        public double SummaryResult(Month currentMonth, Month previousMonth)
        {
            var serviceData = new ServiceCalc();
            var tarifs = new Tarifs();

            var dayDelta = serviceData
                .CreateDelta(currentMonth.DayTop, previousMonth.DayTop);
            var nightDelta = serviceData
                .CreateDelta(currentMonth.NightTop, previousMonth.NightTop);

            var daySummary = serviceData
                .FindPhaseSummary(dayDelta, (int)SocialNormEnum.Day, tarifs.SocialNormEqualDay, tarifs.SocialNormNotEqualDay);
            var nightSummary = serviceData.FindPhaseSummary(nightDelta, (int)SocialNormEnum.Night,
                tarifs.SocialNormEqualNight, tarifs.SocialNormNotEqualNight);

            var summary = ResultSummary(daySummary, nightSummary);

            return Round(summary, 2);
        }
    }
}