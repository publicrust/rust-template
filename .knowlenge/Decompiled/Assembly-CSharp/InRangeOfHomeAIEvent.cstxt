using ProtoBuf;
using UnityEngine;

public class InRangeOfHomeAIEvent : BaseAIEvent
{
	public float Range { get; set; }

	public InRangeOfHomeAIEvent()
		: base(AIEventType.InRangeOfHome)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		InRangeOfHomeAIEventData inRangeOfHomeData = data.inRangeOfHomeData;
		Range = inRangeOfHomeData.range;
	}

	public override AIEventData ToProto()
	{
		AIEventData aIEventData = base.ToProto();
		aIEventData.inRangeOfHomeData = new InRangeOfHomeAIEventData();
		aIEventData.inRangeOfHomeData.range = Range;
		return aIEventData;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		Vector3 b = memory.Position.Get(4);
		base.Result = false;
		bool flag = Vector3Ex.Distance2D(base.Owner.transform.position, b) <= Range;
		base.Result = (base.Inverted ? (!flag) : flag);
	}
}
