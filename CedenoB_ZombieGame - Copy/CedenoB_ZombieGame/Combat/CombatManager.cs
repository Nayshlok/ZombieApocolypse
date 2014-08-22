using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieApocalypseSimulator;
using zombieApocalypse.Model;
using ZombieApocalypseSimulator.Model;

namespace zombieApocalypse.Combat
{
    enum Defense
    {
        Dodge, Parry, None
    }

    class CombatManager
    {
        private readonly Dice D20 = new Dice(1, 20);
        private bool isCritSuccess, isDefendCrit, isDefendFail, botchDefend;
        private int MeleePSBonus;
        private int MeleePPBonus;
        private Character attacker, defender;

        /// <summary>
        /// The only method that can be called outside the class. It will take in two Character objects and try to battle them.
        /// This method is responsible for subtracting the actual damage from the Character SDC or HP property.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns>A boolean that represents that damage was dealt in combat.</returns>
        public bool startCombat(Character attacker, Character defender)
        {
            if ((attacker is Player && defender is Player)
                || (attacker is Zed && defender is Zed))
            {
                Console.WriteLine("The combatants are allies");
                return false;
            }
            else
            {
                this.attacker = attacker;
                this.defender = defender;
                setAttackerBonuses();

                if (confirmHit())
                {
                    bool damageHP = false;
                    if (attacker is Zed)
                    {
                        damageHP = (((Zed)attacker) is Shank) ? true : false;
                    }
                    int damage = damageDone();
                    Console.WriteLine("Damage done: " + damage);
                    if (defender.BaseSDC >= damage && !damageHP)
                    {
                        defender.BaseSDC -= damage;
                    }
                    else if (defender.BaseSDC < damage && defender.BaseSDC > 0 && !damageHP)
                    {
                        damage -= defender.BaseSDC;
                        defender.BaseSDC = 0;
                        defender.BaseHP -= damage;
                    }
                    else
                    {
                        defender.BaseHP -= damage;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void testCombat(Character attacker, Character defender)
        {
            this.attacker = attacker;
            this.defender = defender;
            this.isCritSuccess = true;
            setAttackerBonuses();
            Console.WriteLine("Damage is: " + damageDone());
        }

        /// <summary>
        /// Called to find what bonuses apply to the attackers damage and chance to hit, using the Characters
        /// PP and PS properties.
        /// </summary>
        private void setAttackerBonuses()
        {
            MeleePSBonus = 0;
            MeleePPBonus = 0;
            if (attacker is Player)
            {
                Weapon attackerWeapon = ((Player)attacker).inventory.equippedWeapon;
                if (attackerWeapon is MeleeWeapon)
                {
                    MeleePPBonus = ((attacker.PP - 14) / 2);
                    if (MeleePPBonus < 0)
                    {
                        MeleePPBonus = 0;
                    }
                    MeleePSBonus = (attacker.PS - 15);
                    if (MeleePSBonus < 0)
                    {
                        MeleePSBonus = 0;
                    }
                }
            }
            else
            {
                if (!((Zed)attacker is Spitter))
                {
                    MeleePPBonus = ((attacker.PP - 14) / 2);
                    if (MeleePPBonus < 0)
                    {
                        MeleePPBonus = 0;
                    }
                    MeleePSBonus = (attacker.PS - 15);
                    if (MeleePSBonus < 0)
                    {
                        MeleePSBonus = 0;
                    }
                }
            }
        }

        /// <summary>
        /// This method will determine whether the attacker is able to sccussfully hit the target. It is also responsible for setting the 
        /// isCritSuccess field. Once an attack chance is determined it calculates the number that the attacker has to beat, based on the defender's
        /// AR, and defense chance.
        /// </summary>
        /// <returns></returns>
        private bool confirmHit()
        {

            int baseRoll = D20.Roll();
            isCritSuccess = (baseRoll == 20) ? true : false;
            //Test code for demo
            if (isCritSuccess)
            {
                Console.WriteLine("Attack was Critical");
            }

            if (baseRoll == 1)
            {
                //Demo display
                Console.WriteLine("Attack critically failed.");

                return false;
            }
            int strike = MeleePPBonus;

            strike += attacker.Strike;
            int toHit = baseRoll + strike;
            if (attacker is Player)
            {
                toHit += ((Player)attacker).bonusToHit();
            }

            int AR = 4;
            if (defender is Player)
            {
                if ((Player)defender is Warrior)
                {
                    AR += 2;
                }
            } 
            if(defender is Zed)
            {
                Player tempPlayer = (Player)attacker;
                if (!tempPlayer.inventory.equippedWeapon.ignoreAR)
                {
                    AR += 10;
                }
            }
            int defendAttempt = defendChance();

            if (toHit > AR || isDefendFail)
            {
                botchDefend = (toHit > AR && isDefendFail) ? true : false;
                //Demo code
                if(botchDefend)
                    Console.WriteLine("Botched defense");

                if ((toHit > defendAttempt && !isDefendCrit) || isDefendFail || (isCritSuccess && !isDefendCrit))
                {
                    Console.WriteLine("Attacker was successful: " + toHit);
                    return true;
                }
            }
            Console.WriteLine("Attacker Failed with: " + toHit);
            return false;
        }

        /// <summary>
        /// Calculates the defender's chance to defend, which is compared to the attacker's chance to hit in the confirmHit method.
        /// </summary>
        /// <returns></returns>
        private int defendChance()
        {
            Defense defendOption = defenseChoice();
            if (defendOption != Defense.None)
            {
                int defense = D20.Roll();
                isDefendCrit = (defense == 20) ? true : false;
                //Demo code
                if (isDefendCrit)
                    Console.WriteLine("Critical Defense");

                isDefendFail = (defense == 1) ? true : false;
                //Demo code
                if(isDefendFail)
                    Console.WriteLine("Failed defense");

                if (defendOption == Defense.Parry && defender is Player)
                {
                    if ((Player)defender is Warrior)
                        defense += 2;
                }

                if (defender.PP >= 15)
                {
                    defense += ((defender.PP - 14) / 2);
                }
                Console.WriteLine("Defender " + defendOption +": " + defense);
                return defense;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Determines the defending actions a defender can take. Picks in order, Parry, Dodge, or none if no defense is available.
        /// </summary>
        /// <returns></returns>
        private Defense defenseChoice()
        {
            bool tankAttack = false;
            if (attacker is Zed)
            {
                tankAttack = ((Zed)attacker is Tank) ? true : false;
            }

            if (defender.HasParried && !tankAttack)
            {
                defender.HasParried = false;
                return Defense.Parry;
            }
            else if (defender.HasDodged)
            {
                defender.HasDodged = false;
                return Defense.Dodge;
            }
            else
            {
                return Defense.None;
            }
        }

        /// <summary>
        /// Calculates the damage done in case of a successful hit, it takes the bonus determined in setAttackerBonus() and the Character's
        /// strike property, plus the base damage of Zed or Player Weapon.
        /// </summary>
        /// <returns></returns>
        private int damageDone()
        {
            int damage = MeleePSBonus;
            if (attacker is Player)
            {
                Player tempPlayer = (Player)attacker;
                damage += tempPlayer.inventory.equippedWeapon.baseDamage.Roll();
                damage += tempPlayer.inventory.equippedWeapon.BonusDamage;
            }
            else
            {
                Zed tempZed = (Zed)attacker;
                damage += tempZed.BaseDamage.Roll();
                damage += tempZed.BonusDamage;
            }

            damage *= (isCritSuccess) ? 2 : 1;
            damage *= (botchDefend) ? 2 : 1;

            return damage;
        }

        /// <summary>
        /// Used to determine if damage will bypass SDC and be subtracted from Character's HP property.
        /// </summary>
        /// <returns></returns>
        private bool pierceDamage()
        {
            bool isPierce = false;

            isPierce = (attacker is Zed && ((Zed)attacker) is Shank) ? true : false;
            

            return isPierce;
        }
    }
}
