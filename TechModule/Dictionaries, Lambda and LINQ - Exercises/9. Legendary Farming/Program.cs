using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Legendary_Farming
{
    class Program
    {
        static void Main()
        {
            var resources = new Dictionary<string, long>();
            resources.Add("shards", 0);
            resources.Add("fragments", 0);
            resources.Add("motes", 0);

            for (int i = 0; i < 11; i++)
            {
                var tokens = Console.ReadLine().Split();

                for (int j = 0; j < tokens.Length; j += 2)
                {
                    var qtt = long.Parse(tokens[j]);
                    var item = tokens[j + 1].ToLower();

                    if (!resources.ContainsKey(item))
                    {
                        resources[item] = 0;
                    }

                    resources[item] += qtt;

                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        if (resources[item] >= 250)
                        {
                            resources[item] -= 250;

                            if (item == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            if (item == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            if (item == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            var keyIngr = resources.Where(x => x.Key == "fragments" || x.Key == "shards" || x.Key == "motes").ToDictionary(x => x.Key, x => x.Value);
                            foreach (var keyRespurce in keyIngr.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
                            {
                                Console.WriteLine($"{keyRespurce.Key}: {keyRespurce.Value}");
                            }

                            var rest = resources.Where(x => x.Key != "fragments" && x.Key != "shards" && x.Key != "motes").ToDictionary(x => x.Key, x => x.Value);
                            foreach (var keyRespurce in rest.OrderBy(x => x.Key))
                            {
                                Console.WriteLine($"{keyRespurce.Key}: {keyRespurce.Value}");
                            }

                            return;
                        }
                    }
                }
            }
        }
    }
}
