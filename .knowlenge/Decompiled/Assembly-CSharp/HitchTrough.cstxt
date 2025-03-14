using System;
using Facepunch;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;

public class HitchTrough : StorageContainer
{
	[Serializable]
	public class HitchSpot
	{
		public HitchTrough owner;

		public Transform spot;

		public EntityRef horse;

		public RidableHorse GetHorse(bool isServer = true)
		{
			return horse.Get(isServer) as RidableHorse;
		}

		public bool IsOccupied(bool isServer = true)
		{
			return horse.IsValid(isServer);
		}

		public void SetOccupiedBy(RidableHorse newHorse)
		{
			horse.Set(newHorse);
		}
	}

	public HitchSpot[] hitchSpots;

	public float caloriesToDecaySeconds = 36f;

	public Item GetFoodItem()
	{
		foreach (Item item in base.inventory.itemList)
		{
			if (item.info.category == ItemCategory.Food && (bool)item.info.GetComponent<ItemModConsumable>())
			{
				return item;
			}
		}
		return null;
	}

	public bool ValidHitchPosition(Vector3 pos)
	{
		if (GetClosest(pos, includeOccupied: false, 1f) != null)
		{
			return true;
		}
		return false;
	}

	public bool HasSpace()
	{
		HitchSpot[] array = hitchSpots;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].IsOccupied())
			{
				return true;
			}
		}
		return false;
	}

	public HitchSpot GetClosest(Vector3 testPos, bool includeOccupied = false, float maxRadius = -1f)
	{
		float num = 10000f;
		HitchSpot result = null;
		for (int i = 0; i < hitchSpots.Length; i++)
		{
			float num2 = Vector3.Distance(testPos, hitchSpots[i].spot.position);
			if (num2 < num && (maxRadius == -1f || num2 <= maxRadius) && (includeOccupied || !hitchSpots[i].IsOccupied()))
			{
				num = num2;
				result = hitchSpots[i];
			}
		}
		return result;
	}

	public void Unhitch(RidableHorse horse)
	{
		HitchSpot[] array = hitchSpots;
		foreach (HitchSpot hitchSpot in array)
		{
			if (hitchSpot.GetHorse(base.isServer) == horse)
			{
				if (Interface.CallHook("OnHorseUnhitch", horse, hitchSpot) != null)
				{
					break;
				}
				hitchSpot.SetOccupiedBy(null);
				horse.SetHitch(null);
			}
		}
	}

	public int NumHitched()
	{
		int num = 0;
		HitchSpot[] array = hitchSpots;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsOccupied())
			{
				num++;
			}
		}
		return num;
	}

	public bool AttemptToHitch(RidableHorse horse, HitchSpot hitch = null)
	{
		if (horse == null)
		{
			return false;
		}
		if (hitch == null)
		{
			hitch = GetClosest(horse.transform.position);
		}
		if (hitch != null)
		{
			object obj = Interface.CallHook("OnHorseHitch", horse, hitch);
			if (obj is bool)
			{
				return (bool)obj;
			}
			hitch.SetOccupiedBy(horse);
			horse.SetHitch(this);
			horse.transform.SetPositionAndRotation(hitch.spot.position, hitch.spot.rotation);
			horse.DismountAllPlayers();
			return true;
		}
		return false;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity = Pool.Get<ProtoBuf.IOEntity>();
		info.msg.ioEntity.genericEntRef1 = hitchSpots[0].horse.uid;
		info.msg.ioEntity.genericEntRef2 = hitchSpots[1].horse.uid;
	}

	public override void PostServerLoad()
	{
		HitchSpot[] array = hitchSpots;
		foreach (HitchSpot hitchSpot in array)
		{
			AttemptToHitch(hitchSpot.GetHorse(), hitchSpot);
		}
	}

	public void UnhitchAll()
	{
		HitchSpot[] array = hitchSpots;
		for (int i = 0; i < array.Length; i++)
		{
			RidableHorse horse = array[i].GetHorse();
			if ((bool)horse)
			{
				Unhitch(horse);
			}
		}
	}

	public override void DestroyShared()
	{
		if (base.isServer)
		{
			UnhitchAll();
		}
		base.DestroyShared();
	}

	public override void OnKilled(HitInfo info)
	{
		base.OnKilled(info);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			hitchSpots[0].horse.uid = info.msg.ioEntity.genericEntRef1;
			hitchSpots[1].horse.uid = info.msg.ioEntity.genericEntRef2;
		}
	}
}
