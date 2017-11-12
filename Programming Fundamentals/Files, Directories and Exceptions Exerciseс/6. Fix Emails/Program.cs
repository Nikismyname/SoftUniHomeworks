using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6.Fix_Emails
{
    public class Program
    {
        public static void Main()
        {
            var textLines = File.ReadAllLines("input.txt");
            File.Delete("output.txt");

            for (int i = 0; i < textLines.Length; i+= 2)
            {
                if(textLines[i]!= "stop")
                {
                    string name = textLines[i];
                    string email = textLines[i + 1];
                    int lastDotInd = email.LastIndexOf('.');
                    string domain = email.Substring(lastDotInd+1);
                    if(domain.ToLower() != "us" && domain.ToLower() != "uk")
                    {
                        var textToAppend = $"{name} -> {email}"+ Environment.NewLine;
                        File.AppendAllText("output.txt", textToAppend);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
