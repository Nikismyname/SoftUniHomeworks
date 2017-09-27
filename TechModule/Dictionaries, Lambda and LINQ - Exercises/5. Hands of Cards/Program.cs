using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Hands_of_Cards
{
    class Program
    {
        static void Main()
        {
            var suits = new Dictionary<string, int>();
            suits.Add("S",4);
            suits.Add("H", 3);
            suits.Add("D", 2);
            suits.Add("C", 1);

            var faces = new Dictionary<string, int>();
            faces.Add("2", 2);
            faces.Add("3", 3);
            faces.Add("4", 4);
            faces.Add("5", 5);
            faces.Add("6", 6);
            faces.Add("7", 7);
            faces.Add("8", 8);
            faces.Add("9", 9);
            faces.Add("10", 10);
            faces.Add("J", 11);
            faces.Add("Q", 12);
            faces.Add("K", 13);
            faces.Add("A", 14);


            var playerHands = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();
            while(input != "JOKER")
            {
                var name = input.Split(':').First();
                if (!playerHands.ContainsKey(name))
                {
                    playerHands[name] = new List<string>();
                }

                var cards = input
                    .Split(':')
                    .Last()
                    .Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries)
                    .Select(x=>x.Trim())
                    .ToList();

                foreach (var item in cards)
                {
                    if (!playerHands[name].Contains(item))
                    {
                        playerHands[name].Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in playerHands)
            {
                var score = 0;
                foreach (var card  in item.Value)
                {
                    string face = string.Empty;
                    string suit = string.Empty;

                    if (card.Length == 2)
                    {
                        face = card[0].ToString();
                        suit = card[1].ToString();
                    }
                    else
                    {
                        suit = card[2].ToString();
                        face = card.Substring(0, 2);
                    }

                    score += suits[suit] * faces[face];
                }
                Console.WriteLine($"{item.Key}: {score}");
            }
           // Console.ReadLine();
        }
    }
}
