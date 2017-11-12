using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2___Hornet_Comm
{
    //13:03
    class Program
    {
        static void Main()
        {
            var dict1private = new List<KeyValuePair<string, string>>();
            var dict2broadcast = new List<KeyValuePair<string, string>>();

            string input = Console.ReadLine();
            while (input != "Hornet is Green")
            {
                var tokens = input.Split(new string[] { " <-> " }, StringSplitOptions.None);

                if (tokens.Length != 2)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (tokens[0].All(Char.IsDigit))
                {
                    //private 
                    if (IsCharOrDigit(tokens[1]))
                    {

                        string recCode = new string(tokens[0].Reverse().ToArray());
                        string message = tokens[1];
                        dict1private.Add(new KeyValuePair<string, string>(recCode, message));
                    }
                }

                if (!tokens[0].Any(Char.IsDigit))
                {
                    //boradcast
                    if (IsCharOrDigit(tokens[1]))
                    {
                        string message = tokens[0];
                        string freq = SwithchCase(tokens[1]);
                        dict2broadcast.Add(new KeyValuePair<string, string>(freq, message));
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (dict2broadcast.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var item in dict2broadcast)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }

            Console.WriteLine("Messages:");
            if (dict1private.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var item in dict1private)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }

            Console.ReadLine();

            bool IsCharOrDigit(string inp)
            {
                if (inp.All(x => Char.IsDigit(x) || char.IsLetter(x)))
                {
                    return true;
                }
                return false;
            }

            string SwithchCase(string inp)
            {
                var result = string.Empty;
                for (int i = 0; i < inp.Length; i++)
                {
                    char c = inp[i];
                    if (Char.IsLetter(c))
                    {
                        if (Char.IsUpper(c))
                        {
                            result += Char.ToLower(c);
                        }
                        else
                        if (Char.IsLower(c))
                        {
                            result += Char.ToUpper(c);
                        }
                    }
                    else
                    {
                        result += c;
                    }
                }
                return result;
            }
        }
    }
}
