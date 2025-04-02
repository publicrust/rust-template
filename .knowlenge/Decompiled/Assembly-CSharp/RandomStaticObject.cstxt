using UnityEngine;

public class RandomStaticObject : MonoBehaviour
{
	public uint Seed;

	public float Probability = 0.5f;

	public GameObject[] Candidates;

	protected void Start()
	{
		uint seed = base.transform.position.Seed(World.Seed + Seed);
		if (SeedRandom.Value(ref seed) > Probability)
		{
			for (int i = 0; i < Candidates.Length; i++)
			{
				GameManager.Destroy(Candidates[i]);
			}
			GameManager.Destroy(this);
			return;
		}
		int num = SeedRandom.Range(seed, 0, base.transform.childCount);
		for (int j = 0; j < Candidates.Length; j++)
		{
			GameObject gameObject = Candidates[j];
			if (j == num)
			{
				gameObject.SetActive(value: true);
			}
			else
			{
				GameManager.Destroy(gameObject);
			}
		}
		GameManager.Destroy(this);
	}
}
