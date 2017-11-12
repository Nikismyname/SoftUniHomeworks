using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Roli___The_Coder
{
    //11:44 - 12:45
    public class Program
    {
        public static void Main()
        {
            var IdWIthName = new Dictionary<long, string>();
            var IdWithParticipents = new Dictionary<long, List<string>>();

            var input = Console.ReadLine();
            while (input != "Time for Code")
            {
                string[] tokens = new string[] { "bla", "bla" };
                long id = 5;
                var listOfPeople = new List<string> { "here", "here" };
                var eventName = "bla";

                tokens = input.Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                id = long.Parse(tokens[0]);
                listOfPeople = tokens.Where((x, i) => i >= 2).ToList();
                eventName = tokens[1];

                /*
                if (!long.TryParse(tokens[0], out id))
                {
                    input = Console.ReadLine();
                    continue;
                }
                */

                if (eventName[0] != '#')
                {
                    input = Console.ReadLine();
                    continue;
                }

                
                bool shouldContinue = false;
                foreach (var item in listOfPeople)
                {
                    if (item.Substring(0,1) != "@")
                    {
                        shouldContinue = true;
                        break;
                    }
                }
                if (shouldContinue)
                {
                    input = Console.ReadLine();
                    continue;
                }
                

                if (!IdWIthName.ContainsKey(id))
                {
                    IdWIthName[id] = eventName;
                    IdWithParticipents[id] = new List<string>();

                    for (int i = 0; i < listOfPeople.Count; i++)
                    {
                        if (!IdWithParticipents[id].Contains(listOfPeople[i]))
                        {
                            IdWithParticipents[id].Add(listOfPeople[i]);
                        }
                    }
                }
                else
                {
                    if (IdWIthName[id] == eventName)
                    {
                        for (int i = 0; i < listOfPeople.Count; i++)
                        {
                            if (!IdWithParticipents[id].Contains(listOfPeople[i]))
                            {
                                IdWithParticipents[id].Add(listOfPeople[i]);
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in IdWithParticipents
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => IdWIthName[x.Key]))
            {
                Console.WriteLine($"{IdWIthName[item.Key].Substring(1)} - {item.Value.Count}");
                foreach (var person in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}

