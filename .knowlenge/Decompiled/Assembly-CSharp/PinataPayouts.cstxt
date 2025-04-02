using System;
using UnityEngine;

public class PinataPayouts : PrefabAttribute, IServerComponent
{
	[Serializable]
	public struct Payout
	{
		public ItemAmount[] Reward;

		public int Chance;
	}

	public Payout[] AllPayouts;

	private int totalChance;

	public Payout GetPayout()
	{
		if (totalChance == 0)
		{
			Payout[] allPayouts = AllPayouts;
			for (int i = 0; i < allPayouts.Length; i++)
			{
				Payout payout = allPayouts[i];
				totalChance += payout.Chance;
			}
		}
		if (totalChance == 0)
		{
			return AllPayouts[0];
		}
		int num = UnityEngine.Random.Range(0, totalChance);
		int num2 = 0;
		for (int j = 0; j < AllPayouts.Length; j++)
		{
			Payout result = AllPayouts[j];
			if (num <= num2 + result.Chance)
			{
				return result;
			}
			num2 += result.Chance;
		}
		return AllPayouts[0];
	}

	protected override Type GetIndexedType()
	{
		return typeof(PinataPayouts);
	}
}
