using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Carter's Cavern";
            Console.WriteLine("Welcome to your demise...");

            int monstersSlain = 0;

            #region RaceMenu
            Console.WriteLine("Choose your character's race.");

            Console.WriteLine("D) Demon\n" +
            "O) Ork\n" +
            "G) Gnome\n" +
            "M) Merfolk\n" +
            "H) Human\n" +
            "E) Elf\n" +
            "R) Reptilian\n" +
            "Enter) Human");
            
            ConsoleKey characterKey = Console.ReadKey(true).Key;
            Console.Clear();

            Race playerRace;
            switch (characterKey)
            {
                case ConsoleKey.D:
                    playerRace = Race.Demon;
                    break;

                case ConsoleKey.O:
                    playerRace = Race.Ork;
                    break;

                case ConsoleKey.G:
                    playerRace = Race.Gnome;
                    break;

                case ConsoleKey.H:
                    playerRace = Race.Halfling;
                    break;

                case ConsoleKey.M:
                    playerRace = Race.Merfolk;
                    break;

                case ConsoleKey.E:
                    playerRace = Race.Elf;
                    break;

                case ConsoleKey.R:
                    playerRace = Race.Reptilian;
                    break;

                default:
                    playerRace = Race.Human;
                    break;
            }
            #endregion

            #region WeaponMenu

            Console.WriteLine("Choose your weapon:");
            Weapon playerWeapon = new Weapon();

            ConsoleKey weaponKey = Console.ReadKey(true).Key;
            Console.Clear();
            switch (weaponKey)
            {
                default:
                    break;
            }
            #endregion

            Player player1 = new Player("Player 1", 65, 35, 100, 100, playerRace, playerWeapon);
            bool exit = false;
            do
            {

                Cactuar cac1 = new Cactuar();
                Cactuar cac2 = new Cactuar("Cactuar", 25, 25, 66, 25, 3, 9, "A very angry looking cactus...", true);
                List<Monster> monsterList = new List<Monster> { cac1, cac2 };

                Random rand = new Random();
                int randomNum = rand.Next(monsterList.Count);
                Monster monster = monsterList[randomNum];

                bool reload = false;

                do
                {
                    #region Menu
                    Console.Write("\nPlease choose an action:\n" +
                    "A) Attack " +
                    "R) Run Away\n" +
                    "P) Player Info " +
                    "M) Monster Info\n" +
                    "X) Exit\n");
                    #endregion
                    ConsoleKey userKey = Console.ReadKey(true).Key;
                    Console.Clear(); //Clears console after user has chosen their key
                    switch (userKey)
                    {
                        //Attack
                        case ConsoleKey.A:
                            Console.WriteLine("Attack!");
                            //TODO Run attack method

                            reload = true;
                            break;

                        //Run away
                        case ConsoleKey.R:
                            Console.WriteLine("Attempting to flee...");
                            //TODO Add Run away method

                            reload = true;
                            break;

                        //Player info
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info:\n\n");
                            Console.WriteLine(player1);
                            Console.WriteLine("Monsters slain: " + monstersSlain);
                            reload = true;
                            break;

                        //Monster Info
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info:\n\n");
                            Console.WriteLine(monster);
                            reload = true;
                            break;

                        //Exit
                        case ConsoleKey.Escape:
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Are you sure you want to quit? (Y/N)");
                            userKey = Console.ReadKey(true).Key;
                            Console.Clear();
                            exit = (userKey == ConsoleKey.Y);
                            break;

                        default:
                            Console.WriteLine("Invalid selection made.");
                            reload = true;
                            break;

                    }//end menu switch
                } while (!reload && !exit);
            } while (!exit);//end exit do
        }//end Main
    }//end class Program
}//end Namespace
