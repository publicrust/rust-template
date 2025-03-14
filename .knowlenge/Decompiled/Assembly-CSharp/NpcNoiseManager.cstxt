using System.Collections.Concurrent;
using System.Collections.Generic;
using Facepunch;
using Spatial;
using UnityEngine;

public class NpcNoiseManager : SingletonComponent<NpcNoiseManager>, IServerComponent
{
	private const float voiceChatEventMaxAge = 1f;

	private const float noiseMaxAge = 10f;

	private const float worldSize = 8096f;

	private const int cellSize = 32;

	private ConcurrentDictionary<BasePlayer, double> recentVoiceChatEvents = new ConcurrentDictionary<BasePlayer, double>();

	private Grid<NpcNoiseEvent> noiseGrid = new Grid<NpcNoiseEvent>(32, 8096f);

	private Queue<NpcNoiseEvent> noises = new Queue<NpcNoiseEvent>();

	private double nextTickTime;

	public void AddNoise(BaseEntity initiator, Vector3 position, NpcNoiseIntensity intensity)
	{
		if (!IsInvoking(RemoveOldNoises))
		{
			InvokeRepeating(RemoveOldNoises, 0f, 0f);
		}
		NpcNoiseEvent npcNoiseEvent = Pool.Get<NpcNoiseEvent>();
		npcNoiseEvent.Initiator = initiator;
		npcNoiseEvent.Position = position;
		npcNoiseEvent.Intensity = intensity;
		npcNoiseEvent.EventTime = Time.timeAsDouble;
		noiseGrid.Add(npcNoiseEvent, npcNoiseEvent.Position.x, npcNoiseEvent.Position.z);
		noises.Enqueue(npcNoiseEvent);
	}

	private void RemoveOldNoises()
	{
		using (TimeWarning.New("RemoveOldNoises"))
		{
			while (noises.Count > 0)
			{
				NpcNoiseEvent obj = noises.Peek();
				if (Time.timeAsDouble - obj.EventTime <= 10.0)
				{
					break;
				}
				noises.Dequeue();
				noiseGrid.Remove(obj);
				Pool.Free(ref obj);
			}
		}
	}

	public void GetNoisesAround(Vector3 position, float range, List<NpcNoiseEvent> results)
	{
		if (noiseGrid != null)
		{
			noiseGrid.Query(position.x, position.z, range, results);
		}
	}

	public void OnServerProjectileHit(BaseEntity entity, ServerProjectile projectile, RaycastHit hit)
	{
		AddNoise(entity, projectile.transform.position, NpcNoiseIntensity.High);
	}

	public void OnProjectileHit(BaseEntity entity, HitInfo hit)
	{
		AddNoise(entity, hit.HitPositionWorld, (hit.Weapon is BowWeapon || hit.Weapon is BaseMelee) ? NpcNoiseIntensity.Medium : NpcNoiseIntensity.High);
	}

	public void OnWeaponShot(BasePlayer player, BaseProjectile weapon)
	{
		AddNoise(player, player.transform.position, (weapon is BowWeapon) ? NpcNoiseIntensity.Low : NpcNoiseIntensity.High);
	}

	public void OnWeaponThrown(BasePlayer player, BaseMelee weapon, bool canAiHearIt)
	{
		if (canAiHearIt)
		{
			AddNoise(player, player.transform.position, NpcNoiseIntensity.Low);
		}
	}

	public void OnVoiceChat(BasePlayer player)
	{
		recentVoiceChatEvents[player] = Time.timeAsDouble;
	}

	public bool HasPlayerSpokenNear(BaseEntity querier, BasePlayer targetPlayer, float maxDistance = 16f)
	{
		using (TimeWarning.New("NpcNoiseManager.HasPlayerSpokenNear"))
		{
			double value;
			return recentVoiceChatEvents.TryGetValue(targetPlayer, out value) && Vector3.Distance(querier.transform.position, targetPlayer.transform.position) <= maxDistance;
		}
	}

	public void Tick()
	{
		if (Time.timeAsDouble < nextTickTime)
		{
			return;
		}
		nextTickTime = Time.timeAsDouble + (double)Random.Range(4f, 6f);
		using (TimeWarning.New("NpcNoiseManager.RemoveStaleEntries"))
		{
			using PooledList<BasePlayer> pooledList = Pool.Get<PooledList<BasePlayer>>();
			double value;
			foreach (KeyValuePair<BasePlayer, double> recentVoiceChatEvent in recentVoiceChatEvents)
			{
				recentVoiceChatEvent.Deconstruct(out var key, out value);
				BasePlayer basePlayer = key;
				double num = value;
				if (!basePlayer.IsValid() || Time.timeAsDouble - num > 1.0)
				{
					pooledList.Add(basePlayer);
				}
			}
			foreach (BasePlayer item in pooledList)
			{
				recentVoiceChatEvents.Remove(item, out value);
			}
		}
	}
}
