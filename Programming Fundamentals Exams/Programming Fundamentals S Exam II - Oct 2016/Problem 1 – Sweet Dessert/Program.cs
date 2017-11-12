using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1___Sweet_Dessert
{
    //12:05 -
    public class Program
    {
        public static void Main()
        {
            double cash = double.Parse(Console.ReadLine());
            int nOfGuests = int.Parse(Console.ReadLine());
            double priceBanana = double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double PperKgberry = double.Parse(Console.ReadLine());
            int batches = -1;

            if(nOfGuests% 6 == 0)
            {
                batches = nOfGuests / 6;
            }
            else
            {
                batches = nOfGuests / 6 + 1;
            }
            int nOfPortions = batches * 6;
            int nOfBanna = batches * 2;
            int nOfEggs = batches *4;
            double amountOfBerry = 0.2d * (double)batches;

            double moneyNeeded =
                (double)nOfBanna * priceBanana
                + (double)nOfEggs * priceEgg
                + amountOfBerry * PperKgberry;

            double diff = cash - moneyNeeded;
            if (diff >= 0)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {moneyNeeded.ToString("0.00")}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(-diff).ToString("0.00")}lv more.");
            }
           // Console.ReadLine();
        }
    }
}
