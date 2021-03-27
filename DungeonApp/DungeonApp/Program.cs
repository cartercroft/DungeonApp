using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
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
                            //TODO Add player information

                            reload = true;
                            break;

                        //Monster Info
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info:\n\n");

                            reload = true;
                            break;

                        //Exit
                        case ConsoleKey.Escape:
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Are you sure you want to quit? (Y/N)");
                            exit = true;
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
