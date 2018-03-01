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
            var locationWithPerformer = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != "End")
            {

                var tokens2 = new string[4];

                var tokens = input.Split();
                //separations are only single space
                if(tokens.Any(x=>x == ""))
                {
                    //Console.WriteLine("extra spaces");
                    input = Console.ReadLine();
                    continue;
                }

                //we have exactly one venue 
                string single = string.Empty;
                try
                {
                    single = tokens.Single(x=>x.StartsWith("@"));
                }
                catch
                {
                    //Console.WriteLine("no @");
                    input = Console.ReadLine();
                    continue;
                }

                
                //venue is not on first position;
                var indexOfVenueStart = Array.IndexOf(tokens,single);
                if(indexOfVenueStart == 0)
                {
                    //Console.WriteLine("venu as first item");

                    input = Console.ReadLine();
                    continue;
                }
                var lenght = tokens.Length;

                //we have atleast two tokens 
                if (lenght < 4)
                {
                    //Console.WriteLine("less than 4 tokens");

                    input = Console.ReadLine();
                    continue;
                }

                //the last tho tokens are numbers 
                tokens2[2] = tokens[lenght - 2];
                tokens2[3] = tokens[lenght - 1];
                int outToken;
                if(!int.TryParse(tokens2[2],out outToken) ||!int.TryParse(tokens2[3], out outToken))
                {
                    //Console.WriteLine("final tokens not numbers");

                    input = Console.ReadLine();
                    continue;
                }

                var perfNameTokens = tokens.Where((x, i) => i < indexOfVenueStart).ToList();
                //the performer has less than three names 
                if(perfNameTokens.Count> 3)
                {
                    input = Console.ReadLine();
                    continue;
                }
                var locationTokens = tokens.Where((x, i) => i >= indexOfVenueStart && i< lenght-2).ToList();

                //we have location with atleast one word and less than three
                if(locationTokens.Count<1|| locationTokens.Count > 3)
                {
                    input = Console.ReadLine();
                    continue;
                }

                tokens2[0] = string.Join(" ",perfNameTokens.Select(x=>x.Trim()));
                tokens2[1] = string.Join(" ", locationTokens.Select(x => x.Trim()));


                var performer = tokens2[0];
                var location = tokens2[1].Substring(1,tokens2[1].Length-1);
                var price = long.Parse(tokens2[2]);
                var count = long.Parse(tokens2[3]);

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
                foreach (var performer in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {performer.Key} -> {performer.Value}");
                }
            }
            //Console.ReadLine();
        }
    }
}

