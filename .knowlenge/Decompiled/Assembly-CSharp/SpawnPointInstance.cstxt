using Rust;
using UnityEngine;

public class SpawnPointInstance : MonoBehaviour
{
	public SpawnGroup parentSpawnGroup;

	public BaseSpawnPoint parentSpawnPoint;

	public void Notify()
	{
		if ((bool)parentSpawnGroup)
		{
			parentSpawnGroup.ObjectSpawned(this);
		}
		if ((bool)parentSpawnPoint)
		{
			parentSpawnPoint.ObjectSpawned(this);
		}
	}

	protected void OnDestroy()
	{
		if (!Rust.Application.isQuitting)
		{
			if ((bool)parentSpawnGroup)
			{
				parentSpawnGroup.ObjectRetired(this);
			}
			if ((bool)parentSpawnPoint)
			{
				parentSpawnPoint.ObjectRetired(this);
			}
		}
	}
}
