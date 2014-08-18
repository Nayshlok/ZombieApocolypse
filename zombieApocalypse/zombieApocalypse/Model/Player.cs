using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    public enum ClassType
    {
        Warrior, Sharpshooter, Survivalist
    }
    class Player : Character
    {
        public Inventory inventory { get; set; }
        public ClassType Class { get; set; }

        public Player()
        {
            inventory = new Inventory();
        }

        public int bonusToHit()
        {
            int bonus = 0;

            if (Class == ClassType.Warrior && inventory.equippedWeapon is MeleeWeapon)
            {
                bonus = 1;
            }
            if (Class == ClassType.Warrior && inventory.equippedWeapon is RangedWeapon)
            {
                bonus = -3;
            }
            if (Class == ClassType.Sharpshooter)
            {
                if (inventory.equippedWeapon is RangedWeapon)
                {
                    if (((RangedWeapon)inventory.equippedWeapon).weaponType == RangedType.Rifle)
                    {
                        bonus = 2;
                    }
                    else if (((RangedWeapon)inventory.equippedWeapon).weaponType == RangedType.Handgun)
                    {
                        bonus = 1;
                    }
                }
                else
                {
                    bonus = -3;
                }
            }
            if (Class == ClassType.Survivalist)
            {
                if (inventory.equippedWeapon is SurvivalKnife || inventory.equippedWeapon is SmallCrowbar)
                {
                    bonus = 2;
                }
                else if (inventory.equippedWeapon is RangedWeapon)
                {
                    RangedWeapon tempWeapon = (RangedWeapon)inventory.equippedWeapon;
                    if (tempWeapon.weaponType == RangedType.Shotgun)
                    {
                        bonus = 2;
                    }
                }
            }

            return bonus;
        }
    }
}
