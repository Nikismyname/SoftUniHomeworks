using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Logs_Aggregator
{
    class Program
    {
        static void Main()
        {
            var userWithIps = new Dictionary<string, List<string>>();
            var userWithDuration = new Dictionary<string, long>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var ip = tokens[0];
                var user = tokens[1];
                var duration = long.Parse(tokens[2]);

                if (!userWithIps.ContainsKey(user))
                {
                    userWithIps[user] = new List<string>();
                    userWithDuration[user] = 0;
                }

                userWithDuration[user] += duration;

                if (!userWithIps[user].Contains(ip))
                {
                    userWithIps[user].Add(ip);
                }
            }

            foreach (var item in userWithDuration.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} [{string.Join(", ",userWithIps[item.Key].OrderBy(x=>x))}]");
            }

            //Console.ReadLine();
        }
    }
}
