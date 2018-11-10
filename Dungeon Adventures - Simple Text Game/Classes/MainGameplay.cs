using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class MainGameplay
    {
        public static void ShowUI(Player player)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Name:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Name}");
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Lvl:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Lvl}");
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gold:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Gold}");
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("'help' - shows command list");
            Console.ForegroundColor = ConsoleColor.White; 
        }

        public static void GetPlayerDeclaration(Player player, List<Dungeon> rooms)
        {
            Console.WriteLine();
            bool isThereEvent = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nCommand: ");
                Console.ForegroundColor = ConsoleColor.White;

                string declairedCommand = Console.ReadLine();
                string optionalConditions = null;

                if(declairedCommand.Contains(" "))
                {
                    string[] split = declairedCommand.Split(new char[] { ' ' }, 2);
                    declairedCommand = split[0];
                    optionalConditions = split[1];
                }

                switch(declairedCommand.ToLower())
                {
                    case "h":
                    case "help":
                        PlayerCommand.ShowHelp();
                        break;

                    // Move declarations
                    case "n":
                    case "north":
                    case "s":
                    case "south":
                    case "w":
                    case "west":
                    case "e":
                    case "east":
                        isThereEvent = true;

                        player.Move(rooms, declairedCommand);
                        break;

                    // Info declarations
                    case "coords":
                        PlayerCommand.ShowCoordinates(player);
                        break;
                    case "desc":
                        PlayerCommand.DescribeRoom(player.GetActualRoom(rooms));
                        break;
                    case "look":
                        PlayerCommand.LookForDirections(rooms, player.GetActualRoom(rooms));
                        break;
                    case "stats":
                        PlayerCommand.ShowPlayerStatistics(player);
                        break;
                    case "eq":
                        PlayerCommand.ShowEquipment(player);
                        break;

                    // Action declarations (optionalCondidtions required)
                    case "drink":
                        bool potionDrunk = false;
                        foreach(Potion potion in player.Equipment)
                        {
                            if(potion.Name == optionalConditions)
                            {
                                potion.Use(player);
                                potionDrunk = true;
                                break;
                            }
                        }

                        if(potionDrunk == false)
                        {
                            Console.WriteLine("Wrong potion name!");
                        }
                        break;

                    // Game-self declarations
                    case "clear":
                        PlayerCommand.ClearConsole(player);
                        break;
                    case "exit":
                        PlayerCommand.ExitGame();
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }

            } while (!isThereEvent);
        }

    }
}
