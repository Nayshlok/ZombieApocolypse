using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model.Melee
{
    class SurvivalKnife : MeleeWeapon
    {
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public SurvivalKnife()
		{
			base.baseDamage = new Dice(1,6);
		}
    }
}
