using ProtoBuf;

public class HealthBelowAIEvent : BaseAIEvent
{
	private BaseCombatEntity combatEntity;

	public float HealthFraction { get; set; }

	public HealthBelowAIEvent()
		: base(AIEventType.HealthBelow)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		HealthBelowAIEventData healthBelowData = data.healthBelowData;
		HealthFraction = healthBelowData.healthFraction;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.healthBelowData = new HealthBelowAIEventData();
		aIEventData.healthBelowData.healthFraction = HealthFraction;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		combatEntity = memory.Entity.Get(base.InputEntityMemorySlot) as BaseCombatEntity;
		if (!(combatEntity == null))
		{
			bool flag = combatEntity.healthFraction < HealthFraction;
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
