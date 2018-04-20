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
            // Declarations
            Random rand = new Random();
            List<Dungeon> rooms;
            List<Item> eq;

            // Set Up stuff
            SetUp.createRooms(out rooms);
            SetUp.showGameMenu();
            SetUp.createPlayerChar();

            Console.ReadKey();
        }
    }
}
