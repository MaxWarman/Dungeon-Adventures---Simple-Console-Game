using System;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Combat
    {
        public static void SetupCombat(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.Id} appears in front of {player.Name} while passing to the next room!\nThe battle begins!\n");
        }

        public static bool Resolve(Player player, Monster monster, Random rand)
        {
            if(player.Hp <= 0)
            {
                Setup.Gameover();
                return false;
            }

            if(monster.Hp <= 0)
            {
                monster.Loot(player, rand);
                return false;
            }

            return true;
        }
    }
}
