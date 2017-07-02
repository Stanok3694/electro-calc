namespace ElectricityPayments
{
    public class ServiceFuncData
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

            if (deltaBtwNorms <= 0) return SimpleSummary(deltaBtwMonths, socialNormEqualTarif);
            return DifficultSummary(deltaBtwNorms, socialNormEqualTarif, socialNorm, socialNormNotEqualTarif);
        }

        public double ResultSummary(double daySummary, double nightSummary)
        {
            return daySummary + nightSummary;
        }
    }
}