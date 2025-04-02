using ProtoBuf;
using UnityEngine;

public class InRangeAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public InRangeAIEvent()
		: base(AIEventType.InRange)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		InRangeAIEventData inRangeData = data.inRangeData;
		Range = inRangeData.range;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.inRangeData = new InRangeAIEventData();
		aIEventData.inRangeData.range = Range;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		base.Result = false;
		if (!(baseEntity == null))
		{
			bool flag = Vector3Ex.Distance2D(base.Owner.transform.position, baseEntity.transform.position) <= Range;
			base.Result = (base.Inverted ? (!flag) : flag);
		}
	}
}
