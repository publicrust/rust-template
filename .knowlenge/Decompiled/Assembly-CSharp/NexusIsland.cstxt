using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class NexusIsland : BaseEntity, INexusTransferTriggerController
{
	public const Flags ServerFullFlag = Flags.Reserved1;

	[Header("Nexus Island")]
	public Transform BillboardRoot;

	public Transform Billboard;

	public BoxCollider TransferZone;

	public BoxCollider SpawnZone;

	public float TraceHeight = 100f;

	public LayerMask TraceLayerMask = 1503731969;

	public Transform FerryWaypoint;

	public GameObjectRef MapMarkerPrefab;

	public Transform MapMarkerLocation;

	[NonSerialized]
	public string ZoneKey;

	public static readonly List<NexusIsland> All = new List<NexusIsland>();

	public override void InitShared()
	{
		base.InitShared();
		if (base.isServer && !All.Contains(this))
		{
			All.Add(this);
		}
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		if (base.isServer)
		{
			All.Remove(this);
		}
	}

	public bool CanTransfer(BaseEntity entity)
	{
		if (!(entity is BaseBoat) && !(entity is BaseSubmarine) && !(entity is WaterInflatable) && !(entity is PlayerHelicopter) && !(entity is HotAirBalloon))
		{
			return entity is BasePlayer;
		}
		return true;
	}

	public (string Zone, string Method) GetTransferDestination()
	{
		return (Zone: ZoneKey, Method: "ocean");
	}

	public bool TryFindPosition(out Vector3 position, float radius = 10f)
	{
		if (SpawnZone == null)
		{
			Debug.LogError("SpawnZone is null, cannot find a spawn position", this);
			position = Vector3.zero;
			return false;
		}
		Transform transform = SpawnZone.transform;
		Vector3 size = SpawnZone.size;
		for (int i = 0; i < 10; i++)
		{
			Vector3 position2 = size.Scale(UnityEngine.Random.value - 0.5f, 0f, UnityEngine.Random.value - 0.5f);
			Vector3 vector = transform.TransformPoint(position2);
			if (IsValidPosition(vector, radius))
			{
				float waterSurface = WaterLevel.GetWaterSurface(vector, waves: false, volumes: false);
				if (!Physics.SphereCast(vector.WithY(waterSurface + TraceHeight), radius, Vector3.down, out var hitInfo, TraceHeight + radius, TraceLayerMask, QueryTriggerInteraction.Ignore) || hitInfo.point.y < waterSurface)
				{
					position = vector.WithY(waterSurface);
					return true;
				}
			}
		}
		position = Vector3.zero;
		return false;
		static bool IsValidPosition(Vector3 center, float extent)
		{
			if (ValidBounds.TestInnerBounds(center) && ValidBounds.TestInnerBounds(center + new Vector3(0f - extent, 0f, 0f - extent)) && ValidBounds.TestInnerBounds(center + new Vector3(0f - extent, 0f, extent)) && ValidBounds.TestInnerBounds(center + new Vector3(extent, 0f, 0f - extent)))
			{
				return ValidBounds.TestInnerBounds(center + new Vector3(extent, 0f, extent));
			}
			return false;
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.nexusIsland != null)
		{
			ZoneKey = info.msg.nexusIsland.zoneKey;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.nexusIsland = Pool.Get<ProtoBuf.NexusIsland>();
		info.msg.nexusIsland.zoneKey = ZoneKey;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		BaseEntity baseEntity = GameManager.server.CreateEntity(MapMarkerPrefab.resourcePath, MapMarkerLocation.position, MapMarkerLocation.rotation);
		baseEntity.Spawn();
		baseEntity.SetParent(this, worldPositionStays: true);
	}
}
