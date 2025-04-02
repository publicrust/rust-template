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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.timeSinceThreatData = new TimeSinceThreatAIEventData();
		obj.timeSinceThreatData.value = Value;
		return obj;
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
