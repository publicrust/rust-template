using System;
using UnityEngine;

public class BaseAnimalNPC : BaseNpc, IAIAttack, IAITirednessAbove, IAISleep, IAIHungerAbove, IAISenses, IThinker
{
	public string deathStatName = "";

	public AnimalBrain brain;

	private TimeSince lastBrainError;

	public override void ServerInit()
	{
		base.ServerInit();
		brain = ((Component)this).GetComponent<AnimalBrain>();
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)brain != (Object)null && HasBrain && brain.ShouldServerThink())
		{
			brain.DoThink();
		}
		else if ((Object)(object)brain == (Object)null && TimeSince.op_Implicit(lastBrainError) > 10f)
		{
			lastBrainError = TimeSince.op_Implicit(0f);
			Debug.LogWarning((object)(((Object)((Component)this).gameObject).name + " is missing a brain"));
		}
	}

	public override void OnDied(HitInfo hitInfo = null)
	{
		if (hitInfo != null)
		{
			BasePlayer initiatorPlayer = hitInfo.InitiatorPlayer;
			if ((Object)(object)initiatorPlayer != (Object)null)
			{
				initiatorPlayer.GiveAchievement("KILL_ANIMAL");
				if (!string.IsNullOrEmpty(deathStatName))
				{
					initiatorPlayer.stats.Add(deathStatName, 1, (Stats)5);
					initiatorPlayer.stats.Save();
				}
				initiatorPlayer.LifeStoryKill(this);
			}
		}
		base.OnDied((HitInfo)null);
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		if (base.isServer && Object.op_Implicit((Object)(object)info.InitiatorPlayer) && !info.damageTypes.IsMeleeType())
		{
			info.InitiatorPlayer.LifeStoryShotHit(info.Weapon);
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		Kill();
	}

	public bool CanAttack(BaseEntity entity)
	{
		if ((Object)(object)entity == (Object)null)
		{
			return false;
		}
		if (NeedsToReload())
		{
			return false;
		}
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
		BasePlayer basePlayer = entity as BasePlayer;
		BaseVehicle baseVehicle = (((Object)(object)basePlayer != (Object)null) ? basePlayer.GetMountedVehicle() : null);
		if ((Object)(object)baseVehicle != (Object)null && baseVehicle is BaseModularVehicle)
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		dist = Vector3.Distance(((Component)entity).transform.position, base.AttackPosition);
		return dist <= EngagementRange();
	}

	public bool CanSeeTarget(BaseEntity entity)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)entity == (Object)null)
		{
			return false;
		}
		return entity.IsVisible(GetEntity().CenterPoint(), entity.CenterPoint());
	}

	public bool Reload()
	{
		throw new NotImplementedException();
	}

	public bool StartAttacking(BaseEntity target)
	{
		BaseCombatEntity baseCombatEntity = target as BaseCombatEntity;
		if ((Object)(object)baseCombatEntity == (Object)null)
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

	public bool IsTirednessAbove(float value)
	{
		return 1f - Sleep > value;
	}

	public void StartSleeping()
	{
		SetFact(Facts.IsSleeping, 1);
	}

	public void StopSleeping()
	{
		SetFact(Facts.IsSleeping, 0);
	}

	public bool IsHungerAbove(float value)
	{
		return 1f - Energy.Level > value;
	}

	public bool IsThreat(BaseEntity entity)
	{
		BaseNpc baseNpc = entity as BaseNpc;
		if ((Object)(object)baseNpc != (Object)null)
		{
			if (baseNpc.Stats.Family == Stats.Family)
			{
				return false;
			}
			return IsAfraidOf(baseNpc.Stats.Family);
		}
		BasePlayer basePlayer = entity as BasePlayer;
		if ((Object)(object)basePlayer != (Object)null)
		{
			return IsAfraidOf(basePlayer.Family);
		}
		return false;
	}

	public bool IsTarget(BaseEntity entity)
	{
		BaseNpc baseNpc = entity as BaseNpc;
		if ((Object)(object)baseNpc != (Object)null && baseNpc.Stats.Family == Stats.Family)
		{
			return false;
		}
		return !IsThreat(entity);
	}

	public bool IsFriendly(BaseEntity entity)
	{
		if ((Object)(object)entity == (Object)null)
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
