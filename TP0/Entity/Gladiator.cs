using System;
using TP0.Stuff;
using TP0.Debuff;

namespace TP0.Entity
{
	public class Gladiator
	{
		private string _name;
		private Stuff _stuff;
		private IDebuffAttack _debuff;
		private uint _nbMatchPlayed;
		private uint _nbMatchWon;

		public Stuff stuff {
			get {
				return this._stuff;
			}
		}

		public IDebuffAttack debuff 
		{
			get {
				return this._debuff;
			}
			set {
				this._debuff = value;
			}
		}

		public Gladiator (string name, uint nbMatchPlayed = 0, uint nbMatchWon = 0)
		{
			this._name = name;
			this._stuff = new Stuff();
			this._debuff = new NoDebuff();
			this._nbMatchPlayed = nbMatchPlayed;
			this._nbMatchWon = 0;
		}

		public bool addItem (Item item, SlotStuff slotStuff)
		{
			CheckIfGladiatorCanEquip check = new CheckIfGladiatorCanEquip();

			if (check.canEquip(this, item, slotStuff)) {
				this._stuff.addItem(slotStuff, item);
				return true;
			}

			return false;
		}

		public uint chanceHit (SlotStuff slotStuff)
		{
			return this._stuff.getTotalValueOfStatsForOnePiece(TypeStats.CHANCE_HIT, slotStuff);
		}

		public uint chanceParry (SlotStuff slotStuff)
		{
			return this._stuff.getTotalValueOfStatsForOnePiece(TypeStats.CHANCE_PARRY, slotStuff);
		}

		public double pourcentageVictory ()
		{
			return (this._nbMatchWon / this._nbMatchPlayed) * 100;
		}

		public void addMatch (bool isVictory = false)
		{
			this._nbMatchPlayed++;

			if (isVictory) {
				this._nbMatchWon++;
			}
		}

		public bool isValid ()
		{
			return this._stuff.hasWeapon();
		}
	}
}

