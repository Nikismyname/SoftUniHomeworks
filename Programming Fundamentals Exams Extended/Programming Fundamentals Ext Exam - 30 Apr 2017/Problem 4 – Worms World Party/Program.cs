using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4___Worms_World_Party
{
    //11:57 - 12:15 - 18
    public class Program
    {
        public static void Main()
        {
            var worms = new HashSet<string>();
            var dict = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while(input != "quit")
            {
                var tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string wormName = tokens[0];
                string teamName = tokens[1];
                long wormScore = long.Parse(tokens[2]);

                if (worms.Contains(wormName))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!dict.ContainsKey(teamName))
                {
                    dict[teamName] = new Dictionary<string, long>();
                }

                dict[teamName].Add(wormName,wormScore);
                worms.Add(wormName);

                input = Console.ReadLine();
            }

            int counter = 0;

            foreach (var team in dict
                .OrderByDescending(x=>x.Value.Sum(y=>y.Value))
                .ThenByDescending(x=>x.Value.Average(y=>y.Value)))
            {
                Console.WriteLine($"{++counter}. Team: {team.Key} - {team.Value.Sum(x=>x.Value)}");
                foreach (var worm in team.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
            }

            //Console.ReadLine();
        }
    }
}
