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

		public Transform tr;

		public EntityRef hitchableEntRef;

		public IHitchable GetHitchable(bool isServer = true)
		{
			return hitchableEntRef.Get(isServer) as IHitchable;
		}

		public bool IsOccupied(bool isServer = true)
		{
			return hitchableEntRef.IsValid(isServer);
		}

		public void SetOccupiedBy(IHitchable hitchable)
		{
			if (hitchable == null)
			{
				hitchableEntRef.Set(null);
				return;
			}
			BaseEntity baseEntity = hitchable as BaseEntity;
			if (baseEntity != null)
			{
				hitchableEntRef.Set(baseEntity);
			}
		}
	}

	public interface IHitchable
	{
		void SetHitch(HitchTrough hitch, HitchSpot spot);
	}

	public HitchSpot[] hitchSpots;

	public float caloriesToDecaySeconds = 36f;

	public override void PostServerLoad()
	{
		HitchSpot[] array = hitchSpots;
		foreach (HitchSpot hitchSpot in array)
		{
			AttemptToHitch(hitchSpot.GetHitchable(), hitchSpot);
		}
	}

	public override void DestroyShared()
	{
		if (base.isServer)
		{
			UnHitchAll();
		}
		base.DestroyShared();
	}

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

	public bool IsValidHitchPosition(Vector3 pos)
	{
		return GetClosestSpot(pos, includeOccupied: false, 1f) != null;
	}

	public bool AttemptToHitch(IHitchable hitchable, HitchSpot spot = null)
	{
		if (hitchable == null)
		{
			return false;
		}
		if (spot == null)
		{
			BaseEntity baseEntity = hitchable as BaseEntity;
			if (baseEntity != null)
			{
				spot = GetClosestSpot(baseEntity.transform.position);
			}
		}
		if (spot != null)
		{
			object obj = Interface.CallHook("OnHorseHitch", hitchable, spot);
			if (obj is bool)
			{
				return (bool)obj;
			}
			spot.SetOccupiedBy(hitchable);
			hitchable.SetHitch(this, spot);
			return true;
		}
		return false;
	}

	public HitchSpot GetClosestSpot(Vector3 testPos, bool includeOccupied = false, float maxRadius = -1f)
	{
		float num = 10000f;
		HitchSpot result = null;
		for (int i = 0; i < hitchSpots.Length; i++)
		{
			float num2 = Vector3.Distance(testPos, hitchSpots[i].tr.position);
			if (num2 < num && (maxRadius == -1f || num2 <= maxRadius) && (includeOccupied || !hitchSpots[i].IsOccupied()))
			{
				num = num2;
				result = hitchSpots[i];
			}
		}
		return result;
	}

	public void UnHitch(IHitchable hitchable)
	{
		HitchSpot[] array = hitchSpots;
		foreach (HitchSpot hitchSpot in array)
		{
			if (hitchSpot.GetHitchable(base.isServer) == hitchable)
			{
				if (Interface.CallHook("OnHorseUnhitch", hitchable, hitchSpot) != null)
				{
					break;
				}
				hitchSpot.SetOccupiedBy(null);
				hitchable.SetHitch(null, null);
			}
		}
	}

	public void UnHitchAll()
	{
		HitchSpot[] array = hitchSpots;
		for (int i = 0; i < array.Length; i++)
		{
			IHitchable hitchable = array[i].GetHitchable();
			if (hitchable != null)
			{
				UnHitch(hitchable);
			}
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity = Pool.Get<ProtoBuf.IOEntity>();
		info.msg.ioEntity.genericEntRef1 = hitchSpots[0].hitchableEntRef.uid;
		info.msg.ioEntity.genericEntRef2 = hitchSpots[1].hitchableEntRef.uid;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			hitchSpots[0].hitchableEntRef.uid = info.msg.ioEntity.genericEntRef1;
			hitchSpots[1].hitchableEntRef.uid = info.msg.ioEntity.genericEntRef2;
		}
	}
}
