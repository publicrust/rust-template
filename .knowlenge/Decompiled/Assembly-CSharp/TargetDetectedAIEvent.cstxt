using ProtoBuf;

public class TargetDetectedAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public TargetDetectedAIEvent()
		: base(AIEventType.TargetDetected)
	{
		base.Rate = ExecuteRate.Slow;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		TargetDetectedAIEventData targetDetectedData = data.targetDetectedData;
		Range = targetDetectedData.range;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.targetDetectedData = new TargetDetectedAIEventData();
		aIEventData.targetDetectedData.range = Range;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		BaseEntity nearestTarget = senses.GetNearestTarget(Range);
		if (base.Inverted)
		{
			if (nearestTarget == null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Remove(base.OutputEntityMemorySlot);
			}
			base.Result = nearestTarget == null;
		}
		else
		{
			if (nearestTarget != null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(nearestTarget, base.OutputEntityMemorySlot);
			}
			base.Result = nearestTarget != null;
		}
	}
}
