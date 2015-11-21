using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using TP0.Entity;
using TP0.Stuff;
using TP0.Stuff.Armor;
using TP0.Loader.Factory;

namespace TP0.Loader
{
	public class LoadArmor
	{
		public LoadArmor () {}

		public void loadAll (Gladiator gladiator, List<int> armors)
		{
			ArmorFactory armorFactory = new ArmorFactory();
			List<SlotStuff> slots = new List<SlotStuff>{SlotStuff.ARMOR_HEAD, SlotStuff.SHIELD};
			int index = 0;

			foreach (int idArmor in armors) 
			{
				ListArmor armor = (ListArmor) idArmor;
				Item item = armorFactory.getArmor(armor);

				gladiator.addItem(item, slots[index % slots.Count]);

				index++;
			}
		}
	}
}

