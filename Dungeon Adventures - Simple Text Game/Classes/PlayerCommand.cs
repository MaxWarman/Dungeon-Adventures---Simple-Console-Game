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
            Console.WriteLine("Desc - describes actuall room");
            Console.WriteLine("Look - shows available directions");
            Console.WriteLine("Heal - heals 10 hp if player has Health Potion in equipment");
            Console.WriteLine("Eq - shows players equipment");
            Console.WriteLine("Stats - shows players statistics");

            // Game-self commands
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Clear - clears console window");
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

        public static void ClearConsole(Player player)
        {
            Console.Clear();
            PlayerCommand.DescribeRoom(player.actualRoom);
            MainGameplay.ShowUI(player);
        }

        public static void DescribeRoom(Dungeon room)
        {
            Console.WriteLine("Room description: ");
            Console.WriteLine("\"{0}\"", room.description);
        }

        public static void ExitGame()
        {
            Environment.Exit(0);
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

        public static void ShowPlayerStatistics(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "Player statistics: ");
            Console.WriteLine($"- Strength = {player.Strength}");
            Console.WriteLine($"- Dexterity = {player.Dexterity}");
            Console.WriteLine($"- Hp = {player.Hp}/{player.MaxHp}");
            Console.WriteLine($"- Mp = {player.Mp}/{player.MaxMp}");
            Console.WriteLine($"- Exp = {player.Exp}/{player.ExpToNextLvl}");
            Console.WriteLine($"- Exp total = {player.ExpTotal}");
            Console.ForegroundColor = ConsoleColor.White;

        } 
    }
}
