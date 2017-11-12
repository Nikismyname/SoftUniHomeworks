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
            string input = Console.ReadLine();

            var IDWithName = new Dictionary<long, string>();
            var IDWithGuests = new Dictionary<long, List<string>>();

            while (input != "Time for Code")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                bool valid = true;

                long ID = long.Parse(tokens[0]);
                /*
                if (int.TryParse(tokens[0], out ID) == false)
                {
                    valid = false;
                }
                */
                if (tokens[1].First() != '#')
                {
                    valid = false;
                }
                for (int i = 2; i < tokens.Length; i++)
                {
                    if (tokens[i].First() != '@')
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    if (!IDWithName.ContainsKey(ID))
                    {
                        IDWithName[ID] = tokens[1];
                        IDWithGuests[ID] = tokens.Where((x, i) => i > 1).ToList();
                        IDWithGuests[ID] = IDWithGuests[ID].Distinct().ToList();
                    }
                    else
                    {
                        if (IDWithName[ID] == tokens[1])
                        {
                            IDWithGuests[ID].AddRange(tokens.Where((x, i) => i > 1).ToList());
                            IDWithGuests[ID] = IDWithGuests[ID].Distinct().ToList();
                        }
                    }
                }

                input = Console.ReadLine();
            }

            IDWithName = IDWithName.OrderByDescending(x => IDWithGuests[x.Key].Count)
                .ThenBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in IDWithName)
            {
                Console.WriteLine($"{item.Value.Substring(1, item.Value.Length - 1)} - {IDWithGuests[item.Key].Count}");

                foreach (var guest in IDWithGuests[item.Key].OrderBy(x => x))
                {
                    Console.WriteLine(guest);
                }
            }

            //  Console.ReadLine();
        }
    }
}
