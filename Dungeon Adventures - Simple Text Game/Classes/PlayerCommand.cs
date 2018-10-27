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
            Console.WriteLine("\n" + "Your coordinates: {0},{1}" + "\n", player.x, player.y);
        } 

        public static void ClearConsole(Player player, Dungeon actPlayerRoom)
        {
            Console.Clear();
            PlayerCommand.DescribeRoom(actPlayerRoom);
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
                if (rooms[i].x == room.x && rooms[i].y == room.y + 1)
                {
                    Console.WriteLine("North");
                    continue;
                }
                if (rooms[i].x == room.x && rooms[i].y == room.y - 1)
                {
                    Console.WriteLine("South");
                    continue;
                }
                if (rooms[i].x == room.x - 1 && rooms[i].y == room.y)
                {
                    Console.WriteLine("West");
                    continue;
                }
                if (rooms[i].x == room.x + 1 && rooms[i].y == room.y)
                {
                    Console.WriteLine("East");
                    continue;
                }
            }
        }

        public static void ShowPlayerStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "Player statistics: ");
            Console.WriteLine("- Strength = {0}", player.strength);
            Console.WriteLine("- Dexterity = {0}", player.dexterity);
            Console.WriteLine("- Hp = {0}/{1}", player.hp, player.maxHp);
            Console.WriteLine("- Mp = {0}/{1}", player.mp, player.maxMp);
            Console.WriteLine("- Exp = {0}/{1}", player.exp, player.expToNextLvl);
            Console.ForegroundColor = ConsoleColor.White;

        } 
    }
}
