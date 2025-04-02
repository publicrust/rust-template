using ProtoBuf;

public class AmmoBelowAIEvent : BaseAIEvent
{
	public float Value { get; private set; }

	public AmmoBelowAIEvent()
		: base(AIEventType.AmmoBelow)
	{
		base.Rate = ExecuteRate.Normal;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		AmmoBelowAIEventData ammoBelowData = data.ammoBelowData;
		Value = ammoBelowData.value;
	}

	public override AIEventData ToProto()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.ammoBelowData = new AmmoBelowAIEventData();
		obj.ammoBelowData.value = Value;
		return obj;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		if (base.Owner is IAIAttack iAIAttack)
		{
			bool flag = iAIAttack.GetAmmoFraction() < Value;
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
