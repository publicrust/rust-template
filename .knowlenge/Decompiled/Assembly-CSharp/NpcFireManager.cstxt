using System.Collections.Generic;
using Facepunch;
using Spatial;
using UnityEngine;

public class NpcFireManager : SingletonComponent<NpcFireManager>, IServerComponent
{
	private const float maxFireMeleeAge = 1f;

	private const float worldSize = 8096f;

	private const int cellSize = 32;

	private Grid<BaseEntity> fireGrid = new Grid<BaseEntity>(32, 8096f);

	private Dictionary<BaseEntity, double> recentFireMeleeEvents = new Dictionary<BaseEntity, double>();

	private double nextTickTime;

	public void Add(BaseEntity entity)
	{
		fireGrid.Add(entity, entity.transform.position.x, entity.transform.position.z);
	}

	public void Move(BaseEntity entity)
	{
		using (TimeWarning.New("NpcFireManager.Move"))
		{
			if (IsOnFire(entity))
			{
				Vector3 position = entity.transform.position;
				fireGrid.Move(entity, position.x, position.z);
			}
		}
	}

	public void Remove(BaseEntity entity)
	{
		fireGrid.Remove(entity);
	}

	public void GetFiresAround(Vector3 position, float range, List<BaseEntity> results)
	{
		using (TimeWarning.New("NpcFireManager.GetFiresAround"))
		{
			if (fireGrid != null)
			{
				fireGrid.Query(position.x, position.z, range, results);
			}
		}
	}

	public void OnReceivedSignalServer(BaseEntity entity, BaseEntity.Signal signal, string arg)
	{
		if (signal != 0)
		{
			return;
		}
		if (entity is HeldEntity heldEntity && IsOnFire(heldEntity))
		{
			BasePlayer ownerPlayer = heldEntity.GetOwnerPlayer();
			if (ownerPlayer != null)
			{
				recentFireMeleeEvents[ownerPlayer] = Time.timeAsDouble;
			}
		}
		if (entity is BasePlayer basePlayer && IsOnFire(basePlayer.GetHeldEntity()) && entity != null)
		{
			recentFireMeleeEvents[entity] = Time.timeAsDouble;
		}
	}

	public bool DidMeleeWithFireRecently(BaseEntity querier, BaseEntity target, out double meleeTime, float maxDistance = 10f)
	{
		using (TimeWarning.New("NpcFireManager.DidMeleeWithFireRecently"))
		{
			if (recentFireMeleeEvents.TryGetValue(target, out var value) && Vector3.Distance(querier.transform.position, target.transform.position) <= maxDistance)
			{
				meleeTime = value;
				return true;
			}
			meleeTime = 0.0;
			return false;
		}
	}

	public static bool IsOnFire(BaseEntity entity)
	{
		if (!entity.IsValid())
		{
			return false;
		}
		if (entity.IsOnFire())
		{
			return true;
		}
		if (entity is BaseOven baseOven && baseOven.IsOn() && baseOven.hasOpenFlame)
		{
			return true;
		}
		return false;
	}

	public void Tick()
	{
		if (Time.timeAsDouble < nextTickTime)
		{
			return;
		}
		nextTickTime = Time.timeAsDouble + (double)Random.Range(4f, 6f);
		using (TimeWarning.New("NpcFireManager.RemoveStaleEntries"))
		{
			using PooledList<BaseEntity> pooledList = Pool.Get<PooledList<BaseEntity>>();
			foreach (var (baseEntity2, num2) in recentFireMeleeEvents)
			{
				if (!baseEntity2.IsValid() || Time.timeAsDouble - num2 > 1.0)
				{
					pooledList.Add(baseEntity2);
				}
			}
			foreach (BaseEntity item in pooledList)
			{
				recentFireMeleeEvents.Remove(item);
			}
		}
	}
}
