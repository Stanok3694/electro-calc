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
            Console.ReadKey();
        }
    }
}
