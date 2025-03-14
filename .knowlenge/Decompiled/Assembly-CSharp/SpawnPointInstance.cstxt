using Rust;
using UnityEngine;

public class SpawnPointInstance : MonoBehaviour
{
	internal BaseEntity Entity;

	public ISpawnPointUser parentSpawnPointUser;

	public BaseSpawnPoint parentSpawnPoint;

	public void Notify()
	{
		if (!ObjectEx.IsUnityNull(parentSpawnPointUser))
		{
			parentSpawnPointUser.ObjectSpawned(this);
		}
		if ((bool)parentSpawnPoint)
		{
			parentSpawnPoint.ObjectSpawned(this);
		}
	}

	public void Retire()
	{
		if (!ObjectEx.IsUnityNull(parentSpawnPointUser))
		{
			parentSpawnPointUser.ObjectRetired(this);
		}
		if ((bool)parentSpawnPoint)
		{
			parentSpawnPoint.ObjectRetired(this);
		}
	}

	protected void OnDestroy()
	{
		if (!Rust.Application.isQuitting)
		{
			Retire();
		}
	}
}
