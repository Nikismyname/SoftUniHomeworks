using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries__Lambda_and_LINQ___Exercises
{
    public class Program
    {
        public static void Main()
        {
            var phoneBook = new Dictionary<string, string>();

            var input = Console.ReadLine();
            while(input != "END")
            {
                var tokens = input.Split(' ');
                var action = tokens[0];

                switch (action)
                {
                    case "A":
                        var newName = tokens[1];
                        var newPhone = tokens[2];
                        phoneBook[newName] = newPhone;
                        break;
                    case "S":
                        var searchedName = tokens[1];
                        if (phoneBook.ContainsKey(searchedName))
                        {
                            Console.WriteLine($"{searchedName} -> {phoneBook[searchedName]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {searchedName} does not exist.");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
