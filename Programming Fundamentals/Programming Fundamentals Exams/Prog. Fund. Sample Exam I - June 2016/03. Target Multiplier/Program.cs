using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main()
        {
            var cell = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long y = cell[0];
            long x = cell[1];

            var array = new long[y, x];

            for (int i = 0; i < y; i++)
            {
                var input = Console.ReadLine().Split().Select(long.Parse).ToArray();

                for (int j = 0; j < x; j++)
                {
                    array[i, j] = input[j];
                }
            }

            var target = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long buffer = array[target[0], target[1]];
            long sum =
                array[target[0] - 1, target[1] - 1] +
                array[target[0] - 1, target[1] + 0] +
                array[target[0] - 1, target[1] + 1] +

                array[target[0] + 1, target[1] - 1] +
                array[target[0] + 1, target[1] + 0] +
                array[target[0] + 1, target[1] + 1] +

                array[target[0] + 0, target[1] - 1] +
                array[target[0] + 0, target[1] + 1];

            array[target[0], target[1]] *= sum;

            array[target[0] - 1, target[1] - 1] *= buffer;
            array[target[0] - 1, target[1] + 0] *= buffer;
            array[target[0] - 1, target[1] + 1] *= buffer;

            array[target[0] + 1, target[1] - 1] *= buffer;
            array[target[0] + 1, target[1] + 0] *= buffer;
            array[target[0] + 1, target[1] + 1] *= buffer;

            array[target[0] + 0, target[1] - 1] *= buffer;
            array[target[0] + 0, target[1] + 1] *= buffer;

            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    Console.Write($"{array[j, i]} ");
                }
                Console.WriteLine();
            }

            // Console.ReadLine();
        }
    }
}
