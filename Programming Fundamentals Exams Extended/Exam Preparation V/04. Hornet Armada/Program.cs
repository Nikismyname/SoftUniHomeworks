﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4___Hornet_Armada
{
    //14:01 
    class Program
    {
        static void Main()
        {
            var legionWithSoldiers = new Dictionary<string, Dictionary<string, long>>();
            var legionWithActivity = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var parts = input.Split(new string[] { " -> " }, StringSplitOptions.None);
                var firstTwo = (parts[0].Split(new string[] { " = " }, StringSplitOptions.None));
                var secondTwo = (parts[1].Split(':'));

                int lastActivity = int.Parse(firstTwo[0]);
                string legion = firstTwo[1];
                string soldierType = secondTwo[0];
                int soldierCount = int.Parse(secondTwo[1]);

                if (!legionWithSoldiers.ContainsKey(legion))
                {
                    legionWithSoldiers[legion] = new Dictionary<string, long>();
                    legionWithActivity[legion] = lastActivity;
                }

                if (!legionWithSoldiers[legion].ContainsKey(soldierType))
                {
                    legionWithSoldiers[legion][soldierType] = 0;
                }
                legionWithSoldiers[legion][soldierType] += soldierCount;

                if (lastActivity > legionWithActivity[legion])
                {
                    legionWithActivity[legion] = lastActivity;
                }
            }

            string task = Console.ReadLine();
            if (task.Contains('\\'))
            {
                var tokens = task.Split('\\');
                int maxActivity = int.Parse(tokens[0]);
                var soldierType = tokens[1];

                var legionsWithLowerActivity = legionWithSoldiers
                    .Where(x => legionWithActivity[x.Key] < maxActivity)
                    .Where(x => x.Value.ContainsKey(soldierType))
                    .OrderByDescending(x => x.Value[soldierType])
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var item in legionsWithLowerActivity)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value[soldierType]}");
                }
            }
            else
            {
                string st = task;

                var sortedLegions = legionWithSoldiers
                    .Where(x => x.Value.ContainsKey(st))
                    .OrderByDescending(x => legionWithActivity[x.Key])
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var item in sortedLegions)
                {
                    Console.WriteLine($"{legionWithActivity[item.Key]} : {item.Key}");
                }
            }

            //Console.ReadLine();
        }
    }
}
