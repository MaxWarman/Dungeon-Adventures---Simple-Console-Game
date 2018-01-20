﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Command
    {
        public static void Help()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAvaliable commands:\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("North - go north");
            Console.WriteLine("South - go south");
            Console.WriteLine("West - go west");
            Console.WriteLine("East - go east");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Coords - shows player coordinates");
            Console.WriteLine("Describe - describes actuall room");
            Console.WriteLine("Look - shows available directions");
            Console.WriteLine("Heal - heals 10 hp if player has Health Potion in equipment");
            Console.WriteLine("Eq - shows players equipment");
            Console.WriteLine("Stats - shows players statistics");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exit - closing program");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + "You can use lowercases.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Coords(Player player)
        {
            Console.WriteLine("\n" + "Your coordinates: {0}; {1}" + "\n", player.x, player.y);
        }
        
        // Add Move method

        public static void Describe(Dungeon room)
        {
            Console.WriteLine("\"{0}\"", room.description);
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void Look(List<Dungeon> rooms, Dungeon room)
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

        // Add Heal method

        // Add Show Eq method

        public static void ShowStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "Player statistics: ");
            Console.WriteLine("- Strength = {0}", player.strength);
            Console.WriteLine("- Hp = {0}/{1}", player.Hp, player.maxHp);
            Console.WriteLine("- Exp = {0}/{1}", player.exp, player.expToNext);
            Console.ForegroundColor = ConsoleColor.White;

        }   // Show Stats method

        public static void SaveGame(Player player)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\SaveGame.txt";

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            File.WriteAllText(filePath, string.Empty);

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                string saveInfo = player.name + "|" + player.x.ToString() + "|" + player.y.ToString() + "|" + player.lvl.ToString()
                    + "|" + player.exp.ToString() + "|" + player.expToNext.ToString() + "|" + player.Hp.ToString() + "|" + player.maxHp.ToString()
                    + "|" + player.strength.ToString() + "|" + player.gold.ToString();

                sw.WriteLine(String.Format(saveInfo));
                sw.WriteLine("\n" + "Format of save:" + "\n" + "players name|x|y|lvl|exp|expToNext|hp|maxHp|strength|gold");
            }

            /*
             * Format of save:
             * players name|x|y|lvl|exp|expToNext|hp|maxHp|strength|gold
            */

            Console.WriteLine("Game saved succesfully...");
        }   // Save Game method

        // Finish LoadGame method
        public static void LoadGame()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\SaveGame.txt";
        }
    }
}
