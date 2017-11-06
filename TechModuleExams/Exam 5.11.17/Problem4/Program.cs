using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    public static class Program
    {
        public static void Main()
        {
            var legit = new Dictionary<string, List<DatasetInfo>>();
            var cache = new Dictionary<string, List<DatasetInfo>>();

            string input = Console.ReadLine();
            while(input!= "thetinggoesskrra")
            {
                if(input.Contains(" -> "))
                {
                    var tokens = input
                        .Split(new string[] {" -> "," | " }
                            ,StringSplitOptions.RemoveEmptyEntries);
                    string dataKey = tokens[0];
                    long dataSize = long.Parse(tokens[1]);
                    string dataSet = tokens[2];

                    if (legit.ContainsKey(dataSet))
                    {
                        legit[dataSet].Add( new DatasetInfo(dataSize,dataKey));
                    }
                    else
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache[dataSet] = new List<DatasetInfo>();
                        }
                        cache[dataSet].Add(new DatasetInfo(dataSize, dataKey));
                    }
                }
                else
                {
                    string dataSet = input;
                    legit.Add(dataSet,new List<DatasetInfo>());
                    if (cache.ContainsKey(dataSet))
                    {
                        legit[dataSet] = cache[dataSet];
                        cache.Remove(dataSet);
                    }
                }

                input = Console.ReadLine();
            }
            if (legit.Count > 0)
            {
                var thing = legit.OrderByDescending(x => x.Value.Sum(y => y.size)).First();

                Console.WriteLine($"Data Set: {thing.Key}, Total Size: {thing.Value.Sum(x=>x.size)}");
                foreach (var item in thing.Value)
                {
                    Console.WriteLine($"$.{item.key}");
                }
            }
            //Console.ReadLine();
        }
    }

    public class DatasetInfo
    {
        public long size;
        public string key;
        public DatasetInfo(long size, string key)
        {
            this.size = size;
            this.key = key;
        }
    }
}
