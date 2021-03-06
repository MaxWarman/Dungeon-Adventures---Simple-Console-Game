﻿using System;
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Lvl:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Lvl}");
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gold:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Gold}");
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hp:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Hp}/{player.MaxHp}");
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Mp:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {player.Mp}/{player.MaxMp}");
            Console.Write("     ");

            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("'help' - shows command list\n");
            Console.ForegroundColor = ConsoleColor.White; 
        }

        public static void GetPlayerDeclaration(Player player, List<Dungeon> rooms, Random rand)
        {
            Console.WriteLine();
            bool repeat = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nCommand: ");
                Console.ForegroundColor = ConsoleColor.White;

                string mainCommand = Console.ReadLine();
                string additionalCommand = null;
                int numOfOperations = 1;

                if(mainCommand.Contains(" "))
                {
                    int numOfSpaces = 0;
                    foreach(char ch in mainCommand)
                    {
                        if(ch == ' ')
                        {
                            numOfSpaces++;
                        }
                    }

                    string[] split = mainCommand.Split(new char[] { ' ' }, numOfSpaces + 1);
                    mainCommand = split[0];

                    int isNumber = 0;
                    if (int.TryParse(split[1], out int n) == true)
                    {
                        isNumber++;
                        numOfOperations = n;
                        if(numOfOperations < 0)
                        {
                            numOfOperations = 0;
                        }
                    }

                    for (int i = 1; i < numOfSpaces - isNumber + 1; i++)
                    {
                        additionalCommand += split[i + isNumber];
                        if (i != numOfSpaces - isNumber) // nOS - iN + 1 - 1
                        {
                            additionalCommand += " ";
                        }

                    }
                }

                switch(mainCommand.ToLower())
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
                        

                        repeat = player.Move(rooms, mainCommand, rand);
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

                    // Action declarations (additionalCommand required)
                    case "drink":
                        PlayerCommand.DrinkPotion(player, additionalCommand, numOfOperations);
                        break;

                    // Game-self declarations
                    case "clear":
                        PlayerCommand.ClearConsole(player);
                        break;
                    case "exit":
                        PlayerCommand.ExitGame();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unknown command!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

            } while (repeat == true);
        }

    }
}
