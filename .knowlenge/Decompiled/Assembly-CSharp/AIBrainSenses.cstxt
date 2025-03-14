using System;
using System.Collections.Generic;
using ConVar;
using Oxide.Core;
using Rust.Ai;
using UnityEngine;

public class AIBrainSenses
{
	[ServerVar]
	public static float UpdateInterval = 0.5f;

	[ServerVar]
	public static float HumanKnownPlayersLOSUpdateInterval = 0.2f;

	[ServerVar]
	public static float KnownPlayersLOSUpdateInterval = 0.5f;

	public float knownPlayersLOSUpdateInterval = 0.2f;

	[NonSerialized]
	public float MemoryDuration = 10f;

	[NonSerialized]
	public float LastThreatTimestamp;

	[NonSerialized]
	public float TimeInAgressiveState;

	public static BaseEntity[] queryResults = new BaseEntity[64];

	public static BasePlayer[] playerQueryResults = new BasePlayer[64];

	public float nextUpdateTime;

	public float nextKnownPlayersLOSUpdateTime;

	public BaseEntity owner;

	public BasePlayer playerOwner;

	public IAISenses ownerSenses;

	public float maxRange;

	public float targetLostRange;

	public float visionCone;

	public bool checkVision;

	public bool checkLOS;

	public bool ignoreNonVisionSneakers;

	public float listenRange;

	public bool hostileTargetsOnly;

	public bool senseFriendlies;

	public bool refreshKnownLOS;

	[NonSerialized]
	public bool ignoreTutorialPlayers;

	public EntityType senseTypes;

	public IAIAttack ownerAttack;

	[NonSerialized]
	public BaseAIBrain brain;

	private Func<BaseEntity, bool> aiCaresAbout;

	public float TimeSinceThreat => UnityEngine.Time.realtimeSinceStartup - LastThreatTimestamp;

	public SimpleAIMemory Memory { get; set; } = new SimpleAIMemory();

	public float TargetLostRange => targetLostRange;

	public bool ignoreSafeZonePlayers { get; set; }

	public List<BaseEntity> Players => Memory.Players;

	public void Init(BaseEntity owner, BaseAIBrain brain, float memoryDuration, float range, float targetLostRange, float visionCone, bool checkVision, bool checkLOS, bool ignoreNonVisionSneakers, float listenRange, bool hostileTargetsOnly, bool senseFriendlies, bool ignoreSafeZonePlayers, EntityType senseTypes, bool refreshKnownLOS)
	{
		aiCaresAbout = AiCaresAbout;
		this.owner = owner;
		this.brain = brain;
		MemoryDuration = memoryDuration;
		ownerAttack = owner as IAIAttack;
		playerOwner = owner as BasePlayer;
		maxRange = range;
		this.targetLostRange = targetLostRange;
		this.visionCone = visionCone;
		this.checkVision = checkVision;
		this.checkLOS = checkLOS;
		this.ignoreNonVisionSneakers = ignoreNonVisionSneakers;
		this.listenRange = listenRange;
		this.hostileTargetsOnly = hostileTargetsOnly;
		this.senseFriendlies = senseFriendlies;
		this.ignoreSafeZonePlayers = ignoreSafeZonePlayers;
		this.senseTypes = senseTypes;
		LastThreatTimestamp = UnityEngine.Time.realtimeSinceStartup;
		this.refreshKnownLOS = refreshKnownLOS;
		ownerSenses = owner as IAISenses;
		knownPlayersLOSUpdateInterval = ((owner is HumanNPC) ? HumanKnownPlayersLOSUpdateInterval : KnownPlayersLOSUpdateInterval);
	}

	public void DelaySenseUpdate(float delay)
	{
		nextUpdateTime = UnityEngine.Time.time + delay;
	}

	public void Update()
	{
		if (!(owner == null))
		{
			UpdateSenses();
			UpdateKnownPlayersLOS();
		}
	}

	private void UpdateSenses()
	{
		if (UnityEngine.Time.time < nextUpdateTime)
		{
			return;
		}
		nextUpdateTime = UnityEngine.Time.time + UpdateInterval;
		if (senseTypes != 0)
		{
			if (senseTypes == EntityType.Player)
			{
				SensePlayers();
			}
			else
			{
				SenseBrains();
				if (senseTypes.HasFlag(EntityType.Player))
				{
					SensePlayers();
				}
			}
		}
		Memory.Forget(MemoryDuration);
	}

	public void UpdateKnownPlayersLOS()
	{
		if (UnityEngine.Time.time < nextKnownPlayersLOSUpdateTime)
		{
			return;
		}
		nextKnownPlayersLOSUpdateTime = UnityEngine.Time.time + knownPlayersLOSUpdateInterval;
		foreach (BaseEntity player in Memory.Players)
		{
			if (!(player == null) && !player.IsNpc)
			{
				bool flag = ownerAttack.CanSeeTarget(player);
				Memory.SetLOS(player, flag);
				if (refreshKnownLOS && owner != null && flag && Vector3.Distance(player.transform.position, owner.transform.position) <= TargetLostRange)
				{
					Memory.SetKnown(player, owner, this);
				}
			}
		}
	}

	private void SensePlayers()
	{
		int playersInSphereFast = BaseEntity.Query.Server.GetPlayersInSphereFast(owner.transform.position, maxRange, playerQueryResults, aiCaresAbout);
		for (int i = 0; i < playersInSphereFast; i++)
		{
			BasePlayer ent = playerQueryResults[i];
			Memory.SetKnown(ent, owner, this);
		}
	}

