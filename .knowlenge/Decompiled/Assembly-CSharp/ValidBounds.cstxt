using UnityEngine;

public class ValidBounds : SingletonComponent<ValidBounds>
{
	public Bounds worldBounds;

	public static bool Test(Vector3 vPos)
	{
		if (!SingletonComponent<ValidBounds>.Instance)
		{
			return true;
		}
		return SingletonComponent<ValidBounds>.Instance.IsInside(vPos);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(worldBounds.center, worldBounds.size);
	}

	internal bool IsInside(Vector3 vPos)
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
}
