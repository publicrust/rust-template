using UnityEngine;

public class ScientistBrain : BaseAIBrain
{
	public class BlindedState : BaseBlindedState
	{
		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			HumanNPC obj = entity as HumanNPC;
			obj.SetDucked(flag: false);
			obj.Server_StartGesture(235662700u);
			brain.Navigator.SetDestination(brain.PathFinder.GetRandomPositionAround(entity.transform.position, 1f, 2.5f), BaseNavigator.NavigationSpeed.Slowest);
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			brain.Navigator.ClearFacingDirectionOverride();
			if (entity.ToPlayer() != null)
			{
				entity.ToPlayer().Server_CancelGesture();
			}
		}
	}

	public class ChaseState : BasicAIState
	{
		private StateStatus status = StateStatus.Error;

		private float nextPositionUpdateTime;

		public ChaseState()
			: base(AIState.Chase)
		{
			base.AgrresiveState = true;
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
			if (brain.PathFinder != null)
			{
				status = StateStatus.Running;
				nextPositionUpdateTime = 0f;
			}
		}

		private void Stop()
		{
			brain.Navigator.Stop();
			brain.Navigator.ClearFacingDirectionOverride();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			if (status == StateStatus.Error)
			{
				return status;
			}
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity == null)
			{
				return StateStatus.Error;
			}
			float num = Vector3.Distance(baseEntity.transform.position, entity.transform.position);
			if (brain.Senses.Memory.IsLOS(baseEntity) || num <= brain.Navigator.FaceTargetChaseDistance || base.TimeInState <= 5f)
			{
				brain.Navigator.SetFacingDirectionEntity(baseEntity);
			}
			else
			{
				brain.Navigator.ClearFacingDirectionOverride();
			}
			if (num <= 10f)
			{
				brain.Navigator.SetCurrentSpeed(BaseNavigator.NavigationSpeed.Normal);
			}
			else
			{
				brain.Navigator.SetCurrentSpeed(BaseNavigator.NavigationSpeed.Fast);
			}
			if (Time.time > nextPositionUpdateTime)
			{
				nextPositionUpdateTime = Time.time + Random.Range(0.5f, 1f);
				Vector3 pos = entity.transform.position;
				AIInformationZone informationZone = (entity as HumanNPC).GetInformationZone(baseEntity.transform.position);
				bool flag = false;
				if (informationZone != null)
				{
					AIMovePoint aIMovePoint = informationZone.GetBestMovePointNear(baseEntity, entity, 0f, brain.Navigator.BestMovementPointMaxDistance, checkLOS: true, entity);
					flag = aIMovePoint != null;
					if (!flag && brain.Navigator.CanPathFindToChaseTargetIfNoMovePoint)
					{
						float num2 = brain.Navigator.BestMovementPointMaxDistance * brain.Navigator.PathFindChaseLOSDistanceMultiplier;
						if (num <= num2 && Vector3.Distance(baseEntity.transform.position, brain.Events.Memory.Position.Get(4)) <= num2)
						{
							Vector3 vector = brain.transform.position;
							bool flag2 = false;
							for (int i = 0; i < brain.Navigator.PathFindChaseLOSAttemptCount; i++)
							{
								vector = brain.PathFinder.GetRandomPositionAround(baseEntity.transform.position, 1.5f, 7f) + Vector3.up;
								BasePlayer obj = baseEntity as BasePlayer;
								HumanNPC humanNPC = entity as HumanNPC;
								if (obj != null && humanNPC != null)
								{
									flag2 = !Physics.Linecast(baseEntity.transform.position + Vector3.up, vector, 1218519297, QueryTriggerInteraction.Ignore);
								}
								if (flag2)
								{
									break;
								}
							}
							if (flag2)
							{
								pos = vector;
							}
							flag = flag2;
							nextPositionUpdateTime = Time.time + Random.Range(5f, 8f);
						}
					}
					if (!flag && brain.Navigator.CanUseRandomMovePointIfNonFound)
					{
						aIMovePoint = informationZone.GetBestMovePointNear(baseEntity, entity, 0f, brain.Navigator.BestMovementPointMaxDistance, checkLOS: true, entity, returnClosest: false, returnRandom: true);
						if (aIMovePoint != null)
						{
							nextPositionUpdateTime = Time.time + 15f;
						}
						flag = true;
					}
					if (!flag)
					{
						aIMovePoint = ((!brain.Navigator.CanPathFindToChaseTargetIfNoMovePoint) ? informationZone.GetBestMovePointNear(baseEntity, entity, 0f, brain.Navigator.BestMovementPointMaxDistance, checkLOS: true, entity, returnClosest: true) : informationZone.GetBestMovePointNear(baseEntity, entity, 0f, brain.Navigator.BestMovementPointMaxDistance, checkLOS: true, entity, returnClosest: true, returnRandom: true));
						flag = aIMovePoint != null;
					}
					if ((bool)aIMovePoint)
					{
						aIMovePoint.SetUsedBy(entity, 5f);
						pos = brain.PathFinder.GetRandomPositionAround(aIMovePoint.transform.position, 0f, aIMovePoint.radius - 0.3f);
					}
				}
				if (!flag)
				{
					return StateStatus.Error;
				}
				if (num < 10f)
				{
					brain.Navigator.SetDestination(pos, BaseNavigator.NavigationSpeed.Normal);
				}
				else
				{
					brain.Navigator.SetDestination(pos, BaseNavigator.NavigationSpeed.Fast);
				}
			}
			if (brain.Navigator.Moving)
			{
				return StateStatus.Running;
			}
			return StateStatus.Finished;
		}
	}

	public class CombatState : BasicAIState
	{
		private float nextActionTime;

		private Vector3 combatStartPosition;

		public CombatState()
			: base(AIState.Combat)
		{
			base.AgrresiveState = true;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			combatStartPosition = entity.transform.position;
			FaceTarget();
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			(entity as HumanNPC).SetDucked(flag: false);
			brain.Navigator.ClearFacingDirectionOverride();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			HumanNPC humanNPC = entity as HumanNPC;
			FaceTarget();
			if (Time.time > nextActionTime)
			{
				if (Random.Range(0, 3) == 1)
				{
					nextActionTime = Time.time + Random.Range(1f, 2f);
					humanNPC.SetDucked(flag: true);
					brain.Navigator.Stop();
				}
				else
				{
					nextActionTime = Time.time + Random.Range(2f, 3f);
					humanNPC.SetDucked(flag: false);
					brain.Navigator.SetDestination(brain.PathFinder.GetRandomPositionAround(combatStartPosition, 1f), BaseNavigator.NavigationSpeed.Normal);
				}
			}
			return StateStatus.Running;
		}

		private void FaceTarget()
		{
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity == null)
			{
				brain.Navigator.ClearFacingDirectionOverride();
			}
			else
			{
				brain.Navigator.SetFacingDirectionEntity(baseEntity);
			}
		}
	}

	public class CombatStationaryState : BasicAIState
	{
		public CombatStationaryState()
			: base(AIState.CombatStationary)
		{
			base.AgrresiveState = true;
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			brain.Navigator.ClearFacingDirectionOverride();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (baseEntity != null)
			{
				brain.Navigator.SetFacingDirectionEntity(baseEntity);
			}
			else
			{
				brain.Navigator.ClearFacingDirectionOverride();
			}
			return StateStatus.Running;
		}
	}

	public class CoverState : BasicAIState
	{
		public CoverState()
			: base(AIState.Cover)
		{
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			HumanNPC humanNPC = entity as HumanNPC;
			humanNPC.SetDucked(flag: true);
			AIPoint aIPoint = brain.Events.Memory.AIPoint.Get(4);
			if (aIPoint != null)
			{
				aIPoint.SetUsedBy(entity);
			}
			if (!(humanNPC.healthFraction <= brain.HealBelowHealthFraction) || !(Random.Range(0f, 1f) <= brain.HealChance))
			{
				return;
			}
			Item item = humanNPC.FindHealingItem();
			if (item != null)
			{
				BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
				if (baseEntity == null || (!brain.Senses.Memory.IsLOS(baseEntity) && Vector3.Distance(entity.transform.position, baseEntity.transform.position) >= 5f))
				{
					humanNPC.UseHealingItem(item);
				}
			}
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			(entity as HumanNPC).SetDucked(flag: false);
			brain.Navigator.ClearFacingDirectionOverride();
			AIPoint aIPoint = brain.Events.Memory.AIPoint.Get(4);
			if (aIPoint != null)
			{
				aIPoint.ClearIfUsedBy(entity);
			}
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			HumanNPC humanNPC = entity as HumanNPC;
			BaseEntity baseEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			float num = humanNPC.AmmoFractionRemaining();
			if (num == 0f || (baseEntity != null && !brain.Senses.Memory.IsLOS(baseEntity) && num < 0.25f))
			{
				humanNPC.AttemptReload();
			}
			if (baseEntity != null)
			{
				brain.Navigator.SetFacingDirectionEntity(baseEntity);
			}
			return StateStatus.Running;
		}
	}

	public class DismountedState : BaseDismountedState
	{
		private StateStatus status = StateStatus.Error;

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			status = StateStatus.Error;
			if (brain.PathFinder == null)
			{
				return;
			}
			AIInformationZone informationZone = (entity as HumanNPC).GetInformationZone(entity.transform.position);
			if (!(informationZone == null))
			{
				AICoverPoint bestCoverPoint = informationZone.GetBestCoverPoint(entity.transform.position, entity.transform.position, 25f, 50f, entity);
				if ((bool)bestCoverPoint)
				{
					bestCoverPoint.SetUsedBy(entity, 10f);
				}
				Vector3 pos = ((bestCoverPoint == null) ? entity.transform.position : bestCoverPoint.transform.position);
				if (brain.Navigator.SetDestination(pos, BaseNavigator.NavigationSpeed.Fast))
				{
					status = StateStatus.Running;
				}
			}
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

	public class IdleState : BaseIdleState
	{
	}

	public class KillSelfState : BasicAIState
	{
		public KillSelfState()
			: base(AIState.KillSelf)
		{
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			entity.Kill();
		}
	}

	public class MountAPC : BasicAIState
	{
		public MountAPC()
			: base(AIState.MountAPC)
		{
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			BradleyAPC bradleyAPC = brain.Events.Memory.Entity.Get(7) as BradleyAPC;
			if (bradleyAPC != null)
			{
				bradleyAPC.OnScientistMounted(entity as ScientistNPC);
			}
			entity.Kill();
		}
	}

	public class MountedState : BaseMountedState
	{
	}

	public class MoveToVector3State : BasicAIState
	{
		public MoveToVector3State()
			: base(AIState.MoveToVector3)
		{
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			Stop();
		}

		private void Stop()
		{
			brain.Navigator.Stop();
			brain.Navigator.ClearFacingDirectionOverride();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			Vector3 pos = brain.Events.Memory.Position.Get(7);
			if (!brain.Navigator.SetDestination(pos, BaseNavigator.NavigationSpeed.Fast, 0.5f))
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

	public class RoamState : BaseRoamState
	{
		private StateStatus status = StateStatus.Error;

		private AIMovePoint roamPoint;

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			Stop();
			ClearRoamPointUsage(entity);
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			status = StateStatus.Error;
			ClearRoamPointUsage(entity);
			if (brain.PathFinder == null)
			{
				return;
			}
			status = StateStatus.Error;
			roamPoint = brain.PathFinder.GetBestRoamPoint(GetRoamAnchorPosition(), entity.transform.position, (entity as HumanNPC).eyes.BodyForward(), brain.Navigator.MaxRoamDistanceFromHome, brain.Navigator.BestRoamPointMaxDistance);
			if (roamPoint != null)
			{
				if (brain.Navigator.SetDestination(roamPoint.transform.position, BaseNavigator.NavigationSpeed.Slow))
				{
					roamPoint.SetUsedBy(entity);
					status = StateStatus.Running;
				}
				else
				{
					roamPoint.SetUsedBy(entity, 600f);
				}
			}
		}

		private void ClearRoamPointUsage(BaseEntity entity)
		{
			if (roamPoint != null)
			{
				roamPoint.ClearIfUsedBy(entity);
				roamPoint = null;
			}
		}

		private void Stop()
		{
			brain.Navigator.Stop();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			if (status == StateStatus.Error)
			{
				return status;
			}
			if (brain.Navigator.Moving)
			{
				return StateStatus.Running;
			}
			PickGoodLookDirection();
			return StateStatus.Finished;
		}

		private void PickGoodLookDirection()
		{
		}
	}

	public class TakeCoverState : BasicAIState
	{
		private StateStatus status = StateStatus.Error;

		private BaseEntity coverFromEntity;

		public TakeCoverState()
			: base(AIState.TakeCover)
		{
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			status = StateStatus.Running;
			if (!StartMovingToCover(entity as HumanNPC))
			{
				status = StateStatus.Error;
			}
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateLeave(brain, entity);
			brain.Navigator.ClearFacingDirectionOverride();
			ClearCoverPointUsage(entity);
		}

		private void ClearCoverPointUsage(BaseEntity entity)
		{
			AIPoint aIPoint = brain.Events.Memory.AIPoint.Get(4);
			if (aIPoint != null)
			{
				aIPoint.ClearIfUsedBy(entity);
			}
		}

		private bool StartMovingToCover(HumanNPC entity)
		{
			coverFromEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			Vector3 hideFromPosition = (coverFromEntity ? coverFromEntity.transform.position : (entity.transform.position + entity.LastAttackedDir * 30f));
			AIInformationZone informationZone = entity.GetInformationZone(entity.transform.position);
			if (informationZone == null)
			{
				return false;
			}
			float minRange = ((entity.SecondsSinceAttacked < 2f) ? 2f : 0f);
			float bestCoverPointMaxDistance = brain.Navigator.BestCoverPointMaxDistance;
			AICoverPoint bestCoverPoint = informationZone.GetBestCoverPoint(entity.transform.position, hideFromPosition, minRange, bestCoverPointMaxDistance, entity);
			if (bestCoverPoint == null)
			{
				return false;
			}
			Vector3 position = bestCoverPoint.transform.position;
			if (!brain.Navigator.SetDestination(position, BaseNavigator.NavigationSpeed.Normal))
			{
				return false;
			}
			FaceCoverFromEntity();
			brain.Events.Memory.AIPoint.Set(bestCoverPoint, 4);
			bestCoverPoint.SetUsedBy(entity);
			return true;
		}

		public override void DrawGizmos()
		{
			base.DrawGizmos();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			FaceCoverFromEntity();
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

		private void FaceCoverFromEntity()
		{
			coverFromEntity = brain.Events.Memory.Entity.Get(brain.Events.CurrentInputMemorySlot);
			if (!(coverFromEntity == null))
			{
				brain.Navigator.SetFacingDirectionEntity(coverFromEntity);
			}
		}
	}

	public static int Count;

	public override void AddStates()
	{
		base.AddStates();
		AddState(new IdleState());
		AddState(new RoamState());
		AddState(new ChaseState());
		AddState(new CombatState());
		AddState(new TakeCoverState());
		AddState(new CoverState());
		AddState(new MountedState());
		AddState(new DismountedState());
		AddState(new BaseFollowPathState());
		AddState(new BaseNavigateHomeState());
		AddState(new CombatStationaryState());
		AddState(new BaseMoveTorwardsState());
		AddState(new MoveToVector3State());
		AddState(new BlindedState());
		AddState(new KillSelfState());
		AddState(new MountAPC());
	}

	public override void InitializeAI()
	{
		base.InitializeAI();
		base.ThinkMode = AIThinkMode.Interval;
		thinkRate = 0.25f;
		base.PathFinder = new HumanPathFinder();
		((HumanPathFinder)base.PathFinder).Init(GetBaseEntity());
		Count++;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		Count--;
	}

	public HumanNPC GetEntity()
	{
		return GetBaseEntity() as HumanNPC;
	}

	protected override void OnStateChanged()
	{
		base.OnStateChanged();
		if (base.CurrentState != null)
		{
			switch (base.CurrentState.StateType)
			{
			case AIState.Idle:
			case AIState.Roam:
			case AIState.Patrol:
			case AIState.FollowPath:
			case AIState.Cooldown:
				GetEntity().SetPlayerFlag(BasePlayer.PlayerFlags.Relaxed, b: true);
				break;
			default:
				GetEntity().SetPlayerFlag(BasePlayer.PlayerFlags.Relaxed, b: false);
				break;
			}
		}
	}
}
