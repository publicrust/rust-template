using Facepunch;
using ProtoBuf;
using Rust;
using UnityEngine;

public class Spawnable : MonoBehaviour, IServerComponent
{
	[ReadOnly]
	public SpawnPopulationBase Population;

	[SerializeField]
	private bool ForceSpawnOnly;

	[SerializeField]
	private string ForceSpawnInfoMessage = string.Empty;

	internal bool SpawnIndividual;

	internal Vector3 SpawnPosition;

	internal Quaternion SpawnRotation;

	protected void OnEnable()
	{
		if (!Rust.Application.isLoadingSave)
		{
			Add();
		}
	}

	protected void OnDisable()
	{
		if (!Rust.Application.isQuitting && !Rust.Application.isLoadingSave)
		{
			Remove();
		}
	}

	private void Add()
	{
		SpawnPosition = base.transform.position;
		SpawnRotation = base.transform.rotation;
		if (!SingletonComponent<SpawnHandler>.Instance)
		{
			return;
		}
		if (Population != null)
		{
			SingletonComponent<SpawnHandler>.Instance.AddInstance(this);
		}
		else if (Rust.Application.isLoading && !Rust.Application.isLoadingSave)
		{
			BaseEntity component = GetComponent<BaseEntity>();
			if (component != null && component.enableSaving && !component.syncPosition)
			{
				SingletonComponent<SpawnHandler>.Instance.AddRespawn(new SpawnIndividual(component.prefabID, SpawnPosition, SpawnRotation));
			}
		}
	}

	private void Remove()
	{
		if ((bool)SingletonComponent<SpawnHandler>.Instance && Population != null)
		{
			SingletonComponent<SpawnHandler>.Instance.RemoveInstance(this);
		}
	}

	internal void Save(BaseNetworkable.SaveInfo info)
	{
		if (!(Population == null))
		{
			info.msg.spawnable = Pool.Get<ProtoBuf.Spawnable>();
			info.msg.spawnable.population = Population.FilenameStringId;
		}
	}

	internal void Load(BaseNetworkable.LoadInfo info)
	{
		if (info.msg.spawnable != null)
		{
			Population = FileSystem.Load<SpawnPopulationBase>(StringPool.Get(info.msg.spawnable.population));
		}
		Add();
	}

	protected void OnValidate()
	{
		Population = null;
	}
}
