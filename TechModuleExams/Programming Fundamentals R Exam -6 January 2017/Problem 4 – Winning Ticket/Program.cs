using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4___Winning_Ticket
{
    //16:36 -  18:30 - 
    public class Program
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>x.ToString().Trim());

            foreach (var t in tickets)
            {
                if (t.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }

                var fHalf = t.Substring(0, 10);
                var sHalf = t.Substring(10);
                var infoFirst = AnaliseHalf(fHalf);
                var infoSecond = AnaliseHalf(sHalf);

                if (infoFirst == null || infoSecond == null)
                {
                    Console.WriteLine($"ticket \"{t}\" - no match");
                    continue;
                }

                if (infoFirst.winningChar != infoSecond.winningChar)
                {
                    Console.WriteLine($"ticket \"{t}\" - no match");
                    continue;
                }

                int winningCount = Math.Min(infoFirst.count, infoSecond.count);

                if (winningCount != 10)
                {
                    Console.WriteLine($"ticket \"{t}\" - {winningCount}{infoFirst.winningChar}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{t}\" - 10{infoFirst.winningChar} Jackpot!");
                }
            }

            Console.ReadLine();
        }

        public static TicketHalfInfo AnaliseHalf(string input)
        {
            var chars = "@#$^";
            int longestStreak = 0;
            char longesChar = ' ';
            int localStreak = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (chars.Contains(input[i]))
                {
                    for (int j = i; j < input.Length; j++)
                    {
                        if(input[j] == input[i])
                        {
                            localStreak++;
                        }
                        else
                        {
                            if(localStreak> longestStreak)
                            {
                                longestStreak = localStreak;
                                localStreak = 0;

                                longesChar = input[i];
                                i = j - 1;
                            }
                        }

                        if(j == input.Length - 1)
                        {
                            if (localStreak > longestStreak)
                            {
                                longestStreak = localStreak;
                                localStreak = 0;

                                longesChar = input[i];
                                i = j;
                            }
                        }
                    }
                }
            }

            if(longestStreak>= 6)
            {
                return new TicketHalfInfo(longestStreak, longesChar);
            }
            else
            {
                return null;
            }
        }
    }

    public class TicketHalfInfo
    {
        public char winningChar;
        public int count;

        public TicketHalfInfo(int Count, char ch)
        {
            
            this.winningChar = ch;
            this.count = Count;
        }
    }
}
