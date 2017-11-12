using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var input = Console.ReadLine();
            while (input != "end")
            {
                var tokens = input.Split();
                switch (tokens[0])
                {
                    case "exchange":
                        Exchange(int.Parse(tokens[1]));
                        break;
                    case "min":
                    case "max":
                        MinMax(tokens[1], tokens[0]);
                        break;
                    case "first":
                    case "last":
                        FirsLast(int.Parse(tokens[1]), tokens[2], tokens[0]);
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
            //Console.ReadLine();

            void FirsLast(int count, string evenOdd, string firstLast)
            {
                if (count > array.Length)
                {
                    Console.WriteLine("Invalid count");
                    return;
                }

                int[] finalElements;
                int[] wantedElements = evenOdd == "even" ? array.Where(x => x % 2 == 0).ToArray() : array.Where(x => x % 2 == 1).ToArray();
                if (firstLast == "last")
                {
                    wantedElements = wantedElements.Reverse().ToArray();
                    finalElements = wantedElements.Take(count).ToArray();
                    finalElements = finalElements.Reverse().ToArray();
                }
                else
                {
                    finalElements = wantedElements.Take(count).ToArray();
                }

                Console.WriteLine($"[{string.Join(", ", finalElements)}]");
            }

            void MinMax(string evenOdd, string minMax)
            {
                int[] wantedElements;

                if (evenOdd == "even")
                {
                    wantedElements = array.Where(x => x % 2 == 0).ToArray();
                }
                else
                {
                    wantedElements = array.Where(x => x % 2 == 1).ToArray();
                }

                if (wantedElements.Length == 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    int wantedElement = minMax == "min" ? wantedElements.Min() : wantedElements.Max();
                    int index = Array.LastIndexOf(array, wantedElement);
                    Console.WriteLine(index);
                }
            }

            void Exchange(int ind)
            {
                if (ind < 0 || ind >= array.Length)
                {
                    Console.WriteLine("Invalid index");
                    return;
                }

                int[] firstPart = array.Where((x, i) => i <= ind).ToArray();
                int[] secondPart = array.Where((x, i) => i > ind).ToArray();
                array = secondPart.Concat(firstPart).ToArray();
            }
        }
    }
}
