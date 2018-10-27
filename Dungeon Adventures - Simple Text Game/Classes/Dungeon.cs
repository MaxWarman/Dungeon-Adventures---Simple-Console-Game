namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Dungeon
    {
        public int x;
        public int y;

        public string description;
        public string mobType;

        public bool isThereCombat;
        public bool visited;

        public Dungeon(int x, int y, string desc)
        {
            this.x = x;
            this.y = y;
            this.description = desc;
            this.isThereCombat = false;
            this.visited = false;
        }

        public Dungeon(int x, int y, string desc, string mobType)
        {
            this.x = x;
            this.y = y;

            this.description = desc;
            this.visited = false;

            this.isThereCombat = true;
            this.mobType = mobType;
        }
    }
}
