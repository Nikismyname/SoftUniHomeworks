using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main()
        {
            //portions of 6
            //
            double cash = double.Parse(Console.ReadLine());
            int nOfGuests = int.Parse(Console.ReadLine());
            double bananaP = double.Parse(Console.ReadLine());
            double eggsP = double.Parse(Console.ReadLine());
            double berriesPPerKg = double.Parse(Console.ReadLine());

            int nOfPortions = -1;

            if (nOfGuests % 6 != 0)
            {
                nOfPortions = nOfGuests / 6 + 1;
            }
            else
            {
                nOfPortions = nOfGuests / 6;
            }

            int banansN = nOfPortions * 2;
            int eggsN = nOfPortions * 4;
            double berriesKgN = nOfPortions * 0.2d;

            double moneyNeeded = bananaP * banansN +
                                 eggsP * eggsN +
                                 berriesPPerKg * berriesKgN;

            string diff = Math.Abs(moneyNeeded - cash).ToString("0.00");

            if (cash >= moneyNeeded)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {moneyNeeded.ToString("0.00")}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {diff}lv more.");
            }

            // Console.ReadLine();    
        }
    }
}
