using ProtoBuf;
using UnityEngine;

public class TargetDetectedAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public TargetDetectedAIEvent()
		: base(AIEventType.TargetDetected)
	{
		base.Rate = ExecuteRate.Slow;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		TargetDetectedAIEventData targetDetectedData = data.targetDetectedData;
		Range = targetDetectedData.range;
	}

	public override AIEventData ToProto()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.targetDetectedData = new TargetDetectedAIEventData();
		obj.targetDetectedData.range = Range;
		return obj;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		BaseEntity nearestTarget = senses.GetNearestTarget(Range);
		if (base.Inverted)
		{
			if ((Object)(object)nearestTarget == (Object)null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Remove(base.OutputEntityMemorySlot);
			}
			base.Result = (Object)(object)nearestTarget == (Object)null;
		}
		else
		{
			if ((Object)(object)nearestTarget != (Object)null && base.ShouldSetOutputEntityMemory)
			{
				memory.Entity.Set(nearestTarget, base.OutputEntityMemorySlot);
			}
			base.Result = (Object)(object)nearestTarget != (Object)null;
		}
	}
}
