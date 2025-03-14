using ConVar;
using UnityEngine;

public class ScarecrowBrain : BaseAIBrain
{
	public class AttackState : BasicAIState
	{
		private IAIAttack attack;

		private float originalStoppingDistance;

		public AttackState()
			: base(AIState.Attack)
		{
			base.AgrresiveState = true;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			entity.SetFlag(BaseEntity.Flags.Reserved3, b: true);
			originalStoppingDistance = brain.Navigator.StoppingDistance;
			brain.Navigator.Agent.stoppingDistance = 1f;
			brain.Navigator.StoppingDistance = 1f;
			base.StateEnter(brain, entity);
			attack = entity as IAIAttack;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity != null)
			{
				Vector3 aimDirection = GetAimDirection(brain.Navigator.transform.position, baseEntity.transform.position);
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
			entity.SetFlag(BaseEntity.Flags.Reserved3, b: false);
			brain.Navigator.Agent.stoppingDistance = originalStoppingDistance;
			brain.Navigator.StoppingDistance = originalStoppingDistance;
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
			if (brain.Senses.ignoreSafeZonePlayers)
			{
				BasePlayer basePlayer = baseEntity as BasePlayer;
				if (basePlayer != null && basePlayer.InSafeZone())
				{
					return StateStatus.Error;
				}
			}
			Vector3Ex.Direction2D(baseEntity.transform.position, entity.transform.position);
			Vector3 position = baseEntity.transform.position;
			if (!brain.Navigator.SetDestination(position, BaseNavigator.NavigationSpeed.Fast, 0.2f))
			{
				return StateStatus.Error;
			}
			Vector3 aimDirection = GetAimDirection(brain.Navigator.transform.position, baseEntity.transform.position);
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

		private static Vector3 GetAimDirection(Vector3 from, Vector3 target)
		{
			return Vector3Ex.Direction2D(target, from);
		}

		private void StartAttacking(BaseEntity entity)
		{
			attack.StartAttacking(entity);
		}
	}

	public class ChaseState : BasicAIState
	{
		private float throwDelayTime;

		private bool useBeanCan;

		public ChaseState()
			: base(AIState.Chase)
		{
			base.AgrresiveState = true;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			entity.SetFlag(BaseEntity.Flags.Reserved3, b: true);
			throwDelayTime = UnityEngine.Time.time + Random.Range(0.2f, 0.5f);
			useBeanCan = (float)Random.Range(0, 100) <= 20f;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity != null)
			{
				brain.Navigator.SetDestination(baseEntity.transform.position, BaseNavigator.NavigationSpeed.Fast);
			}
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			entity.SetFlag(BaseEntity.Flags.Reserved3, b: false);
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
			if (useBeanCan && UnityEngine.Time.time >= throwDelayTime && AI.npc_use_thrown_weapons && Halloween.scarecrows_throw_beancans && UnityEngine.Time.time >= ScarecrowNPC.NextBeanCanAllowedTime && (brain.GetBrainBaseEntity() as ScarecrowNPC).TryUseThrownWeapon(baseEntity, 10f))
			{
				brain.Navigator.Stop();
				return StateStatus.Running;
			}
			if (!(brain.GetBrainBaseEntity() as BasePlayer).modelState.aiming)
			{
				if (!brain.Navigator.SetDestination(baseEntity.transform.position, BaseNavigator.NavigationSpeed.Fast, 0.25f))
				{
					return StateStatus.Error;
				}
				if (!brain.Navigator.Moving)
				{
					return StateStatus.Finished;
				}
				return StateStatus.Running;
			}
			return StateStatus.Running;
		}
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
			ScarecrowNPC scarecrowNPC = entity as ScarecrowNPC;
			if (!(scarecrowNPC == null))
			{
				Vector3 vector = brain.Events.Memory.Position.Get(4);
				Vector3 vector2 = vector;
				vector2 = ((!scarecrowNPC.RoamAroundHomePoint) ? brain.PathFinder.GetBestRoamPosition(brain.Navigator, brain.Navigator.transform.position, brain.Events.Memory.Position.Get(4), 10f, brain.Navigator.BestRoamPointMaxDistance) : brain.PathFinder.GetBestRoamPositionFromAnchor(brain.Navigator, vector, vector, 1f, brain.Navigator.BestRoamPointMaxDistance));
				if (brain.Navigator.SetDestination(vector2, BaseNavigator.NavigationSpeed.Slow))
				{
					status = StateStatus.Running;
				}
				else
				{
					status = StateStatus.Error;
				}
			}
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

	public override void AddStates()
	{
		base.AddStates();
		AddState(new BaseIdleState());
		AddState(new ChaseState());
		AddState(new AttackState());
		AddState(new RoamState());
		AddState(new BaseFleeState());
	}

	public override void InitializeAI()
	{
		base.InitializeAI();
		base.ThinkMode = AIThinkMode.Interval;
		thinkRate = 0.25f;
		base.PathFinder = new HumanPathFinder();
		((HumanPathFinder)base.PathFinder).Init(GetBaseEntity());
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
	}
}
