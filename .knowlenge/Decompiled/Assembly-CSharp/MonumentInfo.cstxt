using UnityEngine;

public class MonumentInfo : LandmarkInfo, IPrefabPreProcess
{
	[Header("MonumentInfo")]
	public MonumentType Type = MonumentType.Building;

	[InspectorFlags]
	public MonumentTier Tier = (MonumentTier)(-1);

	public int MinWorldSize;

	public Bounds Bounds = new Bounds(Vector3.zero, Vector3.zero);

	public bool HasNavmesh;

	public bool IsSafeZone;

	public bool AllowPatrolHeliCrash = true;

	[HideInInspector]
	public bool WantsDungeonLink;

	[HideInInspector]
	public bool HasDungeonLink;

	[HideInInspector]
	public DungeonGridInfo DungeonEntrance;

	private OBB obbBounds;

	protected override void Awake()
	{
		base.Awake();
		obbBounds = new OBB(base.transform.position, base.transform.rotation, Bounds);
		if ((bool)TerrainMeta.Path)
		{
			TerrainMeta.Path.Monuments.Add(this);
		}
	}

	private void Start()
	{
	}

	public bool CheckPlacement(Vector3 pos, Quaternion rot, Vector3 scale)
	{
		OBB oBB = new OBB(pos, scale, rot, Bounds);
		Vector3 point = oBB.GetPoint(-1f, 0f, -1f);
		Vector3 point2 = oBB.GetPoint(-1f, 0f, 1f);
		Vector3 point3 = oBB.GetPoint(1f, 0f, -1f);
		Vector3 point4 = oBB.GetPoint(1f, 0f, 1f);
		int topology = TerrainMeta.TopologyMap.GetTopology(point);
		int topology2 = TerrainMeta.TopologyMap.GetTopology(point2);
		int topology3 = TerrainMeta.TopologyMap.GetTopology(point3);
		int topology4 = TerrainMeta.TopologyMap.GetTopology(point4);
		int num = TierToMask(Tier);
		int num2 = 0;
		if ((num & topology) != 0)
		{
			num2++;
		}
		if ((num & topology2) != 0)
		{
			num2++;
		}
		if ((num & topology3) != 0)
		{
			num2++;
		}
		if ((num & topology4) != 0)
		{
			num2++;
		}
		if (num2 < 3)
		{
			return false;
		}
		WaterBody componentInChildren = GetComponentInChildren<WaterBody>();
		if (componentInChildren == null || componentInChildren.Type != WaterBodyType.Lake)
		{
			return true;
		}
		if (pos.y + componentInChildren.MinWaterLevel() < 1f)
		{
			return false;
		}
		return true;
	}

	public float Distance(Vector3 position)
	{
		return obbBounds.Distance(position);
	}

	public float SqrDistance(Vector3 position)
	{
		return obbBounds.SqrDistance(position);
	}

	public float Distance(OBB obb)
	{
		return obbBounds.Distance(obb);
	}

	public float SqrDistance(OBB obb)
	{
		return obbBounds.SqrDistance(obb);
	}

	public bool IsInBounds(Vector3 position)
	{
		return obbBounds.Contains(position);
	}

	public Vector3 ClosestPointOnBounds(Vector3 position)
	{
		return obbBounds.ClosestPoint(position);
	}

	public PathFinder.Point GetPathFinderPoint(int res)
	{
		Vector3 position = base.transform.position;
		float num = TerrainMeta.NormalizeX(position.x);
		float num2 = TerrainMeta.NormalizeZ(position.z);
		PathFinder.Point result = default(PathFinder.Point);
		result.x = Mathf.Clamp((int)(num * (float)res), 0, res - 1);
		result.y = Mathf.Clamp((int)(num2 * (float)res), 0, res - 1);
		return result;
	}

	public int GetPathFinderRadius(int res)
	{
		float a = Bounds.extents.x * TerrainMeta.OneOverSize.x;
		float b = Bounds.extents.z * TerrainMeta.OneOverSize.z;
		return Mathf.CeilToInt(Mathf.Max(a, b) * (float)res);
	}

	protected void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = new Color(0f, 0.7f, 1f, 0.1f);
		Gizmos.DrawCube(Bounds.center, Bounds.size);
		Gizmos.color = new Color(0f, 0.7f, 1f, 1f);
		Gizmos.DrawWireCube(Bounds.center, Bounds.size);
	}

	public MonumentNavMesh GetMonumentNavMesh()
	{
		return GetComponent<MonumentNavMesh>();
	}

	public static int TierToMask(MonumentTier tier)
	{
		int num = 0;
		if ((tier & MonumentTier.Tier0) != 0)
		{
			num |= 0x4000000;
		}
		if ((tier & MonumentTier.Tier1) != 0)
		{
			num |= 0x8000000;
		}
		if ((tier & MonumentTier.Tier2) != 0)
		{
			num |= 0x10000000;
		}
		return num;
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		HasDungeonLink = DetermineHasDungeonLink();
		WantsDungeonLink = DetermineWantsDungeonLink();
		DungeonEntrance = FindDungeonEntrance();
	}

	private DungeonGridInfo FindDungeonEntrance()
	{
		return GetComponentInChildren<DungeonGridInfo>();
	}

	private bool DetermineHasDungeonLink()
	{
		return GetComponentInChildren<DungeonGridLink>() != null;
	}

	private bool DetermineWantsDungeonLink()
	{
		if (Type == MonumentType.WaterWell)
		{
			return false;
		}
		if (Type == MonumentType.Building && displayPhrase.token.StartsWith("mining_quarry"))
		{
			return false;
		}
		if (Type == MonumentType.Radtown && displayPhrase.token.StartsWith("swamp"))
		{
			return false;
		}
		return true;
	}
}
