using CedenoB_ZombieGame.Item.Ammo;
using CedenoB_ZombieGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
   public abstract class Weapon : PlayerItem
    {
        public Dice baseDamage { get; set; }
        public int BonusDamage { get; set; }
        public bool ignoreAR { get; set; }

    }
}
