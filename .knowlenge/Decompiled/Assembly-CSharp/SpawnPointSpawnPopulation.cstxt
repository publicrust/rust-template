using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Spawn Point Spawn Population")]
public class SpawnPointSpawnPopulation : SpawnPopulationBase
{
	[SerializeField]
	private BaseSpawnPoint.SpawnPointType spawnPointType;

	private SpawnFilter Filter = new SpawnFilter();

	public override void SubFill(SpawnHandler spawnHandler, SpawnDistribution distribution, int numToFill, bool initialSpawn)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (numToFill == 0)
		{
			return;
		}
		if (!TryGetSpawnPoints(out var result))
		{
			Debug.LogWarning((object)(((Object)this).name + " couldn't find any spawn points of type: " + spawnPointType), (Object)(object)this);
			return;
		}
		foreach (BaseSpawnPoint item in result)
		{
			Prefab<Spawnable> prefab = Prefabs[Random.Range(0, Prefabs.Length)];
			if ((Object)(object)item != (Object)null && item.IsAvailableTo(prefab.Object))
			{
				item.GetLocation(out var pos, out var rot);
				spawnHandler.Spawn(this, prefab, pos, rot);
				numToFill--;
				if (numToFill == 0)
				{
					break;
				}
			}
		}
	}

	public override byte[] GetBaseMapValues(int populationRes)
	{
		return new byte[0];
	}

	public override SpawnFilter GetSpawnFilter()
	{
		return Filter;
	}

	public override int GetTargetCount(SpawnDistribution distribution)
	{
		if (TryGetSpawnPoints(out var result))
		{
			return result.Count;
		}
		return 0;
	}

	private bool TryGetSpawnPoints(out List<BaseSpawnPoint> result)
	{
		return BaseSpawnPoint.spawnPoints.TryGetValue(spawnPointType, out result);
	}
}
