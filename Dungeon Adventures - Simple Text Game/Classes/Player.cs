using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Player : Coordinates
    {
        // Player info
        public string Name { get; set; }
        public string Occupation { get; set; }

        // Basic stats
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Gold { get; set; } = 0;


        // Expirience properties

        public int Lvl { get; set; }
        public int Exp { get; set; }
        public int ExpTotal { get; set; }
        public int ExpToNextLvl { get; set; }

        // Often variable statistics
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

        private int _mp;
        public int Mp
        {
            get { return _mp; }
            set
            {
                if (value < 0) _mp = 0;
                else if (value > MaxMp) _mp = MaxMp;
                else _mp = value;
            }
        }
        public int MaxMp { get; set; }

        public Dungeon actualRoom;
        public List<Item> eq = new List<Item>();

        // Constructor
        public Player(string name, int occupation)
        {
            this.Name = name;

            this.X = 0;
            this.Y = 0;

            this.Gold = 0;
            this.Lvl = 1;
            this.Exp = this.ExpTotal = 0;
            this.ExpToNextLvl = 100;

            switch (occupation)
            {
                case 1:
                    this.Strength = 15;
                    this.Dexterity = 3;
                    this._hp = this.MaxHp = 15;
                    this._mp = this.MaxMp = 5;
                    this.Occupation = "Warrior";
                    break;
                case 2:
                    this.Strength = 4;
                    this.Dexterity = 5;
                    this._hp = this.MaxHp = 10;
                    this._mp = this.MaxMp = 20;
                    this.Occupation = "Mage";
                    break;
                case 3:
                    this.Strength = 9;
                    this.Dexterity = 9;
                    this._hp = this.MaxHp = 20;
                    this._mp = this.MaxMp = 10;
                    this.Occupation = "Rogue";
                    break;
            }

        }

        // Methods
        public Dungeon GetActualRoom(List<Dungeon> rooms)
        {
            foreach (Dungeon room in rooms)
            {
                if (room.X == this.X && room.Y == this.Y)
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
                switch (declaration)
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

        public void Move(List<Dungeon> rooms, string direction)
        {
            switch (direction.ToLower())
            {
                case "n":
                case "north":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X && room.Y == this.Y + 1)
                        {
                            this.Y++;
                            this.actualRoom.visited = true;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "s":
                case "south":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X && room.Y == this.Y - 1)
                        {
                            this.Y--;
                            this.actualRoom.visited = true;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "w":
                case "west":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X - 1 && room.Y == this.Y)
                        {
                            this.X--;
                            this.actualRoom.visited = true;
                            return;
                        }
                    }
                    Console.WriteLine("\nYou hit the wall, you can't go there...\n");
                    break;
                case "e":
                case "east":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X + 1 && room.X == this.X)
                        {
                            this.X++;
                            this.actualRoom.visited = true;
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
            // Amount of dmg dealt depands on proportional to (strenght value +- player's lvl)
            int damage = rand.Next(this.Strength - this.Lvl, this.Strength + this.Lvl);

            Console.WriteLine();
            Console.WriteLine($"{this.Name} attacks {mob.Id} and deals {damage} dmg!");
            mob.Hp -= damage;
            Console.WriteLine($"{mob.Id} has {mob.Hp} hp left!", mob.Id, mob.Hp);
        }

        public void Escape(Random rand)
        {
            int num = rand.Next(1, 10);
            if (num <= this.Dexterity)
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

            this.Lvl++;
            this.Exp = this.Exp + expGained;
            this.Exp -= ExpToNextLvl;
            this.ExpToNextLvl += 25;

            if (this.Exp >= this.ExpToNextLvl)
            {
                expGained = this.Exp - this.ExpToNextLvl;
                this.Exp -= expGained;
                this.LvlUp(expGained);
            }
        }

    }
}
