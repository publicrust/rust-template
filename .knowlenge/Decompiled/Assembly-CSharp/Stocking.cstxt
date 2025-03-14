using Oxide.Core;
using Rust;
using UnityEngine;

public class Stocking : LootContainer
{
	public static ListHashSet<Stocking> stockings;

	public override void ServerInit()
	{
		base.ServerInit();
		if (stockings == null)
		{
			stockings = new ListHashSet<Stocking>();
		}
		stockings.Add(this);
	}

	internal override void DoServerDestroy()
	{
		stockings.Remove(this);
		base.DoServerDestroy();
	}

	public bool IsEmpty()
	{
		if (base.inventory == null)
		{
			return false;
		}
		for (int num = base.inventory.itemList.Count - 1; num >= 0; num--)
		{
			if (base.inventory.itemList[num] != null)
			{
				return false;
			}
		}
		return true;
	}

	public override void SpawnLoot()
	{
		if (base.inventory == null)
		{
			Debug.Log("CONTACT DEVELOPERS! Stocking::PopulateLoot has null inventory!!! " + base.name);
		}
		else if (IsEmpty() && Interface.CallHook("OnXmasStockingFill", this) == null)
		{
			base.SpawnLoot();
			SetFlag(Flags.On, b: true);
			Hurt(MaxHealth() * 0.1f, DamageType.Generic, null, useProtection: false);
		}
	}

	public override void PlayerStoppedLooting(BasePlayer player)
	{
		base.PlayerStoppedLooting(player);
		SetFlag(Flags.On, b: false);
		if (IsEmpty() && base.healthFraction <= 0.1f)
		{
			Hurt(base.health, DamageType.Generic, this, useProtection: false);
		}
	}
}
