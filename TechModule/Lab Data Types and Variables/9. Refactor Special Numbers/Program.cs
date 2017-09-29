using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            
            bool isSpecial = false;

            for (int num = 1; num <= upperBound; num++)
            {
                int currenNum = num;
                int digitSum = 0;

                while (currenNum > 0)
                {
                    digitSum += currenNum % 10;
                    currenNum /= 10;
                }

                isSpecial = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);
                Console.WriteLine($"{num} -> {isSpecial}");
            }
            //Console.ReadLine();
        }
    }
}
