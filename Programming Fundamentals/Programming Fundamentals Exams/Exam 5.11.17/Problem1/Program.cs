using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem1
{
    public static class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long sKey = long.Parse(Console.ReadLine());
            decimal totalLoss = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(' ');
                var siteName = tokens[0];
                var siteVisits = long.Parse(tokens[1]);
                var PPV = decimal.Parse(tokens[2]);

                decimal siteLoss = (decimal)siteVisits * PPV;
                totalLoss += siteLoss;
                Console.WriteLine(siteName);
            }
            ;
            Console.WriteLine($"Total Loss: {totalLoss.ToString("f20")}");
            Console.WriteLine("Security Token: " + BigInteger.Pow(sKey, n));
           // Console.ReadLine();
           //15:24
        }
    }
}
