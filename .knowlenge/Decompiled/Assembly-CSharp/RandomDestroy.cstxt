using UnityEngine;

public class RandomDestroy : MonoBehaviour
{
	public uint Seed;

	public float Probability = 0.5f;

	protected void Start()
	{
		uint seed = base.transform.position.Seed(World.Seed + Seed);
		if (SeedRandom.Value(ref seed) > Probability)
		{
			GameManager.Destroy(this);
		}
		else
		{
			GameManager.Destroy(base.gameObject);
		}
	}
}
