using System;
using TP0.Stuff;

namespace TP0.Entity
{
	public class Stats
	{
		private uint _value;
		private TypeStats _typeStats;

		public uint value 
		{
			get {
				return this._value;
			}
		}

		public TypeStats typeStats 
		{
			get {
				return this._typeStats;
			}
		}

		public Stats (uint value, TypeStats typeStats)
		{
			this._value = value;
			this._typeStats = typeStats;
		}
	}
}

