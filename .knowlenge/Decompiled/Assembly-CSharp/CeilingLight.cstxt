using System.Collections.Generic;
using ConVar;
using Facepunch;
using Network;
using Rust;
using UnityEngine;

public class CeilingLight : IOEntity
{
	public float pushScale = 2f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("CeilingLight.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override int ConsumptionAmount()
	{
		if (IsOn())
		{
			return 2;
		}
		return base.ConsumptionAmount();
	}

	public override void Hurt(HitInfo info)
	{
		if (base.isServer)
		{
			if (info.damageTypes.Has(DamageType.Explosion))
			{
				ClientRPC(null, "ClientPhysPush", 0, info.attackNormal * 3f * (info.damageTypes.Total() / 50f), info.HitPositionWorld);
			}
			base.Hurt(info);
		}
	}

	public void RefreshGrowables()
	{
		List<GrowableEntity> obj = Facepunch.Pool.GetList<GrowableEntity>();
		Vis.Entities(base.transform.position + new Vector3(0f, 0f - ConVar.Server.ceilingLightHeightOffset, 0f), ConVar.Server.ceilingLightGrowableRange, obj, 512);
		List<PlanterBox> obj2 = Facepunch.Pool.GetList<PlanterBox>();
		foreach (GrowableEntity item in obj)
		{
			if (item.isServer)
			{
				PlanterBox planter = item.GetPlanter();
				if (planter != null && !obj2.Contains(planter))
				{
					obj2.Add(planter);
					planter.ForceLightUpdate();
				}
				item.CalculateQualities(firstTime: false, forceArtificialLightUpdates: true);
				item.SendNetworkUpdate();
			}
		}
		Facepunch.Pool.FreeList(ref obj2);
		Facepunch.Pool.FreeList(ref obj);
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
		bool num = IsOn();
		SetFlag(Flags.On, IsPowered());
		if (num != IsOn())
		{
			if (IsOn())
			{
				LightsOn();
			}
			else
			{
				LightsOff();
			}
		}
	}

	public void LightsOn()
	{
		RefreshGrowables();
	}

	public void LightsOff()
	{
		RefreshGrowables();
	}

	public override void OnKilled(HitInfo info)
	{
		base.OnKilled(info);
		RefreshGrowables();
	}

	public override void OnAttacked(HitInfo info)
	{
		float num = 3f * (info.damageTypes.Total() / 50f);
		ClientRPC(null, "ClientPhysPush", (info.Initiator != null && info.Initiator is BasePlayer && !info.IsPredicting) ? info.Initiator.net.ID : default(NetworkableId), info.attackNormal * num, info.HitPositionWorld);
		base.OnAttacked(info);
	}
}
