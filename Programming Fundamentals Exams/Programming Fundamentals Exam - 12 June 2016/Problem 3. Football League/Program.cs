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
            Dictionary<string, int> points = new Dictionary<string, int>();
            Dictionary<string, int> goals = new Dictionary<string, int>();

            string key = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "final")
            {
                string[] tokens = input.Split();
                string teamA = ParseTeams(tokens[0], key);
                string teamB = ParseTeams(tokens[1], key);

                string score = tokens[2];
                int scoreTA = score.Split(':').Select(int.Parse).First();
                int scoreTB = score.Split(':').Select(int.Parse).Last();

                if (!points.ContainsKey(teamA))
                {
                    points[teamA] = 0;
                    goals[teamA] = 0;
                }

                if (!points.ContainsKey(teamB))
                {
                    points[teamB] = 0;
                    goals[teamB] = 0;
                }

                goals[teamA] += scoreTA;
                goals[teamB] += scoreTB;

                if (scoreTA > scoreTB)
                {
                    points[teamA] += 3;
                }
                else if (scoreTA == scoreTB)
                {
                    points[teamA] += 1;
                    points[teamB] += 1;
                }
                else
                {
                    points[teamB] += 3;
                }

                input = Console.ReadLine();
            }

            points = points.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            goals = goals.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(3)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 0;

            Console.WriteLine("League standings:");
            foreach (var item in points)
            {
                Console.WriteLine($"{++count}. {item.Key} {item.Value}");
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var item in goals)
            {
                Console.WriteLine($"- {item.Key} -> {item.Value}");
            }

            // Console.ReadLine();
        }

        public static string ParseTeams(string team, string key)
        {
            int keyL = key.Length;

            int startIndex = team.IndexOf(key) + keyL;
            int lastIndex = team.LastIndexOf(key);

            string resultTeam = team.Substring(startIndex, lastIndex - startIndex).ToUpper();
            return new string(resultTeam.Reverse().ToArray());
        }
    }
}