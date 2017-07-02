namespace ElectricityPayments
{
    public class CurrentMonth: IMonth
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
}