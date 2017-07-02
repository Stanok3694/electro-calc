namespace ElectricityPayments
{
    public class PrevMonth: IMonth
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