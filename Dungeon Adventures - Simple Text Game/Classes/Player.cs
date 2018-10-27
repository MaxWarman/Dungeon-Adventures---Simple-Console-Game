using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Player: Coordinates
    {
        // Player info
        private string _name;
        public string name
        { get { return _name; } set { _name = value; } }
        private string _occupation;
        public string occupation
        { get { return _occupation; } set { _occupation = value; } }


        // Basic stats
        private int _strength;
        public int strength
        { get { return _strength; } set { _strength = value; } }
        private int _dexterity;
        public int dexterity
        { get { return _dexterity; } set { _dexterity = value; } }
        private int _gold = 0;
        public int gold
        { get { return _gold; } set { _gold = value; } }

        // Expirience properties
        private int _lvl;
        public int lvl
        { get { return _lvl; } set { _lvl = value; } }
        private int _exp;
        public int exp
        { get { return _exp; } set { _exp = value; } }
        private int _expToNextLvl;
        public int expToNextLvl
        { get { return _expToNextLvl; } set { _expToNextLvl = value; } }

        // Variable statistics
        private int _hp;
        public int hp
        {
            get { return hp; }
            set
            {
                if (value < 0) { hp = 0; }
                else if (value > maxHp) { hp = maxHp; }
                else { hp = value; }
            }
        }
        private int _maxHp;
        public int maxHp
        { get { return _maxHp; } set { _maxHp = value; } }

        private int _mp;
        public int mp
        {
            get { return _mp; }
            set
            {
                if (value < 0) _mp = 0;
                else if (value > maxMp) _mp = maxMp;
                else _mp = value;
            }
        }
        private int _maxMp;
        public int maxMp
        { get { return _maxMp; } set { _maxMp = value; } }

        public Dungeon actualRoom;
        public List<Item> eq = new List<Item>();

        // Constructor
        public Player(string name, int occupation)
        {
            this._name = name;

            this.x = 0;
            this.y = 0;

            this._gold = 0;
            this._lvl = 1;
            this._exp = 0;
            this._expToNextLvl = 100;

            switch(occupation)
            {
                case 1:
                    this._strength = 15;
                    this._dexterity = 3;
                    this._hp = this._maxHp = 15;
                    this._mp = this._maxMp = 5;
                    this._occupation = "Warrior";
                    break;
                case 2:
                    this._strength = 4;
                    this._dexterity = 5;
                    this._hp = this._maxHp = 10;
                    this._mp = this._maxMp = 20;
                    this._occupation = "Mage";
                    break;
                case 3:
                    this._strength = 9;
                    this._dexterity = 9;
                    this._hp = this.maxHp = 20;
                    this._mp = this.maxMp = 10;
                    this._occupation = "Rogue";
                    break;
            } 

        }

        // Methods
        public Dungeon GetActualRoom(List<Dungeon> rooms)
        {
            foreach (Dungeon room in rooms)
            {
                if (room.x == this.x && room.y == this.y)
                {
                    return room;
                }
            }
            return null;
        }

        public void TakeOneCombatTurn(Monster mob, Random rand, Dungeon actPlayerRoom)
        {
            Console.WriteLine("\nWhat do you do?");
            Console.WriteLine("1 - Fight; 2 - Cast a spell; 3 - Drink a potion; 4 - Try to escape");
            bool flag = true;
            do
            {
                string declaration = Console.ReadLine();
                switch(declaration)
                {
                    case "1":
                        this.Attack(mob, rand, actPlayerRoom);
                        break;
                    case "2":
                        Console.WriteLine("Not added yet...");
                        break;
                    case "3":
                        Console.WriteLine("Not added yet...");
                        break;
                    case "4":
                        this.Escape(rand);
                        break;
                    default:
                        flag = false;
                        break;

                }
            } while (flag == false);
        }

        public void Move( List<Dungeon> rooms, string direction)
        {
            switch (direction.ToLower())
            {
                case "n":
                case "north":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.x == this.x && room.y == this.y + 1)
                        {
                            this.y++;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "s":
                case "south":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.x == this.x && room.y == this.y - 1)
                        {
                            this.y--;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "w":
                case "west":
                    foreach(Dungeon room in rooms)
                    {
                        if (room.x == this.x - 1 && room.y == this.y)
                        {
                            this.x--;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "e":
                case "east":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.x == this.x + 1 && room.y == this.y)
                        {
                            this.x++; ;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                default:
                    break;
            }
        }

        public void Attack(Monster mob, Random rand, Dungeon actPlayerRoom)
        {
            // Amount of dmg dealt depands on proportional to strenght value - player's lvl
            int damage = rand.Next(this.strength - this.lvl, this.strength + this.lvl);

            Console.WriteLine();
            Console.WriteLine($"{this.name} attacks {mob.Id} and deals {damage} dmg!");
            mob.hp -= damage;
            Console.WriteLine($"{mob.Id} has {mob.hp} hp left!", mob.Id, mob.hp);
        }

        public void Escape(Random rand)
        {
            int num = rand.Next(1, 10);
            if (num <= this.dexterity)
            {
                Console.WriteLine("Escape successed!");
                this.actualRoom.isThereCombat = false;
                return;
            }
            else
            {
                Console.WriteLine("Escape failed!");
            }
        }

        public void LvlUp(int expGained)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Level up!\n");
            Console.ForegroundColor = ConsoleColor.White;

            this.lvl++;
            this.exp = this.exp + expGained;
            this.exp -= expToNextLvl;
            this.expToNextLvl += 25;
            
            if(this.exp >= this.expToNextLvl)
            {
                expGained = this.exp - this.expToNextLvl;
                this.exp -= expGained;
                this.LvlUp(expGained);
            }
        }

    }
}
