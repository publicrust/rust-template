using System.Collections;
using Unity.Mathematics;
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
		((MonoBehaviour)this).StartCoroutine(SpawnFish());
	}

	private IEnumerator SpawnFish()
	{
		while (true)
		{
			yield return CoroutineEx.waitForEndOfFrame;
			if (Object.op_Implicit((Object)(object)TerrainMeta.WaterMap) && Object.op_Implicit((Object)(object)TerrainMeta.HeightMap))
			{
				FishShoal[] array = fishShoals;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].TrySpawn(float3.op_Implicit(((Component)this).transform.position));
					yield return CoroutineEx.waitForEndOfFrame;
				}
			}
		}
	}

	private void Update()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		FishShoal[] array = fishShoals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnUpdate(float3.op_Implicit(((Component)this).transform.position));
		}
	}

	private void LateUpdate()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		FishShoal[] array = fishShoals;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnLateUpdate(float3.op_Implicit(((Component)this).transform.position));
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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.DrawWireSphere(((Component)this).transform.position, 15f);
		Gizmos.DrawWireSphere(((Component)this).transform.position, 40f);
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
