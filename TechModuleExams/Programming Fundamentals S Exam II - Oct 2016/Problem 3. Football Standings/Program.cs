using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Football_Standings
{
    //13:12
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, long[]>();
            string key = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "final")
            {
                var tokens = input.Split();
                var name1 = Decript(tokens[0], key);
                var name2 = Decript(tokens[1], key);
                var team1Goals = int.Parse(tokens[2].Split(':').First());
                var team2Goals = int.Parse(tokens[2].Split(':').Last());

                if (!dict.ContainsKey(name1))
                {
                    dict[name1] = new long[] { 0, 0 };
                }
                if (!dict.ContainsKey(name2))
                {
                    dict[name2] = new long[] { 0, 0 };
                }

                dict[name1][1] += team1Goals;
                dict[name2][1] += team2Goals;

                if (team1Goals > team2Goals)
                {
                    dict[name1][0] += 3;
                }
                else if (team1Goals == team2Goals)
                {
                    dict[name1][0] += 1;
                    dict[name2][0] += 1;
                }
                else
                {
                    dict[name2][0] += 3;
                }

                input = Console.ReadLine();
            }

            int count = 0;
            Console.WriteLine("League standings:");
            foreach (var item in dict.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.Key))
            {
                count++;
                Console.WriteLine($"{count}. {item.Key} {item.Value[0]}");
            }

            Console.WriteLine("Top 3 scored goals:");
            var topScores = dict.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).Take(3);
            foreach (var item in topScores)
            {
                Console.WriteLine($"- {item.Key} -> {item.Value[1]}");
            }

            //Console.ReadLine();
        }
        public static string Decript(string encripted, string key)
        {
            int ind1 = encripted.IndexOf(key);
            int l = key.Length;
            string name1 = encripted.Substring(ind1+l);
            int ind2 = name1.LastIndexOf(key);
            string name = name1.Substring(0,ind2);
            return new string (name.Reverse().ToArray()).ToUpper();
        }
    }
}
