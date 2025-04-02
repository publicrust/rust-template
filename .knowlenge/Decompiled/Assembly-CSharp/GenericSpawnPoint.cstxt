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
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		if (!randomRot)
		{
			return Quaternion.identity;
		}
		int num = Mathf.FloorToInt(360f / randomRotSnapDegrees);
		int num2 = Random.Range(0, num);
		return Quaternion.Euler(0f, (float)num2 * randomRotSnapDegrees, 0f);
	}

	public override void GetLocation(out Vector3 pos, out Quaternion rot)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		pos = ((Component)this).transform.position;
		if (randomRot)
		{
			rot = ((Component)this).transform.rotation * GetRandomRotation();
		}
		else
		{
			rot = ((Component)this).transform.rotation;
		}
		if (dropToGround)
		{
			DropToGround(ref pos, ref rot);
		}
	}

	public override void ObjectSpawned(SpawnPointInstance instance)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (spawnEffect.isValid)
		{
			Effect.server.Run(spawnEffect.resourcePath, ((Component)instance).GetComponent<BaseEntity>(), 0u, Vector3.zero, Vector3.up);
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
