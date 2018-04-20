using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class SetUp
    {
        // returns a list of Dungeon objects - actuall ingame rooms
        public static void createRooms(out List<Dungeon> rooms)
        {
            rooms = new List<Dungeon>();
            string roomDescription;

            // Room 0,0
            roomDescription = "Test description of first room";
            rooms.Add(new Dungeon(0, 0, roomDescription, false));

            // Room 0,1
            roomDescription = "Test description of second room";
            rooms.Add(new Dungeon(0, 1, roomDescription, false));
        }

        // draws and performs dialogue options in game menu
        public static void showGameMenu()
        {
            int actIndex = 0;
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
                    if (i == actIndex)
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
                    if (actIndex == 0)
                        actIndex = menuOptions.Length - 1;
                    else
                        actIndex--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (actIndex == menuOptions.Length - 1)
                        actIndex = 0;
                    else
                        actIndex++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    switch (actIndex)
                    {
                        case 0:
                            // NEW GAME
                            return;
                        case 1:
                            // LOAD GAME
                            Console.WriteLine("Work in progress...");

                            return;
                        case 2:
                            // SHOW CREDITS
                            Console.Clear();
                            Console.WriteLine("'Dungeon Adventures - Simple Text Game'");
                            Console.WriteLine("Original game designed by: Maksymilian Górski");
                            Console.WriteLine("Programmered by: Maksymilian Górski");
                            Console.WriteLine("Produced by: Maksymilian Górski");
                            Console.WriteLine("\nclick any key to back...");
                            Console.ReadKey();
                            break;
                        case 3:
                            // EXIT
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Error, array index not recognized...");
                            break;
                    }
                }

            }
        }

        // player character generator
        public static void createPlayerChar()
        {
            Console.Clear();

            Console.Write("What is your name, brave hero? ");
            string name = "";
            do
            {
                name = Console.ReadLine();
            } while (name == "");

            Console.WriteLine("\nGreat! And what is your occupation?");
            Console.WriteLine("[1] Warrior \n[2] Mage \n[3] Rogue ");
            Console.Write("Your choice: ");
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
            } while (occup == 1);

        }
    }
}
