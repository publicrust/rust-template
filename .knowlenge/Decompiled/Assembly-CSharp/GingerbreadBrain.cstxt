using UnityEngine;

public class GingerbreadBrain : BaseAIBrain
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
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			entity.SetFlag(BaseEntity.Flags.Reserved3, b: true);
			originalStoppingDistance = brain.Navigator.StoppingDistance;
			brain.Navigator.Agent.stoppingDistance = 1f;
			brain.Navigator.StoppingDistance = 1f;
			base.StateEnter(brain, entity);
			attack = entity as IAIAttack;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if ((Object)(object)baseEntity != (Object)null)
			{
				Vector3 aimDirection = GetAimDirection(((Component)brain.Navigator).transform.position, ((Component)baseEntity).transform.position);
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
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
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
			if (brain.Senses.ignoreSafeZonePlayers)
			{
				BasePlayer basePlayer = baseEntity as BasePlayer;
				if ((Object)(object)basePlayer != (Object)null && basePlayer.InSafeZone())
				{
					return StateStatus.Error;
				}
			}
			Vector3Ex.Direction2D(((Component)baseEntity).transform.position, ((Component)entity).transform.position);
			Vector3 position = ((Component)baseEntity).transform.position;
			if (!brain.Navigator.SetDestination(position, BaseNavigator.NavigationSpeed.Fast, 0.2f))
			{
				return StateStatus.Error;
			}
			Vector3 aimDirection = GetAimDirection(((Component)brain.Navigator).transform.position, ((Component)baseEntity).transform.position);
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
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return Vector3Ex.Direction2D(target, from);
		}

		private void StartAttacking(BaseEntity entity)
		{
			attack.StartAttacking(entity);
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
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			base.StateEnter(brain, entity);
			status = StateStatus.Error;
			if (brain.PathFinder == null)
			{
				return;
			}
			ScarecrowNPC scarecrowNPC = entity as ScarecrowNPC;
			if (!((Object)(object)scarecrowNPC == (Object)null))
			{
				Vector3 val = brain.Events.Memory.Position.Get(4);
				Vector3 val2 = val;
				val2 = ((!scarecrowNPC.RoamAroundHomePoint) ? brain.PathFinder.GetBestRoamPosition(brain.Navigator, ((Component)brain.Navigator).transform.position, brain.Events.Memory.Position.Get(4), 10f, brain.Navigator.BestRoamPointMaxDistance) : brain.PathFinder.GetBestRoamPositionFromAnchor(brain.Navigator, val, val, 1f, brain.Navigator.BestRoamPointMaxDistance));
				if (brain.Navigator.SetDestination(val2, BaseNavigator.NavigationSpeed.Slow))
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
		AddState(new BaseChaseState());
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
