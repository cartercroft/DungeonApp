using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        private int _lifePoints;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int BlockChance { get; set; }
        public int MaxLifePoints { get; set; }
        public int LifePoints
        {
            get { return _lifePoints; }
            set
            {
                if(value <= MaxLifePoints)
                {
                    _lifePoints = value;
                }
                else
                {
                    _lifePoints = MaxLifePoints;
                }
            }
        }
        public virtual int CalcBlockChance()
        {
            return BlockChance;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
    }
}
