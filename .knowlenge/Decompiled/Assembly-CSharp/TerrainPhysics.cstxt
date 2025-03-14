using UnityEngine;

public class TerrainPhysics : TerrainExtension
{
	private TerrainSplatMap splat;

	private PhysicMaterial[] materials;

	public override void Setup()
	{
		splat = terrain.GetComponent<TerrainSplatMap>();
		materials = config.GetPhysicMaterials();
	}

	public PhysicMaterial GetMaterial(Vector3 worldPos)
	{
		if (splat == null || materials.Length == 0)
		{
			return null;
		}
		return materials[splat.GetSplatMaxIndex(worldPos)];
	}
}
