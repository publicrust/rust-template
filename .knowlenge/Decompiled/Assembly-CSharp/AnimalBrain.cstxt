using UnityEngine;

public class AnimalBrain : BaseAIBrain
{
	public class AttackState : BasicAIState
	{
		private IAIAttack attack;

		public AttackState()
			: base(AIState.Attack)
		{
			base.AgrresiveState = true;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			base.StateEnter(brain, entity);
			attack = entity as IAIAttack;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			BasePlayer basePlayer = baseEntity as BasePlayer;
			if ((Object)(object)basePlayer != (Object)null && basePlayer.IsDead())
			{
				StopAttacking();
			}
			else if ((Object)(object)baseEntity != (Object)null && baseEntity.Health() > 0f)
			{
				BaseCombatEntity target = baseEntity as BaseCombatEntity;
				Vector3 aimDirection = GetAimDirection(entity as BaseCombatEntity, target);
				brain.Navigator.SetFacingDirectionOverride(aimDirection);
				if (attack.CanAttack(baseEntity))
				{
					StartAttacking(baseEntity);
				}
				brain.Navigator.SetDestination(((Component)baseEntity).transform.position, BaseNavigator.NavigationSpeed.Fast);
			}
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			brain.Navigator.ClearFacingDirectionOverride();
			brain.Navigator.Stop();
			StopAttacking();
		}

		private void StopAttacking()
		{
			attack.StopAttacking();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (attack == null)
			{
				return StateStatus.Error;
			}
			if ((Object)(object)baseEntity == (Object)null)
			{
				brain.Navigator.ClearFacingDirectionOverride();
				StopAttacking();
				return StateStatus.Finished;
			}
			if (baseEntity.Health() <= 0f)
			{
				StopAttacking();
				return StateStatus.Finished;
			}
			BasePlayer basePlayer = baseEntity as BasePlayer;
			if ((Object)(object)basePlayer != (Object)null && basePlayer.IsDead())
			{
				StopAttacking();
				return StateStatus.Finished;
			}
			BaseVehicle baseVehicle = (((Object)(object)basePlayer != (Object)null) ? basePlayer.GetMountedVehicle() : null);
			if ((Object)(object)baseVehicle != (Object)null && baseVehicle is BaseModularVehicle)
			{
				StopAttacking();
				return StateStatus.Error;
			}
			if (brain.Senses.ignoreSafeZonePlayers && (Object)(object)basePlayer != (Object)null && basePlayer.InSafeZone())
			{
				return StateStatus.Error;
			}
			if (!brain.Navigator.SetDestination(((Component)baseEntity).transform.position, BaseNavigator.NavigationSpeed.Fast, 0.25f, (baseEntity is BasePlayer && attack != null) ? attack.EngagementRange() : 0f))
			{
				return StateStatus.Error;
			}
			BaseCombatEntity target = baseEntity as BaseCombatEntity;
			Vector3 aimDirection = GetAimDirection(entity as BaseCombatEntity, target);
			brain.Navigator.SetFacingDirectionOverride(aimDirection);
			if (attack.CanAttack(baseEntity))
			{
				StartAttacking(baseEntity);
			}
			else
			{
				StopAttacking();
			}
			return StateStatus.Running;
		}

