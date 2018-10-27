using System;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Monster: Coordinates
    {
        public string Id { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }

        private int _hp;
        public int Hp
        {
            get { return _hp; }
            set
            {
                if (value < 0) { _hp = 0; }
                else if (value > 0) { _hp = MaxHp; }
                else _hp = value;
            }
        }
        public int MaxHp { get; set; }


        // Constructor
        public Monster(string mobType)
        {
            switch (mobType)
            {
                case "skt1":
                    this.Id = "Skeleton";
                    this.Strength = 2;
                    this.Dexterity = 3;
                    this._hp = this.MaxHp = 7;
                    break;
                default:
                    break;
            }
        }

        // Methods
        public void Attack(Player player, Random rand)
        {
            int dmg = rand.Next(this.Strength - 1, this.Strength + 2);

            Console.WriteLine();
            Console.WriteLine("{0} attacks {1} and deals {2} dmg!", this.Id, player.name, dmg);
            player.hp -= dmg;
            Console.WriteLine("{0} has {1} hp left.", player.name, player.hp);
        }

        public void Loot(Player player, Random rand)
        {
            int num = rand.Next(1, 5);
            Console.WriteLine("\n{0} loots {1} gold coins!", player.name, num);

            num = rand.Next(1, 5);
            if (num == 1)
            {
                Console.WriteLine("{0} loots Health Potion!", player.name);
                player.eq.Add(new Item("Hp potion"));
            }

            int expGained = rand.Next(70, 120);
            Console.WriteLine("{0} gain {1} expirience points!\n", player.name, num);
            if (num + player.exp >= player.expToNextLvl)
            {
                player.LvlUp(expGained);
            }
            else
            {
                player.exp += expGained;
            }
        }
    }
}
