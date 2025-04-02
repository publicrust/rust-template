using UnityEngine;

public class RandomStaticObject : MonoBehaviour
{
	public uint Seed;

	public float Probability = 0.5f;

	public GameObject[] Candidates;

	protected void Start()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		uint num = SeedEx.Seed(((Component)this).transform.position, World.Seed + Seed);
		if (SeedRandom.Value(ref num) > Probability)
		{
			for (int i = 0; i < Candidates.Length; i++)
			{
				GameManager.Destroy(Candidates[i]);
			}
			GameManager.Destroy((Component)(object)this);
			return;
		}
		int num2 = SeedRandom.Range(num, 0, ((Component)this).transform.childCount);
		for (int j = 0; j < Candidates.Length; j++)
		{
			GameObject val = Candidates[j];
			if (j == num2)
			{
				val.SetActive(true);
			}
			else
			{
				GameManager.Destroy(val);
			}
		}
		GameManager.Destroy((Component)(object)this);
	}
}
