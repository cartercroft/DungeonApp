using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire : Monster
    {
        public Vampire(string name, int lifePoints, int maxLifePoints, int hitChance,
            int blockChance, int minDamage, int maxDamage, string description, bool isBuff) : base(name, lifePoints,
                maxLifePoints, hitChance, blockChance, minDamage, maxDamage, description, isBuff)
        { }//FQ CTOR
        public Vampire(bool isBuff)
        {
            Name = "Count Dreadful";
            MaxLifePoints = 40;
            LifePoints = 40;
            MaxDamage = 18;
            MinDamage = 5;
            HitChance = 70;
            BlockChance = 35;
            Description = "An abhorrent vampire rumored to have been spotted around these caverns.";
            IsBuff = isBuff;
        }
        public Vampire() //Default CTOR
        {
            Name = "Vampire Runt";
            MaxLifePoints = 20;
            LifePoints = 20;
            MaxDamage = 8;
            MinDamage = 2;
            HitChance = 80;
            BlockChance = 45;
            Description = "Don't let it near your neck!";
            IsBuff = false;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int calculatedDamage = rand.Next(MinDamage, MaxDamage + 1);
            int leechChance = rand.Next(3);  //33% chance he leeches half of his damage

            int leechPoints = calculatedDamage / 2;

            if (leechChance == 0) //If the 33% chance is successful
            {
                if ((LifePoints + leechPoints) > MaxLifePoints)
                {
                    leechPoints = MaxLifePoints - LifePoints;
                    LifePoints = MaxLifePoints;
                }
                else
                {
                    LifePoints += leechPoints;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} leeched {leechPoints} life points from you!\n" +
                    $"He now has {LifePoints} life points remaining.\n");
                Console.ResetColor();
            }

            return calculatedDamage;
        }//end CalcDamage()
    }//end Vampire
}//end Namespace

