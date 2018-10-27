using System;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Combat
    {
        public static void SetupCombat(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.Id} appears in front of {player.name} while passing to the next room!\nThe battle begins!");
        }

        public static bool Resolve(Player player, Monster monster, Random rand)
        {
            if(player.hp <= 0)
            {
                Setup.Gameover();
                return true;
            }

            if(monster.hp <= 0)
            {
                monster.Loot(player, rand);
                return true;
            }

            return false;
        }
    }
}
