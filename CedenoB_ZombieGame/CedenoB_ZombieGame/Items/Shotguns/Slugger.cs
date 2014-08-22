﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
	public class Slugger : RangedWeapon 
	{
		public int Price { get; set; }
		public int sellPrice { get; set; }

		public Slugger()
		{
			ignoreAR = true; 
			base.baseDamage = new Dice(4,6);
		}
	}
}
