using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model.Melee
{
    class SmallCrowbar : MeleeWeapon
    {
		public int Price { get; set; }
		public int sellPrice { get; set; }

        public SmallCrowbar()
        {
            base.baseDamage = new Dice(2, 6);
        }
    }
}
