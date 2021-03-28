using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Cactuar : Monster
    {

        public Cactuar(string name, int lifePoints, int maxLifePoints, int hitChance,
            int blockChance, int minDamage, int maxDamage, string description, bool isBuff) : base(name, lifePoints,
                maxLifePoints, hitChance, blockChance, minDamage, maxDamage, description, isBuff)
        { }//FQ CTOR
        public Cactuar() //Default CTOR
        {
            Name = "Cactuar";
            MaxLifePoints = 25;
            LifePoints = 25;
            MaxDamage = 9;
            MinDamage = 3;
            HitChance = 66;
            BlockChance = 25;
            Description = "A very angry looking cactus...";
            IsBuff = false;
        }

        public override int CalcBlockChance()
        {
            int calculatedBlockChance = BlockChance;

            if(IsBuff) { calculatedBlockChance += BlockChance; }

            return calculatedBlockChance;
        }
    }
}
