using ProtoBuf;

public class TirednessAboveAIEvent : BaseAIEvent
{
	public float Value { get; private set; }

	public TirednessAboveAIEvent()
		: base(AIEventType.TirednessAbove)
	{
		base.Rate = ExecuteRate.Slow;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		TirednessAboveAIEventData tirednessAboveData = data.tirednessAboveData;
		Value = tirednessAboveData.value;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.tirednessAboveData = new TirednessAboveAIEventData();
		aIEventData.tirednessAboveData.value = Value;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (base.Owner is IAITirednessAbove iAITirednessAbove)
		{
			bool flag = iAITirednessAbove.IsTirednessAbove(Value);
			if (base.Inverted)
			{
				base.Result = !flag;
			}
			else
			{
				base.Result = flag;
			}
		}
	}
}
