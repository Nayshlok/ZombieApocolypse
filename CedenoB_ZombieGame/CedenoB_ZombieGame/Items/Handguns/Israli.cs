﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class Israli : RangedWeapon
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public Israli()
		{
			ignoreAR = true;
			weaponType = RangedType.Handgun;
			base.baseDamage = new Dice(5, 6);
		}
	}
}
