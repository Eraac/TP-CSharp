using System;

namespace TP0.Debuff
{
	public class Trapped : IDebuffAttack
	{
		public uint decreaseAttack (uint chanceHit)
		{
			return chanceHit / 2;
		}
	}
}

