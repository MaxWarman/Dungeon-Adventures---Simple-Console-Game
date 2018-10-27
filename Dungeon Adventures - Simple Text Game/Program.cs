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
            List<Dungeon> rooms;
            Setup.CreateDungeonRooms(out rooms);
            Setup.ShowGameMainMenu();
            Player player = Setup.CreatePlayerCharacter();

            // Game
            while(true)
            {
                Console.Clear();

                player.actualRoom = player.GetActualRoom(rooms);

                if (player.actualRoom.isThereCombat)
                {
                    MainGameplay.PlayCombat(player, rand);
                    player.GetActualRoom(rooms).isThereCombat = false;
                }

                PlayerCommand.DescribeRoom(player.actualRoom);
                MainGameplay.ShowUI(player);
                MainGameplay.GetPlayerDeclaration(player, rooms, player.actualRoom);

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}
