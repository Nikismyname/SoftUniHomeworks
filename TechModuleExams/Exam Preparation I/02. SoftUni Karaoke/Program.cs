using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUni_Karaoke
{
    //14:37 - 14:51 - 14 min
    public class Program
    {
        public static void Main()
        {
            string[] parts = Console.ReadLine().Split(new string[] { ", "},StringSplitOptions.RemoveEmptyEntries);
            string[] songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string input = Console.ReadLine();
            var dict = new Dictionary<string, HashSet<string>>();
            while (input!= "dawn")
            {
                var tokens = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string partName = tokens[0];
                string song = tokens[1];
                string award = tokens[2];

                if(parts.Contains(partName)&& songs.Contains(song))
                {
                    if (!dict.ContainsKey(partName))
                    {
                        dict[partName] = new HashSet<string>();
                    }
                    dict[partName].Add(award);
                }

                input = Console.ReadLine();
            }

            if (dict.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var part in dict
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{part.Key}: {part.Value.Count} awards");
                    foreach (var award in part.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            //Console.ReadLine();
        }
    }
}
