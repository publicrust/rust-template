using ProtoBuf;

public class HungerAboveAIEvent : BaseAIEvent
{
	public float Value { get; private set; }

	public HungerAboveAIEvent()
		: base(AIEventType.HungerAbove)
	{
		base.Rate = ExecuteRate.Slow;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		HungerAboveAIEventData hungerAboveData = data.hungerAboveData;
		Value = hungerAboveData.value;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.hungerAboveData = new HungerAboveAIEventData();
		aIEventData.hungerAboveData.value = Value;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		if (!(base.Owner is IAIHungerAbove iAIHungerAbove))
		{
			base.Result = false;
			return;
		}
		bool flag = iAIHungerAbove.IsHungerAbove(Value);
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
