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
			base.StateEnter(brain, entity);
			attack = entity as IAIAttack;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			BasePlayer basePlayer = baseEntity as BasePlayer;
			if (basePlayer != null && basePlayer.IsDead())
			{
				StopAttacking();
			}
			else if (baseEntity != null && baseEntity.Health() > 0f)
			{
				BaseCombatEntity target = baseEntity as BaseCombatEntity;
				Vector3 aimDirection = GetAimDirection(entity as BaseCombatEntity, target);
				brain.Navigator.SetFacingDirectionOverride(aimDirection);
				if (attack.CanAttack(baseEntity))
				{
					StartAttacking(baseEntity);
				}
				brain.Navigator.SetDestination(baseEntity.transform.position, BaseNavigator.NavigationSpeed.Fast);
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
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (attack == null)
			{
				return StateStatus.Error;
			}
			if (baseEntity == null)
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
			if (basePlayer != null && basePlayer.IsDead())
			{
				StopAttacking();
				return StateStatus.Finished;
			}
			BaseVehicle baseVehicle = ((basePlayer != null) ? basePlayer.GetMountedVehicle() : null);
			if (baseVehicle != null && baseVehicle is BaseModularVehicle)
			{
				StopAttacking();
				return StateStatus.Error;
			}
			if (brain.Senses.ignoreSafeZonePlayers && basePlayer != null && basePlayer.InSafeZone())
			{
				return StateStatus.Error;
			}
			if (!brain.Navigator.SetDestination(baseEntity.transform.position, BaseNavigator.NavigationSpeed.Fast, 0.25f, (baseEntity is BasePlayer && attack != null) ? attack.EngagementRange() : 0f))
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
			if (from == null || target == null)
			{
				if (!(from != null))
				{
					return Vector3.forward;
				}
				return from.transform.forward;
			}
			return Vector3Ex.Direction2D(target.transform.position, from.transform.position);
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
			base.StateEnter(brain, entity);
			attack = entity as IAIAttack;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity != null)
			{
				brain.Navigator.SetDestination(baseEntity.transform.position, BaseNavigator.NavigationSpeed.Fast);
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
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity == null)
			{
				Stop();
				return StateStatus.Error;
			}
			if (!brain.Navigator.SetDestination(baseEntity.transform.position, BaseNavigator.NavigationSpeed.Fast, 0.25f, (baseEntity is BasePlayer && attack != null) ? attack.EngagementRange() : 0f))
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
			base.StateEnter(brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity != null)
			{
				stopFleeDistance = Random.Range(80f, 100f) + Mathf.Clamp(Vector3Ex.Distance2D(brain.Navigator.transform.position, baseEntity.transform.position), 0f, 50f);
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
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity == null)
			{
				return StateStatus.Finished;
			}
			if (Vector3Ex.Distance2D(brain.Navigator.transform.position, baseEntity.transform.position) >= stopFleeDistance)
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
			if (thisEntity == null || fleeFromEntity == null)
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
			if (Random.Range(0, 100) <= turnChance)
			{
				Vector3 position = entity.transform.position;
				Vector3 normalized = (BasePathFinder.GetPointOnCircle(position, 1f, Random.Range(0f, 594f)) - position).normalized;
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
			if (brain.Navigator.MaxRoamDistanceFromHome > -1f)
			{
				return brain.Events.Memory.Position.Get(4);
			}
			return brain.Navigator.transform.position;
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
