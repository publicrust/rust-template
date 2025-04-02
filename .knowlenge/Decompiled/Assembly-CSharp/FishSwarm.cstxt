using System.Collections;
using UnityEngine;

public class FishSwarm : MonoBehaviour
{
	public FishShoal.FishType[] fishTypes;

	public FishShoal[] fishShoals;

	private void Awake()
	{
		fishShoals = new FishShoal[fishTypes.Length];
		for (int i = 0; i < fishTypes.Length; i++)
		{
			fishShoals[i] = new FishShoal(fishTypes[i]);
		}
		StartCoroutine(SpawnFish());
	}

	private IEnumerator SpawnFish()
	{
		while (true)
		{
			yield return CoroutineEx.waitForEndOfFrame;
			if ((bool)TerrainMeta.WaterMap && (bool)TerrainMeta.HeightMap)
			{
				FishShoal[] array = fishShoals;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].TrySpawn(base.transform.position);
					yield return CoroutineEx.waitForEndOfFrame;
				}
			}
		}
	}

	private void Update()
	{
		FishShoal[] array = fishShoals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnUpdate(base.transform.position);
		}
	}

	private void LateUpdate()
	{
		FishShoal[] array = fishShoals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnLateUpdate(base.transform.position);
		}
	}

	private void OnDestroy()
	{
		FishShoal[] array = fishShoals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Dispose();
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(base.transform.position, 15f);
		Gizmos.DrawWireSphere(base.transform.position, 40f);
		if (Application.isPlaying)
		{
			FishShoal[] array = fishShoals;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnDrawGizmosSelected();
			}
		}
	}
}
