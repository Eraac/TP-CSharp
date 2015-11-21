using System;
using System.Collections.Generic;
using TP0.Stuff;

namespace TP0.Entity
{
	public class Stuff
	{
		private Dictionary<SlotStuff, Item> _items;

		public Stuff ()
		{
			this._items = new Dictionary<SlotStuff, Item> ();
		}

		public void addItem (SlotStuff slotStuff, Item item)
		{
			this._items.Add(slotStuff, item);
		}

		public uint getCostAllStuff ()
		{
			uint total = 0;

			foreach (KeyValuePair<SlotStuff, Item> item in this._items) {
				total += item.Value.cost;
			}

			return total;
		}

		public uint getCostItem (SlotStuff slotStuff)
		{
			return (this.hasItem(slotStuff)) ? this._items[slotStuff].cost : 0;
		}

		public bool hasItem (SlotStuff slotStuff)
		{
			return this._items.ContainsKey(slotStuff);
		}

		public uint getTotalValueOfStatsForOnePiece (TypeStats typeStats, SlotStuff slotStuff)
		{
			return (this.hasItem(slotStuff)) ? 
				this._items[slotStuff].getTotalStats(typeStats) : 0;
		}

		public uint getTotalValueOfStatsForAllStuff (TypeStats typeStats)
		{
			uint total = 0;

			foreach (KeyValuePair<SlotStuff, Item> item in this._items) {
				total += item.Value.getTotalStats(typeStats);
			}

			return total;
		}

		public bool hasWeapon()
		{
			return (this.hasItem(SlotStuff.WEAPON_LEFT_HAND) || this.hasItem(SlotStuff.WEAPON_RIGHT_HAND));
		}

		public override string ToString ()
		{
			string itemString = "";

			foreach (KeyValuePair<SlotStuff, Item> item in this._items) 			
			{
				itemString += item.Value.ToString() + " / ";
			}

			return "[Stuff] : " + itemString;
		}
	}
}
