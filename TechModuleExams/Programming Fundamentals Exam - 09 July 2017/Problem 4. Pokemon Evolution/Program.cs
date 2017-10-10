using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Pokemon_Evolution
{
    //19:48 20:09 - 21m
    public class Program
    {
        public static void Main()
        {
            var dict = new Dictionary<string,List<Evo>>();
            string input = Console.ReadLine();
            while(input!= "wubbalubbadubdub")
            {
               
                var tokens = input.Split(new string[] { " -> " }, StringSplitOptions.None);
                if (tokens.Length == 1)
                {
                    if (dict.ContainsKey(tokens[0]))
                    {
                        Console.WriteLine($"# {tokens[0]}");
                        foreach (var item in dict[tokens[0]])
                        {
                            Console.WriteLine($"{item.type} <-> {item.level}");
                        }
                    }
                }
                else
                {
                    string name = tokens[0];
                    string evoType = tokens[1];
                    int evoIndex = int.Parse(tokens[2]);

                    if (!dict.ContainsKey(name))
                    {
                        dict[name] = new List<Evo>();
                    }
                    dict[name].Add(new Evo(evoType,evoIndex));
                }
                input = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"# {item.Key}");
                foreach (var evo in item.Value.OrderByDescending(x=>x.level))
                {
                    Console.WriteLine($"{evo.type} <-> {evo.level}");
                }
            }
            Console.ReadLine();
        }
    }

    public class Evo
    {
        public string type;
        public int level;
        public Evo(string Type, int Level)
        {
            type = Type;
            level = Level;
        }
    }
}
