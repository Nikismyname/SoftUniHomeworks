using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nope
{
    class Program
    {
        static void Main()
        {
            long[] array = Console.ReadLine().Split().Select(long.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "decrease":
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                array[i]--;
                            }
                            break;
                        }
                    case "swap":
                        {
                            long ind1 = long.Parse(tokens[1]);
                            long ind2 = long.Parse(tokens[2]);
                            long buffer = array[ind1];

                            array[ind1] = array[ind2];
                            array[ind2] = buffer;
                            break;
                        }
                    case "multiply":
                        {
                            long ind1 = long.Parse(tokens[1]);
                            long ind2 = long.Parse(tokens[2]);

                            array[ind1] = array[ind1] * array[ind2];
                            break;
                        }
                }
                input = Console.ReadLine();

            }
            Console.WriteLine(string.Join(", ", array));
            // Console.ReadLine();
        }
    }
}
