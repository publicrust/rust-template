using System.Collections.Generic;
using ConVar;
using Rust;
using Rust.Ai;
using UnityEngine;

public class SimpleShark : BaseCombatEntity
{
	public class SimpleState
	{
		public SimpleShark entity;

		private float stateEnterTime;

		public SimpleState(SimpleShark owner)
		{
			entity = owner;
		}

		public virtual float State_Weight()
		{
			return 0f;
		}

		public virtual void State_Enter()
		{
			stateEnterTime = UnityEngine.Time.realtimeSinceStartup;
		}

		public virtual void State_Think(float delta)
		{
		}

		public virtual void State_Exit()
		{
		}

		public virtual bool CanInterrupt()
		{
			return true;
		}

		public virtual float TimeInState()
		{
			return UnityEngine.Time.realtimeSinceStartup - stateEnterTime;
		}
	}

	public class IdleState : SimpleState
	{
		private int patrolTargetIndex;

		public IdleState(SimpleShark owner)
			: base(owner)
		{
		}

		public Vector3 GetTargetPatrolPosition()
		{
			return entity.patrolPath[patrolTargetIndex];
		}

		public override float State_Weight()
		{
			return 1f;
		}

		public override void State_Enter()
		{
			float num = float.PositiveInfinity;
			int num2 = 0;
			for (int i = 0; i < entity.patrolPath.Count; i++)
			{
				float num3 = Vector3.Distance(entity.patrolPath[i], entity.transform.position);
				if (num3 < num)
				{
					num2 = i;
					num = num3;
				}
			}
			patrolTargetIndex = num2;
			base.State_Enter();
		}

		public override void State_Think(float delta)
		{
			if (Vector3.Distance(GetTargetPatrolPosition(), entity.transform.position) < entity.stoppingDistance)
			{
				patrolTargetIndex++;
				if (patrolTargetIndex >= entity.patrolPath.Count)
				{
					patrolTargetIndex = 0;
				}
			}
			if (entity.TimeSinceAttacked() >= 120f && entity.healthFraction < 1f)
			{
				entity.health = entity.MaxHealth();
			}
			entity.destination = entity.WaterClamp(GetTargetPatrolPosition());
		}

		public override void State_Exit()
		{
			base.State_Exit();
		}

		public override bool CanInterrupt()
		{
			return true;
		}
	}

	public class AttackState : SimpleState
	{
		public AttackState(SimpleShark owner)
			: base(owner)
		{
		}

		public override float State_Weight()
		{
			if (!entity.HasTarget() || !entity.CanAttack())
			{
				return 0f;
			}
			return 10f;
		}

		public override void State_Enter()
		{
			base.State_Enter();
		}

		public override void State_Think(float delta)
		{
			BasePlayer target = entity.GetTarget();
			if (target == null)
			{
				return;
			}
			if (TimeInState() >= 10f)
			{
				entity.nextAttackTime = UnityEngine.Time.realtimeSinceStartup + 4f;
				entity.Startle();
				return;
			}
			if (entity.CanAttack())
			{
				entity.Startle();
			}
			float num = Vector3.Distance(entity.GetTarget().eyes.position, entity.transform.position);
			bool num2 = num < 4f;
			if (entity.CanAttack() && num <= 2f)
			{
				entity.DoAttack();
			}
			if (!num2)
			{
				Vector3 vector = Vector3Ex.Direction(entity.GetTarget().eyes.position, entity.transform.position);
				Vector3 point = target.eyes.position + vector * 10f;
				point = entity.WaterClamp(point);
				entity.destination = point;
			}
		}

		public override void State_Exit()
		{
			base.State_Exit();
		}

		public override bool CanInterrupt()
		{
			return true;
		}
	}

	public Vector3 destination;

	public float minSpeed;

	public float maxSpeed;

	public float idealDepth;

	public float minTurnSpeed = 0.25f;

	public float maxTurnSpeed = 2f;

