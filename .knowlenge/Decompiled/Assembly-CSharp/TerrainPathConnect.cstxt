using UnityEngine;

public class TerrainPathConnect : MonoBehaviour
{
	public InfrastructureType Type;

	public PathFinder.Point GetPathFinderPoint(int res, Vector3 worldPos)
	{
		float num = TerrainMeta.NormalizeX(worldPos.x);
		float num2 = TerrainMeta.NormalizeZ(worldPos.z);
		PathFinder.Point result = default(PathFinder.Point);
		result.x = Mathf.Clamp((int)(num * (float)res), 0, res - 1);
		result.y = Mathf.Clamp((int)(num2 * (float)res), 0, res - 1);
		return result;
	}

	public PathFinder.Point GetPathFinderPoint(int res)
	{
		return GetPathFinderPoint(res, base.transform.position);
	}
}
