using UnityEngine;

public class IndividualSpawner : BaseMonoBehaviour, IServerComponent, ISpawnPointUser, ISpawnGroup
{
	public GameObjectRef entityPrefab;

	public float respawnDelayMin = 10f;

	public float respawnDelayMax = 20f;

	public bool useCustomBoundsCheckMask;

	public LayerMask customBoundsCheckMask;

	[SerializeField]
	[Tooltip("Simply spawns the entity once. No respawning. Entity can be saved if desired.")]
	public bool oneTimeSpawner;

	internal bool isSpawnerActive = true;

	public SpawnPointInstance spawnInstance;

	public float nextSpawnTime = -1f;

	public int currentPopulation
	{
		get
		{
			if (!(spawnInstance == null))
			{
				return 1;
			}
			return 0;
		}
	}

	public bool IsSpawned => spawnInstance != null;

	protected void Awake()
	{
		if ((bool)SingletonComponent<SpawnHandler>.Instance)
		{
			SingletonComponent<SpawnHandler>.Instance.SpawnGroups.Add(this);
		}
		else
		{
			Debug.LogWarning(GetType().Name + ": SpawnHandler instance not found.");
		}
	}

	protected void OnDestroy()
	{
		if ((bool)SingletonComponent<SpawnHandler>.Instance)
		{
			SingletonComponent<SpawnHandler>.Instance.SpawnGroups.Remove(this);
		}
		else
		{
			Debug.LogWarning(GetType().Name + ": SpawnHandler instance not found.");
		}
	}

	protected void OnDrawGizmosSelected()
	{
		if (TryGetEntityBounds(out var result))
		{
			Gizmos.color = Color.yellow;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawCube(result.center, result.size);
		}
	}

	public void ObjectSpawned(SpawnPointInstance instance)
	{
		spawnInstance = instance;
	}

	public void ObjectRetired(SpawnPointInstance instance)
	{
		spawnInstance = null;
		nextSpawnTime = Time.time + Random.Range(respawnDelayMin, respawnDelayMax);
	}

	public void Fill()
	{
		if (!oneTimeSpawner)
		{
			TrySpawnEntity();
		}
	}

	public void SpawnInitial()
	{
		TrySpawnEntity();
	}

	public void Clear()
	{
		if (IsSpawned)
		{
			BaseEntity baseEntity = GameObjectEx.ToBaseEntity(spawnInstance.gameObject);
			if (baseEntity != null)
			{
				baseEntity.Kill();
			}
		}
	}

	public void SpawnRepeating()
	{
		if (!IsSpawned && !oneTimeSpawner && Time.time >= nextSpawnTime)
		{
			TrySpawnEntity();
		}
	}

	public bool HasSpaceToSpawn()
	{
		if (useCustomBoundsCheckMask)
		{
			return SpawnHandler.CheckBounds(entityPrefab.Get(), base.transform.position, base.transform.rotation, Vector3.one, customBoundsCheckMask);
		}
		return SingletonComponent<SpawnHandler>.Instance.CheckBounds(entityPrefab.Get(), base.transform.position, base.transform.rotation, Vector3.one);
	}

	public virtual void TrySpawnEntity()
	{
		if (!isSpawnerActive || IsSpawned)
		{
			return;
		}
		if (!HasSpaceToSpawn())
		{
			nextSpawnTime = Time.time + Random.Range(respawnDelayMin, respawnDelayMax);
			return;
		}
		BaseEntity baseEntity = GameManager.server.CreateEntity(entityPrefab.resourcePath, base.transform.position, base.transform.rotation, startActive: false);
		if (baseEntity != null)
		{
			if (!oneTimeSpawner)
			{
				baseEntity.enableSaving = false;
			}
			PoolableEx.AwakeFromInstantiate(baseEntity.gameObject);
			baseEntity.Spawn();
			SpawnPointInstance spawnPointInstance = baseEntity.gameObject.AddComponent<SpawnPointInstance>();
			spawnPointInstance.parentSpawnPointUser = this;
			spawnPointInstance.Notify();
		}
		else
		{
			Debug.LogError("IndividualSpawner failed to spawn entity.", base.gameObject);
		}
	}

	public bool TryGetEntityBounds(out Bounds result)
	{
		if (entityPrefab != null)
		{
			GameObject gameObject = entityPrefab.Get();
			if (gameObject != null)
			{
				BaseEntity component = gameObject.GetComponent<BaseEntity>();
				if (component != null)
				{
					result = component.bounds;
					return true;
				}
			}
		}
		result = default(Bounds);
		return false;
	}
}
