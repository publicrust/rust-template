using System;
using System.Collections;
using System.Collections.Generic;
using ConVar;
using Oxide.Core;
using UnityEngine;
using UnityEngine.AI;

public class NPCPlayer : BasePlayer
{
	public float MovementTickStartDelay = 1f;

	public AIInformationZone VirtualInfoZone;

	public Vector3 finalDestination;

	[NonSerialized]
	private float randomOffset;

	[NonSerialized]
	public Vector3 spawnPos;

	public PlayerInventoryProperties[] loadouts;

	public LayerMask movementMask = 1503731969;

	public bool LegacyNavigation = true;

	public NavMeshAgent NavAgent;

	public float damageScale = 1f;

	public float shortRange = 10f;

	public float attackLengthMaxShortRangeScale = 1f;

	private bool _isDormant;

	private string loadoutname;

	public float lastGunShotTime;

	public float triggerEndTime;

	public float nextTriggerTime;

	private float lastThinkTime;

	private float lastPositionUpdateTime;

	private float lastMovementTickTime;

	public Vector3 lastPos;

	private float lastThrowTime;

	public override bool IsNpc => true;

	public virtual bool IsDormant
	{
		get
		{
			return _isDormant;
		}
		set
		{
			_isDormant = value;
			_ = _isDormant;
		}
	}

	public override float PositionTickRate
	{
		protected get
		{
			return 0.1f;
		}
	}

	public virtual bool IsOnNavMeshLink
	{
		get
		{
			if (IsNavRunning())
			{
				return NavAgent.isOnOffMeshLink;
			}
			return false;
		}
	}

	public virtual bool HasPath
	{
		get
		{
			if (IsNavRunning())
			{
				return NavAgent.hasPath;
			}
			return false;
		}
	}

	protected virtual string CorpsePath => "assets/prefabs/npc/scientist/scientist_corpse.prefab";

	protected virtual bool ShouldCorpseTakeChildren => true;

	protected virtual bool KeepCorpseClothingIntact => true;

	protected virtual string OverrideCorpseName => displayName;

	protected virtual bool CopyInventoryToCorpse => true;

	public virtual bool IsLoadBalanced()
	{
		return false;
	}

	public override void ServerInit()
	{
		if (base.isClient)
		{
			return;
		}
		spawnPos = GetPosition();
		randomOffset = UnityEngine.Random.Range(0f, 1f);
		base.ServerInit();
		UpdateNetworkGroup();
		EquipLoadout(loadouts);
		if (!IsLoadBalanced())
		{
			InvokeRepeating(ServerThink_Internal, 0f, 0.1f);
			lastThinkTime = UnityEngine.Time.time;
		}
		Invoke(EquipTest, 0.25f);
		finalDestination = base.transform.position;
		if (NavAgent == null)
		{
			NavAgent = GetComponent<NavMeshAgent>();
		}
		if ((bool)NavAgent)
		{
			NavAgent.updateRotation = false;
			NavAgent.updatePosition = false;
			if (!LegacyNavigation)
			{
				base.transform.gameObject.GetComponent<BaseNavigator>().Init(this, NavAgent);
			}
		}
		InvokeRandomized(TickMovement, MovementTickStartDelay, PositionTickRate, PositionTickRate * 0.1f);
	}

	public string GetLoadoutName()
	{
		return loadoutname;
	}

	public void EquipLoadout(PlayerInventoryProperties[] loads)
	{
		if (loads != null && loads.Length != 0)
		{
			int num = UnityEngine.Random.Range(0, loads.Length);
			loadoutname = loads[num].niceName;
			loads[num].GiveToPlayer(this);
		}
	}

	public override void ApplyInheritedVelocity(Vector3 velocity)
	{
		ServerPosition = BaseNpc.GetNewNavPosWithVelocity(this, velocity);
	}

	public void RandomMove()
	{
		float num = 8f;
		Vector2 vector = UnityEngine.Random.insideUnitCircle * num;
		SetDestination(spawnPos + new Vector3(vector.x, 0f, vector.y));
	}

	public virtual void SetDestination(Vector3 newDestination)
	{
		finalDestination = newDestination;
	}

	public AttackEntity GetAttackEntity()
	{
		return GetHeldEntity() as AttackEntity;
	}

