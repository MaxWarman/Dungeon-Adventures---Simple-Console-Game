﻿using System;
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
        /*
         * OGARNĄĆ PRZESYŁANIE OBIEKTÓW MIĘDZY KLASAMI 
         */
        static void Main(string[] args)
        {
            // Declarations
            Random rand = new Random();
            List<Dungeon> rooms;

            // Set Up stuff
            Gameplay.createRooms(out rooms);
            Gameplay.showGameMenu();
            Player player = Gameplay.createPlayerChar();

            Gameplay.gameplay(rooms, player, rand);

            Console.ReadKey();
        }
    }
}
