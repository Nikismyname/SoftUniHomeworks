using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1.Most_Frequent_Number
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");
            string nums = File.ReadAllText("input.txt");
            var array = nums.Split(' ').Select(int.Parse).ToArray();

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!dict.ContainsKey(array[i]))
                {
                    dict[array[i]] = 0;
                }
                dict[array[i]]++;
            }
            int max = dict.Max(x => x.Value);
            foreach (var item in dict)
            {
                if(item.Value == max)
                {
                    File.WriteAllText("output.txt",item.Key.ToString());
                    break;
                }
            }
        }
    }
}
