using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main()
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();
            var repeatTown = new Dictionary<string, int>();

            string prohibited = "@#$&0123456789";

            string input = Console.ReadLine();

            while (input != "stop")
            {
                var tokens = input.Split('\\');

                for (int i = 0; i < 2; i++)
                {
                    List<int> prohibInd = new List<int>();

                    for (int j = 0; j < tokens[i].Length; j++)
                    {
                        if (prohibited.Contains(tokens[i][j]))
                        {
                            prohibInd.Add(j);
                        }
                    }

                    for (int j = prohibInd.Count - 1; j >= 0; j--)
                    {
                        tokens[i] = tokens[i].Remove(prohibInd[j], 1);
                    }
                }

                string country = string.Empty;
                string city = string.Empty;

                if (char.IsUpper(tokens[0].First()))
                {
                    country = tokens[0];
                    city = tokens[1];
                }
                else
                {
                    country = tokens[1];
                    city = tokens[0];
                }

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new Dictionary<string, long>();
                    repeatTown[country] = 0;
                }

                if (countries[country].ContainsKey(city))
                {
                    repeatTown[country]++;
                }

                countries[country][city] = long.Parse(tokens[2]);

                input = Console.ReadLine();
            }

            foreach (var item in countries.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Count + repeatTown[item.Key]}");
            }

            var toPrint = new List<KeyValuePair<string, long>>();

            foreach (var item in countries)
            {
                toPrint.AddRange(item.Value);
            }

            foreach (var item in toPrint.OrderByDescending(x => x.Value).Take(3))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            //Console.ReadLine();
        }
    }
}
