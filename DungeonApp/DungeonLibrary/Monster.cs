using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public bool IsBuff { get; set; }
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if(value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else { _minDamage = 1; }
            }
        }
        public Monster() { }
        public Monster(bool isBuff) { IsBuff = false; }
        public Monster(string name, int lifePoints, int maxLifePoints, int hitChance, int blockChance,
    int minDamage, int maxDamage, string description, bool isBuff)
        {
            IsBuff = isBuff;
            if(IsBuff)
            {
                MaxLifePoints = maxLifePoints + (maxLifePoints / 4); //buffed 25%
                LifePoints = MaxLifePoints; //buffed 25%
                HitChance = hitChance + 5; //buffed 5%
                BlockChance = blockChance + 3; //buffed 3%
                MaxDamage = maxDamage + 5;
                MinDamage = minDamage + 3;
            }
            else
            {
                MaxLifePoints = maxLifePoints;
                LifePoints = lifePoints;
                HitChance = hitChance;
                BlockChance = blockChance;
                MinDamage = minDamage;
                MaxDamage = maxDamage;
            }
            Name = name;
            Description = description;
        }


        public override string ToString()
        {
            return string.Format($"Enemy: {(IsBuff ? "Burly" : "")} {Name}\n\n" +
                $"Health: {LifePoints}/{MaxLifePoints}\n" +
                $"Accuracy: {HitChance}%\tDamage: {MinDamage} to {MaxDamage}\n" +
                $"Defence: {BlockChance}\n" +
                $"Description: {Description}");
        }
    }
}
