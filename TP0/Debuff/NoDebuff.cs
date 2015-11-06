using System;

namespace TP0.Debuff
{
	public class NoDebuff : IDebuffAttack
	{
		public uint decreaseAttack (uint chanceHit)
		{
			return chanceHit;
		}
	}
}

