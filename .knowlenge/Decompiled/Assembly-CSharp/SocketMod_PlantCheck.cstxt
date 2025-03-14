using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_PlantCheck : SocketMod
{
	public bool CanBePotted = true;

	public float sphereRadius = 1f;

	public LayerMask layerMask;

	public QueryTriggerInteraction queryTriggers;

	public bool wantsCollide;

	public override bool DoCheck(Construction.Placement place)
	{
		if (!CanBePotted && place.transform != null)
		{
			PlanterBox planterBox = GameObjectEx.ToBaseEntity(place.transform) as PlanterBox;
			if (planterBox != null && planterBox.PlantPot)
			{
				return false;
			}
		}
		Vector3 position = place.position + place.rotation * worldPosition;
		List<BaseEntity> obj = Pool.Get<List<BaseEntity>>();
		Vis.Entities(position, sphereRadius, obj, layerMask.value, queryTriggers);
		bool result = !wantsCollide;
		foreach (BaseEntity item in obj)
		{
			GrowableEntity component = item.GetComponent<GrowableEntity>();
			if ((bool)component && wantsCollide)
			{
				result = true;
				break;
			}
			if ((bool)component && !wantsCollide)
			{
				result = false;
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return result;
	}
}
