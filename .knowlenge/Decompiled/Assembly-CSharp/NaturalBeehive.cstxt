using UnityEngine;

public class NaturalBeehive : LootContainer
{
	public GameObjectRef beeSwarmPrefab;

	public override void OnDied(HitInfo info)
	{
		SpawnSwarm();
		base.OnDied(info);
	}

	private void SpawnSwarm()
	{
		BaseEntity baseEntity = GameManager.server.CreateEntity(beeSwarmPrefab.resourcePath, base.transform.position, Quaternion.identity);
		BeeSwarmAI beeSwarmAI = baseEntity as BeeSwarmAI;
		if ((bool)beeSwarmAI)
		{
			beeSwarmAI.SetHasCameFromAHive(cameFromHive: true);
		}
		baseEntity.Spawn();
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.fromDisk && base.isServer)
		{
			Kill();
		}
	}

	public override float BoundsPadding()
	{
		return 1f;
	}
}
