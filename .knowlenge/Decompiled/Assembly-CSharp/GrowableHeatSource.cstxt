using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;

public class GrowableHeatSource : EntityComponent<BaseEntity>, IServerComponent
{
	public float heatAmount = 5f;

	public AnimationCurve HeatFalloff = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	public float ApplyHeat(Vector3 forPosition)
	{
		if (base.baseEntity == null)
		{
			return 0f;
		}
		if (base.baseEntity.IsOn() || (base.baseEntity is IOEntity iOEntity && iOEntity.IsPowered()))
		{
			float num = Vector3.Distance(forPosition, base.transform.position);
			float num2 = HeatFalloff.Evaluate(num / Server.artificialTemperatureGrowableRange);
			return heatAmount * num2;
		}
		return 0f;
	}

	public void ForceUpdateGrowablesInRange()
	{
		List<GrowableEntity> obj = Facepunch.Pool.Get<List<GrowableEntity>>();
		Vis.Entities(base.transform.position, Server.artificialTemperatureGrowableRange, obj, 524288);
		List<PlanterBox> obj2 = Facepunch.Pool.Get<List<PlanterBox>>();
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
		Facepunch.Pool.FreeUnmanaged(ref obj2);
		Facepunch.Pool.FreeUnmanaged(ref obj);
	}
}
