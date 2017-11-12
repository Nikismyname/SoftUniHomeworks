using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Trophon_the_Grumpy_Cat
{
    public class Program
    {
        //16:55 - 17:24
        public static void Main()
        {
            int[] field = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startPos = int.Parse(Console.ReadLine());
            string value = Console.ReadLine();
            string sign = Console.ReadLine();

            int[] leftField = field.Where((x, i) => i < startPos).ToArray();
            int[] rightField = field.Where((x, i) => i > startPos).ToArray();

            if (value == "cheap")
            {
                leftField = leftField.Where(x => x < field[startPos]).ToArray();
                rightField = rightField.Where(x => x < field[startPos]).ToArray();
            }
            else
            {
                leftField = leftField.Where(x => x >= field[startPos]).ToArray();
                rightField = rightField.Where(x => x >= field[startPos]).ToArray();
            }
            //first try

            if (sign == "positive")
            {
                leftField = leftField.Where(x => x > 0).ToArray();
                rightField = rightField.Where(x => x > 0).ToArray();
            }
            else if (sign == "negative")
            {
                leftField = leftField.Where(x => x < 0).ToArray();
                rightField = rightField.Where(x => x < 0).ToArray();
            }

            long sumLeft = 0;
            if (leftField.Length != 0)
            {
                sumLeft = leftField.Sum();
            }

            long sumRight = 0;
            if (rightField.Length != 0)
            {
                sumRight = rightField.Sum();
            }

            if (sumLeft >= sumRight)
            {
                Console.WriteLine($"Left - {sumLeft}");
            }
            else
            {
                Console.WriteLine($"Right - {sumRight}");
            }

            //Console.ReadLine();
        }
    }
}
