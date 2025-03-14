using UnityEngine;
using UnityEngine.Events;

public class GenericSpawnPoint : BaseSpawnPoint
{
	public bool dropToGround = true;

	public bool randomRot;

	[Range(1f, 180f)]
	public float randomRotSnapDegrees = 1f;

	public GameObjectRef spawnEffect;

	public UnityEvent OnObjectSpawnedEvent = new UnityEvent();

	public UnityEvent OnObjectRetiredEvent = new UnityEvent();

	public Quaternion GetRandomRotation()
	{
		if (!randomRot)
		{
			return Quaternion.identity;
		}
		int maxExclusive = Mathf.FloorToInt(360f / randomRotSnapDegrees);
		int num = Random.Range(0, maxExclusive);
		return Quaternion.Euler(0f, (float)num * randomRotSnapDegrees, 0f);
	}

	public override void GetLocation(out Vector3 pos, out Quaternion rot)
	{
		pos = base.transform.position;
		if (randomRot)
		{
			rot = base.transform.rotation * GetRandomRotation();
		}
		else
		{
			rot = base.transform.rotation;
		}
		if (dropToGround)
		{
			DropToGround(ref pos, ref rot);
		}
	}

	public override void ObjectSpawned(SpawnPointInstance instance)
	{
		if (spawnEffect.isValid)
		{
			Effect.server.Run(spawnEffect.resourcePath, instance.GetComponent<BaseEntity>(), 0u, Vector3.zero, Vector3.up);
		}
		OnObjectSpawnedEvent.Invoke();
		SetSpawningActive(newState: false);
	}

	public override void ObjectRetired(SpawnPointInstance instance)
	{
		OnObjectRetiredEvent.Invoke();
		SetSpawningActive(newState: true);
	}
}
