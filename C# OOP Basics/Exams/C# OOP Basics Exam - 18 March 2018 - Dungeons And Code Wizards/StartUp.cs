using DungeonsAndCodeWizards.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            var dungeonMaster = new DungeonMaster();

            while (dungeonMaster.IsGameOver() == false)
            {
                var input = Console.ReadLine();
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = tokens[0];

                if (command == "JoinParty")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.JoinParty(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "AddItemToPool")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.AddItemToPool(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "PickUpItem")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.PickUpItem(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "UseItem")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.UseItem(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (command == "UseItemOn")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.UseItemOn(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (command == "GiveCharacterItem")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.GiveCharacterItem(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (command == "GetStats")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.GetStats());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (command == "Attack")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.Attack(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }


                else if (command == "Heal")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.Heal(tokens.Skip(1).ToArray()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (command == "EndTurn")
                {
                    try
                    {
                        Console.WriteLine(dungeonMaster.EndTurn());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            Console.WriteLine($"Final stats:");
            try
            {
                Console.WriteLine(dungeonMaster.GetStats());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
	}
}