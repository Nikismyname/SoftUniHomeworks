using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Population_Counter
{
    class Program
    {
        static void Main()
        {
            var countryWithCities = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input!= "report")
            {
                var tokens = input.Split('|');
                var city = tokens[0];
                var country = tokens[1];
                var qtt = long.Parse(tokens[2]);

                if (!countryWithCities.ContainsKey(country))
                {
                    countryWithCities[country] = new Dictionary<string, long>();
                }

                if (!countryWithCities[country].ContainsKey(city))
                {
                    countryWithCities[country][city] = 0;
                }

                countryWithCities[country][city] += qtt;

                input = Console.ReadLine();
            }
            var orderedCountyWithTotalCount = countryWithCities
                .ToDictionary(x => x.Key, x => x.Value.Sum(y => y.Value))
                .OrderByDescending(x=>x.Value);

            foreach (var item in orderedCountyWithTotalCount)
            {
                Console.WriteLine($"{item.Key} (total population: {item.Value})");
                foreach (var city in countryWithCities[item.Key].OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
            //Console.ReadLine();
        }
    }
}
