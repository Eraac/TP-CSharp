using System;
using System.Collections.Generic;
using TP0.Stuff;

namespace TP0.Entity
{
	public class Item
	{
		private List<Stats> _stats;
		private string _name;
		private uint _cost;
        private uint _idItem;
		private TypeStuff _typeStuff;

		public TypeStuff typeStuff 
		{
			get {
				return this._typeStuff;
			}
		}

		public string name
		{
			get {
				return this._name;
			}
		}

		public uint cost
		{
			get {
				return this._cost;
			}
		}

        public uint id
        {
            get {
                return this._idItem;
            }
        }

        public Item (string name, uint cost, uint idItem, TypeStuff typeStuff)
		{
			this._stats = new List<Stats> ();
			this._name = name;
			this._cost = cost;
            this._idItem = idItem;
			this._typeStuff = typeStuff;
		}

		public void addStats (Stats stats)
		{
			this._stats.Add(stats);
		}

		public uint getTotalStats (TypeStats typeStats)
		{
			uint total = 0;

			foreach (Stats stats in this._stats) {
				if (stats.typeStats == typeStats) {
					total += stats.value;
				}
			}

			return total;
		}

		public override string ToString ()
		{
			return string.Format ("[Item: typeStuff={0}, name={1}, cost={2}]", typeStuff, name, cost);
		}
	}
}

