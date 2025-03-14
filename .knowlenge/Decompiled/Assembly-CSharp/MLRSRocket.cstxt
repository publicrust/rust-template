using System.Collections.Generic;
using Rust;
using UnityEngine;

public class MLRSRocket : TimedExplosive, SamSite.ISamSiteTarget
{
	[SerializeField]
	private GameObjectRef mapMarkerPrefab;

	[SerializeField]
	private GameObjectRef launchBlastFXPrefab;

	[SerializeField]
	private GameObjectRef explosionGroundFXPrefab;

	[SerializeField]
	private ServerProjectile serverProjectile;

	private EntityRef mapMarkerInstanceRef;

	public static List<MLRSRocket> serverList = new List<MLRSRocket>();

	public SamSite.SamTargetType SAMTargetType => SamSite.targetTypeMissile;

	public override void ServerInit()
	{
		base.ServerInit();
		serverList.Add(this);
		CreateMapMarker();
		Effect.server.Run(launchBlastFXPrefab.resourcePath, PivotPoint(), base.transform.up, null, broadcast: true);
	}

	internal override void DoServerDestroy()
	{
		serverList.Remove(this);
		base.DoServerDestroy();
	}

	public override void ProjectileImpact(RaycastHit info, Vector3 rayOrigin)
	{
		Explode(rayOrigin);
		if (Physics.Raycast(info.point + Vector3.up, Vector3.down, 4f, 1084293393, QueryTriggerInteraction.Ignore))
		{
			Effect.server.Run(explosionGroundFXPrefab.resourcePath, info.point, Vector3.up, null, broadcast: true);
		}
	}

	private void CreateMapMarker()
	{
		BaseEntity baseEntity = mapMarkerInstanceRef.Get(base.isServer);
		if (baseEntity.IsValid())
		{
			baseEntity.Kill();
		}
		BaseEntity baseEntity2 = GameManager.server.CreateEntity(mapMarkerPrefab?.resourcePath, base.transform.position, Quaternion.identity);
		baseEntity2.OwnerID = base.OwnerID;
		baseEntity2.Spawn();
		baseEntity2.SetParent(this, worldPositionStays: true);
		mapMarkerInstanceRef.Set(baseEntity2);
	}

	public bool IsValidSAMTarget(bool staticRespawn)
	{
		return !staticRespawn;
	}

	public override Vector3 GetLocalVelocityServer()
	{
		return serverProjectile.CurrentVelocity;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!ColliderEx.IsOnLayer(other, Layer.Trigger))
		{
			return;
		}
		if (other.CompareTag("MLRSRocketTrigger"))
		{
			Explode();
			TimedExplosive componentInParent = other.GetComponentInParent<TimedExplosive>();
			if (componentInParent != null)
			{
				componentInParent.Explode();
			}
		}
		else if (other.GetComponent<TriggerSafeZone>() != null)
		{
			Kill();
		}
	}
}
