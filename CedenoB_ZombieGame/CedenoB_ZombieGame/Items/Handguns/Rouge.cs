﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class Rouge : RangedWeapon
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public Rouge()
		{
			weaponType = RangedType.Handgun;
			base.baseDamage = new Dice(3,6);
		}
	}
}
