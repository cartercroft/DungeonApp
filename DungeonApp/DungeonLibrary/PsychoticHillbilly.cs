using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class PsychoticHillbilly : Monster
    {
        public PsychoticHillbilly(string name, int lifePoints, int maxLifePoints, int hitChance,
            int blockChance, int minDamage, int maxDamage, string description, bool isBuff) : base(name, lifePoints,
                maxLifePoints, hitChance, blockChance, minDamage, maxDamage, description, isBuff)
        { }//FQ CTOR
        public PsychoticHillbilly(bool isBuff)
        {
            Name = "Psycho Hillbilly";
            MaxLifePoints = 40;
            LifePoints = 40;
            MaxDamage = 30;
            MinDamage = 12;
            HitChance = 60;
            BlockChance = 50;
            Description = "A furious redneck. He looks familiar.";
            IsBuff = isBuff;
        }
        public PsychoticHillbilly() //Default CTOR
        {
            Name = "Crazy Billy Bob";
            MaxLifePoints = 25;
            LifePoints = 25;
            MaxDamage = 20;
            MinDamage = 8;
            HitChance = 50;
            BlockChance = 35;
            Description = "It's your old friend Billy Bob! He's got an odd look in his eye.";
            IsBuff = false;
        }

        public override int CalcBlockChance()
        {
            int calculatedBlockChance = BlockChance;

            if (IsBuff) { calculatedBlockChance += BlockChance; }

            return calculatedBlockChance;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int calculatedDamage = rand.Next(MinDamage, MaxDamage + 1);

            if (IsBuff)
            {
                calculatedDamage = calculatedDamage * 2;
            }

            return calculatedDamage;
        }
    }
}
