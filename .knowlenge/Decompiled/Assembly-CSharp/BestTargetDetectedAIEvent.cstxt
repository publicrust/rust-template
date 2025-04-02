using ProtoBuf;

public class BestTargetDetectedAIEvent : BaseAIEvent
{
	public BestTargetDetectedAIEvent()
		: base(AIEventType.BestTargetDetected)
	{
		base.Rate = ExecuteRate.Normal;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (!(base.Owner is IAIAttack iAIAttack))
		{
			return;
		}
		BaseEntity bestTarget = iAIAttack.GetBestTarget();
		if (base.Inverted)
		{
			if (bestTarget == null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Remove(base.OutputEntityMemorySlot);
			}
			base.Result = bestTarget == null;
		}
		else
		{
			if (bestTarget != null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(bestTarget, base.OutputEntityMemorySlot);
			}
			base.Result = bestTarget != null;
		}
	}
}
