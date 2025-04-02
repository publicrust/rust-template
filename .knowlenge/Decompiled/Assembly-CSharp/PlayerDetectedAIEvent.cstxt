using ProtoBuf;

public class PlayerDetectedAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public PlayerDetectedAIEvent()
		: base(AIEventType.PlayerDetected)
	{
		base.Rate = ExecuteRate.Slow;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		PlayerDetectedAIEventData playerDetectedData = data.playerDetectedData;
		Range = playerDetectedData.range;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.playerDetectedData = new PlayerDetectedAIEventData();
		aIEventData.playerDetectedData.range = Range;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = false;
		BaseEntity nearestPlayer = senses.GetNearestPlayer(Range);
		if (base.Inverted)
		{
			if (nearestPlayer == null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Remove(base.OutputEntityMemorySlot);
			}
			base.Result = nearestPlayer == null;
		}
		else
		{
			if (nearestPlayer != null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(nearestPlayer, base.OutputEntityMemorySlot);
			}
			base.Result = nearestPlayer != null;
		}
	}
}
