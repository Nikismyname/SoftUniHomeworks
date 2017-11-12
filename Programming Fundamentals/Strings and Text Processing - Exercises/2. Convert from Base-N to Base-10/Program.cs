using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _2.Convert_from_Base_N_to_Base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            ulong baseN = (ulong)int.Parse(tokens[0]);
            string num = tokens[1].Trim();
            BigInteger result = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                ulong currPow = (ulong)(num.Length - i - 1);
                var currDigit = int.Parse(num[i].ToString());

                BigInteger digitMultiplyer = 1;

                {
                    for (ulong j = 0; j < currPow; j++)
                    {
                        digitMultiplyer *= baseN;
                    }
                    result += currDigit * digitMultiplyer;
                }
            }

            Console.WriteLine(result.ToString());
            //Console.ReadLine();
        }
    }
}
