using System;


namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    public class Potion: Item
    {
        public Potion(string potionName)
        {
            this.Name = potionName;
            this.ItemType = "potion";
        }

        public void Use(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have drunk {Name}!");
            switch(Name)
            {
                case "hp potion":
                    player.Hp += 5;
                    Console.WriteLine("5 Hp restored!");
                    break;
                case "mp potion":
                    player.Mp += 10;
                    Console.WriteLine("10 Mp restored!");
                    break;
                default:
                    break;
            }
            for (int i = 0; i < player.Equipment.Count; i++)
            {
                if(player.Equipment[i].Name == Name)
                {
                    player.Equipment.RemoveAt(i);
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
