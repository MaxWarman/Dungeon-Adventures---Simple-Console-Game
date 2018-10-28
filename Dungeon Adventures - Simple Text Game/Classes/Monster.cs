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
                else if (value > MaxHp) { _hp = MaxHp; }
                else { _hp = value; }
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
            int damage = rand.Next(this.Strength - 1, this.Strength + 2);

            Console.WriteLine($"\n{this.Id} attacks {player.Name} and deals {damage} damage!");
            player.Hp -= damage;
            Console.WriteLine($"{player.Name} has {player.Hp} hp left.");
        }

        public void Loot(Player player, Random rand)
        {
            int num = rand.Next(1, 5);
            Console.WriteLine($"\n{player.Name} loots {num} gold coins!");

            num = rand.Next(1, 5);
            if (num == 1)
            {
                Console.WriteLine($"{player.Name} loots Health Potion!", player.Name);
                player.eq.Add(new Item("Hp potion"));
            }

            int expGained = rand.Next(70, 120);
            Console.WriteLine($"{player.Name} gain {expGained} expirience points!\n");
            player.ExpTotal += expGained;
            if (expGained + player.Exp >= player.ExpToNextLvl)
            {
                player.LvlUp(expGained);
            }
            else
            {
                player.Exp += expGained;
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
