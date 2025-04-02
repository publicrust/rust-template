using System.Collections.Generic;
using UnityEngine;

public class TriggerMount : TriggerBase, IServerComponent
{
	private class EntryInfo
	{
		public float entryTime;

		public Vector3 entryPos;

		public EntryInfo(float entryTime, Vector3 entryPos)
		{
			this.entryTime = entryTime;
			this.entryPos = entryPos;
		}

		public void Set(float entryTime, Vector3 entryPos)
		{
			this.entryTime = entryTime;
			this.entryPos = entryPos;
		}
	}

	private const float MOUNT_DELAY = 3.5f;

	private const float MAX_MOVE = 0.5f;

	private Dictionary<BaseEntity, EntryInfo> entryInfo;

	internal override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null)
		{
			return null;
		}
		BasePlayer basePlayer = baseEntity.ToPlayer();
		if (basePlayer == null || basePlayer.IsNpc)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	internal override void OnEntityEnter(BaseEntity ent)
	{
		base.OnEntityEnter(ent);
		if (entryInfo == null)
		{
			entryInfo = new Dictionary<BaseEntity, EntryInfo>();
		}
		entryInfo.Add(ent, new EntryInfo(Time.time, ent.transform.position));
		Invoke(CheckForMount, 3.6f);
	}

	internal override void OnEntityLeave(BaseEntity ent)
	{
		if (ent != null && entryInfo != null)
		{
			entryInfo.Remove(ent);
		}
		base.OnEntityLeave(ent);
	}

	private void CheckForMount()
	{
		if (entityContents == null || entryInfo == null)
		{
			return;
		}
		foreach (KeyValuePair<BaseEntity, EntryInfo> item in entryInfo)
		{
			BaseEntity key = item.Key;
			if (!key.IsValid())
			{
				continue;
			}
			EntryInfo value = item.Value;
			BasePlayer basePlayer = key.ToPlayer();
			bool flag = (basePlayer.IsAdmin || basePlayer.IsDeveloper) && basePlayer.IsFlying;
			if (!(basePlayer != null) || !basePlayer.IsAlive() || flag)
			{
				continue;
			}
			bool flag2 = false;
			if (!basePlayer.isMounted && !basePlayer.IsSleeping() && value.entryTime + 3.5f < Time.time && Vector3.Distance(key.transform.position, value.entryPos) < 0.5f)
			{
				BaseVehicle componentInParent = GetComponentInParent<BaseVehicle>();
				if (componentInParent != null && !componentInParent.IsDead())
				{
					componentInParent.AttemptMount(basePlayer);
					flag2 = true;
				}
			}
			if (!flag2)
			{
				value.Set(Time.time, key.transform.position);
				Invoke(CheckForMount, 3.6f);
			}
		}
	}
}
