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
            string[] tickets = Console.ReadLine().
                Split(new char[] { ' ', '\t', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalf = ticket.Substring(0, 10);
                string secondHalf = ticket.Substring(10, 10);

                CheckInfo one = CheckHalf(firstHalf);
                CheckInfo two = CheckHalf(secondHalf);

                if (one == null || two == null)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                if (one.symbol != two.symbol)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                int winningNum = Math.Min(one.occurances, two.occurances);

                if (winningNum >= 6 && winningNum <= 9)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {winningNum}{one.symbol}");
                    continue;
                }

                if (winningNum == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{one.symbol} Jackpot!");
                }
            }

            //Console.ReadLine();
        }

        public static CheckInfo CheckHalf(string toCheck)
        {
            string symb = "@#$^";
            int occurances = 0;
            int finalOcc = 0;
            char finalChar = ' ';
            for (int i = 0; i < toCheck.Length; i++)
            {
                if (symb.Contains((char)toCheck[i]))
                {
                    occurances++;
                    for (int j = i + 1; j < toCheck.Length; j++)
                    {
                        if (toCheck[i] == toCheck[j])
                        {
                            occurances++;
                        }
                        else
                        {
                            if (occurances >= 6 && occurances > finalOcc)
                            {
                                finalOcc = occurances;
                                finalChar = toCheck[i];
                            }

                            occurances = 0;
                            break;
                        }
                        //in case of end search
                        if (j == toCheck.Length - 1)
                        {
                            if (occurances >= 6 && occurances > finalOcc)
                            {
                                finalOcc = occurances;
                                finalChar = toCheck[i];
                            }

                            occurances = 0;
                        }
                    }
                }
            }
            if (finalOcc < 6)
            {
                return null;
            }
            else
            {
                return new CheckInfo(finalChar, finalOcc);
            }
        }
    }

    public class CheckInfo
    {
        public char symbol;
        public int occurances;

        public CheckInfo(char s, int o)
        {
            symbol = s;
            occurances = o;
        }
    }
}
