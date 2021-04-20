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
        static void Main()
        {
            Console.Title = "Carter's Cavern";
            Console.WriteLine("Welcome to your demise...\n");

            int monstersSlain = 0;

            #region RaceMenu
            Console.WriteLine("Choose your character's race.\n");

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
            Console.WriteLine($"You have chosen to play as a(n) {playerRace}.");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            #endregion

            #region WeaponMenu

            Console.WriteLine("Choose your weapon:\n");
            Weapon playerWeapon = new Weapon();

            Console.WriteLine("1) Bronze Longsword\n2) Bronze Two-Handed Sword\n" +
                "3) Bronze Battleaxe\n4) Bronze Throwing Dart\n" +
                "Enter) Bronze Shortsword\n");
            ConsoleKey weaponKey = Console.ReadKey(true).Key;
            Console.Clear();
            switch (weaponKey)
            {
                case ConsoleKey.D1:
                    playerWeapon = new Weapon(9, 15, "Bronze Longsword", 5, false);
                    break;

                case ConsoleKey.D2:
                    playerWeapon = new Weapon(10, 22, "Bronze Two-Handed Sword", 15, true);
                    break;

                case ConsoleKey.D3:
                    playerWeapon = new Weapon(8, 25, "Bronze Battleaxe", 0, false);
                    break;

                case ConsoleKey.D4:
                    playerWeapon = new Weapon(3, 9, "Wooden Club", 50, true);
                    break;

                default: //leaves weapon as default bronze shortsword weapon ctor
                    break;
            }

            Console.WriteLine($"You have chosen to use the {playerWeapon.Name}.\n");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            #endregion

            Player player1 = new Player("Player 1", 50, 25, 100, 100, playerRace, playerWeapon);
            bool exit = false;
            do
            {

                #region Monsters
                Cactuar cac1 = new Cactuar();
                Cactuar cac2 = new Cactuar("Cactuar", 25, 25, 66, 25, 3, 9, "A very angry looking cactus...", true);
                MonsterSloth sloth1 = new MonsterSloth();
                MonsterSloth sloth2 = new MonsterSloth(true);
                PsychoticHillbilly bill1 = new PsychoticHillbilly();
                PsychoticHillbilly bill2 = new PsychoticHillbilly(true);
                #endregion
                List<Monster> monsterList = new List<Monster> { cac1, cac2, sloth1, sloth2, bill1, bill2 };

                Random rand = new Random();
                int randomNum = rand.Next(monsterList.Count);
                Monster monster = monsterList[randomNum];

                bool reload = false;

                Console.WriteLine(GetRoom());
                Console.WriteLine("\nStanding before you: {0} " + monster.Name,
                    monster.IsBuff ? "Burly" : "");

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
                            Combat.DoBattle(player1, monster);
                            if (monster.LifePoints <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                Console.WriteLine("You stumble through the darkness...\n\n");
                                System.Threading.Thread.Sleep(1234);
                                //exit inner loop to load a new monster & room
                                reload = true;
                                monstersSlain++;
                            }//handles monster death
                            break;

                        //Run away
                        case ConsoleKey.R:
                            Console.WriteLine("Attempting to flee...");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"{monster.Name} strikes as you flee!");
                            Combat.DoAttack(monster, player1);
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            reload = true;
                            break;

                        //Player info
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info:\n\n");
                            Console.WriteLine(player1);
                            Console.WriteLine("Monsters slain: " + monstersSlain);
                            break;

                        //Monster Info
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info:\n\n");
                            Console.WriteLine(monster);
                            break;

                        //Exit
                        case ConsoleKey.Escape:
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Are you sure you want to quit? (Y/N)");
                            userKey = Console.ReadKey(true).Key;
                            Console.Clear();
                            exit = (userKey == ConsoleKey.Y);
                            reload = true;
                            break;

                        default:
                            Console.WriteLine("Invalid selection made.");
                            reload = true;
                            break;

                    }//end menu switch

                    if (player1.LifePoints <= 0) //handles player death
                    {
                        Console.WriteLine("Oh dear, you have died!\a");
                        exit = true;
                    }//Handles player death

                } while (!reload && !exit);//end reload do
            } while (!exit);//end exit do

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Game over\n");
            Console.WriteLine("You defeated {0} monsters.", monstersSlain);
            Console.ResetColor();
        }//end Main

        public static string GetRoom()
        {

            string[] rooms =
            {
                "The room is dark and musty with the smell of lost souls..",
                "A strange ceiling is the focal point of the room before you. It's honeycombed with hundreds of holes about as wide as your head. " +
                "They seem to penetrate the ceiling to some height beyond a couple feet, but you can't be sure from your vantage point.",
                " A chill crawls up your spine and out over your skin as you look upon this room. The carvings on the wall are magnificent, a symphony in stonework --" +
                " but given the themes represented, it might be better described as a requiem. Scenes of death, both violent and peaceful, " +
                "appear on every wall framed by grinning skeletons and ghoulish forms in ragged cloaks.", "This hall is choked with corpses. The bodies of orcs and ogres lie in tangled heaps where they died," +
                " and the floor is sticky with dried blood. It looks like the orcs and ogres were fighting. Some " +
                "side was the victor but you're not sure which one. The bodies are largely stripped of valuables, " +
                "but a few broken weapons jut from the slain or lie discarded on the floor.",
                "This chamber holds one occupant: the statue of a male figure with elven features but the broad, muscular body of a hale human." +
                " It kneels on the floor as though fallen to that posture. Both its arms reach upward in supplication, and its face is a mask of grief. " +
                "Two great feathered wings droop from its back, both sculpted to look broken. The statue is skillfully crafted.",
                "You open the door to a scene of carnage. Two male humans, a male elf, and a female dwarf lie in drying pools of their blood. It seems that they might once have been wearing armor, " +
                "except for the elf, who remains dressed in a blue robe. Clearly they lost some battle and victors stripped them of their valuables.",
                "Three low, oblong piles of rubble lie near the center of this small room. Each has a weapon jutting upright from one end -- a longsword, a spear, and a quarterstaff. " +
                "The piles resemble cairns used to bury dead adventurers.", "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it. It's as though the room was" +
                " gripped in two enormous hands and broken like a loaf of bread. Someone has torn a tall stone door from its hinges somewhere else in the dungeon and used it to bridge the 15-foot gap of the chasm" +
                " between the two sides of the room. Whatever did that must have possessed tremendous strength because the door is huge, and the enormous hinges look bent and mangled." };

            Random rng = new Random();

            int indexNbr = rng.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }//End GetRoom()
    }//End class Program
}//end namespace DungeonApp

