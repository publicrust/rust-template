using UnityEngine;

public class ValidBounds : SingletonComponent<ValidBounds>
{
	public Bounds worldBounds;

	public static bool Test(BaseEntity entity, Vector3 vPos)
	{
		if (!SingletonComponent<ValidBounds>.Instance)
		{
			return true;
		}
		if (entity != null && entity.net != null && entity.net.group != null && TutorialIsland.IsTutorialNetworkGroup(entity.net.group.ID))
		{
			return SingletonComponent<ValidBounds>.Instance.IsInsideOuterBounds(vPos);
		}
		return SingletonComponent<ValidBounds>.Instance.IsInsideInnerBounds(vPos);
	}

	public static float TestDist(BaseEntity entity, Vector3 vPos)
	{
		if (!SingletonComponent<ValidBounds>.Instance)
		{
			return float.MaxValue;
		}
		if (entity != null && entity.net != null && entity.net.group != null && TutorialIsland.IsTutorialNetworkGroup(entity.net.group.ID))
		{
			return float.MaxValue;
		}
		return SingletonComponent<ValidBounds>.Instance.DistToWorldEdge2D(vPos);
	}

	public static bool TestInnerBounds(Vector3 vPos)
	{
		if (!SingletonComponent<ValidBounds>.Instance)
		{
			return true;
		}
		return SingletonComponent<ValidBounds>.Instance.IsInsideInnerBounds(vPos);
	}

	public static bool TestOuterBounds(Vector3 vPos)
	{
		if (!SingletonComponent<ValidBounds>.Instance)
		{
			return true;
		}
		return SingletonComponent<ValidBounds>.Instance.IsInsideOuterBounds(vPos);
	}

	internal bool IsInsideInnerBounds(Vector3 vPos)
	{
		if (vPos.IsNaNOrInfinity())
		{
			return false;
		}
		if (!worldBounds.Contains(vPos))
		{
			return false;
		}
		if (TerrainMeta.Terrain != null)
		{
			if (World.Procedural && vPos.y < TerrainMeta.Position.y)
			{
				return false;
			}
			if (TerrainMeta.OutOfMargin(vPos))
			{
				return false;
			}
		}
		return true;
	}

	internal bool IsInsideOuterBounds(Vector3 vPos)
	{
		if (vPos.IsNaNOrInfinity())
		{
			return false;
		}
		if (!new Bounds(worldBounds.center, new Vector3(worldBounds.size.x + TutorialIsland.TutorialBoundsSize * 2f, worldBounds.size.y, worldBounds.size.z + TutorialIsland.TutorialBoundsSize * 2f)).Contains(vPos))
		{
			return false;
		}
		if (TerrainMeta.Terrain != null)
		{
			if (World.Procedural && vPos.y < TerrainMeta.Position.y)
			{
				return false;
			}
			if (TerrainMeta.OutOfMarginPlusTutorialBounds(vPos))
			{
				return false;
			}
		}
		return true;
	}

	public static float GetMaximumPointTutorial()
	{
		if (SingletonComponent<ValidBounds>.Instance == null)
		{
			return 0f;
		}
		return Mathf.Min(TerrainMeta.Position.x + TerrainMeta.Size.x * 2f + TutorialIsland.TutorialBoundsSize, SingletonComponent<ValidBounds>.Instance.worldBounds.extents.x + TutorialIsland.TutorialBoundsSize);
	}

	public static float GetMaximumPoint()
	{
		if (SingletonComponent<ValidBounds>.Instance == null)
		{
			return 0f;
		}
		float num = SingletonComponent<ValidBounds>.Instance.worldBounds.max.x;
		if (TerrainMeta.Terrain != null)
		{
			num = Mathf.Min(TerrainMeta.Position.x + TerrainMeta.Size.x, num);
		}
		return num;
	}

	internal float DistToWorldEdge2D(Vector3 vPos)
	{
		if (!IsInsideInnerBounds(vPos))
		{
			return -1f;
		}
		float num = BoundsEx.InnerDistToEdge2D(worldBounds, vPos);
		if (TerrainMeta.Terrain != null)
		{
			float b = TerrainMeta.InnerDistToEdge2D(vPos);
			return Mathf.Min(num, b);
		}
		return num;
	}
}
