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
            List<Dungeon> rooms = new List<Dungeon>();
            rooms = createRooms(ref rooms);

            // Creating players equipment
            List<Item> eq = new List<Item>();

            // Game Menu

            //showGameMenu();
            Console.WriteLine("Dungeon Adventures - The Text Game");
            //int znak = Console.ReadKey().KeyChar;
            //if (znak == Convert.ToInt32(ConsoleKey.UpArrow))
            


            Console.ReadKey();
        }

        static List<Dungeon> createRooms(ref List<Dungeon> rooms)
        {
            string roomDescription;

            // Room 0,0
            roomDescription = "Test description of first room";
            rooms.Add(new Dungeon(0, 0, roomDescription, false));

            // Room 0,1
            roomDescription = "Test description of second room";
            rooms.Add(new Dungeon(0, 1, roomDescription, false));

            return rooms;
        }
        static void showGameMenu()
        {
            do
            {
                int actIndex = 0;
                string[] menuOptions = new string[4];
                menuOptions[0] = "---    1. New Game     ---";
                menuOptions[1] = "---    2. Load Game    ---";
                menuOptions[2] = "---    3. Credits      ---";
                menuOptions[3] = "---    4. Exit         ---";

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i != actIndex)
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

                int character = int.Parse(Console.ReadKey().ToString());


            } while (true);
        }
    }
}
