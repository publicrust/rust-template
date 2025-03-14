using UnityEngine;

public class Gib : ListComponent<Gib>
{
	public static int gibCount;

	public MeshFilter _meshFilter;

	public MeshRenderer _meshRenderer;

	public MeshCollider _meshCollider;

	public BoxCollider _boxCollider;

	public SphereCollider _sphereCollider;

	public CapsuleCollider _capsuleCollider;

	public Rigidbody _rigidbody;

	public static string GetEffect(PhysicMaterial physicMaterial)
	{
		return AssetNameCache.GetNameLower(physicMaterial) switch
		{
			"wood" => "assets/bundled/prefabs/fx/building/wood_gib.prefab", 
			"concrete" => "assets/bundled/prefabs/fx/building/stone_gib.prefab", 
			"metal" => "assets/bundled/prefabs/fx/building/metal_sheet_gib.prefab", 
			"rock" => "assets/bundled/prefabs/fx/building/stone_gib.prefab", 
			"flesh" => "assets/bundled/prefabs/fx/building/wood_gib.prefab", 
			_ => "assets/bundled/prefabs/fx/building/wood_gib.prefab", 
		};
	}
}
