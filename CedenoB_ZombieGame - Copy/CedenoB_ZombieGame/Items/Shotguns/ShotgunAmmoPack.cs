using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Items.Shotguns
{
	public class ShotgunAmmoPack : AmmoPack
	{

		public ShotgunAmmoPack()
		{
			this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Shotgun;
		}

		public ShotgunAmmoPack(int amount)
		{
			this.Qty = amount;
		}
	}
}
