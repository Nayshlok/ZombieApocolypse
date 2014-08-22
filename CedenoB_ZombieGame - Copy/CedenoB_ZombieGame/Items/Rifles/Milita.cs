using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class Milita : RangedWeapon
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public Milita()
		{
			base.baseDamage = new Dice(4,6);
		}
	}
}
