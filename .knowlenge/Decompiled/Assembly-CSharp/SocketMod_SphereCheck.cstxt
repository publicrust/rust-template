using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_SphereCheck : SocketMod
{
	public float sphereRadius = 1f;

	public LayerMask layerMask;

	public bool wantsCollide;

	public bool requireMonument;

	[Space]
	public BaseEntity[] entityWhitelist;

	private Translate.Phrase lastError = new Translate.Phrase();

	protected override Translate.Phrase ErrorPhrase => lastError;

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 position = place.position + place.rotation * worldPosition;
		List<Collider> obj = Pool.Get<List<Collider>>();
		GamePhysics.OverlapSphere(position, sphereRadius, obj, layerMask.value, QueryTriggerInteraction.Collide);
		if (requireMonument)
		{
			for (int i = 0; i < obj.Count; i++)
			{
				Collider collider = obj[i];
				if (!collider.gameObject.HasCustomTag(GameObjectTag.BlockBarricadePlacement) && (ColliderEx.GetMonument(collider) == null || collider.gameObject.HasCustomTag(GameObjectTag.AllowBarricadePlacement)))
				{
					obj.RemoveAt(i);
					i--;
				}
			}
		}
		bool flag = wantsCollide == obj.Count > 0;
		if (entityWhitelist.Length != 0)
		{
			foreach (Collider item in obj)
			{
				BaseEntity baseEntity = GameObjectEx.ToBaseEntity(item);
				if (baseEntity != null)
				{
					flag = DeployVolume.CheckEntityList(baseEntity, entityWhitelist, trueIfAnyFound: true);
				}
			}
		}
		if (!flag)
		{
			lastError = ConstructionErrors.NotStableEnough;
			if ((int)layerMask == 2097152 || (int)layerMask == 136314880)
			{
				lastError = (wantsCollide ? ConstructionErrors.MustPlaceOnConstruction : ConstructionErrors.CantPlaceOnConstruction);
			}
			else if (!wantsCollide && requireMonument)
			{
				lastError = ConstructionErrors.CantPlaceOnMonument;
			}
			else if (!wantsCollide && obj.Count > 0)
			{
				using List<Collider>.Enumerator enumerator = obj.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string blockedByErrorFromCollider = ConstructionErrors.GetBlockedByErrorFromCollider(DeployVolume.LastDeployHit = enumerator.Current);
					if (!string.IsNullOrEmpty(blockedByErrorFromCollider))
					{
						Construction.lastPlacementErrorIsDetailed = true;
						lastError = blockedByErrorFromCollider;
						break;
					}
				}
			}
		}
		else if (wantsCollide && ((int)layerMask & 0x8000000) == 0)
		{
			flag = !GamePhysics.CheckSphere(place.position, 5f, 134217728);
			if (!flag)
			{
				lastError = ConstructionErrors.InvalidAreaVehicleLarge;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		if (flag)
		{
			return true;
		}
		return false;
	}
}
