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

	public ulong skin;

	public bool enabledInStandalone;

	[Tooltip("Will bypass the inventory check if this is enabled, allowing anyone to craft this item, enabledInStandalone will still need to be true")]
	public bool alwaysUnlock;

	public float baseHealth;

	public List<ItemAmount> baseCost;

	public PhysicMaterial physicMaterial;

	public ProtectionProperties damageProtecton;

	public bool supportsColourChange;

	public BaseEntity.Menu.Option upgradeMenu;
}
