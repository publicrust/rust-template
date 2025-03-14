public class JunkPileWaterSpawner : SpawnGroup
{
	public BaseEntity attachToParent;

	protected override void PostSpawnProcess(BaseEntity entity, BaseSpawnPoint spawnPoint)
	{
		base.PostSpawnProcess(entity, spawnPoint);
		if (attachToParent != null)
		{
			entity.SetParent(attachToParent, worldPositionStays: true);
		}
	}
}
