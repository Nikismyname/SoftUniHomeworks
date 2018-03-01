using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _4.Weather
{
    class Program
    {
        static void Main()
        {
            var pattern = @"([A-Z]{2})([0-9]+\.[0-9]{1,2})([a-zA-Z]+?)\|";
            var dict = new Dictionary<string, WeatherInfo>();
            var input = Console.ReadLine();
            while(input != "end")
            {
                var match = Regex.Match(input,pattern);
                if (match.Success)
                {
                    var city = match.Groups[1].Value;
                    float temp = float.Parse(match.Groups[2].Value);
                    string desc = match.Groups[3].Value;
                    
                    dict[city] = new WeatherInfo(temp,desc);
                }
                input = Console.ReadLine();
            }

            foreach (var item in dict.OrderBy(x=>x.Value.temp))
            {
                Console.WriteLine($"{item.Key} => {item.Value.temp.ToString("0.00")} => {item.Value.desc}");
            }
            //Console.ReadLine();
        }
    }
    class WeatherInfo
    {
        public float temp;
        public string desc;
        public WeatherInfo(float Temp, string Desc)
        {
            this.temp = Temp;
            this.desc = Desc;
        }
    }
}
