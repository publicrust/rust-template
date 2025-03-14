using UnityEngine;

public class TerrainPathConnect : MonoBehaviour
{
	public InfrastructureType Type;

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
}
