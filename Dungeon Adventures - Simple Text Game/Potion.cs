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

        public void Drink(Player player)
        {
            switch(Name)
            {
                // "You have drunk..." in every case because of refreshing via .ClearConsole()

                case "hp potion":
                    player.Hp += 5;
                    PlayerCommand.ClearConsole(player);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou have drunk {Name}!");
                    Console.WriteLine("5 Hp restored!");
                    break;
                case "mp potion":
                    player.Mp += 10;
                    PlayerCommand.ClearConsole(player);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou have drunk {Name}!");
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