	public float attackCooldown = 7f;

	public float aggroRange = 15f;

	public float obstacleDetectionRadius = 1f;

	public Animator animator;

	public GameObjectRef bloodCloud;

	public GameObjectRef corpsePrefab;

	private const string SPEARGUN_KILL_STAT = "shark_speargun_kills";

	[ServerVar]
	public static float forceSurfaceAmount = 0f;

	[ServerVar]
	public static bool disable = false;

	private Vector3 spawnPos;

	private float stoppingDistance = 3f;

	private float currentSpeed;

	private float lastStartleTime;

	private float startleDuration = 1f;

	private SimpleState[] states;

	private SimpleState _currentState;

	private bool sleeping;

	private List<Vector3> patrolPath = new List<Vector3>();

	private BasePlayer target;

	private float lastSeenTargetTime;

	private float nextTargetSearchTime;

	private static BasePlayer[] playerQueryResults = new BasePlayer[64];

	private float minFloorDist = 2f;

	private float minSurfaceDist = 1f;

	private float lastTimeAttacked;

	public float nextAttackTime;

	private Vector3 cachedObstacleNormal;

	private float cachedObstacleDistance;

	private float obstacleAvoidanceScale;

	private float obstacleDetectionRange = 5f;

	private float timeSinceLastObstacleCheck;

	public override bool IsNpc => true;

	private void GenerateIdlePoints(Vector3 center, float radius, float heightOffset, float staggerOffset = 0f)
	{
		patrolPath.Clear();
		float num = 0f;
		int num2 = 32;
		int layerMask = 10551553;
		(float, float) waterAndTerrainSurface = WaterLevel.GetWaterAndTerrainSurface(center, waves: false, volumes: false);
		float item = waterAndTerrainSurface.Item1;
		float item2 = waterAndTerrainSurface.Item2;
		for (int i = 0; i < num2; i++)
		{
			num += 360f / (float)num2;
			float radius2 = 1f;
			Vector3 pointOnCircle = BasePathFinder.GetPointOnCircle(center, radius2, num);
			Vector3 vector = Vector3Ex.Direction(pointOnCircle, center);
			pointOnCircle = ((!UnityEngine.Physics.SphereCast(center, obstacleDetectionRadius, vector, out var hitInfo, radius + staggerOffset, layerMask)) ? (center + vector * radius) : (center + vector * (hitInfo.distance - 6f)));
			if (staggerOffset != 0f)
			{
				pointOnCircle += vector * Random.Range(0f - staggerOffset, staggerOffset);
			}
			pointOnCircle.y += Random.Range(0f - heightOffset, heightOffset);
			pointOnCircle.y = Mathf.Clamp(pointOnCircle.y, item2 + 3f, item - 3f);
			patrolPath.Add(pointOnCircle);
		}
	}

