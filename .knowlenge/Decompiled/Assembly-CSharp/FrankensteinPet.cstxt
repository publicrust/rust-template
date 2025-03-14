using System.Collections;
using Network;
using Oxide.Core;
using Rust;
using UnityEngine;

public class FrankensteinPet : BasePet, IAISenses, IAIAttack
{
	[Header("Frankenstein")]
	[ServerVar(Help = "How long before a Frankenstein Pet dies un controlled and not asleep on table")]
	public static float decayminutes = 180f;

	[Header("Audio")]
	public SoundDefinition AttackVocalSFX;

	public float nextAttackTime;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("FrankensteinPet.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (!base.isClient)
		{
			InvokeRandomized(TickDecay, UnityEngine.Random.Range(30f, 60f), 60f, 6f);
		}
	}

	public IEnumerator DelayEquipWeapon(ItemDefinition item, float delay)
	{
		yield return new WaitForSeconds(delay);
		if (!(inventory == null) && inventory.containerBelt != null && !(item == null))
		{
			inventory.GiveItem(ItemManager.Create(item, 1, 0uL), inventory.containerBelt);
			EquipWeapon();
		}
	}

	private void TickDecay()
	{
		BasePlayer basePlayer = BasePlayer.FindByID(base.OwnerID);
		if ((!(basePlayer != null) || basePlayer.IsSleeping()) && !(base.healthFraction <= 0f) && !base.IsDestroyed)
		{
			float num = 1f / decayminutes;
			float amount = MaxHealth() * num;
			Hurt(amount, DamageType.Decay, this, useProtection: false);
		}
	}

	public float EngagementRange()
	{
		AttackEntity attackEntity = GetAttackEntity();
		if ((bool)attackEntity)
		{
			return attackEntity.effectiveRange * (attackEntity.aiOnlyInRange ? 1f : 2f) * base.Brain.AttackRangeMultiplier;
		}
		return base.Brain.SenseRange;
	}

	public bool IsThreat(BaseEntity entity)
	{
		return IsTarget(entity);
	}

	public bool IsTarget(BaseEntity entity)
	{
		if (entity is BasePlayer)
		{
			return !entity.IsNpc;
		}
		return false;
	}

	public bool IsFriendly(BaseEntity entity)
	{
		return false;
	}

	public bool CanAttack(BaseEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		if (entity.gameObject.layer == 21 || entity.gameObject.layer == 8)
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
		if (InSafeZone() || (entity is BasePlayer basePlayer && basePlayer.InSafeZone()))
		{
			return false;
		}
		if (!CanSeeTarget(entity))
		{
			return false;
		}
		return true;
	}

	public bool IsTargetInRange(BaseEntity entity, out float dist)
	{
		dist = Vector3.Distance(entity.transform.position, base.transform.position);
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

	public bool NeedsToReload()
	{
		return false;
	}

	public bool Reload()
	{
		return true;
	}

	public float CooldownDuration()
	{
		return BaseAttackRate;
	}

	public bool IsOnCooldown()
	{
		return Time.realtimeSinceStartup < nextAttackTime;
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

	private void Attack(BaseCombatEntity target)
	{
		if (!(target == null))
		{
			Vector3 vector = target.ServerPosition - ServerPosition;
			if (vector.magnitude > 0.001f)
			{
				ServerRotation = Quaternion.LookRotation(vector.normalized);
			}
			target.Hurt(BaseAttackDamge, AttackDamageType, this);
			SignalBroadcast(Signal.Attack);
			ClientRPC(null, "OnAttack");
			nextAttackTime = Time.realtimeSinceStartup + CooldownDuration();
		}
	}

	public void StopAttacking()
	{
	}

	public float GetAmmoFraction()
	{
		return AmmoFractionRemaining();
	}

	public BaseEntity GetBestTarget()
	{
		return null;
	}

	public void AttackTick(float delta, BaseEntity target, bool targetIsLOS)
	{
	}

	public override bool ShouldDropActiveItem()
	{
		return false;
	}

	public override BaseCorpse CreateCorpse()
	{
		using (TimeWarning.New("Create corpse"))
		{
			NPCPlayerCorpse nPCPlayerCorpse = DropCorpse("assets/rust.ai/agents/NPCPlayer/pet/frankensteinpet_corpse.prefab") as NPCPlayerCorpse;
			if ((bool)nPCPlayerCorpse)
			{
				nPCPlayerCorpse.transform.position = nPCPlayerCorpse.transform.position + Vector3.down * NavAgent.baseOffset;
				nPCPlayerCorpse.SetLootableIn(2f);
				nPCPlayerCorpse.SetFlag(Flags.Reserved5, HasPlayerFlag(PlayerFlags.DisplaySash));
				nPCPlayerCorpse.SetFlag(Flags.Reserved2, b: true);
				nPCPlayerCorpse.TakeFrom(inventory.containerMain, inventory.containerWear, inventory.containerBelt);
				nPCPlayerCorpse.playerName = OverrideCorpseName();
				nPCPlayerCorpse.playerSteamID = userID;
				nPCPlayerCorpse.Spawn();
				ItemContainer[] containers = nPCPlayerCorpse.containers;
				for (int i = 0; i < containers.Length; i++)
				{
					containers[i].Clear();
				}
			}
			object obj = Interface.CallHook("OnCorpsePopulate", this, nPCPlayerCorpse);
			if (obj is BaseCorpse)
			{
				return (BaseCorpse)obj;
			}
			return nPCPlayerCorpse;
		}
	}

	protected virtual string OverrideCorpseName()
	{
		return "Frankenstein";
	}
}
