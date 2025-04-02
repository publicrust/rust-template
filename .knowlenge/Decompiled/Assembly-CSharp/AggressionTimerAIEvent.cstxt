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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.aggressionTimerData = new AggressionTimerAIEventData();
		obj.aggressionTimerData.value = Value;
		return obj;
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
