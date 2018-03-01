using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main()
        {

            var personWCoffeeType = new Dictionary<string, string>();
            var coffeeTypeWQtt = new Dictionary<string, long>();


            var tokens1 = Console.ReadLine().Split();
            string del1 = tokens1[0];
            string del2 = tokens1[1];

            string input = Console.ReadLine();

            while (input != "end of info")
            {
                if (input.Contains(del1))
                {
                    string person = input.Split(new string[] { del1 }, StringSplitOptions.RemoveEmptyEntries).First();
                    string coffeeType = input.Split(new string[] { del1 }, StringSplitOptions.RemoveEmptyEntries).Last();

                    personWCoffeeType[person] = coffeeType;

                    if (!coffeeTypeWQtt.ContainsKey(coffeeType))
                    {
                        coffeeTypeWQtt[coffeeType] = 0;
                    }
                }
                else if (input.Contains(del2))
                {
                    string[] tokens = input.Split(new string[] { del2 }, StringSplitOptions.RemoveEmptyEntries);
                    string coffeeType = tokens[0];
                    long qtt = long.Parse(tokens[1]);

                    if (!coffeeTypeWQtt.ContainsKey(coffeeType))
                    {
                        coffeeTypeWQtt[coffeeType] = 0;
                    }

                    coffeeTypeWQtt[coffeeType] += qtt;
                }

                input = Console.ReadLine();
            }

            foreach (var item in coffeeTypeWQtt)
            {
                if (item.Value == 0)
                {
                    Console.WriteLine($"Out of {item.Key}");
                }
            }

            input = Console.ReadLine();

            while (input != "end of week")
            {
                var tokens = input.Split();
                string personName = tokens[0];
                long qtt = long.Parse(tokens[1]);

                if (coffeeTypeWQtt[personWCoffeeType[personName]] > qtt)
                {
                    coffeeTypeWQtt[personWCoffeeType[personName]] -= qtt;
                }
                else
                {
                    coffeeTypeWQtt[personWCoffeeType[personName]] = 0;
                    Console.WriteLine($"Out of {personWCoffeeType[personName]}");
                }

                input = Console.ReadLine();
            }

            coffeeTypeWQtt = coffeeTypeWQtt.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Coffee Left:");
            foreach (var item in coffeeTypeWQtt)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key} {item.Value}");
                }
            }

            Console.WriteLine("For:");
            foreach (var item in coffeeTypeWQtt.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                List<string> drinkersOf = new List<string>();

                foreach (var person in personWCoffeeType)
                {
                    if (person.Value == item.Key)
                    {
                        drinkersOf.Add(person.Key);
                    }
                }

                foreach (var per in drinkersOf.OrderByDescending(x => x))
                {
                    Console.WriteLine($"{per} {item.Key}");
                }
            }

            // Console.ReadLine();
        }
    }
}
