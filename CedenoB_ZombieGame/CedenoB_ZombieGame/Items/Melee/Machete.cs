using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class Machete : MeleeWeapon
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public Machete()
		{
			base.baseDamage = new Dice(3,6);
			ignoreAR = true;
		}
	}
}
