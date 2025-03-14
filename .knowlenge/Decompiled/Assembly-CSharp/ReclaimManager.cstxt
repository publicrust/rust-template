using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class ReclaimManager : BaseEntity
{
	public class PlayerReclaimEntry
	{
		public ulong killerID;

		public string killerString;

		public ulong victimID;

		public float timeAlive;

		public int id;

		public ItemContainer inventory;

		public void Init()
		{
			inventory = Pool.Get<ItemContainer>();
			inventory.entityOwner = instance;
			inventory.allowedContents = ItemContainer.ContentsType.Generic;
			inventory.SetOnlyAllowedItem(null);
			inventory.maxStackSize = 0;
			inventory.ServerInitialize(null, 40);
			inventory.canAcceptItem = null;
			inventory.GiveUID();
		}

		public void Cleanup()
		{
			timeAlive = 0f;
			killerID = 0uL;
			killerString = "";
			victimID = 0uL;
			id = -2;
			if (inventory != null)
			{
				inventory.Clear();
				Pool.Free(ref inventory);
			}
		}
	}

	private const int defaultReclaims = 128;

	private const int reclaimSlotCount = 40;

	private int lastReclaimID;

	[ServerVar]
	public static float reclaim_expire_minutes = 120f;

	private static ReclaimManager _instance;

	public List<PlayerReclaimEntry> entries = new List<PlayerReclaimEntry>();

	private float lastTickTime;

	public static ReclaimManager instance => _instance;

	public int AddPlayerReclaim(ulong victimID, List<Item> itemList, ulong killerID = 0uL, string killerString = "", int reclaimIDToUse = -1)
	{
		PlayerReclaimEntry playerReclaimEntry = NewEntry();
		for (int num = itemList.Count - 1; num >= 0; num--)
		{
			itemList[num].MoveToContainer(playerReclaimEntry.inventory);
		}
		if (reclaimIDToUse == -1)
		{
			lastReclaimID++;
			reclaimIDToUse = lastReclaimID;
		}
		playerReclaimEntry.victimID = victimID;
		playerReclaimEntry.killerID = killerID;
		playerReclaimEntry.killerString = killerString;
		playerReclaimEntry.id = reclaimIDToUse;
		entries.Add(playerReclaimEntry);
		return reclaimIDToUse;
	}

	public void DoCleanup()
	{
		for (int num = entries.Count - 1; num >= 0; num--)
		{
			PlayerReclaimEntry playerReclaimEntry = entries[num];
			if (playerReclaimEntry.inventory.itemList.Count == 0 || playerReclaimEntry.timeAlive / 60f > reclaim_expire_minutes)
			{
				RemoveEntry(playerReclaimEntry);
			}
		}
	}

	public void TickEntries()
	{
		float num = Time.realtimeSinceStartup - lastTickTime;
		foreach (PlayerReclaimEntry entry in entries)
		{
			entry.timeAlive += num;
		}
		lastTickTime = Time.realtimeSinceStartup;
		DoCleanup();
	}

	public bool HasReclaims(ulong playerID)
	{
		foreach (PlayerReclaimEntry entry in entries)
		{
			if (entry.victimID == playerID && entry.inventory.itemList.Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	public PlayerReclaimEntry GetReclaimForPlayer(ulong playerID, int reclaimID)
	{
		foreach (PlayerReclaimEntry entry in entries)
		{
			if (entry.victimID == playerID && entry.id == reclaimID)
			{
				return entry;
			}
		}
		return null;
	}

	public bool GetReclaimsForPlayer(ulong playerID, ref List<PlayerReclaimEntry> list)
	{
		foreach (PlayerReclaimEntry entry in entries)
		{
			if (entry.victimID == playerID)
			{
				list.Add(entry);
			}
		}
		return list.Count > 0;
	}

	public PlayerReclaimEntry NewEntry()
	{
		PlayerReclaimEntry playerReclaimEntry = Pool.Get<PlayerReclaimEntry>();
		playerReclaimEntry.Init();
		return playerReclaimEntry;
	}

	public void RemoveEntry(PlayerReclaimEntry entry)
	{
		entry.Cleanup();
		entries.Remove(entry);
		Pool.Free(ref entry);
		entry = null;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (!info.fromDisk || info.msg.reclaimManager == null)
		{
			return;
		}
		lastReclaimID = info.msg.reclaimManager.lastReclaimID;
		foreach (ProtoBuf.ReclaimManager.ReclaimInfo reclaimEntry in info.msg.reclaimManager.reclaimEntries)
		{
			PlayerReclaimEntry playerReclaimEntry = NewEntry();
			playerReclaimEntry.killerID = reclaimEntry.killerID;
			playerReclaimEntry.victimID = reclaimEntry.victimID;
			playerReclaimEntry.killerString = reclaimEntry.killerString;
			playerReclaimEntry.inventory.Load(reclaimEntry.inventory);
			entries.Add(playerReclaimEntry);
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (!info.forDisk)
		{
			return;
		}
		info.msg.reclaimManager = Pool.Get<ProtoBuf.ReclaimManager>();
		info.msg.reclaimManager.reclaimEntries = Pool.GetList<ProtoBuf.ReclaimManager.ReclaimInfo>();
		info.msg.reclaimManager.lastReclaimID = lastReclaimID;
		foreach (PlayerReclaimEntry entry in entries)
		{
			ProtoBuf.ReclaimManager.ReclaimInfo reclaimInfo = Pool.Get<ProtoBuf.ReclaimManager.ReclaimInfo>();
			reclaimInfo.killerID = entry.killerID;
			reclaimInfo.victimID = entry.victimID;
			reclaimInfo.killerString = entry.killerString;
			reclaimInfo.inventory = entry.inventory.Save();
			info.msg.reclaimManager.reclaimEntries.Add(reclaimInfo);
		}
	}

	public override void ServerInit()
	{
		InvokeRepeating(TickEntries, 1f, 60f);
		_instance = this;
		base.ServerInit();
	}

	internal override void DoServerDestroy()
	{
		_instance = null;
		base.DoServerDestroy();
	}
}
