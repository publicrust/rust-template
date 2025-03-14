using UnityEngine;

public class RandomStaticPrefab : MonoBehaviour
{
	public uint Seed;

	public float Probability = 0.5f;

	public string ResourceFolder = string.Empty;

	protected void Start()
	{
		uint seed = base.transform.position.Seed(World.Seed + Seed);
		if (SeedRandom.Value(ref seed) > Probability)
		{
			GameManager.Destroy(this);
			return;
		}
		Prefab.LoadRandom("assets/bundled/prefabs/autospawn/" + ResourceFolder, ref seed).Spawn(base.transform);
		GameManager.Destroy(this);
	}
}