	public BaseProjectile GetGun()
	{
		AttackEntity attackEntity = GetHeldEntity() as AttackEntity;
		if (attackEntity == null)
		{
			return null;
		}
		BaseProjectile baseProjectile = attackEntity as BaseProjectile;
		if ((bool)baseProjectile)
		{
			return baseProjectile;
		}
		return null;
	}

	public virtual float AmmoFractionRemaining()
	{
		AttackEntity attackEntity = GetAttackEntity();
		if ((bool)attackEntity)
		{
			return attackEntity.AmmoFraction();
		}
		return 0f;
	}

	public virtual bool IsReloading()
	{
		AttackEntity attackEntity = GetAttackEntity();
		if (!attackEntity)
		{
			return false;
		}
		return attackEntity.ServerIsReloading();
	}

	public virtual void AttemptReload()
	{
		AttackEntity attackEntity = GetAttackEntity();
		if (!(attackEntity == null) && attackEntity.CanReload())
		{
			attackEntity.ServerReload();
		}
	}

	public virtual bool ShotTest(float targetDist)
	{
		AttackEntity attackEntity = GetHeldEntity() as AttackEntity;
		if (attackEntity == null)
		{
			return false;
		}
		BaseProjectile baseProjectile = attackEntity as BaseProjectile;
		if ((bool)baseProjectile)
		{
			if (baseProjectile.primaryMagazine.contents <= 0)
			{
				baseProjectile.ServerReload();
				return false;
			}
			if (baseProjectile.NextAttackTime > UnityEngine.Time.time)
			{
				return false;
			}
		}
		else
		{
			FlameThrower flameThrower = attackEntity as FlameThrower;
			if (flameThrower != null && flameThrower.ammo <= 0)
			{
				flameThrower.ServerReload();
				return false;
			}
		}
		if (!Mathf.Approximately(attackEntity.attackLengthMin, -1f))
		{
			if (IsInvoking(TriggerDown))
			{
				return true;
			}
			if (UnityEngine.Time.time < nextTriggerTime)
			{
				return true;
			}
			InvokeRepeating(TriggerDown, 0f, 0.01f);
			if (targetDist <= shortRange)
			{
				triggerEndTime = UnityEngine.Time.time + UnityEngine.Random.Range(attackEntity.attackLengthMin, attackEntity.attackLengthMax * attackLengthMaxShortRangeScale);
			}
			else
			{
				triggerEndTime = UnityEngine.Time.time + UnityEngine.Random.Range(attackEntity.attackLengthMin, attackEntity.attackLengthMax);
			}
			TriggerDown();
			return true;
		}
		attackEntity.ServerUse(damageScale);
		lastGunShotTime = UnityEngine.Time.time;
		return true;
	}

	public virtual float GetAimConeScale()
	{
		return 1f;
	}

	public void CancelBurst(float delay = 0.2f)
	{
		if (triggerEndTime > UnityEngine.Time.time + delay)
		{
			triggerEndTime = UnityEngine.Time.time + delay;
		}
	}

	public bool MeleeAttack()
	{
		AttackEntity attackEntity = GetHeldEntity() as AttackEntity;
		if (attackEntity == null)
		{
			return false;
		}
		BaseMelee baseMelee = attackEntity as BaseMelee;
		if (baseMelee == null)
		{
			return false;
		}
		baseMelee.ServerUse(damageScale);
		return true;
	}

	public virtual void TriggerDown()
	{
		AttackEntity attackEntity = GetHeldEntity() as AttackEntity;
		if (attackEntity != null)
		{
			attackEntity.ServerUse(damageScale);
		}
		lastGunShotTime = UnityEngine.Time.time;
		if (UnityEngine.Time.time > triggerEndTime)
		{
			CancelInvoke(TriggerDown);
			nextTriggerTime = UnityEngine.Time.time + ((attackEntity != null) ? attackEntity.attackSpacing : 1f);
		}
	}

	public virtual void EquipWeapon(bool skipDeployDelay = false)
	{
		if (base.inventory == null || base.inventory.containerBelt == null)
		{
			return;
		}
		Item slot = base.inventory.containerBelt.GetSlot(0);
		if (Interface.CallHook("OnNpcEquipWeapon", this, slot) != null || slot == null)
		{
			return;
		}
		UpdateActiveItem(base.inventory.containerBelt.GetSlot(0).uid);
		BaseEntity heldEntity = slot.GetHeldEntity();
		if (!(heldEntity != null))
		{
			return;
		}
		AttackEntity component = heldEntity.GetComponent<AttackEntity>();
		if (component != null)
		{
			if (skipDeployDelay)
			{
				component.ResetAttackCooldown();
			}
			component.TopUpAmmo();
		}
	}

