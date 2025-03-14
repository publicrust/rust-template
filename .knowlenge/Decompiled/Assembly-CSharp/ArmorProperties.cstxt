using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Armor Properties")]
public class ArmorProperties : ScriptableObject
{
	[InspectorFlags]
	public HitArea area;

	public bool Contains(HitArea hitArea)
	{
		return (area & hitArea) != 0;
	}
}
