using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _6.Email_Statistics
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pattern = @"^([a-zA-Z]{5,})@([a-z]{3,}(?:\.com|\.bg|\.org))$";
            var dict = new Dictionary<string,List<string>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    var username = match.Groups[1].Value;
                    var domain = match.Groups[2].Value;
                    if (!dict.ContainsKey(domain))
                    {
                        dict[domain] = new List<string>();
                    }
                    if (!dict[domain].Contains(username))
                    {
                        dict[domain].Add(username);
                    }
                }
            }
            foreach (var item in dict.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine(item.Key+":");
                foreach (var username in item.Value)
                {
                    Console.WriteLine($"### {username}");
                }
            }
          //  Console.ReadLine();
        }
    }
}