	public void EquipTest()
	{
		EquipWeapon(skipDeployDelay: true);
	}

	internal void ServerThink_Internal()
	{
		float delta = UnityEngine.Time.time - lastThinkTime;
		ServerThink(delta);
		lastThinkTime = UnityEngine.Time.time;
	}

	public virtual void ServerThink(float delta)
	{
		TickAi(delta);
	}

	public virtual void Resume()
	{
	}

	public virtual bool IsNavRunning()
	{
		return false;
	}

	public virtual void TickAi(float delta)
	{
	}

	public void TickMovement()
	{
		float delta = UnityEngine.Time.realtimeSinceStartup - lastMovementTickTime;
		lastMovementTickTime = UnityEngine.Time.realtimeSinceStartup;
		MovementUpdate(delta);
	}

	public override float GetNetworkTime()
	{
		if (UnityEngine.Time.realtimeSinceStartup - lastPositionUpdateTime > PositionTickRate * 2f)
		{
			return UnityEngine.Time.time;
		}
		return lastPositionUpdateTime;
	}

	public virtual void MovementUpdate(float delta)
	{
		if (!LegacyNavigation || base.isClient || !IsAlive() || IsWounded() || (!base.isMounted && !IsNavRunning()))
		{
			return;
		}
		if (IsDormant || !syncPosition)
		{
			if (IsNavRunning())
			{
				NavAgent.destination = ServerPosition;
			}
			return;
		}
		Vector3 moveToPosition = base.transform.position;
		if (HasPath)
		{
			moveToPosition = NavAgent.nextPosition;
		}
		if (ValidateNextPosition(ref moveToPosition))
		{
			UpdateSpeed(delta);
			UpdatePositionAndRotation(moveToPosition);
		}
	}

	private bool ValidateNextPosition(ref Vector3 moveToPosition)
	{
		if (!ValidBounds.Test(this, moveToPosition) && base.transform != null && !base.IsDestroyed)
		{
			Debug.Log("Invalid NavAgent Position: " + this?.ToString() + " " + moveToPosition.ToString() + " (destroying)");
			Kill();
			return false;
		}
		return true;
	}

	private void UpdateSpeed(float delta)
	{
		float b = DesiredMoveSpeed();
		NavAgent.speed = Mathf.Lerp(NavAgent.speed, b, delta * 8f);
	}

	protected virtual void UpdatePositionAndRotation(Vector3 moveToPosition)
	{
		lastPositionUpdateTime = UnityEngine.Time.time;
		ServerPosition = moveToPosition;
		SetAimDirection(GetAimDirection());
	}

	public Vector3 GetPosition()
	{
		return base.transform.position;
	}

	public virtual float DesiredMoveSpeed()
	{
		float running = Mathf.Sin(UnityEngine.Time.time + randomOffset);
		return GetSpeed(running, 0f, 0f);
	}

	public override bool EligibleForWounding(HitInfo info)
	{
		return false;
	}

	public virtual Vector3 GetAimDirection()
	{
		if (Vector3Ex.Distance2D(finalDestination, GetPosition()) >= 1f)
		{
			Vector3 normalized = (finalDestination - GetPosition()).normalized;
			return new Vector3(normalized.x, 0f, normalized.z);
		}
		return base.eyes.BodyForward();
	}

	public virtual void SetAimDirection(Vector3 newAim)
	{
		if (!(newAim == Vector3.zero))
		{
			AttackEntity attackEntity = GetAttackEntity();
			if ((bool)attackEntity)
			{
				newAim = attackEntity.ModifyAIAim(newAim);
			}
			base.eyes.rotation = Quaternion.LookRotation(newAim, Vector3.up);
			viewAngles = base.eyes.rotation.eulerAngles;
			ServerRotation = base.eyes.rotation;
			lastPositionUpdateTime = UnityEngine.Time.time;
		}
	}

	public bool TryUseThrownWeapon(BaseEntity target, float attackRate)
	{
		if (HasThrownItemCooldown())
		{
			return false;
		}
		Item item = FindThrownWeapon();
		if (item == null)
		{
			lastThrowTime = UnityEngine.Time.time;
			return false;
		}
		return TryUseThrownWeapon(item, target, attackRate);
	}

