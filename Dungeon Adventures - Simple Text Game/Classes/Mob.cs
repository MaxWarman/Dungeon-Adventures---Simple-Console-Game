using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Player
    {
        public string name;

        public int strength;
        public int dexterity;
        public int gold;

        public int lvl;
        public int exp;
        public int expToNext;

        private int hp;
        public int maxHp;

        public int Hp
        {
            get { return hp; }
            set
            {
                if (value < 0) hp = 0;
                else if (value > maxHp) hp = maxHp;
                else hp = value;
            }
        }   // hp - Property

        public int x;
        public int y;


        public Player(string name)
        {
            this.name = name;

            this.strength = 10;
            this.hp = this.maxHp = 15;
            this.dexterity = 4;

            this.gold = 0;
            this.lvl = 1;
            this.exp = 0;
            this.expToNext = 100;

            this.x = 0;
            this.y = 0;
        }   // Constructor



        public void fight(Monster mob, int dmg)
        {
            Console.WriteLine();
            Console.WriteLine("{0} attacks {1}!", this.name, mob.name);
            Console.WriteLine("Deals {0} damage!", dmg);
            mob.Hp -= dmg;
            Console.WriteLine("{0} has {1} hp left.", mob.name, mob.Hp);
        }   // Fight method

        public bool tryToRun(int rand)
        {
            if (rand <= dexterity)
            {
                Console.WriteLine("Escape succesed!");
                return true;
            }
            return false;
        }   // Run method

    }

    class Monster
    {
        public string name;
        public int strength;
        private int hp;

        public int Hp
        {
            get { return hp; }
            set
            {
                if (value < 0) hp = 0;
                else hp = value;
            }
        }   // hp - Property

        public Monster(string name)
        {
            switch(name)
            {
                case "Skeleton":
                    this.name = name;
                    this.strength = 5;
                    this.hp = 10;
                    break;                
            }
        }   // Constructor

        public void fight(Player mob, int dmg)
        {
            Console.WriteLine();
            Console.WriteLine("{0} attacks {1}!", this.name, mob.name);
            Console.WriteLine("Deals {0} damage!", dmg);
            mob.Hp -= dmg;
            Console.WriteLine("{0} has {1} hp left.", mob.name, mob.Hp);
        }   // Fight method
    }
}
