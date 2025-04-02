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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.tirednessAboveData = new TirednessAboveAIEventData();
		obj.tirednessAboveData.value = Value;
		return obj;
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
