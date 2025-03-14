using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Skin Set Collection")]
public class SkinSetCollection : ScriptableObject
{
	public SkinSet[] Skins;

	public int GetIndex(float MeshNumber)
	{
		return Mathf.Clamp(Mathf.FloorToInt(MeshNumber * (float)Skins.Length), 0, Skins.Length - 1);
	}

	public SkinSet Get(float MeshNumber)
	{
		return Skins[GetIndex(MeshNumber)];
	}
}
