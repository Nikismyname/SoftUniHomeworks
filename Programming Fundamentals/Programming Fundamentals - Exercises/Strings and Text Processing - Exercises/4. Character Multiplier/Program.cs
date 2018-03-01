using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Character_Multiplier
{
    class Program
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split();
            var a = tokens[0];
            var b = tokens[1];

            int shorter = Math.Min(a.Length, b.Length);
            int longer = Math.Max(a.Length, b.Length);

            string c = a.Length > b.Length ? a : b;

            long sum = 0;
            for (int i = 0; i < longer; i++)
            {
                if(i< shorter)
                {
                    sum += (int)a[i] * (int)b[i];
                }
                else
                {
                    sum += (int)c[i];
                }
            }
            Console.WriteLine(sum);
            //Console.ReadLine();
        }
    }
}
