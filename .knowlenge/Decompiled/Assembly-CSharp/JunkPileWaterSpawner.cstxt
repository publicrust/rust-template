using UnityEngine;

public class JunkPileWaterSpawner : SpawnGroup
{
	public BaseEntity attachToParent;

	protected override void PostSpawnProcess(BaseEntity entity, BaseSpawnPoint spawnPoint)
	{
		base.PostSpawnProcess(entity, spawnPoint);
		if ((Object)(object)attachToParent != (Object)null)
		{
			entity.SetParent(attachToParent, worldPositionStays: true);
		}
	}
}
