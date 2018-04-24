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
        public string mobType;

        public bool isBattle;
        public bool visited;

        public Dungeon(int x, int y, string desc)
        {
            this.x = x;
            this.y = y;
            this.description = desc;
            this.isBattle = false;
            this.visited = false;
        }

        public Dungeon(int x, int y, string desc, string mobType)
        {
            this.x = x;
            this.y = y;

            this.description = desc;
            this.visited = false;

            this.isBattle = true;
            this.mobType = mobType;
        }
    }
}
