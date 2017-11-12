using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _1.Convert_from_Base_10_to_Base_N
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var tokens = input.Split();
            var newBase = int.Parse(tokens[0]);
            var num  = BigInteger.Parse(tokens[1]);
           

            List<int> newNum = new List<int>();

            while (true)
            {
                newNum.Add((int)(num % newBase));
                num = num / newBase;
                if (num <= 0) { break; }
            }

            newNum.Reverse();
            Console.WriteLine(string.Join("", newNum));
            //Console.ReadLine();
        }
    }
}
