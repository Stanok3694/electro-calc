using System;
namespace ElectricityPayments
{
    internal class Program
    {
        private static void Main()
        {
            var calculator = new ServiceCalc();
            var jule = new Month(2376, 1644);
            var june = new Month(2342, 1625);
            var may = new Month(2160, 1521);

            var summary1 = calculator.SummaryResult(june, may);
            var summary2 = calculator.SummaryResult(jule, june);

            Console.WriteLine("Your previous result is: " + summary1);
            Console.WriteLine("Your current result is: " + summary2);
            

            var a = DateTime.Today;
            var currentMonth = a.Month;
            Console.WriteLine(currentMonth);

            var monthString = "";

            switch (currentMonth)
            {
                case 1:
                    monthString = "January";
                    break;
                case 2:
                    monthString = "February";
                    break;
                case 3:
                    monthString = "March";
                    break;
                case 4:
                    monthString = "April";
                    break;
                case 5:
                    monthString = "May";
                    break;
                case 6:
                    monthString = "June";
                    break;
                case 7:
                    monthString = "Jule";
                    break;
            }

            Console.WriteLine(monthString);

            Console.ReadKey();
        }
    }
}
