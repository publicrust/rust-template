using ProtoBuf;

public class AggressionTimerAIEvent : BaseAIEvent
{
	public float Value { get; private set; }

	public AggressionTimerAIEvent()
		: base(AIEventType.AggressionTimer)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		AggressionTimerAIEventData aggressionTimerData = data.aggressionTimerData;
		Value = aggressionTimerData.value;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.aggressionTimerData = new AggressionTimerAIEventData();
		aIEventData.aggressionTimerData.value = Value;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (base.Inverted)
		{
			base.Result = senses.TimeInAgressiveState < Value;
		}
		else
		{
			base.Result = senses.TimeInAgressiveState >= Value;
		}
	}
}
