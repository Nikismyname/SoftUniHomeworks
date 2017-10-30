using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Resurrection
{
    //10:12 - 10:34 22m
    public class Program
    {
        public static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int bodyLength = int.Parse(Console.ReadLine());
                string bodyWidthStr = Console.ReadLine();
                decimal bodyWidth = decimal.Parse(bodyWidthStr);
                int j = -1;
                if (bodyWidthStr.Contains('.'))
                {
                    j = bodyWidthStr.Split('.').Last().Length;
                }
                else
                {
                    j = 0;
                }
                //Console.WriteLine(j);
                int oneWingLength = int.Parse(Console.ReadLine());
                decimal totalYears = (decimal)Math.Pow(bodyLength, 2) * (bodyWidth + 2 * (decimal)oneWingLength);
                Console.WriteLine(totalYears.ToString($"f{j}"));
            }
            //Console.ReadLine();
        }
    }
}
