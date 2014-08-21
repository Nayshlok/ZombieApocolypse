using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator
{
    enum ClassPlayer
    {
        Warrior,
        Sharp_Shooter,
        Survivalist
    }

    class Player:Character
    {
        Random rand = new Random();
        private int turnsDead { get; set; }
        

        private ClassPlayer _PlayerClass;
        public ClassPlayer PlayerClass
        {
            get { return _PlayerClass; }
            set { _PlayerClass = value; }
        }

        private Inventory _Inventory;
        public Inventory inventory
        {
            get { return _Inventory; }
            set { _Inventory = value; }
        }
        private int _ZombifyChance;
        public int ZombifyChance
        {
            get { return _ZombifyChance; }
            set { _ZombifyChance = value; }
        }

        private int _Money;
        public int Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        public Player(string name):base(name)
        {

        }

        public void Zombify(Player playerChecked)
        {
            
            if (playerChecked.IsLiving == false)
            {
                playerChecked.ZombifyChance = 5 * turnsDead;
                int random = rand.Next(0, 100);
                //Chance to become Zombie
                if (random >= playerChecked.ZombifyChance && random <= playerChecked.ZombifyChance)
                {
                   random = rand.Next(0, 102);
                   //Zombie Type radomness
                   if (random >= 0 && random <= 39)
                   {
                       Sloucher sloucher = new Sloucher(playerChecked.Name);
                   }
                   else if (random >= 40 && random <= 59)
                   {
                       FastAttack fastattack = new FastAttack(playerChecked.Name);
                   }
                   else if (random >= 60 && random <= 79)
                   {
                       Spitter spitter = new Spitter(playerChecked.Name);
                   }
                   else if (random >= 80 && random <= 89)
                   {
                       Shank shank = new Shank(playerChecked.Name);
                   }
                   else if (random >= 90 && random <= 99)
                   {
                       Tank tank = new Tank(playerChecked.Name);
                   }
                       //This else is here to handle any randomization that my go wrong.
                   else
                   {
                       Sloucher sloucher = new Sloucher(playerChecked.Name);
                   }
                }
            }
            else
            {

            }
            playerChecked.turnsDead = playerChecked.turnsDead + 1;
        }

        public int bonusToHit()
        {
            int bonus = 0;

            if (this is Warrior && inventory.equippedWeapon is MeleeWeapon)
            {
                bonus = 1;
            }
            if (this is Warrior && inventory.equippedWeapon is RangedWeapon)
            {
                bonus = -3;
            }
            if (this is SharpShooter)
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
            if (this is Survivalist)
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
