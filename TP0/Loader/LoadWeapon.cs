using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Linq;
using TP0.Entity;
using TP0.Loader.Factory;
using TP0.Stuff.Weapon;
using TP0.Stuff;

namespace TP0.Loader
{
	public class LoadWeapon
	{
		public LoadWeapon () {}

		public void loadAll (Gladiator gladiator, List<int> weapons)
		{
			WeaponFactory weaponFactory = new WeaponFactory();
			List<SlotStuff> slots = new List<SlotStuff>{SlotStuff.WEAPON_LEFT_HAND, SlotStuff.WEAPON_RIGHT_HAND};
			int index = 0;

			foreach (int idWeapon in weapons)
			{
				ListWeapon weapon = (ListWeapon) idWeapon;
				Item item = weaponFactory.getWeapon (weapon);

				gladiator.addItem(item, slots[index % slots.Count]);

				index++;
			}
		}
	}
}

