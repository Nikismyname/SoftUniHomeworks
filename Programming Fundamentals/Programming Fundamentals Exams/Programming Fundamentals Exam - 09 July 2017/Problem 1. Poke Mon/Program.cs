using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Poke_Mon
{
    //17:57 18:10 - 13m
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int nOrig = n;
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int pokes = 0;
            int i = 0;
            while (n>= m)
            {
                n -= m;
                pokes++;

                if(n == 0.5 * nOrig)
                {
                    if (y >= 1)
                    {
                        n = n / y;
                    }
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(pokes);
         //   Console.ReadLine();
        }
    }
}
