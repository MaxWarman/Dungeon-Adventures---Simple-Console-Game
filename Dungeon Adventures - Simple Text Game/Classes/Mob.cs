using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Player
    {
        // player info
        public string name;
        public string occup;

        // basic stats
        public int strength;
        public int dexterity;
        public int gold;

        // exp properties
        public int lvl;
        public int exp;
        public int expToNext;

        public List<Item> eq = new List<Item>();

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

        private int mp;
        public int maxMp;
        public int Mp
        {
            get { return mp; }
            set
            {
                if (value < 0) mp = 0;
                else if (value > maxMp) mp = maxMp;
                else mp = value;
            }
        }   // mp - Property

        public int x;
        public int y;

        public Player(string name, int occ)
        {
            this.name = name;

            this.x = 0;
            this.y = 0;

            this.gold = 0;
            this.lvl = 1;
            this.exp = 0;
            this.expToNext = 100;

            switch(occ)
            {
                case 1:     // warrior
                    this.strength = 15;
                    this.dexterity = 2;
                    this.hp = this.maxHp = 15;
                    this.mp = this.maxMp = 5;
                    this.occup = "Warrior";
                    break;
                case 2:     // mage
                    this.strength = 4;
                    this.dexterity = 5;
                    this.hp = this.maxHp = 10;
                    this.mp = this.maxMp = 20;
                    this.occup = "Mage";
                    break;
                case 3:     // rogue
                    this.strength = 9;
                    this.dexterity = 9;
                    this.hp = this.maxHp = 20;
                    this.mp = this.maxMp = 10;
                    this.occup = "Rogue";
                    break;
            }   // edditable occupation list

        }   // Constructor

        public Dungeon actRoom(List<Dungeon> rooms)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].x == this.x && rooms[i].y == this.y)
                {
                    return rooms[i];
                }
            }
            return null;
        }   // Return current players room object

        public void takeBattleTurn(Monster mob, Random rand, Dungeon actPlayerRoom)
        {
            if (this.Hp <= 0)
                Gameplay.gameover();

            Console.WriteLine("\nWhat do you do?");
            Console.WriteLine("1 - Fight; 2 - Cast a spell; 3 - Drink a potion; 4 - Try to escape");
            bool flag = true;
            do
            {
                string declaration = Console.ReadLine();
                switch(declaration)
                {
                    case "1":
                        this.fight(mob, rand, actPlayerRoom);
                        break;
                    case "2":
                        Console.WriteLine("Not ready yet. Work in progress...");
                        break;
                    case "3":
                        Console.WriteLine("Not ready yet. Work in progress...");
                        break;
                    case "4":
                        if(tryToEscape(rand))
                        {
                            Console.WriteLine("Escape successed!");
                            actPlayerRoom.isBattle = false;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Escape failed!");
                        }
                        break;
                    default:
                        flag = false;
                        break;

                }
            } while (!flag);
        }   // Make one turn in battle method

        public void fight(Monster mob, Random rand, Dungeon actPlayerRoom)
        {
            int dmg = rand.Next(this.strength - this.lvl, this.strength + this.lvl);    // amount of dmg dealt depands on proportional to strenght value - player's lvl

            Console.WriteLine();
            Console.WriteLine("{0} attacks {1} and deals {2} dmg!", this.name, mob.name, dmg);
            mob.Hp -= dmg;
            Console.WriteLine("{0} has {1} hp left!", mob.name, mob.Hp);
            if (mob.Hp <= 0)
            {
                mob.kill(this, rand);
                actPlayerRoom.isBattle = false;
                return;
            }

        }   // Fight mob method

        public bool tryToEscape(Random rand)
        {
            int num = rand.Next(1, 10);
            if (num <= this.dexterity)
            {
                return true;
            }
            return false;
        }   // Run method

        public void lvlUp(int num)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Level up!\n");
            Console.ForegroundColor = ConsoleColor.White;

            this.lvl++;
            this.exp = this.exp + num;
            this.exp -= expToNext;
            this.expToNext += 25;
            
            if(this.exp >= this.expToNext)
            {
                num = this.exp - this.expToNext;
                this.exp -= num;
                this.lvlUp(num);
            }
        }   // Lvl Up method - ADD SKILL INCREASE OF SKILLS AFTER LVL UP

    }

    class Monster
    {
        public string name;
        public int strength;
        public int dexterity;
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

        public Monster(string mobType)
        {
            switch(mobType)
            {
                case "skt1":        // skeleton type 1
                    this.name = "Skeleton";
                    this.strength = 2;
                    this.dexterity = 3;
                    this.hp = 7;
                    break;
                default:                    
                    break;            
            }
        }   // Constructor

        public void fight(Player player, Random rand)
        {
            int dmg = rand.Next(this.strength - 1, this.strength + 2);

            Console.WriteLine();
            Console.WriteLine("{0} attacks {1} and deals {2} dmg!", this.name, player.name, dmg);
            player.Hp -= dmg;
            Console.WriteLine("{0} has {1} hp left.", player.name, player.Hp);
        }   // Fight a player method

        public void kill(Player player, Random rand)
        {
            int num = rand.Next(1, 5);
            Console.WriteLine("\n{0} loots {1} gold coins!", player.name, num);

            num = rand.Next(1, 5);
            if(num == 1)
            {
                Console.WriteLine("{0} loots Health Potion!", player.name);
                player.eq.Add(new Item("Hp potion"));
            }

            num = rand.Next(70, 120);
            Console.WriteLine("{0} gain {1} expirience points!\n", player.name, num);
            if(num + player.exp >= player.expToNext)
            {
                player.lvlUp(num);
            }
            else
            {
                player.exp += num;
            }
        }   // Kill and loot a monster method
    }
}
