using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class DoorManipulator : IOEntity
{
	public enum DoorEffect
	{
		Close,
		Open,
		Toggle
	}

	public EntityRef entityRef;

	public Door targetDoor;

	public DoorEffect powerAction;

	private bool toggle = true;

	public virtual bool PairWithLockedDoors()
	{
		return true;
	}

	public virtual void SetTargetDoor(Door newTargetDoor)
	{
		Door door = targetDoor;
		targetDoor = newTargetDoor;
		SetFlag(Flags.On, targetDoor != null);
		entityRef.Set(newTargetDoor);
		if (door != targetDoor && targetDoor != null)
		{
			DoAction();
		}
	}

	public virtual void SetupInitialDoorConnection()
	{
		if (targetDoor == null && !entityRef.IsValid(serverside: true))
		{
			SetTargetDoor(FindDoor(PairWithLockedDoors()));
		}
		if (targetDoor != null && !entityRef.IsValid(serverside: true))
		{
			entityRef.Set(targetDoor);
		}
		if (entityRef.IsValid(serverside: true) && targetDoor == null)
		{
			SetTargetDoor(entityRef.Get(serverside: true).GetComponent<Door>());
		}
	}

	public override void Init()
	{
		base.Init();
		SetupInitialDoorConnection();
	}

	public Door FindDoor(bool allowLocked = true)
	{
		List<Door> obj = Pool.GetList<Door>();
		Vis.Entities(base.transform.position, 1f, obj, 2097152, QueryTriggerInteraction.Ignore);
		Door result = null;
		float num = float.PositiveInfinity;
		foreach (Door item in obj)
		{
			if (!item.isServer)
			{
				continue;
			}
			if (!allowLocked)
			{
				BaseLock baseLock = item.GetSlot(Slot.Lock) as BaseLock;
				if (baseLock != null && baseLock.IsLocked())
				{
					continue;
				}
			}
			float num2 = Vector3.Distance(item.transform.position, base.transform.position);
			if (num2 < num)
			{
				result = item;
				num = num2;
			}
		}
		Pool.FreeList(ref obj);
		return result;
	}

	public virtual void DoActionDoorMissing()
	{
		SetTargetDoor(FindDoor(PairWithLockedDoors()));
	}

	public void DoAction()
	{
		bool flag = IsPowered();
		if (targetDoor == null)
		{
			DoActionDoorMissing();
		}
		if (!(targetDoor != null))
		{
			return;
		}
		if (targetDoor.IsBusy())
		{
			Invoke(DoAction, 1f);
		}
		else if (powerAction == DoorEffect.Open)
		{
			if (flag)
			{
				if (!targetDoor.IsOpen())
				{
					targetDoor.SetOpen(open: true);
				}
			}
			else if (targetDoor.IsOpen())
			{
				targetDoor.SetOpen(open: false);
			}
		}
		else if (powerAction == DoorEffect.Close)
		{
			if (flag)
			{
				if (targetDoor.IsOpen())
				{
					targetDoor.SetOpen(open: false);
				}
			}
			else if (!targetDoor.IsOpen())
			{
				targetDoor.SetOpen(open: true);
			}
		}
		else if (powerAction == DoorEffect.Toggle)
		{
			if (flag && toggle)
			{
				targetDoor.SetOpen(!targetDoor.IsOpen());
				toggle = false;
			}
			else if (!toggle)
			{
				toggle = true;
			}
		}
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
		DoAction();
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity.genericEntRef1 = entityRef.uid;
		info.msg.ioEntity.genericInt1 = (int)powerAction;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			entityRef.uid = info.msg.ioEntity.genericEntRef1;
			powerAction = (DoorEffect)info.msg.ioEntity.genericInt1;
		}
	}
}
