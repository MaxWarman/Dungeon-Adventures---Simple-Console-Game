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
    }
}
