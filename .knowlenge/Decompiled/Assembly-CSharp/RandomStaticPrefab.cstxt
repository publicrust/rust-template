using UnityEngine;

public class RandomStaticPrefab : MonoBehaviour
{
	public uint Seed;

	public float Probability = 0.5f;

	public string ResourceFolder = string.Empty;

	protected void Start()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		uint seed = SeedEx.Seed(((Component)this).transform.position, World.Seed + Seed);
		if (SeedRandom.Value(ref seed) > Probability)
		{
			GameManager.Destroy((Component)(object)this);
			return;
		}
		Prefab.LoadRandom("assets/bundled/prefabs/autospawn/" + ResourceFolder, ref seed).Spawn(((Component)this).transform);
		GameManager.Destroy((Component)(object)this);
	}
}
