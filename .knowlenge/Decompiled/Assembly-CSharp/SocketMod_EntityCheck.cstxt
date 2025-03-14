using System.Collections.Generic;
using System.Linq;
using Facepunch;
using UnityEngine;

public class SocketMod_EntityCheck : SocketMod
{
	public float sphereRadius = 1f;

	public LayerMask layerMask;

	public QueryTriggerInteraction queryTriggers;

	public BaseEntity[] entityTypes;

	public bool wantsCollide;

	protected override Translate.Phrase ErrorPhrase => ConstructionErrors.InvalidEntity;

	public override bool DoCheck(Construction.Placement place)
	{
		bool result = !wantsCollide;
		Vector3 position = place.position + place.rotation * worldPosition;
		List<BaseEntity> obj = Pool.Get<List<BaseEntity>>();
		Vis.Entities(position, sphereRadius, obj, layerMask.value, queryTriggers);
		foreach (BaseEntity ent in obj)
		{
			bool flag = entityTypes.Any((BaseEntity x) => x.prefabID == ent.prefabID);
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
