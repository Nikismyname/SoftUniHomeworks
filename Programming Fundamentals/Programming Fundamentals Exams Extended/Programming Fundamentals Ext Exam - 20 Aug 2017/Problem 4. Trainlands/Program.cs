using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Trainlands
{
    //18:51- 19:17- 26m
    public class Program
    {
        public static void Main()
        {
            var dict = new Dictionary<string, List<Wagon>>();

            string input = Console.ReadLine();
            while(input!= "It's Training Men!")
            {
                if (input.Contains(" -> ") && input.Contains(" : "))
                {
                    var tokens = input.
                        Split(new char[] { ' ', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string trainName = tokens[0];
                    string wagonName = tokens[1];
                    int wagonPower = int.Parse(tokens[2]);

                    if (!dict.ContainsKey(trainName))
                    {
                        dict[trainName] = new List<Wagon>();
                    }

                    dict[trainName].Add(new Wagon(wagonName, wagonPower));
                }
                else if (input.Contains(" -> "))
                {
                    var tokens = input.
                       Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string trainName = tokens[0];
                    string otherTrain = tokens[1];

                    if (!dict.ContainsKey(trainName))
                    {
                        dict[trainName] = new List<Wagon>();
                    }

                    dict[trainName].AddRange(dict[otherTrain]);
                    dict.Remove(otherTrain);
                }
                else if (input.Contains(" = "))
                {
                    var tokens = input.
                        Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string trainName = tokens[0];
                    string otherTrain = tokens[1];

                    if (!dict.ContainsKey(trainName))
                    {
                        dict[trainName] = new List<Wagon>();
                    }

                    dict[trainName] = new List<Wagon>(dict[otherTrain]);
                }
                input = Console.ReadLine();
            }
            dict = dict
                .OrderByDescending(x => x.Value.Sum(y => y.power))
                .ThenBy(x=>x.Value.Count)
                .ToDictionary(x=>x.Key,x=>x.Value);

            foreach (var item in dict)
            {
                Console.WriteLine($"Train: {item.Key}");
                foreach (var wagon in item.Value.OrderByDescending(x=>x.power))
                {
                    Console.WriteLine($"###{wagon.name} - {wagon.power}");
                }
            }
            //Console.ReadLine();
        }
    }

    public class Wagon
    {
        public string name;
        public int power;
        public Wagon(string n, int p)
        {
            name = n;
            power = p;
        }
    }
}
