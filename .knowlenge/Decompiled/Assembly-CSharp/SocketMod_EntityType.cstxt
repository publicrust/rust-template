using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_EntityType : SocketMod
{
	public float sphereRadius = 1f;

	public LayerMask layerMask;

	public QueryTriggerInteraction queryTriggers;

	public BaseEntity searchType;

	public bool wantsCollide;

	protected override Translate.Phrase ErrorPhrase => ConstructionErrors.InvalidEntityType;

	public override string GetDebugErrorMessage()
	{
		return base.GetDebugErrorMessage() + $" {searchType}";
	}

	public override bool DoCheck(Construction.Placement place)
	{
		bool result = !wantsCollide;
		Vector3 position = place.position + place.rotation * worldPosition;
		List<BaseEntity> obj = Pool.Get<List<BaseEntity>>();
		Vis.Entities(position, sphereRadius, obj, layerMask.value, queryTriggers);
		foreach (BaseEntity item in obj)
		{
			bool flag = item.GetType().IsAssignableFrom(searchType.GetType());
			if (flag && wantsCollide)
			{
				result = true;
				break;
			}
			if (flag && !wantsCollide)
			{
				result = false;
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return result;
	}
}
