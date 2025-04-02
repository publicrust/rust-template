using UnityEngine;

public class BaseFishNPC : BaseNpc, IAIAttack, IAISenses, IThinker
{
	protected FishBrain brain;

	public override void ServerInit()
	{
		base.ServerInit();
		brain = GetComponent<FishBrain>();
		if (!base.isClient)
		{
			AIThinkManager.AddAnimal(this);
		}
	}

	internal override void DoServerDestroy()
	{
		if (!base.isClient)
		{
			AIThinkManager.RemoveAnimal(this);
			base.DoServerDestroy();
		}
	}

	public virtual void TryThink()
	{
		if (brain.ShouldServerThink())
		{
			brain.DoThink();
		}
	}

	public bool CanAttack(BaseEntity entity)
	{
		if (IsOnCooldown())
		{
			return false;
		}
		if (!IsTargetInRange(entity, out var _))
		{
			return false;
		}
		if (!CanSeeTarget(entity))
		{
			return false;
		}
		return true;
	}

	public bool NeedsToReload()
	{
		return false;
	}

	public float EngagementRange()
	{
		return AttackRange * brain.AttackRangeMultiplier;
	}

	public bool IsTargetInRange(BaseEntity entity, out float dist)
	{
		dist = Vector3.Distance(entity.transform.position, base.AttackPosition);
		return dist <= EngagementRange();
	}

	public bool CanSeeTarget(BaseEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		return entity.IsVisible(GetEntity().CenterPoint(), entity.CenterPoint());
	}

	public bool Reload()
	{
		return true;
	}

	public bool StartAttacking(BaseEntity target)
	{
		BaseCombatEntity baseCombatEntity = target as BaseCombatEntity;
		if (baseCombatEntity == null)
		{
			return false;
		}
		Attack(baseCombatEntity);
		return true;
	}

	public void StopAttacking()
	{
	}

	public float CooldownDuration()
	{
		return AttackRate;
	}

	public bool IsOnCooldown()
	{
		return !AttackReady();
	}

	public bool IsThreat(BaseEntity entity)
	{
		BaseNpc baseNpc = entity as BaseNpc;
		if (baseNpc != null)
		{
			if (baseNpc.Stats.Family == Stats.Family)
			{
				return false;
			}
			return IsAfraidOf(baseNpc.Stats.Family);
		}
		BasePlayer basePlayer = entity as BasePlayer;
		if (basePlayer != null)
		{
			return IsAfraidOf(basePlayer.Family);
		}
		return false;
	}

	public bool IsTarget(BaseEntity entity)
	{
		BaseNpc baseNpc = entity as BaseNpc;
		if (baseNpc != null && baseNpc.Stats.Family == Stats.Family)
		{
			return false;
		}
		return !IsThreat(entity);
	}

	public bool IsFriendly(BaseEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		return entity.prefabID == prefabID;
	}

	public float GetAmmoFraction()
	{
		return 1f;
	}

	public BaseEntity GetBestTarget()
	{
		return null;
	}

	public void AttackTick(float delta, BaseEntity target, bool targetIsLOS)
	{
	}
}
