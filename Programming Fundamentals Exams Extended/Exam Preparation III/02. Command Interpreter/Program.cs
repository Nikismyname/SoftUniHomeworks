using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2___Command_Interpreter
{
    //14:46
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(new char[] { ' ', '\r', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string input = Console.ReadLine();
            while (input != "end")
            {
                var tokens = input.Split();
                switch (tokens[0])
                {
                    case "reverse":
                        Reverse(int.Parse(tokens[2]), int.Parse(tokens[4]));
                        break;
                    case "sort":
                        Sort(int.Parse(tokens[2]), int.Parse(tokens[4]));
                        break;
                    case "rollLeft":
                        RollLeft(int.Parse(tokens[1]));
                        break;
                    case "rollRight":
                        RollRight(int.Parse(tokens[1]));
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
            // Console.ReadLine();

            void RollLeft(int count)
            {
                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }

                int rollCount = count % array.Length;
                var leftArray = array.Where((x, i) => i < rollCount).ToArray();
                var rightArray = array.Where((x, i) => i >= rollCount).ToArray();
                array = rightArray.Concat(leftArray).ToArray();
            }

            void RollRight(int count)
            {
                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }

                int rollCount = count % array.Length;
                var leftArray = array.Where((x, i) => i < array.Length - rollCount).ToArray();
                var rightArray = array.Where((x, i) => i >= array.Length - rollCount).ToArray();
                array = rightArray.Concat(leftArray).ToArray();
            }

            void Reverse(int start, int count)
            {
                if (start < 0 || start >= array.Length)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }

                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }

                if (start + count - 1 >= array.Length)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }

                for (int i = 0; i < Math.Floor((double)count / 2); i++)
                {
                    string buffer = array[start + i];
                    array[start + i] = array[start + count - 1 - i];
                    array[start + count - 1 - i] = buffer;
                }
            }

            void Sort(int start, int count)
            {
                if (start < 0 || start >= array.Length)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }
                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }
                if (start + count - 1 >= array.Length)
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }

                var subArray = array.Where((x, i) => i >= start && i < start + count).OrderBy(x => x).ToList();

                for (int i = 0; i < count; i++)
                {
                    array[start + i] = subArray[i];
                }
            }
        }
    }
}
