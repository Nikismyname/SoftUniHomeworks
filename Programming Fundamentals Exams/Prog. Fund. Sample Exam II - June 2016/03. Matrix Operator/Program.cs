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
            long y = long.Parse(Console.ReadLine());

            long[][] table = new long[y][];

            for (int i = 0; i < y; i++)
            {
                table[i] = Console.ReadLine().Split().Select(long.Parse).ToArray();
            }

            string input = Console.ReadLine();
            while (input != "end")
            {
                var tokens = input.Split();

                switch (tokens[0])
                {
                    case "remove":
                        Remove(ref table, tokens);
                        break;
                    case "swap":
                        Swap(ref table, tokens);
                        break;
                    case "insert":
                        Insert(ref table, tokens);
                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine(string.Join(" ", table[i]));
            }

            //Console.ReadLine();
        }

        public static void Insert(ref long[][] table, string[] tokens)
        {
            int row = int.Parse(tokens[1]);
            long num = int.Parse(tokens[2]);

            List<long> insertion = table[row].ToList();
            insertion.Insert(0, num);
            table[row] = insertion.ToArray();
        }

        public static void Swap(ref long[][] table, string[] tokens)
        {
            int rowOne = int.Parse(tokens[1]);
            int rowTwo = int.Parse(tokens[2]);

            long[] buffer = table[rowOne].ToArray();

            table[rowOne] = table[rowTwo];
            table[rowTwo] = buffer;
        }

        public static void Remove(ref long[][] table, string[] tokens)
        {
            int num = int.Parse(tokens[3]);

            if (tokens[2] == "row")
            {
                switch (tokens[1])
                {
                    case "even":
                        table[num] = table[num].Where(x => Math.Abs(x) % 2 == 1).ToArray();
                        break;
                    case "odd":
                        table[num] = table[num].Where(x => Math.Abs(x) % 2 == 0).ToArray();
                        break;
                    //maybe 0 is not positive
                    case "positive":
                        table[num] = table[num].Where(x => x < 0).ToArray();
                        break;
                    case "negative":
                        table[num] = table[num].Where(x => x >= 0).ToArray();
                        break;
                }
            }

            if (tokens[2] == "col")
            {

                Func<long, bool> test = x =>
                {
                    throw new ArgumentException();
                };

                switch (tokens[1])
                {
                    case "even":
                        test = x =>
                        {
                            if (Math.Abs(x) % 2 == 1)
                            {
                                return true;
                            }
                            return false;
                        };
                        break;
                    case "odd":
                        test = x =>
                        {
                            if (Math.Abs(x) % 2 == 0)
                            {
                                return true;
                            }
                            return false;
                        }; break;
                    //maybe 0 is not positive
                    case "positive":
                        test = x =>
                        {
                            if (x < 0)
                            {
                                return true;
                            }
                            return false;
                        };
                        break;
                    case "negative":
                        test = x =>
                        {
                            if (x >= 0)
                            {
                                return true;
                            }
                            return false;
                        }; break;
                }


                for (int i = 0; i < table.Length; i++)
                {
                    //Console.WriteLine($"lenght, desired index: {table[i].Length} {num}");

                    if (table[i].Length >= num + 1)
                    {
                        //  Console.WriteLine("here");
                        if (!test(table[i][num]))
                        {
                            // Console.WriteLine("here2");
                            table[i] = table[i].Where((x, j) => j != num).ToArray();
                        }
                    }
                }
            }
        }
    }
}
/*

 */
