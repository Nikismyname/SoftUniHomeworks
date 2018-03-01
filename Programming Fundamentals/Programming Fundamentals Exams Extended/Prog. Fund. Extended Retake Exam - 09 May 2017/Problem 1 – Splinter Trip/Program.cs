using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1____Splinter_Trip
{
    //14:25- 14:46 : 21m
    public class Program
    {
        public static void Main()
        {
            const int fuelPerMile = 25;
            const double heavyWindMod = 1.5f;

            double tripDistMiles = double.Parse(Console.ReadLine());
            double fuelCapLiter = double.Parse(Console.ReadLine());
            double milesInHeavyWind = double.Parse(Console.ReadLine());

            double distInNotHW = tripDistMiles - milesInHeavyWind;

            double fuelNotHW = distInNotHW * 25;
            double fuelHW = milesInHeavyWind * 25d * 1.5d;

            double fuel = (double)fuelNotHW + (double)fuelHW;
            fuel *= 1.05d;
            Console.WriteLine($"Fuel needed: {fuel.ToString("f2")}L");

            double dif = Math.Abs(fuelCapLiter - fuel);

            if(fuelCapLiter>= fuel)
            {
                Console.WriteLine($"Enough with {dif.ToString("f2")}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {dif.ToString("f2")}L more fuel.");
            }

            //Console.ReadLine();
        }
    }
}
