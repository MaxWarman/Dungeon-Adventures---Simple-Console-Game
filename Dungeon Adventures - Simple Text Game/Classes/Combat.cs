using System;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Combat
    {
        public static void ArrangeCombat(Player player, Random rand)
        {
            Monster monster = new Monster(player.actualRoom.MobTypeInside);
            bool doesCombatLast = true;
            bool doesPlayerAttackFirst = false;

            SetupCombat(player, monster);

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNew turn!\n");
                Console.ForegroundColor = ConsoleColor.White;
                if(player.Dexterity > monster.Dexterity)
                {
                    doesPlayerAttackFirst = true;
                }

                if (doesPlayerAttackFirst)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{player.Name} attacks first!");
                    Console.ForegroundColor = ConsoleColor.White;

                    player.TakeOneCombatTurn(monster, rand, player.actualRoom);

                    doesCombatLast = ResolveCombat(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }

                    monster.Attack(player, rand);
                    doesCombatLast = ResolveCombat(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monster.Type} attacks first!");
                    Console.ForegroundColor = ConsoleColor.White;

                    monster.Attack(player, rand);

                    doesCombatLast = Combat.ResolveCombat(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }

                    player.TakeOneCombatTurn(monster, rand, player.actualRoom);

                    doesCombatLast = Combat.ResolveCombat(player, monster, rand);
                    if (doesCombatLast == false)
                    { break; }
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nPress any key...");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ReadKey();
            } while (doesCombatLast == true);
        }

        public static void SetupCombat(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.Type} appears in front of {player.Name} while passing to the next room!\nThe battle begins!");
        }

        public static bool ResolveCombat(Player player, Monster monster, Random rand)
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
