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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.hungerAboveData = new HungerAboveAIEventData();
		obj.hungerAboveData.value = Value;
		return obj;
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
