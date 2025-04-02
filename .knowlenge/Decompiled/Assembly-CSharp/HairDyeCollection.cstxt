using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Hair Dye Collection")]
public class HairDyeCollection : ScriptableObject
{
	public Texture capMask;

	public bool applyCap;

	public HairDye[] Variations;

	public HairDye Get(float seed)
	{
		if (Variations.Length != 0)
		{
			return Variations[Mathf.Clamp(Mathf.FloorToInt(seed * (float)Variations.Length), 0, Variations.Length - 1)];
		}
		return null;
	}
}
