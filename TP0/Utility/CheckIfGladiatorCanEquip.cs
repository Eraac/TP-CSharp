using TP0.Entity;
using TP0.Stuff;

namespace TP0.Utility
{
	public class CheckIfGladiatorCanEquip
	{
		private const uint MAX_COST_STUFF = 10;

		public bool canEquip(Gladiator gladiator, Item item, SlotStuff slotStuff)
		{
			return this.checkSlot(item, slotStuff) && this.checkCost(gladiator, item, slotStuff);
		}

		private bool checkCost(Gladiator gladiator, Item item, SlotStuff slotStuff)
		{
			uint newCost = gladiator.stuff.getCostAllStuff() + item.cost - gladiator.stuff.getCostItem(slotStuff);
			//		Le total actuel de l'équipement + coût nouveau item - l'item qui sera ramplacé

			if (newCost > MAX_COST_STUFF) {
				return false;
			}

			return true;
		}

		private bool checkSlot(Item item, SlotStuff slotStuff)
		{
			switch (item.typeStuff) 
			{
			case TypeStuff.ARMOR:
				return this.equipArmorOnSlot(slotStuff);

			case TypeStuff.WEAPON:
				return this.equipWeaponOnSlot(slotStuff);
			}

			return false;
		}

		private bool equipWeaponOnSlot(SlotStuff slotStuff)
		{
			return (slotStuff == SlotStuff.WEAPON_LEFT_HAND || slotStuff == SlotStuff.WEAPON_RIGHT_HAND);
		}

		private bool equipArmorOnSlot(SlotStuff slotStuff)
		{
			return (slotStuff == SlotStuff.ARMOR_HEAD || slotStuff == SlotStuff.SHIELD);
		}
	}
}

