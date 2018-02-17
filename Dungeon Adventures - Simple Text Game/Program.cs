using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventures___Simple_Text_Game.Classes;
using System.IO;

namespace Dungeon_Adventures___Simple_Text_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating rooms
            Random rand = new Random();
            List<Dungeon> rooms;
            createRooms(out rooms);

            // Creating players equipment
            List<Item> eq = new List<Item>();



            // Game Menu
            showGameMenu();


            Console.ReadKey();
        }

        // returns a list of Dungeon objects - actuall ingame rooms
        static void createRooms(out List<Dungeon> rooms)
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
        static void showGameMenu()
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

                if(key == ConsoleKey.UpArrow)
                {
                    if (actIndex == 0)
                        actIndex = menuOptions.Length - 1;
                    else
                        actIndex--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (actIndex == menuOptions.Length-1)
                        actIndex = 0;
                    else
                        actIndex++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    switch(actIndex)
                    {
                        case 0:
                            // NEW GAME
                            return;
                        case 1:
                            // LOAD GAME
                            Console.WriteLine("Work in progress...");
                            return;
                            break;
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
    }
}
