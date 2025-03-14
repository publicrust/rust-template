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
		brain = GetComponent<AnimalBrain>();
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
		if (brain != null && HasBrain && brain.ShouldServerThink())
		{
			brain.DoThink();
		}
		else if (brain == null && (float)lastBrainError > 10f)
		{
			lastBrainError = 0f;
			Debug.LogWarning(base.gameObject.name + " is missing a brain");
		}
	}

	public override void OnDied(HitInfo hitInfo = null)
	{
		if (hitInfo != null)
		{
			BasePlayer initiatorPlayer = hitInfo.InitiatorPlayer;
			if (initiatorPlayer != null)
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
		if (base.isServer && (bool)info.InitiatorPlayer && !info.damageTypes.IsMeleeType())
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
		if (entity == null)
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
		BaseVehicle baseVehicle = ((basePlayer != null) ? basePlayer.GetMountedVehicle() : null);
		if (baseVehicle != null && baseVehicle is BaseModularVehicle)
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
		throw new NotImplementedException();
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
