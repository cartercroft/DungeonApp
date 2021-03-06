using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int randomNum = rand.Next(1, 101);
            System.Threading.Thread.Sleep(1000);

            if (randomNum <= (attacker.CalcHitChance() - defender.CalcBlockChance()))
            {
                int damageDealt = attacker.CalcDamage();
                if (damageDealt < defender.LifePoints)
                {
                    defender.LifePoints -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{attacker.Name} hit {defender.Name} for" +
                        $" {damageDealt} damage!\n{defender.Name} has {defender.LifePoints} HP left!\n");
                }
                else
                {
                    defender.LifePoints -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{attacker.Name} hit {defender.Name} for" +
                    $" {damageDealt} damage!");
                }

                Console.ResetColor();
            }

            else { Console.WriteLine("{0}'s attack missed!", attacker.Name); }
        }

        public static void DoBattle(Character player, Character monster)
        {
            DoAttack(player, monster); //player attacks monster

            if (monster.LifePoints > 0) //if monster is still alive, monster attacks player.
            {
                DoAttack(monster, player);
            }
        }
    }
}
