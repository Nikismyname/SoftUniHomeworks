using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _7.Query_Mess
{
    class Program
    {
        static void Main()
        {
            var dict =new Dictionary<string, List<string>>();
            string pattern = @"(?<=^|&|\?)([^?&]*?)=(.*?)(?=$|\?|&)";
            string input = Console.ReadLine();
            while(input!= "END")
            {
                var matches = Regex.Matches(input,pattern);
                foreach (Match item in matches)
                {
                    var var = item.Groups[1].Value;
                    var val = item.Groups[2].Value;

                    var = var.Replace("+", " ");
                    var = var.Replace("%20", " ");
                    var = Regex.Replace(var,@"\s+"," ");
                    var = var.Trim();

                    val = val.Replace("+", " ");
                    val = val.Replace("%20", " ");
                    val = Regex.Replace(val, @"\s+", " ");
                    val = val.Trim();

                    if (!dict.ContainsKey(var))
                    {
                        dict[var] = new List<string>();
                    }
                    dict[var].Add(val);
                }

                foreach (var item in dict)
                {
                    Console.Write($"{item.Key}=[{string.Join(", ", item.Value)}]");
                }
                Console.WriteLine();
                dict.Clear();
                input = Console.ReadLine();
            }
            //Console.ReadLine();
        }
    }
}
