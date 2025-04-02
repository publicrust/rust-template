using UnityEngine;

public class CH47AIBrain : BaseAIBrain
{
	public class DropCrate : BasicAIState
	{
		private float nextDropTime;

		public DropCrate()
			: base(AIState.DropCrate)
		{
		}

		public override bool CanInterrupt()
		{
			if (base.CanInterrupt())
			{
				return !CanDrop();
			}
			return false;
		}

		public bool CanDrop()
		{
			if (Time.time > nextDropTime)
			{
				return (brain.GetBrainBaseEntity() as CH47HelicopterAIController).CanDropCrate();
			}
			return false;
		}

		public override float GetWeight()
		{
			if (!CanDrop())
			{
				return 0f;
			}
			if (IsInState())
			{
				return 10000f;
			}
			if (brain.CurrentState != null && brain.CurrentState.StateType == AIState.Orbit && brain.CurrentState.TimeInState > 60f)
			{
				CH47DropZone closest = CH47DropZone.GetClosest(brain.mainInterestPoint);
				if ((bool)closest && Vector3Ex.Distance2D(closest.transform.position, brain.mainInterestPoint) < 200f)
				{
					CH47AIBrain component = brain.GetComponent<CH47AIBrain>();
					if (component != null)
					{
						float num = Mathf.InverseLerp(300f, 600f, component.Age);
						return 1000f * num;
					}
				}
			}
			return 0f;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			CH47HelicopterAIController obj = entity as CH47HelicopterAIController;
			obj.SetDropDoorOpen(open: true);
			obj.EnableFacingOverride(enabled: false);
			CH47DropZone closest = CH47DropZone.GetClosest(obj.transform.position);
			if (closest == null)
			{
				nextDropTime = Time.time + 60f;
			}
			brain.mainInterestPoint = closest.transform.position;
			obj.SetMoveTarget(brain.mainInterestPoint);
			base.StateEnter(brain, entity);
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			CH47HelicopterAIController cH47HelicopterAIController = entity as CH47HelicopterAIController;
			if (CanDrop() && Vector3Ex.Distance2D(brain.mainInterestPoint, cH47HelicopterAIController.transform.position) < 5f && cH47HelicopterAIController.rigidBody.velocity.magnitude < 5f)
			{
				cH47HelicopterAIController.DropCrate();
				nextDropTime = Time.time + 120f;
			}
			return StateStatus.Running;
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			(entity as CH47HelicopterAIController).SetDropDoorOpen(open: false);
			nextDropTime = Time.time + 60f;
			base.StateLeave(brain, entity);
		}
	}

	public class EgressState : BasicAIState
	{
		private bool killing;

		private bool egressAltitueAchieved;

		public EgressState()
			: base(AIState.Egress)
		{
		}

		public override bool CanInterrupt()
		{
			return false;
		}

		public override float GetWeight()
		{
			CH47HelicopterAIController cH47HelicopterAIController = brain.GetBrainBaseEntity() as CH47HelicopterAIController;
			if (cH47HelicopterAIController.OutOfCrates() && !cH47HelicopterAIController.ShouldLand())
			{
				return 10000f;
			}
			CH47AIBrain component = brain.GetComponent<CH47AIBrain>();
			if (component != null)
			{
				if (!(component.Age > 1800f))
				{
					return 0f;
				}
				return 10000f;
			}
			return 0f;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			CH47HelicopterAIController obj = entity as CH47HelicopterAIController;
			obj.EnableFacingOverride(enabled: false);
			Transform transform = obj.transform;
			Rigidbody rigidBody = obj.rigidBody;
			Vector3 vector = Vector3.Cross(Vector3.Cross(rhs: (rigidBody.velocity.magnitude < 0.1f) ? transform.forward : rigidBody.velocity.normalized, lhs: transform.up), Vector3.up);
			brain.mainInterestPoint = transform.position + vector * 8000f;
			brain.mainInterestPoint.y = 100f;
			obj.SetMoveTarget(brain.mainInterestPoint);
			base.StateEnter(brain, entity);
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			if (killing)
			{
				return StateStatus.Running;
			}
			CH47HelicopterAIController cH47HelicopterAIController = entity as CH47HelicopterAIController;
			Vector3 position = cH47HelicopterAIController.transform.position;
			if (position.y < 85f && !egressAltitueAchieved)
			{
				CH47LandingZone closest = CH47LandingZone.GetClosest(position);
				if (closest != null && Vector3Ex.Distance2D(closest.transform.position, position) < 20f)
				{
					float waterOrTerrainSurface = WaterLevel.GetWaterOrTerrainSurface(position, waves: false, volumes: false);
					waterOrTerrainSurface += 100f;
					Vector3 moveTarget = position;
					moveTarget.y = waterOrTerrainSurface;
					cH47HelicopterAIController.SetMoveTarget(moveTarget);
					return StateStatus.Running;
				}
			}
			egressAltitueAchieved = true;
			cH47HelicopterAIController.SetMoveTarget(brain.mainInterestPoint);
			if (base.TimeInState > 300f)
			{
				SingletonComponent<InvokeHandler>.Instance.Invoke(cH47HelicopterAIController.DelayedKill, 2f);
				killing = true;
			}
			return StateStatus.Running;
		}
	}

