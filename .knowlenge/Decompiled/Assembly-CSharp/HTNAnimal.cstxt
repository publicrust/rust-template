using System.Runtime.CompilerServices;
using Apex.Ai.HTN;
using ConVar;
using Network;
using Rust.Ai;
using Rust.Ai.HTN;
using UnityEngine;

public class HTNAnimal : BaseCombatEntity, IHTNAgent
{
	[Header("Client Animation")]
	public Vector3 HipFudge = new Vector3(-90f, 0f, 90f);

	public Transform HipBone;

	public Transform LookBone;

	public bool UpdateWalkSpeed = true;

	public bool UpdateFacingDirection = true;

	public bool UpdateGroundNormal = true;

	public Transform alignmentRoot;

	public bool LaggyAss = true;

	public bool LookAtTarget;

	public float MaxLaggyAssRotation = 70f;

	public float MaxWalkAnimSpeed = 25f;

	[Header("Hierarchical Task Network")]
	public HTNDomain _aiDomain;

	[Header("Ai Definition")]
	public BaseNpcDefinition _aiDefinition;

	[Header("Client Effects")]
	public MaterialEffect FootstepEffects;

	public Transform[] Feet;

	[ReadOnly]
	public string BaseFolder;

	private bool isDormant;

	private float lastInvokedTickTime;

	public override bool IsNpc => true;

	public BaseEntity Body => this;

	public Vector3 BodyPosition => base.transform.position;

	public Vector3 EyePosition => CenterPoint();

	public Quaternion EyeRotation => base.transform.rotation;

	protected override float PositionTickRate => 0.1f;

	public BaseNpc.AiStatistics.FamilyEnum Family => AiDefinition.Info.ToFamily(AiDefinition.Info.Family);

	public BaseNpcDefinition AiDefinition => _aiDefinition;

	public HTNDomain AiDomain => _aiDomain;

	public Vector3 estimatedVelocity { get; set; }

	public bool IsDormant
	{
		get
		{
			return isDormant;
		}
		set
		{
			if (isDormant != value)
			{
				isDormant = value;
				if (isDormant)
				{
					Pause();
				}
				else
				{
					Resume();
				}
			}
		}
	}

