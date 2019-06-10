using System;
using System.Collections.Generic;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Player: Coordinates
    {
        // Player info
        public string Name { get; set; }
        public string Occupation { get; set; }

        // Expirience properties
        public int Lvl { get; set; }
        public int Exp { get; set; }
        public int ExpTotal { get; set; }
        public int ExpToNextLvl { get; set; }

        // Frequently variable stats
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Gold { get; set; } = 0;

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
        public List<Item> Equipment = new List<Item>();

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
                    this.Strength = 7;
                    this.Dexterity = 3;
                    this.Hp = this.MaxHp = 15;
                    this.Mp = this.MaxMp = 5;
                    this.Equipment.Add(new Potion("hp potion"));
                    this.Occupation = "Warrior";
                    break;
                case 2:
                    this.Strength = 3;
                    this.Dexterity = 4;
                    this.Hp = this.MaxHp = 10;
                    this.Mp = this.MaxMp = 20;
                    this.Equipment.Add(new Potion("mp potion"));
                    this.Occupation = "Mage";
                    break;
                case 3:
                    this.Strength = 5;
                    this.Dexterity = 5;
                    this.Hp = this.MaxHp = 20;
                    this.Mp = this.MaxMp = 10;
                    this.Occupation = "Rogue";
                    break;
            }

            this.Equipment.Add(new Potion("hp potion"));
            this.Equipment.Add(new Potion("mp potion"));

        }

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWhat do you do?");
            Console.WriteLine("1 - Fight; 2 - Cast a spell; 3 - Drink a potion; 4 - Try to escape");
            Console.ForegroundColor = ConsoleColor.White;

            bool repeat = false;
            do
            {
                string declaration = Console.ReadLine();
                switch (declaration.ToLower())
                {
                    case "1":
                        this.Attack(mob, rand, actPlayerRoom);
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine("Not added yet...");
                        repeat = true;
                        break;
                    case "3":
                        bool hasPotion = false;
                        foreach(Item item in Equipment)
                        {
                            if(item.ItemType == "potion")
                            {
                                hasPotion = true;
                                break;
                            }
                        }

                        if(hasPotion == false)
                        {
                            Console.WriteLine("\nYou havn't any!");
                            repeat = true;
                            break;
                        }

                        bool potionDrunk = false;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nOwned potions:");
                            Console.ForegroundColor = ConsoleColor.White;

                            foreach (Potion potion in Equipment)
                            {
                                Console.WriteLine($" - {potion.Name}");
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nWhich potion do you want to drink?\t");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("back - return to menu\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            string potionDeclaration = Console.ReadLine();

                            if(potionDeclaration == "back")
                            {
                                TakeOneCombatTurn(mob, rand, actPlayerRoom);
                                break;
                            }

                            foreach (Potion potion in Equipment)
                            {
                                if (potion.Name == potionDeclaration)
                                {
                                    potion.Drink(this, 1);
                                    potionDrunk = true;
                                    break;
                                }
                            }

                            if (potionDrunk == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nWrong potion name!");
                                Console.ForegroundColor = ConsoleColor.White;
                                repeat = true;
                            }
                        } while (potionDrunk == false);
                        repeat = false;
                        break;
                    case "4":
                        this.Escape(rand);
                        break;
                    default:
                        repeat = true;
                        break;

                }
            } while (repeat == true);
        }

        public bool Move(List<Dungeon> rooms, string direction, Random rand)
        {
            switch (direction.ToLower())
            {
                case "n":
                case "north":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X && room.Y == this.Y + 1)
                        {
                            this.actualRoom.WasVisited = true;
                            this.Y++;
                            return false;
                        }
                    }
                    break;
                case "s":
                case "south":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X && room.Y == this.Y - 1)
                        {
                            this.actualRoom.WasVisited = true;
                            this.Y--;
                            return false;
                        }
                    }
                    break;
                case "w":
                case "west":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X - 1 && room.Y == this.Y)
                        {
                            this.actualRoom.WasVisited = true;
                            this.X--;
                            return false;
                        }
                    }
                    break;
                case "e":
                case "east":
                    foreach (Dungeon room in rooms)
                    {
                        if (room.X == this.X + 1 && room.Y == this.Y)
                        {
                            this.actualRoom.WasVisited = true;
                            this.X++;
                            return false ;
                        }
                    }          
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou hit the wall, you can't go there...");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }

        public void Attack(Monster mob, Random rand, Dungeon actPlayerRoom)
        {
            // Amount of dmg dealt is proportional to (strenght value +- player's lvl)
            int damage = rand.Next(this.Strength - this.Lvl, this.Strength + this.Lvl);

            Console.WriteLine();
            Console.WriteLine($"{this.Name} attacks {mob.Type} and deals {damage} dmg!");
            mob.Hp -= damage;
            Console.WriteLine($"{mob.Type} has {mob.Hp}/{mob.MaxHp} hp left!", mob.Type, mob.Hp);
        }

        public void Escape(Random rand)
        {
            int num = rand.Next(1, 10);
            if (num <= this.Dexterity)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Escape successed!");
                Console.ForegroundColor = ConsoleColor.White;
                this.actualRoom.IsThereCombat = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escape failed!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void LvlUp(int num)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Level up!\n");
            Console.ForegroundColor = ConsoleColor.White;

            this.Lvl++;
            this.Exp = this.Exp + num;
            this.Exp -= ExpToNextLvl;
            this.ExpToNextLvl += 25;

            switch(this.Occupation)
            {
                case "Warrior":
                    this.MaxHp += 3;
                    this.MaxMp += 1;
                    this.Strength += 2;
                    this.Dexterity += 1;
                    break;
                case "Mage":
                    this.MaxHp += 1;
                    this.MaxMp += 4;
                    this.Strength += 1;
                    this.Dexterity += 1;
                    break;
                case "Rogue":
                    this.MaxHp += 2;
                    this.MaxMp += 2;
                    this.Strength += 2;
                    this.Dexterity += 2;
                    break;
            }

            if (this.Exp >= this.ExpToNextLvl)
            {
                num = this.Exp - this.ExpToNextLvl;
                this.Exp -= num;
                this.LvlUp(num);
            }

            
        }

    }
}
