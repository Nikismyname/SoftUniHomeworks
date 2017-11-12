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
            long n = long.Parse(Console.ReadLine()); //wing flaps
            double m = double.Parse(Console.ReadLine()); // distancePer1000 wing flaps
            int breakH = 5;
            long p = long.Parse(Console.ReadLine()); //wing flaps before break
            int wingFlapsPerSec = 100;

            double distance = n * m / 1000;
            double nOfBreaks = Math.Floor((double)n / p);
            double extraTime = nOfBreaks * breakH;
            double timeForFlaps = n / wingFlapsPerSec;
            double overAllTime = timeForFlaps + extraTime;

            Console.WriteLine($"{distance.ToString("0.00")} m.");
            Console.WriteLine($"{overAllTime} s.");
            //Console.ReadLine();
        }
    }
}
