using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Setup
    {
        public static Player CreatePlayerCharacter()
        {
            Console.Clear();

            Console.WriteLine("What is your name, brave hero?");
            string name = "";
            do
            {
                name = Console.ReadLine();
            } while (name == "");

            Console.WriteLine("\nGreat! And what is your occupation?");
            Console.WriteLine("[1] Warrior \n[2] Mage \n[3] Rogue ");
            Console.Write("Click to choose...");
            int occup = 0;
            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        occup = 1;
                        break;
                    case ConsoleKey.D2:
                        occup = 2;
                        break;
                    case ConsoleKey.D3:
                        occup = 3;
                        break;
                    default:
                        occup = 0;
                        break;
                }
            } while (occup == 0);
            Player pl = new Player(name, occup);
            return pl;
        }

        public static void CreateDungeonRooms(out List<Dungeon> rooms)
        {
            rooms = new List<Dungeon>();
            string roomDescription;

            // Room 0,0
            roomDescription = "This is the first room. Test combat in the northern room.";
            rooms.Add(new Dungeon(0, 0, roomDescription));

            // Room 0,1
            roomDescription = "This is second room. Here was battle.";
            rooms.Add(new Dungeon(0, 1, roomDescription, "skt1"));

            // Room 0,2
            roomDescription = "Room 0,2, here was battle";
            rooms.Add(new Dungeon(0, 2, roomDescription, "skt1"));

            // Room 1,0
            roomDescription = "First room on right. Shall be treasure room in the future.";
            rooms.Add(new Dungeon(1, 0, roomDescription));

            // Room 1,2
            roomDescription = "Left-top corner room. Here was battle.";
            rooms.Add(new Dungeon(1, 2, roomDescription, "skt1"));

            // Room -1,2
            roomDescription = "Right-top corner room";
            rooms.Add(new Dungeon(-1, 2, roomDescription));

        }

        public static void ShowGameMainMenu()
        {
            int actualIndex = 0;
            while (true)
            {
                Console.Clear();
                string[] menuOptions = new string[4];
                menuOptions[0] = "---    New Game     ---";
                menuOptions[1] = "---    Load Game    ---";
                menuOptions[2] = "---    Credits      ---";
                menuOptions[3] = "---    Exit         ---";

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Dungeon Adventures - The Text Game");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == actualIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuOptions[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (actualIndex == 0)
                    { actualIndex = menuOptions.Length - 1; }
                    else
                    { actualIndex--; }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (actualIndex == menuOptions.Length - 1)
                    { actualIndex = 0; }
                    else
                    { actualIndex++; }
                }
                else if (key == ConsoleKey.Enter)
                {
                    switch (actualIndex)
                    {
                        case 0:
                            // New game
                            return;
                        case 1:
                            // Load game
                            Console.WriteLine("Work in progress...");

                            return;
                        case 2:
                            // Credits
                            Console.Clear();
                            Console.WriteLine("Title: 'Dungeon Adventures - The Console Game'");
                            Console.WriteLine("Original game designed by: MaxWarman");
                            Console.WriteLine("Programmered by: MaxWarman");
                            Console.WriteLine("Produced by: MaxWarman");
                            Console.WriteLine("Music by: it's a console game... (duh)");
                            Console.WriteLine("\nclick any key to go back...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Error, array index not recognized...");
                            break;
                    }
                }

            }
        }

        public static void Gameover()
        {
            Console.WriteLine("You died.");
            Console.ReadKey();
        }
    }
}
