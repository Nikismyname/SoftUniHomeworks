using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine().ToCharArray().Select(x=>int.Parse(x.ToString())).ToList();
            int b = int.Parse(Console.ReadLine());
            a.Reverse();
            var result = new List<int>();
            int carryOver = 0;
            for (int i = 0; i < a.Count; i++)
            { 
                int newNum = (a[i] * b) + carryOver;
                result.Add(newNum % 10);
                carryOver = (int)newNum / 10;
            }
            if (carryOver != 0)
            {
                result.Add(carryOver);
            }
            result.Reverse();
            bool cuttingZeros = true;
            for (int i = 0; i < result.Count; i++)
            {
                if (cuttingZeros)
                {
                    if (result[i] != 0)
                    {
                        Console.Write(result[i]);
                        cuttingZeros = false;
                    }
                }
                else
                {
                    Console.Write(result[i]);
                }
            }
            if(result.All(x=>x == 0))
            {
                Console.WriteLine(0);
            }
            //Console.ReadLine();
        }
    }
}
