using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Sum_Big_Numbers
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            var charA = a.ToCharArray().Reverse().ToArray();
            var charB = b.ToCharArray().Reverse().ToArray();
            var min = Math.Min(a.Length, b.Length);
            var result = new List<int>();

            int carryOver = 0;
            for (int i = 0; i < min; i++)
            {
                int n1 = int.Parse(charA[i].ToString());
                int n2 = int.Parse(charB[i].ToString());
                int newSum = n1 + n2 + carryOver;
                result.Add(newSum % 10);
                carryOver = (int)newSum / 10;
            }

            if (charA.Length != charB.Length)
            {
                var c = charA.Length > charB.Length ? charA : charB;
                c = c.Skip(min).ToArray();

                for (int i = 0; i < c.Length; i++)
                {
                    int newDigit = int.Parse(c[i].ToString());
                    result.Add((newDigit + carryOver) % 10);
                    carryOver = (int)(newDigit + carryOver) / 10;
                }
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
            //Console.ReadLine();
        }
    }
}
