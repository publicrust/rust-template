using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;

public class GrowableHeatSource : EntityComponent<BaseEntity>, IServerComponent
{
	public float heatAmount = 5f;

	public float ApplyHeat(Vector3 forPosition)
	{
		if (base.baseEntity == null)
		{
			return 0f;
		}
		if (base.baseEntity.IsOn() || (base.baseEntity is IOEntity iOEntity && iOEntity.IsPowered()))
		{
			return Mathx.RemapValClamped(Vector3.Distance(forPosition, base.transform.position), 0f, Server.artificialTemperatureGrowableRange, 0f, heatAmount);
		}
		return 0f;
	}

	public void ForceUpdateGrowablesInRange()
	{
		List<GrowableEntity> obj = Facepunch.Pool.GetList<GrowableEntity>();
		Vis.Entities(base.transform.position, Server.artificialTemperatureGrowableRange, obj, 512);
		List<PlanterBox> obj2 = Facepunch.Pool.GetList<PlanterBox>();
		foreach (GrowableEntity item in obj)
		{
			if (item.isServer)
			{
				PlanterBox planter = item.GetPlanter();
				if (planter != null && !obj2.Contains(planter))
				{
					obj2.Add(planter);
					planter.ForceTemperatureUpdate();
				}
				item.CalculateQualities(firstTime: false, forceArtificialLightUpdates: false, forceArtificialTemperatureUpdates: true);
				item.SendNetworkUpdate();
			}
		}
		Facepunch.Pool.FreeList(ref obj2);
		Facepunch.Pool.FreeList(ref obj);
	}
}
