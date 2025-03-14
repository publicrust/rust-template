using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Building Grade")]
public class BuildingGrade : ScriptableObject
{
	public enum Enum
	{
		None = -1,
		Twigs,
		Wood,
		Stone,
		Metal,
		TopTier,
		Count
	}

	public Enum type;

	public float baseHealth;

	public List<ItemAmount> baseCost;

	public PhysicMaterial physicMaterial;

	public ProtectionProperties damageProtecton;

	public BaseEntity.Menu.Option upgradeMenu;
}