	private void SenseBrains()
	{
		int brainsInSphereFast = BaseEntity.Query.Server.GetBrainsInSphereFast(owner.transform.position, maxRange, queryResults, aiCaresAbout);
		for (int i = 0; i < brainsInSphereFast; i++)
		{
			BaseEntity ent = queryResults[i];
			Memory.SetKnown(ent, owner, this);
		}
	}

	private bool AiCaresAbout(BaseEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		if (!entity.isServer)
		{
			return false;
		}
		if (entity.EqualNetID(owner))
		{
			return false;
		}
		if (entity.Health() <= 0f)
		{
			return false;
		}
		if (entity.IsTransferProtected())
		{
			return false;
		}
		if (!IsValidSenseType(entity))
		{
			return false;
		}
		BaseCombatEntity baseCombatEntity = entity as BaseCombatEntity;
		BasePlayer basePlayer = entity as BasePlayer;
		if (basePlayer != null)
		{
			if (basePlayer.IsDead())
			{
				return false;
			}
			if (ignoreTutorialPlayers && basePlayer.IsInTutorial)
			{
				return false;
			}
		}
		if (ignoreSafeZonePlayers && basePlayer != null && basePlayer.InSafeZone())
		{
			return false;
		}
		if (listenRange > 0f && baseCombatEntity != null && baseCombatEntity.TimeSinceLastNoise <= 1f && baseCombatEntity.CanLastNoiseBeHeard(owner.transform.position, listenRange))
		{
			return true;
		}
		if (senseFriendlies && ownerSenses != null && ownerSenses.IsFriendly(entity))
		{
			return true;
		}
		float num = float.PositiveInfinity;
		if (baseCombatEntity != null && AI.accuratevisiondistance)
		{
			num = Vector3.Distance(owner.transform.position, baseCombatEntity.transform.position);
			if (num > maxRange)
			{
				return false;
			}
		}
		if (checkVision && !IsTargetInVision(entity))
		{
			if (!ignoreNonVisionSneakers)
			{
				return false;
			}
			if (basePlayer != null && !basePlayer.IsNpc)
			{
				if (!AI.accuratevisiondistance)
				{
					num = Vector3.Distance(owner.transform.position, basePlayer.transform.position);
				}
				if ((basePlayer.IsDucked() && num >= brain.IgnoreSneakersMaxDistance) || num >= brain.IgnoreNonVisionMaxDistance)
				{
					return false;
				}
			}
		}
		if (hostileTargetsOnly && baseCombatEntity != null && !baseCombatEntity.IsHostile() && !(baseCombatEntity is ScarecrowNPC))
		{
			return false;
		}
		if (checkLOS && ownerAttack != null)
		{
			bool flag = ownerAttack.CanSeeTarget(entity);
			Memory.SetLOS(entity, flag);
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	private bool IsValidSenseType(BaseEntity ent)
	{
		BasePlayer basePlayer = ent as BasePlayer;
		if (basePlayer != null)
		{
			if (basePlayer.IsNpc)
			{
				if (ent is BasePet)
				{
					return true;
				}
				if (ent is ScarecrowNPC)
				{
					return true;
				}
				if (senseTypes.HasFlag(EntityType.BasePlayerNPC))
				{
					return true;
				}
			}
			else if (senseTypes.HasFlag(EntityType.Player))
			{
				return true;
			}
		}
		if (senseTypes.HasFlag(EntityType.NPC) && ent is BaseNpc)
		{
			return true;
		}
		if (senseTypes.HasFlag(EntityType.WorldItem) && ent is WorldItem)
		{
			return true;
		}
		if (senseTypes.HasFlag(EntityType.Corpse) && ent is BaseCorpse)
		{
			return true;
		}
		if (senseTypes.HasFlag(EntityType.TimedExplosive) && ent is TimedExplosive)
		{
			return true;
		}
		if (senseTypes.HasFlag(EntityType.Chair) && ent is BaseChair)
		{
			return true;
		}
		return false;
	}

	private bool IsTargetInVision(BaseEntity target)
	{
		Vector3 rhs = Vector3Ex.Direction(target.transform.position, owner.transform.position);
		return Vector3.Dot((playerOwner != null) ? playerOwner.eyes.BodyForward() : owner.transform.forward, rhs) >= visionCone;
	}

	public BaseEntity GetNearestPlayer(float rangeFraction)
	{
		return GetNearest(Memory.Players, rangeFraction);
	}

	public BaseEntity GetNearestThreat(float rangeFraction)
	{
		return GetNearest(Memory.Threats, rangeFraction);
	}

	public BaseEntity GetNearestTarget(float rangeFraction)
	{
		return GetNearest(Memory.Targets, rangeFraction);
	}

	private BaseEntity GetNearest(List<BaseEntity> entities, float rangeFraction)
	{
		if (entities == null || entities.Count == 0)
		{
			return null;
		}
		float num = float.PositiveInfinity;
		BaseEntity result = null;
		foreach (BaseEntity entity in entities)
		{
			if (!(entity == null) && !(entity.Health() <= 0f) && Interface.CallHook("OnNpcTarget", owner, entity) == null)
			{
				float num2 = Vector3.Distance(entity.transform.position, owner.transform.position);
				if (num2 <= rangeFraction * maxRange && num2 < num)
				{
					result = entity;
				}
			}
		}
		return result;
	}
}
