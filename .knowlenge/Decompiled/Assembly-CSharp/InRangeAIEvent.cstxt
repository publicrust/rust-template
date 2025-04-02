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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.inRangeData = new InRangeAIEventData();
		obj.inRangeData.range = Range;
		return obj;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		BaseEntity baseEntity = memory.Entity.Get(base.InputEntityMemorySlot);
		base.Result = false;
		if (!((Object)(object)baseEntity == (Object)null))
		{
			bool flag = Vector3Ex.Distance2D(((Component)base.Owner).transform.position, ((Component)baseEntity).transform.position) <= Range;
			base.Result = (base.Inverted ? (!flag) : flag);
		}
	}
}
