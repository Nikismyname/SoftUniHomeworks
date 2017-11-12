using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Prev
{
    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            List<decimal> profits = new List<decimal>();

            for (long i = 0; i < n; i++)
            {
                long aPassCount = long.Parse(Console.ReadLine());
                decimal aPassPrice = decimal.Parse(Console.ReadLine());
                long yPassCount = long.Parse(Console.ReadLine());
                decimal yPassPrice = decimal.Parse(Console.ReadLine());

                decimal fuelPricePerH = decimal.Parse(Console.ReadLine());
                decimal fuelConsPerH = decimal.Parse(Console.ReadLine());
                decimal flightDur = decimal.Parse(Console.ReadLine());

                decimal expenses = flightDur * fuelConsPerH * fuelPricePerH;

                decimal income =
                    aPassPrice * aPassCount +
                    yPassPrice * yPassCount;

                decimal profit = income - expenses;

                profits.Add(profit);

                if (income == expenses)
                {
                    throw new ArgumentException();
                }

                if (income >= expenses)
                {
                    Console.WriteLine($"You are ahead with {profit.ToString("F3")}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {profit.ToString("F3")}$.");
                }

            }

            if (n > 0)
            {
                Console.WriteLine($"Overall profit -> {profits.Sum().ToString("F3")}$.");
                Console.WriteLine($"Average profit -> {profits.Average().ToString("F3")}$.");
            }
            //Console.ReadLine();
        }
    }
}