	public class IdleState : BaseIdleState
	{
		public override float GetWeight()
		{
			return 0.1f;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			CH47HelicopterAIController cH47HelicopterAIController = entity as CH47HelicopterAIController;
			cH47HelicopterAIController.SetMoveTarget(cH47HelicopterAIController.GetPosition() + cH47HelicopterAIController.rigidBody.velocity.normalized * 10f);
			base.StateEnter(brain, entity);
		}
	}

	public class LandState : BasicAIState
	{
		private float landedForSeconds;

		private float lastLandtime;

		private float landingHeight = 20f;

		private float nextDismountTime;

		public LandState()
			: base(AIState.Land)
		{
		}

		public override float GetWeight()
		{
			if (!(brain.GetBrainBaseEntity() as CH47HelicopterAIController).ShouldLand())
			{
				return 0f;
			}
			float num = Time.time - lastLandtime;
			if (IsInState() && landedForSeconds < 12f)
			{
				return 1000f;
			}
			if (!IsInState() && num > 10f)
			{
				return 9000f;
			}
			return 0f;
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			CH47HelicopterAIController cH47HelicopterAIController = entity as CH47HelicopterAIController;
			Vector3 position = cH47HelicopterAIController.transform.position;
			_ = cH47HelicopterAIController.transform.forward;
			CH47LandingZone closest = CH47LandingZone.GetClosest(cH47HelicopterAIController.landingTarget);
			if (!closest)
			{
				return StateStatus.Error;
			}
			float magnitude = cH47HelicopterAIController.rigidBody.velocity.magnitude;
			float num = Vector3Ex.Distance2D(closest.transform.position, position);
			bool enabled = num < 40f;
			bool altitudeProtection = num > 15f && position.y < closest.transform.position.y + 10f;
			cH47HelicopterAIController.EnableFacingOverride(enabled);
			cH47HelicopterAIController.SetAltitudeProtection(altitudeProtection);
			int num2;
			if (Mathf.Abs(closest.transform.position.y - position.y) < 3f && num <= 5f)
			{
				num2 = ((magnitude < 1f) ? 1 : 0);
				if (num2 != 0)
				{
					landedForSeconds += delta;
					if (lastLandtime == 0f)
					{
						lastLandtime = Time.time;
					}
				}
			}
			else
			{
				num2 = 0;
			}
			float num3 = 1f - Mathf.InverseLerp(0f, 7f, num);
			landingHeight -= 4f * num3 * Time.deltaTime;
			if (landingHeight < -5f)
			{
				landingHeight = -5f;
			}
			cH47HelicopterAIController.SetAimDirection(closest.transform.forward);
			Vector3 moveTarget = brain.mainInterestPoint + new Vector3(0f, landingHeight, 0f);
			if (num < 100f && num > 15f)
			{
				Vector3 vector = Vector3Ex.Direction2D(closest.transform.position, position);
				if (Physics.SphereCast(position, 15f, vector, out var hitInfo, num, 1218511105))
				{
					Vector3 vector2 = Vector3.Cross(vector, Vector3.up);
					moveTarget = hitInfo.point + vector2 * 50f;
				}
			}
			cH47HelicopterAIController.SetMoveTarget(moveTarget);
			if (num2 != 0)
			{
				if (landedForSeconds > 1f && Time.time > nextDismountTime)
				{
					foreach (BaseVehicle.MountPointInfo mountPoint in cH47HelicopterAIController.mountPoints)
					{
						if ((bool)mountPoint.mountable && mountPoint.mountable.AnyMounted())
						{
							nextDismountTime = Time.time + 0.5f;
							mountPoint.mountable.DismountAllPlayers();
							break;
						}
					}
				}
				if (landedForSeconds > 8f)
				{
					brain.GetComponent<CH47AIBrain>().ForceSetAge(float.PositiveInfinity);
				}
			}
			return StateStatus.Running;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			brain.mainInterestPoint = (entity as CH47HelicopterAIController).landingTarget;
			landingHeight = 15f;
			base.StateEnter(brain, entity);
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			CH47HelicopterAIController obj = entity as CH47HelicopterAIController;
			obj.EnableFacingOverride(enabled: false);
			obj.SetAltitudeProtection(on: true);
			obj.SetMinHoverHeight(30f);
			landedForSeconds = 0f;
			base.StateLeave(brain, entity);
		}

