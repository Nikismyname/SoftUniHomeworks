using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Trainers
{   //17:51 - 18:16 25min
    public class Program
    {
        public static void Main()
        {
            var dict = new Dictionary<string, decimal>();
            dict.Add("Technical", 0);
            dict.Add("Theoretical", 0);
            dict.Add("Practical", 0);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long distInMiles = long.Parse(Console.ReadLine());
                decimal cargo = decimal.Parse(Console.ReadLine());
                string team = Console.ReadLine();

                long distInMeters = distInMiles * 1600;
                decimal fuel = distInMeters * 0.7m;
                decimal cargoWorth = cargo * 1.5m * 1000;
                decimal fuelCost = fuel * 2.5m;
                decimal earnedMoney = cargoWorth - fuelCost;

                dict[team] += earnedMoney;
            }
            var winner = dict.OrderByDescending(x=>x.Value).First();
            Console.WriteLine($"The {winner.Key} Trainers win with ${winner.Value.ToString("0.000")}.");
            //Console.ReadLine();
        }
    }
}
