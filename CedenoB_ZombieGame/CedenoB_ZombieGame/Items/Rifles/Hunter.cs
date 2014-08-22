﻿using CedenoB_ZombieGame.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class Hunter : Rifle
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public Hunter()
		{
			base.baseDamage = new Dice(5,6);
		
		}
	}
}
