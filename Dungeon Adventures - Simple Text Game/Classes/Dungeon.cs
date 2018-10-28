using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Dungeon: Coordinates
    {

        public string description;
        public string mobType;

        public bool isThereCombat;
        public bool visited;

        public Dungeon(int x, int y, string desc)
        {
            this.X = x;
            this.Y = y;
            this.description = desc;
            this.isThereCombat = false;
            this.visited = false;
        }

        public Dungeon(int x, int y, string desc, string mobType)
        {
            this.X = x;
            this.Y = y;

            this.description = desc;
            this.visited = false;

            this.isThereCombat = true;
            this.mobType = mobType;
        }

        public static void UpdateRoom(Player player, List<Dungeon> rooms)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(rooms[i].X == player.X && rooms[i].Y == player.Y)
                {
                    rooms[i] = player.actualRoom;
                    break;
                }
            }
        }
    }
}
