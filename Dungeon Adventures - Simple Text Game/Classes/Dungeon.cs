using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Dungeon
    {
        public int x;
        public int y;
        public string description;
        public bool isThereBattle;

        public Dungeon(int x, int y, string desc)
        {
            this.x = x;
            this.y = y;
            this.description = desc;
        }
    }
}
