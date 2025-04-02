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

	public LayerMask TraceLayerMask = LayerMask.op_Implicit(1503731969);

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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)SpawnZone == (Object)null)
		{
			Debug.LogError((object)"SpawnZone is null, cannot find a spawn position", (Object)(object)this);
			position = Vector3.zero;
			return false;
		}
		Transform transform = ((Component)SpawnZone).transform;
		Vector3 size = SpawnZone.size;
		RaycastHit val3 = default(RaycastHit);
		for (int i = 0; i < 10; i++)
		{
			Vector3 val = Vector3Ex.Scale(size, Random.value - 0.5f, 0f, Random.value - 0.5f);
			Vector3 val2 = transform.TransformPoint(val);
			if (IsValidPosition(val2, radius))
			{
				float waterSurface = WaterLevel.GetWaterSurface(val2, waves: false, volumes: false);
				if (!Physics.SphereCast(Vector3Ex.WithY(val2, waterSurface + TraceHeight), radius, Vector3.down, ref val3, TraceHeight + radius, LayerMask.op_Implicit(TraceLayerMask), (QueryTriggerInteraction)1) || ((RaycastHit)(ref val3)).point.y < waterSurface)
				{
					position = Vector3Ex.WithY(val2, waterSurface);
					return true;
				}
			}
		}
		position = Vector3.zero;
		return false;
		static bool IsValidPosition(Vector3 center, float extent)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
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
		info.msg.nexusIsland = Pool.Get<NexusIsland>();
		info.msg.nexusIsland.zoneKey = ZoneKey;
	}

	public override void ServerInit()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		base.ServerInit();
		BaseEntity baseEntity = GameManager.server.CreateEntity(MapMarkerPrefab.resourcePath, MapMarkerLocation.position, MapMarkerLocation.rotation);
		baseEntity.Spawn();
		baseEntity.SetParent(this, worldPositionStays: true);
	}
}