	private void GenerateIdlePoints_Shrinkwrap(Vector3 center, float radius, float heightOffset, float staggerOffset = 0f)
	{
		patrolPath.Clear();
		float num = 0f;
		int num2 = 32;
		int layerMask = 10551553;
		(float, float) waterAndTerrainSurface = WaterLevel.GetWaterAndTerrainSurface(center, waves: false, volumes: false);
		float item = waterAndTerrainSurface.Item1;
		float item2 = waterAndTerrainSurface.Item2;
		for (int i = 0; i < num2; i++)
		{
			num += 360f / (float)num2;
			float radius2 = radius * 2f;
			Vector3 vector = BasePathFinder.GetPointOnCircle(center, radius2, num);
			Vector3 vector2 = Vector3Ex.Direction(center, vector);
			if (UnityEngine.Physics.SphereCast(vector, obstacleDetectionRadius, vector2, out var hitInfo, radius + staggerOffset, layerMask))
			{
				vector = hitInfo.point - vector2 * 6f;
			}
			else
			{
				vector += vector2 * radius;
			}
			if (staggerOffset != 0f)
			{
				vector += vector2 * Random.Range(0f - staggerOffset, staggerOffset);
			}
			vector.y += Random.Range(0f - heightOffset, heightOffset);
			vector.y = Mathf.Clamp(vector.y, item2 + 3f, item - 3f);
			patrolPath.Add(vector);
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (disable)
		{
			Invoke(base.KillMessage, 0.01f);
			return;
		}
		base.transform.position = WaterClamp(base.transform.position);
		Init();
		InvokeRandomized(CheckSleepState, 0f, 1f, 0.5f);
	}

	public void CheckSleepState()
	{
		bool flag = BaseNetworkable.HasCloseConnections(base.transform.position, 100f);
		sleeping = !flag;
	}

	public void Init()
	{
		GenerateIdlePoints_Shrinkwrap(base.transform.position, 20f, 2f, 3f);
		states = new SimpleState[2];
		states[0] = new IdleState(this);
		states[1] = new AttackState(this);
		base.transform.position = patrolPath[0];
	}

	private void Think(float delta)
	{
		if (states == null)
		{
			return;
		}
		if (disable)
		{
			if (!IsInvoking(base.KillMessage))
			{
				Invoke(base.KillMessage, 0.01f);
			}
		}
		else
		{
			if (sleeping)
			{
				return;
			}
			SimpleState simpleState = null;
			float num = -1f;
			SimpleState[] array = states;
			foreach (SimpleState simpleState2 in array)
			{
				float num2 = simpleState2.State_Weight();
				if (num2 > num)
				{
					simpleState = simpleState2;
					num = num2;
				}
			}
			if (simpleState != _currentState && (_currentState == null || _currentState.CanInterrupt()))
			{
				if (_currentState != null)
				{
					_currentState.State_Exit();
				}
				simpleState.State_Enter();
				_currentState = simpleState;
			}
			UpdateTarget(delta);
			_currentState.State_Think(delta);
			UpdateObstacleAvoidance(delta);
			UpdateDirection(delta);
			UpdateSpeed(delta);
			UpdatePosition(delta);
			SetFlag(Flags.Open, HasTarget() && CanAttack());
		}
	}

	public Vector3 WaterClamp(Vector3 point)
	{
		(float, float) waterAndTerrainSurface = WaterLevel.GetWaterAndTerrainSurface(point, waves: false, volumes: false);
		float item = waterAndTerrainSurface.Item1;
		float min = waterAndTerrainSurface.Item2 + minFloorDist;
		float max = item - minSurfaceDist;
		if (forceSurfaceAmount != 0f)
		{
			item = WaterLevel.GetWaterSurface(point, waves: false, volumes: false);
			min = (max = item + forceSurfaceAmount);
		}
		point.y = Mathf.Clamp(point.y, min, max);
		return point;
	}

	public bool ValidTarget(BasePlayer newTarget)
	{
		if (AI.ignoreplayers || SimpleAIMemory.PlayerIgnoreList.Contains(newTarget))
		{
			return false;
		}
		float maxDistance = Vector3.Distance(newTarget.eyes.position, base.transform.position);
		Vector3 direction = Vector3Ex.Direction(newTarget.eyes.position, base.transform.position);
		int layerMask = 10551552;
		if (UnityEngine.Physics.Raycast(base.transform.position, direction, maxDistance, layerMask))
		{
			return false;
		}
		if (newTarget.isMounted)
		{
			if ((bool)newTarget.GetMountedVehicle())
			{
				return false;
			}
			WaterInflatable component = newTarget.GetMounted().GetComponent<WaterInflatable>();
			if (component != null && !component.buoyancy.enabled)
			{
				return false;
			}
		}
		else if (!WaterLevel.Test(newTarget.CenterPoint(), waves: true, volumes: false, newTarget))
		{
			return false;
		}
		return true;
	}

	public void ClearTarget()
	{
		target = null;
		lastSeenTargetTime = 0f;
	}

	public override void OnDied(HitInfo hitInfo = null)
	{
		if (base.isServer)
		{
			if (Rust.GameInfo.HasAchievements && hitInfo != null && hitInfo.InitiatorPlayer != null && !hitInfo.InitiatorPlayer.IsNpc && hitInfo.Weapon != null && hitInfo.Weapon.ShortPrefabName.Contains("speargun"))
			{
				hitInfo.InitiatorPlayer.stats.Add("shark_speargun_kills", 1, Stats.All);
				hitInfo.InitiatorPlayer.stats.Save(forceSteamSave: true);
			}
			BaseCorpse baseCorpse = DropCorpse(corpsePrefab.resourcePath);
			if ((bool)baseCorpse)
			{
				baseCorpse.Spawn();
				baseCorpse.TakeChildren(this);
			}
			Invoke(base.KillMessage, 0.5f);
		}
		base.OnDied(hitInfo);
	}

	public void UpdateTarget(float delta)
	{
		if (target != null)
		{
			bool flag = Vector3.Distance(target.eyes.position, base.transform.position) > aggroRange * 2f;
			bool flag2 = UnityEngine.Time.realtimeSinceStartup > lastSeenTargetTime + 4f;
			if (!ValidTarget(target) || flag || flag2)
			{
				ClearTarget();
			}
			else
			{
				lastSeenTargetTime = UnityEngine.Time.realtimeSinceStartup;
			}
		}
		if (UnityEngine.Time.realtimeSinceStartup < nextTargetSearchTime || !(target == null))
		{
			return;
		}
		nextTargetSearchTime = UnityEngine.Time.realtimeSinceStartup + 1f;
		if (!BaseNetworkable.HasCloseConnections(base.transform.position, aggroRange))
		{
			return;
		}
		int playersInSphereFast = Query.Server.GetPlayersInSphereFast(base.transform.position, aggroRange, playerQueryResults);
		for (int i = 0; i < playersInSphereFast; i++)
		{
			BasePlayer basePlayer = playerQueryResults[i];
			if (!basePlayer.isClient && ValidTarget(basePlayer))
			{
				target = basePlayer;
				lastSeenTargetTime = UnityEngine.Time.realtimeSinceStartup;
				break;
			}
		}
	}

	public float TimeSinceAttacked()
	{
		return UnityEngine.Time.realtimeSinceStartup - lastTimeAttacked;
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		lastTimeAttacked = UnityEngine.Time.realtimeSinceStartup;
		if (info.damageTypes.Total() > 20f)
		{
			Startle();
		}
		if (info.InitiatorPlayer != null && target == null && ValidTarget(info.InitiatorPlayer))
		{
			target = info.InitiatorPlayer;
			lastSeenTargetTime = UnityEngine.Time.realtimeSinceStartup;
		}
	}

	public bool HasTarget()
	{
		return target != null;
	}

	public BasePlayer GetTarget()
	{
		return target;
	}

	public override string Categorize()
	{
		return "Shark";
	}

	public bool CanAttack()
	{
		return UnityEngine.Time.realtimeSinceStartup > nextAttackTime;
	}

	public void DoAttack()
	{
		if (HasTarget())
		{
			GetTarget().Hurt(Random.Range(30f, 70f), DamageType.Bite, this);
			Vector3 posWorld = WaterClamp(GetTarget().CenterPoint());
			Effect.server.Run(bloodCloud.resourcePath, posWorld, Vector3.forward);
			nextAttackTime = UnityEngine.Time.realtimeSinceStartup + attackCooldown;
		}
	}

	public void Startle()
	{
		lastStartleTime = UnityEngine.Time.realtimeSinceStartup;
	}

	public bool IsStartled()
	{
		return lastStartleTime + startleDuration > UnityEngine.Time.realtimeSinceStartup;
	}

	private float GetDesiredSpeed()
	{
		if (!IsStartled())
		{
			return minSpeed;
		}
		return maxSpeed;
	}

	public float GetTurnSpeed()
	{
		if (IsStartled())
		{
			return maxTurnSpeed;
		}
		if (obstacleAvoidanceScale != 0f)
		{
			return Mathf.Lerp(minTurnSpeed, maxTurnSpeed, obstacleAvoidanceScale);
		}
		return minTurnSpeed;
	}

	private float GetCurrentSpeed()
	{
		return currentSpeed;
	}

	private void UpdateObstacleAvoidance(float delta)
	{
		timeSinceLastObstacleCheck += delta;
		if (timeSinceLastObstacleCheck < 0.5f)
		{
			return;
		}
		Vector3 forward = base.transform.forward;
		Vector3 position = base.transform.position;
		int layerMask = 1503764737;
		if (UnityEngine.Physics.SphereCast(position, obstacleDetectionRadius, forward, out var hitInfo, obstacleDetectionRange, layerMask))
		{
			Vector3 point = hitInfo.point;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			if (UnityEngine.Physics.SphereCast(position + Vector3.down * 0.25f + base.transform.right * 0.25f, obstacleDetectionRadius, forward, out var hitInfo2, obstacleDetectionRange, layerMask))
			{
				vector = hitInfo2.point;
			}
			if (UnityEngine.Physics.SphereCast(position + Vector3.down * 0.25f - base.transform.right * 0.25f, obstacleDetectionRadius, forward, out var hitInfo3, obstacleDetectionRange, layerMask))
			{
				vector2 = hitInfo3.point;
			}
			if (vector != Vector3.zero && vector2 != Vector3.zero)
			{
				Vector3 normal = new Plane(point, vector, vector2).normal;
				if (normal != Vector3.zero)
				{
					hitInfo.normal = normal;
				}
			}
			cachedObstacleNormal = hitInfo.normal;
			cachedObstacleDistance = hitInfo.distance;
			obstacleAvoidanceScale = 1f - Mathf.InverseLerp(2f, obstacleDetectionRange * 0.75f, hitInfo.distance);
		}
		else
		{
			obstacleAvoidanceScale = Mathf.MoveTowards(obstacleAvoidanceScale, 0f, timeSinceLastObstacleCheck * 2f);
			if (obstacleAvoidanceScale == 0f)
			{
				cachedObstacleDistance = 0f;
			}
		}
		timeSinceLastObstacleCheck = 0f;
	}

	private void UpdateDirection(float delta)
	{
		_ = base.transform.forward;
		Vector3 vector = Vector3Ex.Direction(WaterClamp(destination), base.transform.position);
		if (obstacleAvoidanceScale != 0f)
		{
			Vector3 vector2;
			if (cachedObstacleNormal != Vector3.zero)
			{
				Vector3 lhs = QuaternionEx.LookRotationForcedUp(cachedObstacleNormal, Vector3.up) * Vector3.forward;
				vector2 = ((!(Vector3.Dot(lhs, base.transform.right) > Vector3.Dot(lhs, -base.transform.right))) ? (-base.transform.right) : base.transform.right);
			}
			else
			{
				vector2 = base.transform.right;
			}
			vector = vector2 * obstacleAvoidanceScale;
			vector.Normalize();
		}
		if (vector != Vector3.zero)
		{
			Quaternion b = Quaternion.LookRotation(vector, Vector3.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, delta * GetTurnSpeed());
		}
	}

	private void UpdatePosition(float delta)
	{
		Vector3 forward = base.transform.forward;
		Vector3 point = base.transform.position + forward * GetCurrentSpeed() * delta;
		point = WaterClamp(point);
		base.transform.position = point;
	}

	private void UpdateSpeed(float delta)
	{
		currentSpeed = Mathf.Lerp(currentSpeed, GetDesiredSpeed(), delta * 4f);
	}

	public void Update()
	{
		if (base.isServer)
		{
			Think(UnityEngine.Time.deltaTime);
		}
	}
}
