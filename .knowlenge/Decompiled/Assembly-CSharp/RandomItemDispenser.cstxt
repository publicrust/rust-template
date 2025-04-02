using System;
using Oxide.Core;
using UnityEngine;

public class RandomItemDispenser : PrefabAttribute, IServerComponent
{
	[Serializable]
	public struct RandomItemChance
	{
		public ItemDefinition Item;

		public int Amount;

		[Range(0f, 1f)]
		public float Chance;

		public bool IgnoreInTutorial;
	}

	public RandomItemChance[] Chances;

	public bool OnlyAwardOne = true;

	protected override Type GetIndexedType()
	{
		return typeof(RandomItemDispenser);
	}

	public void DistributeItems(BasePlayer forPlayer, Vector3 distributorPosition)
	{
		RandomItemChance[] chances = Chances;
		for (int i = 0; i < chances.Length; i++)
		{
			RandomItemChance itemChance = chances[i];
			if (!(forPlayer != null) || !forPlayer.IsInTutorial || !itemChance.IgnoreInTutorial)
			{
				bool flag = TryAward(itemChance, forPlayer, distributorPosition);
				if (OnlyAwardOne && flag)
				{
					break;
				}
			}
		}
	}

	private bool TryAward(RandomItemChance itemChance, BasePlayer forPlayer, Vector3 distributorPosition)
	{
		if (Interface.CallHook("OnRandomItemAward", this, itemChance, forPlayer, distributorPosition) != null)
		{
			return false;
		}
		float num = UnityEngine.Random.Range(0f, 1f);
		if (itemChance.Chance >= num)
		{
			Item item = ItemManager.Create(itemChance.Item, itemChance.Amount, 0uL);
			if (item != null)
			{
				item.SetItemOwnership(forPlayer, ItemOwnershipPhrases.GatheredPhrase);
				if ((bool)forPlayer)
				{
					forPlayer.GiveItem(item, BaseEntity.GiveItemReason.ResourceHarvested);
				}
				else
				{
					item.Drop(distributorPosition + Vector3.up * 0.5f, Vector3.up);
				}
			}
			return true;
		}
		return false;
	}
}