	public BaseEntity MainTarget
	{
		get
		{
			if (AiDomain.NpcContext.OrientationType != NpcOrientation.LookAtAnimal)
			{
				return AiDomain.NpcContext.PrimaryEnemyPlayerInLineOfSight.Player;
			}
			return AiDomain.NpcContext.BaseMemory.PrimaryKnownAnimal.Animal;
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("HTNAnimal.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override float StartHealth()
	{
		return AiDefinition.Vitals.HP;
	}

	public override float StartMaxHealth()
	{
		return AiDefinition.Vitals.HP;
	}

	public override float MaxHealth()
	{
		return AiDefinition.Vitals.HP;
	}

	public override float MaxVelocity()
	{
		return AiDefinition.Movement.RunSpeed;
	}

	public override void ServerInit()
	{
		if (base.isClient)
		{
			return;
		}
		base.ServerInit();
		UpdateNetworkGroup();
		if (AiDomain == null)
		{
			Debug.LogError(base.name + " requires an AI domain to be set.");
			DieInstantly();
			return;
		}
		AiDomain.Initialize(this);
		if (!AiManager.ai_htn_use_agency_tick)
		{
			InvokeRepeating(InvokedTick, 0f, 0.1f);
		}
	}

	public override void ResetState()
	{
		base.ResetState();
		if (AiDomain != null)
		{
			AiDomain.ResetState();
		}
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		AiDomain.Dispose();
	}

	public override void Hurt(HitInfo info)
	{
		base.Hurt(info);
		if (AiDomain != null && IsAlive())
		{
			AiDomain.OnHurt(info);
		}
	}

	public override void OnKilled(HitInfo info)
	{
		AiDefinition?.OnCreateCorpse(this);
		Invoke(base.KillMessage, 0.5f);
	}

	public override void OnSensation(Sensation sensation)
	{
		base.OnSensation(sensation);
		if (AiDomain != null && IsAlive())
		{
			AiDomain.OnSensation(sensation);
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
	}

	public void Resume()
	{
	}

	public void Pause()
	{
	}

	public void Tick()
	{
		InvokedTick();
	}

	private void InvokedTick()
	{
		float time = UnityEngine.Time.time;
		float delta = time - lastInvokedTickTime;
		lastInvokedTickTime = UnityEngine.Time.time;
		if (IsDormant)
		{
			return;
		}
		if (AiDomain != null)
		{
			AiDomain.TickDestinationTracker();
			if (AiDomain.PlannerContext.IsWorldStateDirty || AiDomain.PlannerContext.PlanState == PlanStateType.NoPlan)
			{
				AiDomain.Think();
			}
			AiDomain.Tick(UnityEngine.Time.time);
		}
		TickMovement(delta);
		TickOrientation(delta, time);
	}

	private void TickMovement(float delta)
	{
		if (AI.move && !(AiDomain == null) && !(AiDomain.NavAgent == null) && AiDomain.NavAgent.isOnNavMesh)
		{
			Vector3 moveToPosition = base.transform.position;
			if (AiDomain.NavAgent.hasPath)
			{
				moveToPosition = AiDomain.NavAgent.nextPosition;
			}
			if (_ValidateNextPosition(ref moveToPosition))
			{
				base.transform.localPosition = base.transform.InverseTransformPoint(moveToPosition);
				base.transform.hasChanged = true;
			}
		}
	}

	private bool _ValidateNextPosition(ref Vector3 moveToPosition)
	{
		if (!ValidBounds.Test(moveToPosition) && base.transform != null && !base.IsDestroyed)
		{
			Debug.Log($"Invalid NavAgent Position: {this} {moveToPosition.ToString()} (destroying)");
			Kill();
			return false;
		}
		return true;
	}

	public void ForceOrientationTick()
	{
		TickOrientation(UnityEngine.Time.deltaTime, UnityEngine.Time.time);
	}

	private void TickOrientation(float delta, float time)
	{
		if (!(AiDomain == null) && AiDomain.NpcContext != null)
		{
			Vector3 forward = base.transform.forward;
			switch (AiDomain.NpcContext.OrientationType)
			{
			default:
				return;
			case NpcOrientation.Heading:
				forward = AiDomain.GetHeadingDirection();
				break;
			case NpcOrientation.PrimaryTargetBody:
				forward = AiDomain.NpcContext.GetDirectionToPrimaryEnemyPlayerTargetBody();
				break;
			case NpcOrientation.PrimaryTargetHead:
				forward = AiDomain.NpcContext.GetDirectionToPrimaryEnemyPlayerTargetHead();
				break;
			case NpcOrientation.LastKnownPrimaryTargetLocation:
				forward = AiDomain.NpcContext.GetDirectionToMemoryOfPrimaryEnemyPlayerTarget();
				break;
			case NpcOrientation.LastAttackedDirection:
				forward = AiDomain.NpcContext.GetDirectionLastAttackedDir();
				break;
			case NpcOrientation.LookAround:
				forward = AiDomain.NpcContext.GetDirectionLookAround();
				break;
			case NpcOrientation.AudibleTargetDirection:
				forward = AiDomain.NpcContext.GetDirectionAudibleTarget();
				break;
			case NpcOrientation.LookAtAnimal:
				forward = AiDomain.NpcContext.GetDirectionToAnimal();
				break;
			}
			if (!Mathf.Approximately(forward.sqrMagnitude, 0f))
			{
				ServerRotation = Quaternion.LookRotation(forward, base.transform.up);
			}
		}
	}

	[SpecialName]
	Transform IHTNAgent.get_transform()
	{
		return base.transform;
	}
}
