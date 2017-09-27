using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    class Program
    {
        static void Main()
        {
            var dragons = new Dictionary<string, Dictionary<string, long[]>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var type = tokens[0];
                var name = tokens[1];

                long demage = 45;
                if (tokens[2] != "null")
                {
                    demage = long.Parse(tokens[2]);
                }
                long health = 250;
                if (tokens[3] != "null")
                {
                    health = long.Parse(tokens[3]);
                }
                long armor = 10;
                if (tokens[4] != "null")
                {
                    armor = long.Parse(tokens[4]);
                }

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new Dictionary<string, long[]>();
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new long[3];
                }

                dragons[type][name][0] = demage;
                dragons[type][name][1] = health;
                dragons[type][name][2] = armor;

            }

            foreach (var type in dragons)
            {
                var damage = ((double)type.Value.Sum(x => x.Value[0]) / type.Value.Count).ToString("0.00");
                var health = ((double)type.Value.Sum(x => x.Value[1]) / type.Value.Count).ToString("0.00");
                var armor = ((double)type.Value.Sum(x => x.Value[2]) / type.Value.Count).ToString("0.00");

                Console.WriteLine($"{type.Key}::({damage}/{health}/{armor})");

                foreach (var dragon in type.Value.OrderBy(x=>x.Key))
                {
                    var damageL = dragon.Value[0];
                    var healthL = dragon.Value[1];
                    var armorL = dragon.Value[2];
                    Console.WriteLine($"-{dragon.Key} -> damage: {damageL}, health: {healthL}, armor: {armorL}");
                }
            }
            //Console.ReadLine();
        }
    }
}
