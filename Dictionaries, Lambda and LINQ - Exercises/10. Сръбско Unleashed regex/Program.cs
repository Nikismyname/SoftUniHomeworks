using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10.Сръбско_Unleashed
{
    class Program
    {
        static void Main()
        {
            var regex = "^((?:[a-zA-Z]+ ?){1,3}) @((?:[a-zA-Z]+ ?){1,3}) ([0-9]+) ([0-9]+)$";

            var locationWithPerformer = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while(input != "End")
            {
                
                var match = Regex.Match(input,regex);
                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                var performer = match.Groups[1].Value;
                var location = match.Groups[2].Value;
                var price = long.Parse(match.Groups[3].Value);
                var count = long.Parse(match.Groups[4].Value);

                //Console.WriteLine($"{performer} {location} {price} {count}");

                if (!locationWithPerformer.ContainsKey(location))
                {
                    locationWithPerformer[location] = new Dictionary<string, long>();
                }

                if (!locationWithPerformer[location].ContainsKey(performer))
                {
                    locationWithPerformer[location][performer] = 0;
                }

                locationWithPerformer[location][performer] += price * count;

                input = Console.ReadLine();
            }

            foreach (var item in locationWithPerformer)
            {
                Console.WriteLine(item.Key);
                foreach (var performer in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {performer.Key} -> {performer.Value}");  
                }
            }
            //Console.ReadLine();
        }
    }
}
