using ProtoBuf;
using UnityEngine;

public class BaseAIEvent
{
	public enum ExecuteRate
	{
		Slow,
		Normal,
		Fast,
		VeryFast
	}

	private float executeTimer;

	protected float deltaTime;

	public AIEventType EventType { get; private set; }

	public int TriggerStateContainerID { get; private set; } = -1;

	public ExecuteRate Rate { get; protected set; } = ExecuteRate.Normal;

	public float ExecutionRate => Rate switch
	{
		ExecuteRate.Slow => 1f, 
		ExecuteRate.Normal => 0.5f, 
		ExecuteRate.Fast => 0.25f, 
		ExecuteRate.VeryFast => 0.1f, 
		_ => 0.5f, 
	};

	public bool ShouldExecute { get; protected set; }

	public bool Result { get; protected set; }

	public bool Inverted { get; private set; }

	public int OutputEntityMemorySlot { get; protected set; } = -1;

	public bool ShouldSetOutputEntityMemory => OutputEntityMemorySlot > -1;

	public int InputEntityMemorySlot { get; protected set; } = -1;

	public int ID { get; protected set; }

	public BaseEntity Owner { get; private set; }

	public bool HasValidTriggerState => TriggerStateContainerID != -1;

	public BaseAIEvent(AIEventType type)
	{
		EventType = type;
	}

	public virtual void Init(AIEventData data, BaseEntity owner)
	{
		Init(data.triggerStateContainer, data.id, owner, data.inputMemorySlot, data.outputMemorySlot, data.inverted);
	}

	public virtual void Init(int triggerStateContainer, int id, BaseEntity owner, int inputMemorySlot, int outputMemorySlot, bool inverted)
	{
		TriggerStateContainerID = triggerStateContainer;
		ID = id;
		Owner = owner;
		InputEntityMemorySlot = inputMemorySlot;
		OutputEntityMemorySlot = outputMemorySlot;
		Inverted = inverted;
	}

	public virtual AIEventData ToProto()
	{
		return new AIEventData
		{
			id = ID,
			eventType = (int)EventType,
			triggerStateContainer = TriggerStateContainerID,
			outputMemorySlot = OutputEntityMemorySlot,
			inputMemorySlot = InputEntityMemorySlot,
			inverted = Inverted
		};
	}

	public virtual void Reset()
	{
		executeTimer = 0f;
		deltaTime = 0f;
		Result = false;
	}

	public void Tick(float deltaTime, IAIEventListener listener)
	{
		this.deltaTime += deltaTime;
		executeTimer += deltaTime;
		float executionRate = ExecutionRate;
		if (executeTimer >= executionRate)
		{
			executeTimer = 0f;
			ShouldExecute = true;
		}
		else
		{
			ShouldExecute = false;
		}
	}

	public virtual void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
	}

	public virtual void PostExecute()
	{
		deltaTime = 0f;
	}

	public void TriggerStateChange(IAIEventListener listener, int sourceEventID)
	{
		listener.EventTriggeredStateChange(TriggerStateContainerID, sourceEventID);
	}

	public static BaseAIEvent CreateEvent(AIEventType eventType)
	{
		switch (eventType)
		{
		case AIEventType.Timer:
			return new TimerAIEvent();
		case AIEventType.PlayerDetected:
			return new PlayerDetectedAIEvent();
		case AIEventType.StateError:
			return new StateErrorAIEvent();
		case AIEventType.Attacked:
			return new AttackedAIEvent();
		case AIEventType.StateFinished:
			return new StateFinishedAIEvent();
		case AIEventType.InAttackRange:
			return new InAttackRangeAIEvent();
		case AIEventType.HealthBelow:
			return new HealthBelowAIEvent();
		case AIEventType.InRange:
			return new InRangeAIEvent();
		case AIEventType.PerformedAttack:
			return new PerformedAttackAIEvent();
		case AIEventType.TirednessAbove:
			return new TirednessAboveAIEvent();
		case AIEventType.HungerAbove:
			return new HungerAboveAIEvent();
		case AIEventType.ThreatDetected:
			return new ThreatDetectedAIEvent();
		case AIEventType.TargetDetected:
			return new TargetDetectedAIEvent();
		case AIEventType.AmmoBelow:
			return new AmmoBelowAIEvent();
		case AIEventType.BestTargetDetected:
			return new BestTargetDetectedAIEvent();
		case AIEventType.IsVisible:
			return new IsVisibleAIEvent();
		case AIEventType.AttackTick:
			return new AttackTickAIEvent();
		case AIEventType.IsMounted:
			return new IsMountedAIEvent();
		case AIEventType.And:
			return new AndAIEvent();
		case AIEventType.Chance:
			return new ChanceAIEvent();
		case AIEventType.TargetLost:
			return new TargetLostAIEvent();
		case AIEventType.TimeSinceThreat:
			return new TimeSinceThreatAIEvent();
		case AIEventType.OnPositionMemorySet:
			return new OnPositionMemorySetAIEvent();
		case AIEventType.AggressionTimer:
			return new AggressionTimerAIEvent();
		case AIEventType.Reloading:
			return new ReloadingAIEvent();
		case AIEventType.InRangeOfHome:
			return new InRangeOfHomeAIEvent();
		case AIEventType.IsBlinded:
			return new IsBlindedAIEvent();
		default:
			Debug.LogWarning("No case for " + eventType.ToString() + " event in BaseAIEvent.CreateEvent()!");
			return null;
		}
	}
}
