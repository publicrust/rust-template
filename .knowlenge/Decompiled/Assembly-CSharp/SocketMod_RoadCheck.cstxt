using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_RoadCheck : SocketMod
{
	public float sphereRadius = 1f;

	public bool wantsCollide;

	public LayerMask layerMask = 65536;

	protected override Translate.Phrase ErrorPhrase
	{
		get
		{
			if (!wantsCollide)
			{
				return ConstructionErrors.CantPlaceOnRoad;
			}
			return ConstructionErrors.MustPlaceOnRoad;
		}
	}

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 position = place.position + place.rotation * worldPosition;
		List<Collider> obj = Pool.Get<List<Collider>>();
		GamePhysics.OverlapSphere(position, sphereRadius, obj, layerMask.value, QueryTriggerInteraction.Collide);
		bool flag = false;
		for (int i = 0; i < obj.Count; i++)
		{
			Collider collider = obj[i];
			if (collider != null && collider.gameObject.HasCustomTag(GameObjectTag.Road))
			{
				flag = true;
				break;
			}
		}
		bool num = wantsCollide == flag;
		Pool.FreeUnmanaged(ref obj);
		if (num)
		{
			return true;
		}
		return false;
	}
}