		private static Vector3 GetAimDirection(BaseCombatEntity from, BaseCombatEntity target)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)from == (Object)null || (Object)(object)target == (Object)null)
			{
				if (!((Object)(object)from != (Object)null))
				{
					return Vector3.forward;
				}
				return ((Component)from).transform.forward;
			}
			return Vector3Ex.Direction2D(((Component)target).transform.position, ((Component)from).transform.position);
		}

		private void StartAttacking(BaseEntity entity)
		{
			attack.StartAttacking(entity);
		}
	}

	public class ChaseState : BasicAIState
	{
		private IAIAttack attack;

		public ChaseState()
			: base(AIState.Chase)
		{
			base.AgrresiveState = true;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			base.StateEnter(brain, entity);
			attack = entity as IAIAttack;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if ((Object)(object)baseEntity != (Object)null)
			{
				brain.Navigator.SetDestination(((Component)baseEntity).transform.position, BaseNavigator.NavigationSpeed.Fast);
			}
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			Stop();
		}

		private void Stop()
		{
			brain.Navigator.Stop();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if ((Object)(object)baseEntity == (Object)null)
			{
				Stop();
				return StateStatus.Error;
			}
			if (!brain.Navigator.SetDestination(((Component)baseEntity).transform.position, BaseNavigator.NavigationSpeed.Fast, 0.25f, (baseEntity is BasePlayer && attack != null) ? attack.EngagementRange() : 0f))
			{
				return StateStatus.Error;
			}
			if (!brain.Navigator.Moving)
			{
				return StateStatus.Finished;
			}
			return StateStatus.Running;
		}
	}

	public class FleeState : BasicAIState
	{
		private float nextInterval = 2f;

		private float stopFleeDistance;

		public FleeState()
			: base(AIState.Flee)
		{
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			base.StateEnter(brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if ((Object)(object)baseEntity != (Object)null)
			{
				stopFleeDistance = Random.Range(80f, 100f) + Mathf.Clamp(Vector3Ex.Distance2D(((Component)brain.Navigator).transform.position, ((Component)baseEntity).transform.position), 0f, 50f);
			}
			FleeFrom(brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot), entity);
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			Stop();
		}

		private void Stop()
		{
			brain.Navigator.Stop();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if ((Object)(object)baseEntity == (Object)null)
			{
				return StateStatus.Finished;
			}
			if (Vector3Ex.Distance2D(((Component)brain.Navigator).transform.position, ((Component)baseEntity).transform.position) >= stopFleeDistance)
			{
				return StateStatus.Finished;
			}
			if ((brain.Navigator.UpdateIntervalElapsed(nextInterval) || !brain.Navigator.Moving) && !FleeFrom(baseEntity, entity))
			{
				return StateStatus.Error;
			}
			return StateStatus.Running;
		}

		private bool FleeFrom(BaseEntity fleeFromEntity, BaseEntity thisEntity)
		{
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)thisEntity == (Object)null || (Object)(object)fleeFromEntity == (Object)null)
			{
				return false;
			}
			nextInterval = Random.Range(3f, 6f);
			if (!brain.PathFinder.GetBestFleePosition(brain.Navigator, brain.Senses, fleeFromEntity, brain.Events.Memory.Position.Get(4), 50f, 100f, out var result))
			{
				return false;
			}
			bool num = brain.Navigator.SetDestination(result, BaseNavigator.NavigationSpeed.Fast);
			if (!num)
			{
				Stop();
			}
			return num;
		}
	}

	public class IdleState : BaseIdleState
	{
		private float nextTurnTime;

		private float minTurnTime = 10f;

		private float maxTurnTime = 20f;

		private int turnChance = 33;

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			FaceNewDirection(entity);
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			brain.Navigator.ClearFacingDirectionOverride();
		}

		private void FaceNewDirection(BaseEntity entity)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			if (Random.Range(0, 100) <= turnChance)
			{
				Vector3 position = ((Component)entity).transform.position;
				Vector3 val = BasePathFinder.GetPointOnCircle(position, 1f, Random.Range(0f, 594f)) - position;
				Vector3 normalized = ((Vector3)(ref val)).normalized;
				brain.Navigator.SetFacingDirectionOverride(normalized);
			}
			nextTurnTime = Time.realtimeSinceStartup + Random.Range(minTurnTime, maxTurnTime);
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			if (Time.realtimeSinceStartup >= nextTurnTime)
			{
				FaceNewDirection(entity);
			}
			return StateStatus.Running;
		}
	}

	public class MoveToPointState : BasicAIState
	{
		private float originalStopDistance;

		public MoveToPointState()
			: base(AIState.MoveToPoint)
		{
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			BaseNavigator navigator = brain.Navigator;
			originalStopDistance = navigator.StoppingDistance;
			navigator.StoppingDistance = 0.5f;
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			brain.Navigator.StoppingDistance = originalStopDistance;
			Stop();
		}

		private void Stop()
		{
			brain.Navigator.Stop();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			base.StateThink(delta, brain, entity);
			Vector3 pos = brain.Events.Memory.Position.Get(6);
			if (!brain.Navigator.SetDestination(pos, ControlTestAnimalSpeed))
			{
				return StateStatus.Error;
			}
			if (!brain.Navigator.Moving)
			{
				return StateStatus.Finished;
			}
			return StateStatus.Running;
		}
	}

	public class MoveTowardsState : BaseMoveTorwardsState
	{
	}

	public class RoamState : BasicAIState
	{
		private StateStatus status = StateStatus.Error;

		public RoamState()
			: base(AIState.Roam)
		{
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			Stop();
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			base.StateEnter(brain, entity);
			status = StateStatus.Error;
			if (brain.PathFinder == null)
			{
				return;
			}
			Vector3 center;
			if (brain.InGroup() && !brain.IsGroupLeader)
			{
				center = brain.Events.Memory.Position.Get(5);
				center = BasePathFinder.GetPointOnCircle(center, Random.Range(2f, 7f), Random.Range(0f, 359f));
			}
			else
			{
				center = brain.PathFinder.GetBestRoamPosition(brain.Navigator, GetRoamAnchorPosition(), brain.Events.Memory.Position.Get(4), GetRoamPointMinDistance(), GetRoamPointMaxDistance());
			}
			if (brain.Navigator.SetDestination(center, BaseNavigator.NavigationSpeed.Slow))
			{
				if (brain.InGroup() && brain.IsGroupLeader)
				{
					brain.SetGroupRoamRootPosition(center);
				}
				status = StateStatus.Running;
			}
			else
			{
				status = StateStatus.Error;
			}
		}

		public virtual Vector3 GetRoamAnchorPosition()
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			if (brain.Navigator.MaxRoamDistanceFromHome > -1f)
			{
				return brain.Events.Memory.Position.Get(4);
			}
			return ((Component)brain.Navigator).transform.position;
		}

		public virtual float GetRoamPointMinDistance()
		{
			if (brain.Navigator.MaxRoamDistanceFromHome > -1f)
			{
				return 5f;
			}
			return 20f;
		}

		public virtual float GetRoamPointMaxDistance()
		{
			if (brain.Navigator.MaxRoamDistanceFromHome > -1f)
			{
				return brain.Navigator.MaxRoamDistanceFromHome;
			}
			return brain.Navigator.BestRoamPointMaxDistance;
		}

		private void Stop()
		{
			brain.Navigator.Stop();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			if (status == StateStatus.Error)
			{
				return status;
			}
			if (brain.Navigator.Moving)
			{
				return StateStatus.Running;
			}
			return StateStatus.Finished;
		}
	}

	public static int Count;

	public static BaseNavigator.NavigationSpeed ControlTestAnimalSpeed = BaseNavigator.NavigationSpeed.Fast;

	public override void AddStates()
	{
		base.AddStates();
		AddState(new IdleState());
		AddState(new MoveTowardsState());
		AddState(new FleeState());
		AddState(new RoamState());
		AddState(new AttackState());
		AddState(new BaseSleepState());
		AddState(new ChaseState());
		AddState(new BaseCooldownState());
		AddState(new MoveToPointState());
	}

	public override void InitializeAI()
	{
		base.InitializeAI();
		base.ThinkMode = AIThinkMode.Interval;
		thinkRate = 0.25f;
		base.PathFinder = new BasePathFinder();
		Count++;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		Count--;
	}

	public BaseAnimalNPC GetEntity()
	{
		return GetBaseEntity() as BaseAnimalNPC;
	}
}
