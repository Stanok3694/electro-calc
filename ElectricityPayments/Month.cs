namespace ElectricityPayments
{
    public class Month: IMonth
    {
        public int DayTop { get; set; }
        public int NightTop { get; set; }
        public double Summary { get; set; }

        public Month(int dayTop, int nightTop)
        {
            DayTop = dayTop;
            NightTop = nightTop;
        }
    }
}