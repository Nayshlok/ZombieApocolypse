﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class SludgeHammer : MeleeWeapon
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public SludgeHammer()
		{
			base.baseDamage = new Dice(2,12);
		}
	}
}
