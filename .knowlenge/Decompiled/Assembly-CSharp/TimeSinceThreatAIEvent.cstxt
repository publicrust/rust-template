using ProtoBuf;

public class TimeSinceThreatAIEvent : BaseAIEvent
{
	public float Value { get; private set; }

	public TimeSinceThreatAIEvent()
		: base(AIEventType.TimeSinceThreat)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		TimeSinceThreatAIEventData timeSinceThreatData = data.timeSinceThreatData;
		Value = timeSinceThreatData.value;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.timeSinceThreatData = new TimeSinceThreatAIEventData();
		aIEventData.timeSinceThreatData.value = Value;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (base.Inverted)
		{
			base.Result = senses.TimeSinceThreat < Value;
		}
		else
		{
			base.Result = senses.TimeSinceThreat >= Value;
		}
	}
}
