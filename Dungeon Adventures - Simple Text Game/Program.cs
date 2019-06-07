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
            List<Dungeon> rooms = new List<Dungeon>();
            Setup.CreateDungeonRooms(rooms);
            Setup.ShowGameMainMenu();
            Player player = Setup.CreatePlayerCharacter();

            //foreach (Dungeon room in rooms)
            //{
            //    Console.WriteLine($"{room.X}, {room.Y}, {room.description}");
            //}
            //Console.ReadKey();

            //Game
            while (true)
            {
                Console.Clear();

                player.actualRoom = player.GetActualRoom(rooms);


                int chanceForEnemyRespawn = rand.Next(1, 2);
                bool enemyRespawnes = false;
                if (player.actualRoom.IsThereCombat == true)
                {
                    Combat.ArrangeCombat(player, rand);
                    player.actualRoom.IsThereCombat = false;
                    if (chanceForEnemyRespawn == 1)
                    {
                        player.actualRoom.IsThereCombat = true;
                        enemyRespawnes = true;
                    }
                }

                PlayerCommand.DescribeRoom(player.actualRoom);
                MainGameplay.ShowUI(player);

                // Inform if the enemy respawns
                if (enemyRespawnes == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou still feel the dark magic inside this chamber...");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Dungeon.UpdateRoom(player, rooms);
                MainGameplay.GetPlayerDeclaration(player, rooms, rand);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
    }
}
