using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    public enum RangedType
    {
        Handgun, Rifle, Shotgun
    }

    class RangedWeapon : Weapon
    {
        public RangedType weaponType { get; set; }
    }
}
