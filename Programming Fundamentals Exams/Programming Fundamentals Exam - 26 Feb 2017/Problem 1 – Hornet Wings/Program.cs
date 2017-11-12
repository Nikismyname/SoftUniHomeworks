using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1___Hornet_Wings
{   //12:45 : 13:02 - 17
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()); //wing flaps 
            double m = double.Parse(Console.ReadLine()); // distance per 1000 flaps
            int p = int.Parse(Console.ReadLine()); // 5 sec break after p flaps
            const int flapsPerSecond = 100;

            double dist = (double)(n * m) / 1000;
            int nOfBreaks = (int)Math.Floor(((double)n / p));
            long extraTime = nOfBreaks * 5;
            double flightTime = (double)(n / 100);
            double conmbinedTime = flightTime + extraTime;
            Console.WriteLine(dist.ToString("0.00") + " m.");
            Console.WriteLine(conmbinedTime + " s.");
            //Console.ReadLine();
        }
    }
}
