using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.NSA
{
    //16:11 - 16:23 - 12 min
    public class Program
    {
        public static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while(input!= "quit")
            {
                var tokens = input.Split(new string[] { " -> " },StringSplitOptions.RemoveEmptyEntries);
                string country = tokens[0];
                string spy = tokens[1];
                int days = int.Parse(tokens[2]);

                if (!dict.ContainsKey(country))
                {
                    dict[country] = new Dictionary<string, int>();
                }

                if (!dict[country].ContainsKey(spy))
                {
                    dict[country][spy] = 0;
                }

                dict[country][spy] = days;

                input = Console.ReadLine();
            }

            foreach (var item in dict.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"Country: {item.Key}");

                foreach (var spy in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }

            //Console.ReadLine();
        }
    }
}
