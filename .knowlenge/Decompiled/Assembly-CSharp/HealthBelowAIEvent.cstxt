using ProtoBuf;
using UnityEngine;

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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.healthBelowData = new HealthBelowAIEventData();
		obj.healthBelowData.healthFraction = HealthFraction;
		return obj;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		combatEntity = memory.Entity.Get(base.InputEntityMemorySlot) as BaseCombatEntity;
		if (!((Object)(object)combatEntity == (Object)null))
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
