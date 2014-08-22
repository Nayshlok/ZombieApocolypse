using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Items.Ammo
{
	public abstract class Shotgun : RangedWeapon
	{
		public Shotgun()
		{
			this.Ammo = CedenoB_ZombieGame.Item.Ammo.AmmoType.Shotgun;
		}

		//abstract public override void Use(object o);
	}
}