		public override bool CanInterrupt()
		{
			return true;
		}
	}

	public class OrbitState : BasicAIState
	{
		public OrbitState()
			: base(AIState.Orbit)
		{
		}

		public Vector3 GetOrbitCenter()
		{
			return brain.mainInterestPoint;
		}

		public override float GetWeight()
		{
			if (IsInState())
			{
				float num = 1f - Mathf.InverseLerp(120f, 180f, base.TimeInState);
				return 5f * num;
			}
			if (brain.CurrentState != null && brain.CurrentState.StateType == AIState.Patrol && brain.CurrentState is PatrolState patrolState && patrolState.AtPatrolDestination())
			{
				return 5f;
			}
			return 0f;
		}

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			CH47HelicopterAIController obj = entity as CH47HelicopterAIController;
			obj.EnableFacingOverride(enabled: true);
			obj.InitiateAnger();
			base.StateEnter(brain, entity);
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			Vector3 orbitCenter = GetOrbitCenter();
			CH47HelicopterAIController cH47HelicopterAIController = entity as CH47HelicopterAIController;
			Vector3 position = cH47HelicopterAIController.GetPosition();
			Vector3 vector = Vector3Ex.Direction2D(orbitCenter, position);
			Vector3 vector2 = Vector3.Cross(Vector3.up, vector);
			float num = ((Vector3.Dot(Vector3.Cross(cH47HelicopterAIController.transform.right, Vector3.up), vector2) < 0f) ? (-1f) : 1f);
			float num2 = 75f;
			Vector3 normalized = (-vector + vector2 * num * 0.6f).normalized;
			Vector3 vector3 = orbitCenter + normalized * num2;
			cH47HelicopterAIController.SetMoveTarget(vector3);
			cH47HelicopterAIController.SetAimDirection(Vector3Ex.Direction2D(vector3, position));
			base.StateThink(delta, brain, entity);
			return StateStatus.Running;
		}

		public override void StateLeave(BaseAIBrain brain, BaseEntity entity)
		{
			CH47HelicopterAIController obj = entity as CH47HelicopterAIController;
			obj.EnableFacingOverride(enabled: false);
			obj.CancelAnger();
			base.StateLeave(brain, entity);
		}
	}

	public class PatrolState : BasePatrolState
	{
		protected float patrolApproachDist = 75f;

		public override void StateEnter(BaseAIBrain brain, BaseEntity entity)
		{
			base.StateEnter(brain, entity);
			brain.mainInterestPoint = brain.PathFinder.GetRandomPatrolPoint();
		}

		public override StateStatus StateThink(float delta, BaseAIBrain brain, BaseEntity entity)
		{
			base.StateThink(delta, brain, entity);
			(entity as CH47HelicopterAIController).SetMoveTarget(brain.mainInterestPoint);
			return StateStatus.Running;
		}

		public bool AtPatrolDestination()
		{
			return Vector3Ex.Distance2D(GetDestination(), brain.transform.position) < patrolApproachDist;
		}

		public Vector3 GetDestination()
		{
			return brain.mainInterestPoint;
		}

		public override bool CanInterrupt()
		{
			if (base.CanInterrupt())
			{
				return AtPatrolDestination();
			}
			return false;
		}

		public override float GetWeight()
		{
			if (IsInState())
			{
				if (AtPatrolDestination() && base.TimeInState > 2f)
				{
					return 0f;
				}
				return 3f;
			}
			float num = Mathf.InverseLerp(70f, 120f, TimeSinceState()) * 5f;
			return 1f + num;
		}
	}

	public override void AddStates()
	{
		base.AddStates();
		AddState(new IdleState());
		AddState(new PatrolState());
		AddState(new OrbitState());
		AddState(new EgressState());
		AddState(new DropCrate());
		AddState(new LandState());
	}

	public override void InitializeAI()
	{
		base.InitializeAI();
		base.ThinkMode = AIThinkMode.FixedUpdate;
		base.PathFinder = new CH47PathFinder();
	}

	public void FixedUpdate()
	{
		if (!(base.baseEntity == null) && !base.baseEntity.isClient)
		{
			Think(Time.fixedDeltaTime);
		}
	}
}
