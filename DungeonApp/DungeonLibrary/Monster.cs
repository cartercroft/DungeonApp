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
        public Monster(string name, int lifePoints, int maxLifePoints, int hitChance, int blockChance,
            int minDamage, int maxDamage, string description)
        {
            Name = name;
            MaxLifePoints = maxLifePoints;
            LifePoints = lifePoints;
            HitChance = hitChance;
            BlockChance = blockChance;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format($"Enemy: {Name}\n" +
                $"Health: {LifePoints}/{MaxLifePoints}" +
                $"Accuracy: {HitChance}%\tDamage:{MinDamage} to {MaxDamage}\n" +
                $"Defence: {BlockChance}\n" +
                $"Description: {Description}");
        }
    }
}
