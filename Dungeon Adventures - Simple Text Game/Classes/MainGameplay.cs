using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class MainGameplay
    {
        public static void PlayCombat(Player player, Random rand)
        {
            Monster monster = new Monster(player.actualRoom.mobType);
            bool doesCombatLast = true;

            Combat.SetupCombat(player, monster);

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("New turn!\n");
                Console.ForegroundColor = ConsoleColor.White;

                if (player.Dexterity > monster.Dexterity)
                {
                    Console.WriteLine($"{player.Name} attacks first!");
                    player.TakeOneCombatTurn(monster, rand, player.actualRoom);

                    doesCombatLast = Combat.Resolve(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }

                    monster.Attack(player, rand);
                    doesCombatLast = Combat.Resolve(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }
                }
                else
                {
                    Console.WriteLine($"{monster.Id} attacks first!");
                    monster.Attack(player, rand);

                    doesCombatLast = Combat.Resolve(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }

                    player.TakeOneCombatTurn(monster, rand, player.actualRoom);

                    doesCombatLast = Combat.Resolve(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }
                }
                Console.ForegroundColor = ConsoleColor.White;

            } while (doesCombatLast == true);
        }

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
                Console.Write("\nCommand: ");
                string declaration = Console.ReadLine();

                switch(declaration.ToLower())
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

                        player.Move(rooms, declaration);
                        break;

                    // Player info declarations
                    case "coords":
                        PlayerCommand.ShowCoordinates(player);
                        break;
                    case "desc":
                        PlayerCommand.DescribeRoom(player.GetActualRoom(rooms));
                        break;
                    case "l":
                    case "look":
                        PlayerCommand.LookForDirections(rooms, player.GetActualRoom(rooms));
                        break;
                    case "stats":
                        PlayerCommand.ShowPlayerStatistics(player);
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
