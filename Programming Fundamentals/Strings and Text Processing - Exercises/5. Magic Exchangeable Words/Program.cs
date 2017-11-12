using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Magic_Exchangeable_Words
{
    class Program
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split();
            string a = tokens[0];
            string b = tokens[1];

            List<List<int>> createDistList(string input)
            {
                var dict = new Dictionary<char, List<int>>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (!dict.ContainsKey(input[i]))
                    {
                        dict[input[i]] = new List<int>();
                    }
                    dict[input[i]].Add(i);
                }
                return dict.Select(x => x.Value).ToList();
            }

            int min = Math.Min(a.Length, b.Length);
            var list1 = createDistList(a.Substring(0, min));
            var list2 = createDistList(b.Substring(0, min));

            bool replcableToMinL = true;
            if (list1.Count != list2.Count)
            {
                replcableToMinL = false;
            }
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (!list1[i].SequenceEqual(list2[i]))
                    {
                        replcableToMinL = false;
                        break;
                    }
                }
            }
            bool secondCheck = true;
            if (a.Length != b.Length)
            {
                var c = a.Length > b.Length ? a : b;
                var checkedChars = c.ToCharArray().Take(min);
                if (c.ToCharArray().Skip(min).Any(x => checkedChars.Contains(x) == false))
                {
                    secondCheck = false;
                }
            }

            if(secondCheck && replcableToMinL)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.ReadLine();
        }
    }
}
