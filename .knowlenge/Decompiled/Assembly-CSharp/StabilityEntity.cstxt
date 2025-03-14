using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Oxide.Core;
using ProtoBuf;
using Rust;
using UnityEngine;

public class StabilityEntity : DecayEntity
{
	public class StabilityCheckWorkQueue : ObjectWorkQueue<StabilityEntity>
	{
		protected override void RunJob(StabilityEntity entity)
		{
			if (ShouldAdd(entity))
			{
				entity.StabilityCheck();
			}
		}

		protected override bool ShouldAdd(StabilityEntity entity)
		{
			if (!ConVar.Server.stability)
			{
				return false;
			}
			if (!entity.IsValid())
			{
				return false;
			}
			if (!entity.isServer)
			{
				return false;
			}
			return true;
		}
	}

	public class UpdateSurroundingsQueue : ObjectWorkQueue<Bounds>
	{
		protected override void RunJob(Bounds bounds)
		{
			if (!ConVar.Server.stability)
			{
				return;
			}
			List<BaseEntity> obj = Facepunch.Pool.GetList<BaseEntity>();
			Vis.Entities(bounds.center, bounds.extents.magnitude + 1f, obj, 2263296);
			foreach (BaseEntity item in obj)
			{
				if (!item.IsDestroyed && !item.isClient)
				{
					if (item is StabilityEntity)
					{
						(item as StabilityEntity).OnPhysicsNeighbourChanged();
					}
					else
					{
						item.BroadcastMessage("OnPhysicsNeighbourChanged", SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			Facepunch.Pool.FreeList(ref obj);
		}
	}

	private class Support
	{
		public StabilityEntity parent;

		public EntityLink link;

		public float factor = 1f;

		public Support(StabilityEntity parent, EntityLink link, float factor)
		{
			this.parent = parent;
			this.link = link;
			this.factor = factor;
		}

		public StabilityEntity SupportEntity(StabilityEntity ignoreEntity = null)
		{
			StabilityEntity stabilityEntity = null;
			for (int i = 0; i < link.connections.Count; i++)
			{
				StabilityEntity stabilityEntity2 = link.connections[i].owner as StabilityEntity;
				if (!(stabilityEntity2 == null) && !(stabilityEntity2 == parent) && !(stabilityEntity2 == ignoreEntity) && !stabilityEntity2.isClient && !stabilityEntity2.IsDestroyed && (stabilityEntity == null || stabilityEntity2.cachedDistanceFromGround < stabilityEntity.cachedDistanceFromGround))
				{
					stabilityEntity = stabilityEntity2;
				}
			}
			return stabilityEntity;
		}
	}

	public static StabilityCheckWorkQueue stabilityCheckQueue = new StabilityCheckWorkQueue();

	public static UpdateSurroundingsQueue updateSurroundingsQueue = new UpdateSurroundingsQueue();

	public bool grounded;

	[NonSerialized]
	public float cachedStability;

	[NonSerialized]
	public int cachedDistanceFromGround = int.MaxValue;

	private List<Support> supports;

	private int stabilityStrikes;

	private bool dirty;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.stabilityEntity = Facepunch.Pool.Get<ProtoBuf.StabilityEntity>();
		info.msg.stabilityEntity.stability = cachedStability;
		info.msg.stabilityEntity.distanceFromGround = cachedDistanceFromGround;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.stabilityEntity != null)
		{
			cachedStability = info.msg.stabilityEntity.stability;
			cachedDistanceFromGround = info.msg.stabilityEntity.distanceFromGround;
			if (cachedStability <= 0f)
			{
				cachedStability = 0f;
			}
			if (cachedDistanceFromGround <= 0)
			{
				cachedDistanceFromGround = int.MaxValue;
			}
		}
	}

	public override void ResetState()
	{
		base.ResetState();
		cachedStability = 0f;
		cachedDistanceFromGround = int.MaxValue;
		if (base.isServer)
		{
			supports = null;
			stabilityStrikes = 0;
			dirty = false;
		}
	}

	public void InitializeSupports()
	{
		supports = new List<Support>();
		if (grounded)
		{
			return;
		}
		List<EntityLink> entityLinks = GetEntityLinks();
		for (int i = 0; i < entityLinks.Count; i++)
		{
			EntityLink entityLink = entityLinks[i];
			if (entityLink.IsMale())
			{
				if (entityLink.socket is StabilitySocket)
				{
					supports.Add(new Support(this, entityLink, (entityLink.socket as StabilitySocket).support));
				}
				if (entityLink.socket is ConstructionSocket)
				{
					supports.Add(new Support(this, entityLink, (entityLink.socket as ConstructionSocket).support));
				}
			}
		}
	}

	public int DistanceFromGround(StabilityEntity ignoreEntity = null)
	{
		if (grounded)
		{
			return 1;
		}
		if (supports == null)
		{
			return 1;
		}
		if (ignoreEntity == null)
		{
			ignoreEntity = this;
		}
		int num = int.MaxValue;
		for (int i = 0; i < supports.Count; i++)
		{
			StabilityEntity stabilityEntity = supports[i].SupportEntity(ignoreEntity);
			if (!(stabilityEntity == null))
			{
				int num2 = stabilityEntity.CachedDistanceFromGround(ignoreEntity);
				if (num2 != int.MaxValue)
				{
					num = Mathf.Min(num, num2 + 1);
				}
			}
		}
		return num;
	}

	public float SupportValue(StabilityEntity ignoreEntity = null)
	{
		if (grounded)
		{
			return 1f;
		}
		if (supports == null)
		{
			return 1f;
		}
		if (ignoreEntity == null)
		{
			ignoreEntity = this;
		}
		float num = 0f;
		for (int i = 0; i < supports.Count; i++)
		{
			Support support = supports[i];
			StabilityEntity stabilityEntity = support.SupportEntity(ignoreEntity);
			if (!(stabilityEntity == null))
			{
				float num2 = stabilityEntity.CachedSupportValue(ignoreEntity);
				if (num2 != 0f)
				{
					num += num2 * support.factor;
				}
			}
		}
		return Mathf.Clamp01(num);
	}

	public int CachedDistanceFromGround(StabilityEntity ignoreEntity = null)
	{
		if (grounded)
		{
			return 1;
		}
		if (supports == null)
		{
			return 1;
		}
		if (ignoreEntity == null)
		{
			ignoreEntity = this;
		}
		int num = int.MaxValue;
		for (int i = 0; i < supports.Count; i++)
		{
			StabilityEntity stabilityEntity = supports[i].SupportEntity(ignoreEntity);
			if (!(stabilityEntity == null))
			{
				int num2 = stabilityEntity.cachedDistanceFromGround;
				if (num2 != int.MaxValue)
				{
					num = Mathf.Min(num, num2 + 1);
				}
			}
		}
		return num;
	}

	public float CachedSupportValue(StabilityEntity ignoreEntity = null)
	{
		if (grounded)
		{
			return 1f;
		}
		if (supports == null)
		{
			return 1f;
		}
		if (ignoreEntity == null)
		{
			ignoreEntity = this;
		}
		float num = 0f;
		for (int i = 0; i < supports.Count; i++)
		{
			Support support = supports[i];
			StabilityEntity stabilityEntity = support.SupportEntity(ignoreEntity);
			if (!(stabilityEntity == null))
			{
				float num2 = stabilityEntity.cachedStability;
				if (num2 != 0f)
				{
					num += num2 * support.factor;
				}
			}
		}
		return Mathf.Clamp01(num);
	}

	public void StabilityCheck()
	{
		if (base.IsDestroyed || Interface.CallHook("OnEntityStabilityCheck", this) != null)
		{
			return;
		}
		if (supports == null)
		{
			InitializeSupports();
		}
		bool flag = false;
		int num = DistanceFromGround();
		if (num != cachedDistanceFromGround)
		{
			cachedDistanceFromGround = num;
			flag = true;
		}
		float num2 = SupportValue();
		if (Mathf.Abs(cachedStability - num2) > Stability.accuracy)
		{
			cachedStability = num2;
			flag = true;
		}
		if (flag)
		{
			dirty = true;
			UpdateConnectedEntities();
			UpdateStability();
		}
		else if (dirty)
		{
			dirty = false;
			SendNetworkUpdate();
		}
		if (num2 < Stability.collapse)
		{
			if (stabilityStrikes < Stability.strikes)
			{
				UpdateStability();
				stabilityStrikes++;
			}
			else
			{
				Kill(DestroyMode.Gib);
			}
		}
		else
		{
			stabilityStrikes = 0;
		}
	}

	public void UpdateStability()
	{
		stabilityCheckQueue.Add(this);
	}

	public void UpdateSurroundingEntities()
	{
		updateSurroundingsQueue.Add(WorldSpaceBounds().ToBounds());
	}

	public void UpdateConnectedEntities()
	{
		List<EntityLink> entityLinks = GetEntityLinks();
		for (int i = 0; i < entityLinks.Count; i++)
		{
			EntityLink entityLink = entityLinks[i];
			if (!entityLink.IsFemale())
			{
				continue;
			}
			for (int j = 0; j < entityLink.connections.Count; j++)
			{
				StabilityEntity stabilityEntity = entityLink.connections[j].owner as StabilityEntity;
				if (!(stabilityEntity == null) && !stabilityEntity.isClient && !stabilityEntity.IsDestroyed)
				{
					stabilityEntity.UpdateStability();
				}
			}
		}
	}

	protected void OnPhysicsNeighbourChanged()
	{
		if (!base.IsDestroyed)
		{
			StabilityCheck();
		}
	}

	protected void DebugNudge()
	{
		StabilityCheck();
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			UpdateStability();
		}
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		UpdateSurroundingEntities();
	}
}
