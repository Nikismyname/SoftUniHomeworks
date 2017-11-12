using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Files
{
    //17:39 - 16:45;
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, List<string[]>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { '\\' },StringSplitOptions.RemoveEmptyEntries);
                var root = tokens[0].Trim();
                var rest = tokens[tokens.Length - 1].Trim();

                var tokensRest = rest.Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
                var dotTokens = tokensRest[0].Split(new char[] { '.' },StringSplitOptions.RemoveEmptyEntries);

                //that wasn't documented - you can have multiple donts in name
                var fileName = string.Join(".",dotTokens.Where((x,j)=> j< dotTokens.Length-1));
                //var fileName = dotTokens[0];
                var extension = dotTokens.Last().Trim();

                var size = tokensRest[1].Trim();

                //Console.WriteLine($"{fileName} {extension} {size}");

                if (!dict.ContainsKey(root))
                {
                    dict[root] = new List<string[]>();
                }

                if(dict[root].Any(x=>x[0] == fileName && x[1] == extension))
                {
                    var toChange = dict[root].Single(x => x[0] == fileName && x[1] == extension);
                    toChange[2] = size;
                }
                else
                {
                    dict[root].Add(new string[] {fileName,extension,size });
                }
            }

            var command = Console.ReadLine().Split();
            var ext = command[0].Trim();
            var groot = command[2].Trim();

            if (dict.ContainsKey(groot))
            {
                var files = dict[groot].Where(x => x[1] == ext).OrderByDescending(x => double.Parse(x[2])).ThenBy(x => x[0]).ToList();
                if(files.Count == 0)
                {
                    Console.WriteLine("No");
                }
                else
                {
                    foreach (var item in files)
                    {
                        Console.WriteLine($"{item[0]}.{item[1]} - {item[2]} KB");
                    }
                }

            }
            else
            {
                Console.WriteLine("No");
            }

            //Console.ReadLine();
        }
    }
}
