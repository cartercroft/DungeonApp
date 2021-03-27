using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        public Weapon()
        {
            MaxDamage = 5;
            MinDamage = 3;
            BonusHitChance = 10;
            Name = "Bronze Shortsword";
            IsTwoHanded = false;
        }
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2} to {3} Damage)\nBonus Hit Chance: {4}%",
                IsTwoHanded ? "Two-Handed" : "One-Handed", Name, MinDamage, MaxDamage, BonusHitChance);
        }
    }
}

