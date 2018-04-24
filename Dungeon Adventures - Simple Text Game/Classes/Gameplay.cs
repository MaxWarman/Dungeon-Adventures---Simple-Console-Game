using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventures___Simple_Text_Game.Classes
{
    class Gameplay
    {
        public static void gameplay(List<Dungeon> rooms, Player player, Random rand)
        {
            Console.Clear();

            Dungeon actPlayerRoom = player.actRoom(rooms);  // make object of current room (just to not look for it everytime in 'rooms' List)

            Console.WriteLine("Room description:");
            Command.describe(actPlayerRoom);

            if (actPlayerRoom.isBattle)
            {
                Gameplay.battle(player, rand, actPlayerRoom);
            }
            player.actRoom(rooms).isBattle = actPlayerRoom.isBattle;    // update .isBattle parameter in 'rooms' List

            Gameplay.showUI(player);    // show players interface
            Gameplay.playerDeclaration(player, rooms);  // let player type command

        }

        public static void createRooms(out List<Dungeon> rooms)
        {
            rooms = new List<Dungeon>();
            string roomDescription;

            // Room 0,0
            roomDescription = "Test description of first room";
            rooms.Add(new Dungeon(0, 0, roomDescription, "skt1"));

            // Room 0,1
            roomDescription = "Test description of second room";
            rooms.Add(new Dungeon(0, 1, roomDescription, "skt1"));
        }   // returns a list of Dungeon objects - actuall ingame rooms

        public static void battle(Player player, Random rand, Dungeon actPlayerRoom)
        {
            Monster mob = new Monster(actPlayerRoom.mobType);

            Console.WriteLine("{0} appears in front of {1}! The battle begins!", mob.name, player.name);

            do
            {
                bool plFirst;   // true, if player attacks first in current turn

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNew turn!\n");

                if (player.dexterity >= mob.dexterity)
                {
                    plFirst = true;
                    Console.WriteLine("{0} attacks first!", player.name);
                }
                else
                {
                    plFirst = false;
                    Console.WriteLine("{0} attacks first!", mob.name);
                }
                Console.ForegroundColor = ConsoleColor.White;

                if (plFirst)
                {
                    player.takeBattleTurn(mob, rand, actPlayerRoom);

                    if (actPlayerRoom.isBattle == false)        // Finish battle if mob was killed
                        break;

                    mob.fight(player, rand);
                }
                else
                {
                    mob.fight(player, rand);

                    player.takeBattleTurn(mob, rand, actPlayerRoom);
                    if (actPlayerRoom.isBattle == false)        // Finish battle if mob was killed
                        break;
                }

            } while (mob.Hp >= 0 || player.Hp >= 0);
        }

        public static void showGameMenu()
        {
            int actIndex = 0;
            while (true)
            {
                Console.Clear();
                string[] menuOptions = new string[4];
                menuOptions[0] = "---    New Game     ---";
                menuOptions[1] = "---    Load Game    ---";
                menuOptions[2] = "---    Credits      ---";
                menuOptions[3] = "---    Exit         ---";

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Dungeon Adventures - The Text Game");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == actIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuOptions[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (actIndex == 0)
                        actIndex = menuOptions.Length - 1;
                    else
                        actIndex--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (actIndex == menuOptions.Length - 1)
                        actIndex = 0;
                    else
                        actIndex++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    switch (actIndex)
                    {
                        case 0:
                            // NEW GAME
                            return;
                        case 1:
                            // LOAD GAME
                            Console.WriteLine("Work in progress...");

                            return;
                        case 2:
                            // SHOW CREDITS
                            Console.Clear();
                            Console.WriteLine("'Dungeon Adventures - Simple Text Game'");
                            Console.WriteLine("Original game designed by: Maksymilian Górski");
                            Console.WriteLine("Programmered by: Maksymilian Górski");
                            Console.WriteLine("Produced by: Maksymilian Górski");
                            Console.WriteLine("\nclick any key to back...");
                            Console.ReadKey();
                            break;
                        case 3:
                            // EXIT
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Error, array index not recognized...");
                            break;
                    }
                }

            }
        }   // draws and performs dialogue options in game menu

        public static Player createPlayerChar()
        {
            Console.Clear();

            Console.Write("What is your name, brave hero? ");
            string name = "";
            do
            {
                name = Console.ReadLine();
            } while (name == "");

            Console.WriteLine("\nGreat! And what is your occupation?");
            Console.WriteLine("[1] Warrior \n[2] Mage \n[3] Rogue ");
            Console.Write("Click to choose...");
            int occup = 0;
            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        occup = 1;
                        break;
                    case ConsoleKey.D2:
                        occup = 2;
                        break;
                    case ConsoleKey.D3:
                        occup = 3;
                        break;
                    default:
                        occup = 0;
                        break;
                }
            } while (occup == 0);
            Player pl = new Player(name, occup);
            return pl;
        }   // player character generator

        public static void showUI(Player player)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Imię: {0}", player.name);
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Lvl: {0}", player.lvl);
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gold: {0}", player.gold);
            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Help - type for list of commands\t");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void playerDeclaration(Player player, List<Dungeon> rooms)
        {
            Console.WriteLine();
            bool flag = false;              // change to true, when important event happens (for example: player is moving to next room)
            do
            {
                Console.Write("\nCommand: ");
                string declaration = Console.ReadLine();

                switch(declaration)
                {
                    case "h":
                    case "Help":
                    case "help":
                        Command.help();
                        break;
                    case "Coords":
                    case "coords":
                        Command.coords(player);
                        break;
                    case "Desc":
                    case "desc":
                        Command.describe(player.actRoom(rooms));
                        break;
                    case "l":
                    case "Look":
                    case "look":
                        Command.look(rooms, player.actRoom(rooms));
                        break;
                    case "Stats":
                    case "stats":
                        Command.showStats(player);
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }

            } while (!flag);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public static void gameover()
        {
            Console.WriteLine("Gameover :(");
            Console.ReadKey();
        }
    }
}
