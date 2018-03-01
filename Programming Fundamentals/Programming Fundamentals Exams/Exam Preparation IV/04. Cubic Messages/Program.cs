using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam_Preparation_IV
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (input != "Over!")
            {
                int num = int.Parse(Console.ReadLine());

                string pattern = "^([0-9]+)([a-zA-Z]{" + num + "})([^a-zA-Z]*)$";

                if (Regex.Match(input, pattern).Success)
                {
                    Match match = Regex.Match(input, pattern);
                    string message = match.Groups[2].Value;
                    string prev = match.Groups[1].Value;
                    string post = match.Groups[3].Value;

                    // Console.WriteLine($"{prev}  {message}  {post}");

                    int lastIndMess = message.Length - 1;

                    string code = string.Empty;

                    foreach (var c in prev + post)
                    {
                        if (char.IsDigit(c))
                        {
                            int index = int.Parse(Convert.ToString(c));

                            if (index < 0 || index > lastIndMess)
                            {
                                code += " ";
                            }
                            else
                            {
                                code += message[index];
                            }
                        }
                    }

                    Console.WriteLine(message + " == " + code);
                }

                input = Console.ReadLine();
            }

            // Console.ReadLine();
        }
    }
}
