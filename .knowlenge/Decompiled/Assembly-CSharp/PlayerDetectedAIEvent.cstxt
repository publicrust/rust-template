using ProtoBuf;
using UnityEngine;

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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.playerDetectedData = new PlayerDetectedAIEventData();
		obj.playerDetectedData.range = Range;
		return obj;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = false;
		BaseEntity nearestPlayer = senses.GetNearestPlayer(Range);
		if (base.Inverted)
		{
			if ((Object)(object)nearestPlayer == (Object)null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Remove(base.OutputEntityMemorySlot);
			}
			base.Result = (Object)(object)nearestPlayer == (Object)null;
		}
		else
		{
			if ((Object)(object)nearestPlayer != (Object)null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(nearestPlayer, base.OutputEntityMemorySlot);
			}
			base.Result = (Object)(object)nearestPlayer != (Object)null;
		}
	}
}
