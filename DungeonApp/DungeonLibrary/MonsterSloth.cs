using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class MonsterSloth : Monster
    {
        public MonsterSloth(string name, int lifePoints, int maxLifePoints, int hitChance,
            int blockChance, int minDamage, int maxDamage, string description, bool isBuff) : base(name, lifePoints,
                maxLifePoints, hitChance, blockChance, minDamage, maxDamage, description, isBuff)
        { }//FQ CTOR
        public MonsterSloth(bool isBuff)
        {
            Name = "Monster Sloth";
            MaxLifePoints = 12;
            LifePoints = 12;
            MaxDamage = 15;
            MinDamage = 12;
            HitChance = 80;
            BlockChance = 15;
            Description = "A colossal yet adorable animal. It seems angry.";
            IsBuff = isBuff;
        }
        public MonsterSloth() //Default CTOR
        {
            Name = "Monster Sloth";
            MaxLifePoints = 12;
            LifePoints = 12;
            MaxDamage = 15;
            MinDamage = 12;
            HitChance = 80;
            BlockChance = 15;
            Description = "A colossal yet adorable animal. It seems angry.";
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
            
            if(IsBuff)
            {
                calculatedDamage = calculatedDamage * (5 / 3);
            }

            return calculatedDamage;
        }
    }
}
