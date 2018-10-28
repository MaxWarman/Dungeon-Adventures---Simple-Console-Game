using System;
using System.Collections.Generic;
using Dungeon_Adventures___Simple_Text_Game.Classes;

namespace Dungeon_Adventures___Simple_Text_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Setup
            Random rand = new Random();
            Setup.CreateDungeonRooms(out List<Dungeon> rooms);
            Setup.ShowGameMainMenu();
            Player player = Setup.CreatePlayerCharacter();

            // Game
            while(true)
            {
                Console.Clear();

                player.actualRoom = player.GetActualRoom(rooms);

                if (player.actualRoom.isThereCombat == true)
                {
                    MainGameplay.PlayCombat(player, rand);
                    player.actualRoom.isThereCombat = false;
                }

                PlayerCommand.DescribeRoom(player.actualRoom);
                MainGameplay.ShowUI(player);

                Dungeon.UpdateRoom(player, rooms);
                MainGameplay.GetPlayerDeclaration(player, rooms);

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}
