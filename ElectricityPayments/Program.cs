using System;

namespace ElectricityPayments
{
    internal class Program
    {
        private static void Main()
        {
            var calculator = new ServiceCalc();
            var june = new Month(2342, 1625);
            var may = new Month(2160, 1521);

            var summary = calculator.SummaryResult(june, may);

            Console.WriteLine("Your result is: " + summary);
            Console.ReadKey();
        }
    }
}
