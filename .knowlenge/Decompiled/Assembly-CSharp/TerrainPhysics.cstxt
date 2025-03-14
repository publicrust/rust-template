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
		return materials[splat.GetSplatMaxIndex(worldPos)];
	}
}
