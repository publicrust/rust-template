using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_BuildingBlock : SocketMod
{
	public float sphereRadius = 1f;

	public LayerMask layerMask;

	public QueryTriggerInteraction queryTriggers;

	public bool wantsCollide;

	protected override Translate.Phrase ErrorPhrase => ConstructionErrors.MustPlaceOnConstruction;

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 position = place.position + place.rotation * worldPosition;
		List<BuildingBlock> obj = Pool.Get<List<BuildingBlock>>();
		Vis.Entities(position, sphereRadius, obj, layerMask.value, queryTriggers);
		bool flag = obj.Count > 0;
		if (flag && wantsCollide)
		{
			Pool.FreeUnmanaged(ref obj);
			return true;
		}
		if (flag && !wantsCollide)
		{
			Pool.FreeUnmanaged(ref obj);
			return false;
		}
		Pool.FreeUnmanaged(ref obj);
		return !wantsCollide;
	}
}
