using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.User_Logs
{
    class Program
    {
        static void Main()
        {
            var userIPs = new Dictionary<string, Dictionary<string, int>>();
            var input = Console.ReadLine();
            while (input != "end")
            {
                var tokens = input.Split();
                var ip = tokens[0].Split('=')[1];
                var user = tokens[2].Split('=')[1];

                if(!userIPs.ContainsKey(user))
                {
                    userIPs[user] = new Dictionary<string, int>();
                }

                if (!userIPs[user].ContainsKey(ip))
                {
                    userIPs[user][ip] = 0;
                }

                userIPs[user][ip]++;

                input = Console.ReadLine();
            }

            foreach (var item in userIPs.OrderBy(x=>x.Key))
            {
                Console.WriteLine(item.Key+ ":");
                Console.WriteLine(string.Join(", ", item.Value.Select(x => $"{x.Key} => {x.Value}"))+".");
            }
            //Console.ReadLine();
        }
    }
}
