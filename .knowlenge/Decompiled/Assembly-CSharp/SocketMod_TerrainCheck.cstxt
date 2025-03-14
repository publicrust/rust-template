using UnityEngine;

public class SocketMod_TerrainCheck : SocketMod
{
	public bool wantsInTerrain = true;

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		bool flag = IsInTerrain(base.transform.position);
		if (!wantsInTerrain)
		{
			flag = !flag;
		}
		Gizmos.color = (flag ? Color.green : Color.red);
		Gizmos.DrawSphere(Vector3.zero, 0.1f);
	}

	public static bool IsInTerrain(Vector3 vPoint)
	{
		if (TerrainMeta.OutOfBounds(vPoint))
		{
			return false;
		}
		if (!TerrainMeta.Collision || !TerrainMeta.Collision.GetIgnore(vPoint))
		{
			Terrain[] activeTerrains = Terrain.activeTerrains;
			foreach (Terrain terrain in activeTerrains)
			{
				if (terrain.SampleHeight(vPoint) + terrain.transform.position.y > vPoint.y)
				{
					return true;
				}
			}
		}
		if (Physics.Raycast(new Ray(vPoint + Vector3.up * 3f, Vector3.down), 3f, 65536))
		{
			return true;
		}
		return false;
	}

	public override bool DoCheck(Construction.Placement place)
	{
		if (IsInTerrain(place.position + place.rotation * worldPosition) == wantsInTerrain)
		{
			return true;
		}
		Construction.lastPlacementError = fullName + ": not in terrain";
		return false;
	}
}
