using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.SoftUni_Karaoke
{
    //15:57 - 16:14 = 17
    public class Program
    {
        public static void Main()
        {
            var part = Console.ReadLine().Split(new string[] {", " }, StringSplitOptions.None);
            var songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            var dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while(input!= "dawn")
            {
                var tokens = input.Split(new string[] { ", " }, StringSplitOptions.None);
                var name = tokens[0];
                var song = tokens[1];
                var award = tokens[2];

                if((!part.Contains(name)) || (!songs.Contains(song)))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<string>();
                }

                if (!dict[name].Contains(award))
                {
                    dict[name].Add(award);
                }

                input = Console.ReadLine();
            }

            foreach (var item in dict.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} awards");
                foreach (var aw in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"--{aw}");
                }
            }

            if(dict.Count == 0)
            {
                Console.WriteLine("No awards");
            }

            //Console.ReadLine();
        }
    }
}
