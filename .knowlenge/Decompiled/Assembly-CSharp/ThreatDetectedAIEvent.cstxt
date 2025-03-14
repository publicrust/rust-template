using ProtoBuf;

public class ThreatDetectedAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public ThreatDetectedAIEvent()
		: base(AIEventType.ThreatDetected)
	{
		base.Rate = ExecuteRate.Slow;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		ThreatDetectedAIEventData threatDetectedData = data.threatDetectedData;
		Range = threatDetectedData.range;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.threatDetectedData = new ThreatDetectedAIEventData();
		aIEventData.threatDetectedData.range = Range;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		BaseEntity nearestThreat = senses.GetNearestThreat(Range);
		if (base.Inverted)
		{
			if (nearestThreat == null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Remove(base.OutputEntityMemorySlot);
			}
			base.Result = nearestThreat == null;
		}
		else
		{
			if (nearestThreat != null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(nearestThreat, base.OutputEntityMemorySlot);
			}
			base.Result = nearestThreat != null;
		}
	}
}
