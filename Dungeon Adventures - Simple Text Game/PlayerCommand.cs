using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class PlayerCommand
    {
        public static void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAvaliable commands:\n");

            // Move commands
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("North - go north");
            Console.WriteLine("South - go south");
            Console.WriteLine("West - go west");
            Console.WriteLine("East - go east");

            // General commands
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Coords - shows player coordinates");
            Console.WriteLine("Desc - describes actual room");
            Console.WriteLine("Look - shows available directions");
            Console.WriteLine("Drink [potion name] - drinks potion and performs it's effects");
            Console.WriteLine("Eq - shows players equipment");
            Console.WriteLine("Stats - shows players statistics");
            Console.WriteLine("Clear - clears console window");

            // Game-self commands
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exit - closing program");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + "You can use lowercases.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowCoordinates(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + $"Your coordinates: {player.X},{player.Y}" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DrinkPotion(Player player, string additionalCommand)
        {
            bool drunk = false;
            foreach (Potion potion in player.Equipment)
            {
                if (potion.Name == additionalCommand)
                {
                    potion.Drink(player);
                    drunk = true;
                    break;
                }
            }
            if (drunk == false)
            {
                Console.WriteLine("Wrong potion name!");
            }
        }

        public static void DescribeRoom(Dungeon room)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Room description: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\"{0}\"", room.Description);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LookForDirections(List<Dungeon> rooms, Dungeon room)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAvailable directions:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].X == room.X && rooms[i].Y == room.Y + 1)
                {
                    Console.WriteLine("North");
                    continue;
                }
                if (rooms[i].X == room.X && rooms[i].Y == room.Y - 1)
                {
                    Console.WriteLine("South");
                    continue;
                }
                if (rooms[i].X == room.X - 1 && rooms[i].Y == room.Y)
                {
                    Console.WriteLine("West");
                    continue;
                }
                if (rooms[i].X == room.X + 1 && rooms[i].Y == room.Y)
                {
                    Console.WriteLine("East");
                    continue;
                }
            }
        }

        public static void ShowEquipment(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYour equipment: ");
            Console.ForegroundColor = ConsoleColor.White;
            if (player.Equipment.Count == 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach(Item item in player.Equipment)
                {
                    Console.WriteLine($" - {item.Name}");
                }
            }
        }

        public static void ShowPlayerStatistics(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "Player statistics: ");
            Console.WriteLine($"- Strength = {player.Strength}");
            Console.WriteLine($"- Dexterity = {player.Dexterity}");
            //Commented since displayed in UI
            //Console.WriteLine($"- Hp = {player.Hp}/{player.MaxHp}");
            //Console.WriteLine($"- Mp = {player.Mp}/{player.MaxMp}");
            Console.WriteLine($"- Exp = {player.Exp}/{player.ExpToNextLvl}");
            Console.WriteLine($"- Exp total = {player.ExpTotal}");
            Console.ForegroundColor = ConsoleColor.White;

        } 

        public static void ClearConsole(Player player)
        {
            Console.Clear();
            PlayerCommand.DescribeRoom(player.actualRoom);
            MainGameplay.ShowUI(player);
        }

        public static void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
