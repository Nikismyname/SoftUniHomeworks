using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_4___Cubic_s_Messages
{
    //16:10 - 16:40
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "Over!")
            {
                int m = int.Parse(Console.ReadLine());
                string pattern = $@"^([0-9]+)([a-zA-Z]{{{m}}})([^a-zA-Z]+)$";
                var match = Regex.Match(input,pattern);
                if (match.Success)
                {
                    var message = match.Groups[2].Value;
                    var indecies = string.Concat(match.Groups[1].Value, match.Groups[3].Value);
                    List<char> result = new List<char>();

                    for (int i = 0; i < indecies.Length; i++)
                    {
                        if (Char.IsDigit(indecies[i]))
                        {
                            var ind = int.Parse(indecies[i].ToString());
                            if(ind>= message.Length)
                            {
                                result.Add(' ');
                            }
                            else
                            {
                                result.Add(message[ind]);
                            }
                        }
                    }
                    Console.WriteLine($"{message} == {new string(result.ToArray())}");
                }
                input = Console.ReadLine();
            }
            //Console.ReadLine();
        }
    }
}
