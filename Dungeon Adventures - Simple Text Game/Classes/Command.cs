using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Command
    {
        public static void help()
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

            // Exit commmands
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exit - closing program");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + "You can use lowercases.");
            Console.ForegroundColor = ConsoleColor.White;
        }   // Show Help method

        public static void coords(Player player)
        {
            Console.WriteLine("\n" + "Your coordinates: {0},{1}" + "\n", player.x, player.y);
        }   // Show actual player coordinates
        
        public static void move(Player player, List<Dungeon> rooms, string dir)
        {
            switch(dir)
            {
                case "n":
                case "North":
                case "north":
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].x == player.x && rooms[i].y == player.y + 1)
                        {
                            player.y += 1;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "s":
                case "South":
                case "south":
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].x == player.x && rooms[i].y == player.y - 1)
                        {
                            player.y -= 1;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "w":
                case "West":
                case "west":
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].x == player.x - 1 && rooms[i].y == player.y)
                        {
                            player.x -= 1;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "e":
                case "East":
                case "east":
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].x == player.x + 1 && rooms[i].y == player.y)
                        {
                            player.x += 1;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                default:
                    break;
            }
        }   // Change room method

        public static void clear(Player player, Dungeon actPlayerRoom)
        {
            Console.Clear();
            Command.describe(actPlayerRoom);
            Gameplay.showUI(player);
        }   // Clear console method

        public static void describe(Dungeon room)
        {
            Console.WriteLine("\"{0}\"", room.description);
        }   // Show current room description

        public static void exit()
        {
            Environment.Exit(0);
        }   // Exit program method

        public static void look(List<Dungeon> rooms, Dungeon room)  // room = actPlayerRoom
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
        }   // Describe possible directions to move

        // Add Heal method

        // Add Show Eq method

        public static void showStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "Player statistics: ");
            Console.WriteLine("- Strength = {0}", player.strength);
            Console.WriteLine("- Dexterity = {0}", player.dexterity);
            Console.WriteLine("- Hp = {0}/{1}", player.Hp, player.maxHp);
            Console.WriteLine("- Mp = {0}/{1}", player.Mp, player.maxMp);
            Console.WriteLine("- Exp = {0}/{1}", player.exp, player.expToNext);
            Console.ForegroundColor = ConsoleColor.White;

        }   // Show Stats method

        public static void saveGame(Player player)
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
        }   // Save Game method    - CHECK IT

        public static void loadGame()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\SaveGame.txt";
        }   // Finish LoadGame method   - CHECK IT
    }
}
