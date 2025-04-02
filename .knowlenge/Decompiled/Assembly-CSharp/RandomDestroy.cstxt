using UnityEngine;

public class RandomDestroy : MonoBehaviour
{
	public uint Seed;

	public float Probability = 0.5f;

	protected void Start()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		uint num = SeedEx.Seed(((Component)this).transform.position, World.Seed + Seed);
		if (SeedRandom.Value(ref num) > Probability)
		{
			GameManager.Destroy((Component)(object)this);
		}
		else
		{
			GameManager.Destroy(((Component)this).gameObject);
		}
	}
}
