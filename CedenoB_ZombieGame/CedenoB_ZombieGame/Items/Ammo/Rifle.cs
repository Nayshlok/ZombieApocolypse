﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Items.Ammo
{
	public abstract class Rifle : RangedWeapon
	{
		public Rifle()
		{
			this.Ammo = CedenoB_ZombieGame.Item.Ammo.AmmoType.Rifle;
		}

		//abstract public override void Use(object o);
	
	}
}
