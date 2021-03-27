using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Cactuar : Monster
    {
        public bool IsMetal { get; set; }

        public Cactuar(string name, int lifePoints, int maxLifePoints, int hitChance,
            int blockChance, int minDamage, int maxDamage, string description, bool isMetal) : base(name, lifePoints,
                maxLifePoints, hitChance, blockChance, minDamage, maxDamage, description)
        {
            IsMetal = isMetal;
        }

        public Cactuar() //Default Cactuar
        {
            Name = "Cactuar";
            MaxLifePoints = 25;
            LifePoints = 25;
            MaxDamage = 9;
            MinDamage = 3;
            HitChance = 66;
            BlockChance = 25;
            Description = "A very angry looking cactus...";
            IsMetal = false;
        }

        public override int CalcBlockChance()
        {
            int calculatedBlockChance = BlockChance;

            if(IsMetal) { calculatedBlockChance += BlockChance; }

            return calculatedBlockChance;
        }
    }
}
