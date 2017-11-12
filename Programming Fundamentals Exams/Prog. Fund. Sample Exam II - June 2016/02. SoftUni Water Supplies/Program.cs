using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nope
{
    public class Program
    {
        public static void Main()
        {
            decimal water = decimal.Parse(Console.ReadLine());
            decimal[] levels = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            decimal capacity = decimal.Parse(Console.ReadLine());

            bool enough = true;
            bool reversedArray = false;

            if (water % 2 == 1)
            {
                reversedArray = true;
                Array.Reverse(levels);
            }

            for (int i = 0; i < levels.Length; i++)
            {
                decimal needed = capacity - levels[i];

                if (water < needed)
                {
                    Console.WriteLine("We need more water!");
                    Console.WriteLine($"Bottles left: {levels.Length - i}");

                    List<int> indeciesLeft = new List<int>();

                    for (int j = i; j < levels.Length; j++)
                    {
                        indeciesLeft.Add(j);
                    }

                    if (reversedArray)
                    {
                        //indeciesLeft.Reverse();

                        for (int j = 0; j < indeciesLeft.Count; j++)
                        {
                            indeciesLeft[j] = levels.Length - indeciesLeft[j] - 1;
                        }
                    }

                    Console.WriteLine($"With indexes: {string.Join(", ", indeciesLeft)}");
                    decimal waterNeeded = 0;

                    for (int j = i; j < levels.Length; j++)
                    {
                        waterNeeded += capacity - levels[j];
                    }
                    waterNeeded -= water;

                    Console.WriteLine($"We need {waterNeeded} more liters!");
                    enough = false;
                    break;
                }
                else
                {
                    water -= needed;
                }
            }

            if (enough)
            {

                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {water}l.");
            }

            //Console.ReadLine();
        }
    }
}
