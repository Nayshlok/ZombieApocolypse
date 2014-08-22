using CedenoB_ZombieGame.Item.Items.Ammo;
using CedenoB_ZombieGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedenoB_ZombieGame.Item.Model
{
	public class ShotgunAmmo : GunAmmo
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public ShotgunAmmo()
		{
			this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Shotgun;
		}
	}
}
