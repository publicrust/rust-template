using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class EggHuntEvent : BaseHuntEvent
{
	public class EggHunter
	{
		public ulong userid;

		public string displayName;

		public int numEggs;
	}

	public float warmupTime = 10f;

	public float cooldownTime = 10f;

	public float warnTime = 20f;

	public float timeAlive;

	public static EggHuntEvent serverEvent = null;

	public static EggHuntEvent clientEvent = null;

	[NonSerialized]
	public static float durationSeconds = 180f;

	private Dictionary<ulong, EggHunter> _eggHunters = new Dictionary<ulong, EggHunter>();

	public List<CollectableEasterEgg> _spawnedEggs = new List<CollectableEasterEgg>();

	public ItemAmount[] placementAwards;

	public bool IsEventActive()
	{
		if (timeAlive > warmupTime)
		{
			return timeAlive - warmupTime < durationSeconds;
		}
		return false;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if ((bool)serverEvent && base.isServer)
		{
			serverEvent.Kill();
			serverEvent = null;
		}
		serverEvent = this;
		Invoke(StartEvent, warmupTime);
	}

	public void StartEvent()
	{
		SpawnEggs();
	}

	public void SpawnEggsAtPoint(int numEggs, Vector3 pos, Vector3 aimDir, float minDist = 1f, float maxDist = 2f)
	{
		for (int i = 0; i < numEggs; i++)
		{
			Vector3 vector = pos;
			aimDir = ((!(aimDir == Vector3.zero)) ? AimConeUtil.GetModifiedAimConeDirection(90f, aimDir) : UnityEngine.Random.onUnitSphere);
			vector = pos + Vector3Ex.Direction2D(pos + aimDir * 10f, pos) * UnityEngine.Random.Range(minDist, maxDist);
			vector.y = TerrainMeta.HeightMap.GetHeight(vector);
			CollectableEasterEgg collectableEasterEgg = GameManager.server.CreateEntity(HuntablePrefab[UnityEngine.Random.Range(0, HuntablePrefab.Length)].resourcePath, vector) as CollectableEasterEgg;
			collectableEasterEgg.Spawn();
			_spawnedEggs.Add(collectableEasterEgg);
		}
	}

	[ContextMenu("SpawnDebug")]
	public void SpawnEggs()
	{
		foreach (BasePlayer activePlayer in BasePlayer.activePlayerList)
		{
			SpawnEggsAtPoint(UnityEngine.Random.Range(4, 6) + Mathf.RoundToInt(activePlayer.eggVision), activePlayer.transform.position, activePlayer.eyes.BodyForward(), 15f, 25f);
		}
	}

	public void RandPickup()
	{
		foreach (BasePlayer activePlayer in BasePlayer.activePlayerList)
		{
			_ = activePlayer;
		}
	}

	public void EggCollected(BasePlayer player)
	{
		EggHunter eggHunter = null;
		if (_eggHunters.ContainsKey(player.userID))
		{
			eggHunter = _eggHunters[player.userID];
		}
		else
		{
			eggHunter = new EggHunter();
			eggHunter.displayName = player.displayName;
			eggHunter.userid = player.userID;
			_eggHunters.Add(player.userID, eggHunter);
		}
		if (eggHunter == null)
		{
			Debug.LogWarning("Easter error");
			return;
		}
		eggHunter.numEggs++;
		QueueUpdate();
		int num = ((!((float)Mathf.RoundToInt(player.eggVision) * 0.5f < 1f)) ? 1 : UnityEngine.Random.Range(0, 2));
		SpawnEggsAtPoint(UnityEngine.Random.Range(1 + num, 2 + num), player.transform.position, player.eyes.BodyForward(), 15f, 25f);
	}

	public void QueueUpdate()
	{
		if (!IsInvoking(DoNetworkUpdate))
		{
			Invoke(DoNetworkUpdate, 2f);
		}
	}

	public void DoNetworkUpdate()
	{
		SendNetworkUpdate();
	}

	public static void Sort(List<EggHunter> hunterList)
	{
		hunterList.Sort((EggHunter a, EggHunter b) => b.numEggs.CompareTo(a.numEggs));
	}

	public List<EggHunter> GetTopHunters()
	{
		List<EggHunter> list = Facepunch.Pool.GetList<EggHunter>();
		foreach (KeyValuePair<ulong, EggHunter> eggHunter in _eggHunters)
		{
			list.Add(eggHunter.Value);
		}
		Sort(list);
		return list;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.eggHunt = Facepunch.Pool.Get<EggHunt>();
		List<EggHunter> topHunters = GetTopHunters();
		info.msg.eggHunt.hunters = Facepunch.Pool.GetList<EggHunt.EggHunter>();
		for (int i = 0; i < Mathf.Min(10, topHunters.Count); i++)
		{
			EggHunt.EggHunter eggHunter = Facepunch.Pool.Get<EggHunt.EggHunter>();
			eggHunter.displayName = topHunters[i].displayName;
			eggHunter.numEggs = topHunters[i].numEggs;
			eggHunter.playerID = topHunters[i].userid;
			info.msg.eggHunt.hunters.Add(eggHunter);
		}
	}

	public void CleanupEggs()
	{
		foreach (CollectableEasterEgg spawnedEgg in _spawnedEggs)
		{
			if (spawnedEgg != null)
			{
				spawnedEgg.Kill();
			}
		}
	}

	public void Cooldown()
	{
		CancelInvoke(Cooldown);
		Kill();
	}

	public virtual void PrintWinnersAndAward()
	{
		List<EggHunter> topHunters = GetTopHunters();
		if (topHunters.Count > 0)
		{
			EggHunter eggHunter = topHunters[0];
			Chat.Broadcast(eggHunter.displayName + " is the top bunny with " + eggHunter.numEggs + " eggs collected.", "", "#eee", 0uL);
			for (int i = 0; i < topHunters.Count; i++)
			{
				EggHunter eggHunter2 = topHunters[i];
				BasePlayer basePlayer = BasePlayer.FindByID(eggHunter2.userid);
				if ((bool)basePlayer)
				{
					basePlayer.ChatMessage("You placed " + (i + 1) + " of " + topHunters.Count + " with " + topHunters[i].numEggs + " eggs collected.");
				}
				else
				{
					Debug.LogWarning("EggHuntEvent Printwinners could not find player with id :" + eggHunter2.userid);
				}
			}
			for (int j = 0; j < placementAwards.Length && j < topHunters.Count; j++)
			{
				BasePlayer basePlayer2 = BasePlayer.FindByID(topHunters[j].userid);
				if ((bool)basePlayer2)
				{
					basePlayer2.inventory.GiveItem(ItemManager.Create(placementAwards[j].itemDef, (int)placementAwards[j].amount, 0uL), basePlayer2.inventory.containerMain);
					basePlayer2.ChatMessage("You received " + (int)placementAwards[j].amount + "x " + placementAwards[j].itemDef.displayName.english + " as an award!");
				}
			}
		}
		else
		{
			Chat.Broadcast("Wow, no one played so no one won.", "", "#eee", 0uL);
		}
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		if (base.isServer)
		{
			serverEvent = null;
		}
		else
		{
			clientEvent = null;
		}
	}

	public void Update()
	{
		timeAlive += UnityEngine.Time.deltaTime;
		if (base.isServer && !base.IsDestroyed)
		{
			if (timeAlive - warmupTime > durationSeconds - warnTime)
			{
				SetFlag(Flags.Reserved1, b: true);
			}
			if (timeAlive - warmupTime > durationSeconds && !IsInvoking(Cooldown))
			{
				SetFlag(Flags.Reserved2, b: true);
				CleanupEggs();
				PrintWinnersAndAward();
				Invoke(Cooldown, 10f);
			}
		}
	}

	public float GetTimeRemaining()
	{
		float num = durationSeconds - timeAlive;
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}
}
