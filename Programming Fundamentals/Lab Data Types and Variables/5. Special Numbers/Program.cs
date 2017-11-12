using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Special_Numbers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = i
                    .ToString()
                    .ToCharArray()
                    .Select(x => int.Parse(x.ToString()))
                    .Sum(x => x);

                if(sumOfDigits  ==5 || sumOfDigits== 7 || sumOfDigits  == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
          //Console.ReadLine();
        }
    }
}
