using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.CODE_Phoenix_Oscar_Romeo_November
{
    //11:01-11:18 - 17min
    //10:12 - 11:18 1h06min
    public class Program
    {
        public static void Main()
        {
            var dict = new Dictionary<string, HashSet<string>>();
            string input = Console.ReadLine();
            while(input!= "Blaze it!")
            {
                var tokens = input.Split(new char[] {'-','>',' ' },StringSplitOptions.RemoveEmptyEntries);
                string creature = tokens[0];
                string sMate = tokens[1];

                if(creature == sMate)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!dict.ContainsKey(creature))
                {
                    dict[creature] = new HashSet<string>();
                }

                dict[creature].Add(sMate);
                input = Console.ReadLine();
            }

            var dict2 = new Dictionary<string, int>();
            foreach (var item in dict)
            {
                int sMates = 0;
                foreach (var mate in item.Value)
                {
                    if (dict.ContainsKey(mate))
                    {
                        if (!dict[mate].Contains(item.Key))
                        {
                            sMates++;
                        }
                    }
                    else
                    {
                        sMates++;
                    }
                }
                dict2.Add(item.Key, sMates);
            }
            foreach (var item in dict2.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            //Console.ReadLine();
        }
    }
}
