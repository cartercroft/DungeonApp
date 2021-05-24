using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        public Race CharacterRace;
        public Weapon EquippedWeapon;

        public Player(string name, int hitChance, int blockChance, int maxLifePoints, int lifePoints, 
            Race characterRace, Weapon equippedWeapon)
        {
            Name = name;
            HitChance = hitChance;
            BlockChance = blockChance;
            MaxLifePoints = maxLifePoints;
            LifePoints = lifePoints;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }

        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n"
                + "Life: {1}/{2}\n" +
                "Weapon: {3}\n" +
                "Hit Chance: {4}%\n" +
                "Block: {5}\n"
                + "Description: {6}\n", Name, LifePoints, MaxLifePoints,
                EquippedWeapon, HitChance, BlockChance, CharacterRace);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

    }
}
