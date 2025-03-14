using System.Collections.Generic;
using Facepunch;
using Network;
using UnityEngine;

public class JunkPile : BaseEntity
{
	public GameObjectRef sinkEffect;

	public SpawnGroup[] spawngroups;

	public NPCSpawner NPCSpawn;

	private const float lifetimeMinutes = 30f;

	protected bool isSinking;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("JunkPile.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(TimeOut, 1800f);
		InvokeRepeating(CheckEmpty, 10f, 30f);
		Invoke(SpawnInitial, 1f);
		isSinking = false;
	}

	private void SpawnInitial()
	{
		SpawnGroup[] array = spawngroups;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SpawnInitial();
		}
	}

	public bool SpawnGroupsEmpty()
	{
		SpawnGroup[] array = spawngroups;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].currentPopulation > 0)
			{
				return false;
			}
		}
		if (NPCSpawn != null && NPCSpawn.currentPopulation > 0)
		{
			return false;
		}
		return true;
	}

	public void CheckEmpty()
	{
		if (SpawnGroupsEmpty() && !PlayersNearby())
		{
			CancelInvoke(CheckEmpty);
			SinkAndDestroy();
		}
	}

	public bool PlayersNearby()
	{
		List<BasePlayer> obj = Pool.GetList<BasePlayer>();
		Vis.Entities(base.transform.position, TimeoutPlayerCheckRadius(), obj, 131072);
		bool result = false;
		foreach (BasePlayer item in obj)
		{
			if (!item.IsSleeping() && item.IsAlive() && !(item is HumanNPC))
			{
				result = true;
				break;
			}
		}
		Pool.FreeList(ref obj);
		return result;
	}

	public virtual float TimeoutPlayerCheckRadius()
	{
		return 15f;
	}

	public void TimeOut()
	{
		if (PlayersNearby())
		{
			Invoke(TimeOut, 30f);
			return;
		}
		SpawnGroupsEmpty();
		SinkAndDestroy();
	}

	public void SinkAndDestroy()
	{
		CancelInvoke(SinkAndDestroy);
		SpawnGroup[] array = spawngroups;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Clear();
		}
		SetFlag(Flags.Reserved8, b: true, recursive: true);
		if (NPCSpawn != null)
		{
			NPCSpawn.Clear();
		}
		ClientRPC(null, "CLIENT_StartSink");
		base.transform.position -= new Vector3(0f, 5f, 0f);
		isSinking = true;
		Invoke(KillMe, 22f);
	}

	public void KillMe()
	{
		Kill();
	}
}
