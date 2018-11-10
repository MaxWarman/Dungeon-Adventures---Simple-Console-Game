using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Dungeon: Coordinates
    {
        public string Description { get; set; }
        public string MobTypeInside { get; set; }

        public bool IsThereCombat { get; set; }
        public bool WasVisited { get; set; }

        public Dungeon(int x, int y, string desc)
        {
            this.X = x;
            this.Y = y;
            this.Description = desc;
            this.IsThereCombat = false;
            this.WasVisited = false;
        }

        public Dungeon(int x, int y, string desc, string mobType)
        {
            this.X = x;
            this.Y = y;

            this.Description = desc;
            this.WasVisited = false;

            this.IsThereCombat = true;
            this.MobTypeInside = mobType;
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