	public bool TryUseThrownWeapon(Item item, BaseEntity target, float attackRate)
	{
		if (HasThrownItemCooldown())
		{
			return false;
		}
		float num = Vector3.Distance(target.transform.position, base.transform.position);
		if (num <= 2f || num >= 20f)
		{
			return false;
		}
		Vector3 position = target.transform.position;
		if (!IsVisible(CenterPoint(), position))
		{
			return false;
		}
		if (UseThrownWeapon(item, target))
		{
			if (this is ScarecrowNPC)
			{
				ScarecrowNPC.NextBeanCanAllowedTime = UnityEngine.Time.time + Halloween.scarecrow_throw_beancan_global_delay;
			}
			lastThrowTime = UnityEngine.Time.time;
			return true;
		}
		return false;
	}

	public bool HasThrownItemCooldown()
	{
		return UnityEngine.Time.time - lastThrowTime < 10f;
	}

	protected bool UseThrownWeapon(Item item, BaseEntity target)
	{
		UpdateActiveItem(item.uid);
		ThrownWeapon thrownWeapon = GetActiveItem().GetHeldEntity() as ThrownWeapon;
		if (thrownWeapon == null)
		{
			return false;
		}
		StartCoroutine(DoThrow(thrownWeapon, target));
		return true;
	}

	private IEnumerator DoThrow(ThrownWeapon thrownWeapon, BaseEntity target)
	{
		modelState.aiming = true;
		yield return new WaitForSeconds(1.5f);
		SetAimDirection(Vector3Ex.Direction(target.transform.position, base.transform.position));
		thrownWeapon.ResetAttackCooldown();
		thrownWeapon.ServerThrow(target.transform.position);
		modelState.aiming = false;
		Invoke(EquipTest, 0.5f);
	}

	public Item FindThrownWeapon()
	{
		if (base.inventory == null || base.inventory.containerBelt == null)
		{
			return null;
		}
		for (int i = 0; i < base.inventory.containerBelt.capacity; i++)
		{
			Item slot = base.inventory.containerBelt.GetSlot(i);
			if (slot != null && slot.GetHeldEntity() as ThrownWeapon != null)
			{
				return slot;
			}
		}
		return null;
	}

	public override BaseCorpse CreateCorpse(PlayerFlags flagsOnDeath, Vector3 posOnDeath, Quaternion rotOnDeath, List<TriggerBase> triggersOnDeath, bool forceServerSide = false)
	{
		using (TimeWarning.New("Create corpse"))
		{
			NPCPlayerCorpse nPCPlayerCorpse = DropCorpse(CorpsePath, flagsOnDeath, modelState) as NPCPlayerCorpse;
			if ((bool)nPCPlayerCorpse)
			{
				if (NavAgent != null)
				{
					nPCPlayerCorpse.transform.position += Vector3.down * NavAgent.baseOffset;
				}
				nPCPlayerCorpse.SetLootableIn(2f);
				nPCPlayerCorpse.SetFlag(Flags.Reserved5, HasPlayerFlag(PlayerFlags.DisplaySash));
				nPCPlayerCorpse.SetFlag(Flags.Reserved2, b: true);
				if (CopyInventoryToCorpse)
				{
					nPCPlayerCorpse.TakeFrom(this, base.inventory.containerMain, base.inventory.containerWear, base.inventory.containerBelt);
				}
				else
				{
					nPCPlayerCorpse.CreateEmptyContainer(base.inventory.containerMain.capacity);
				}
				nPCPlayerCorpse.playerName = OverrideCorpseName;
				nPCPlayerCorpse.playerSteamID = userID;
				nPCPlayerCorpse.Spawn();
				if (ShouldCorpseTakeChildren)
				{
					nPCPlayerCorpse.TakeChildren(this);
				}
				for (int i = 0; i < nPCPlayerCorpse.containers.Length; i++)
				{
					ItemContainer itemContainer = nPCPlayerCorpse.containers[i];
					if (!KeepCorpseClothingIntact || i != 1)
					{
						itemContainer.Clear();
					}
				}
				object obj = Interface.CallHook("OnCorpsePopulate", this, nPCPlayerCorpse);
				if (obj is BaseCorpse)
				{
					return (BaseCorpse)obj;
				}
				ApplyLoot(nPCPlayerCorpse);
			}
			return nPCPlayerCorpse;
		}
	}

	protected virtual void ApplyLoot(NPCPlayerCorpse corpse)
	{
	}
}
