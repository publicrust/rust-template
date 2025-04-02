using ProtoBuf;
using UnityEngine;

public class TimerAIEvent : BaseAIEvent
{
	protected float currentDuration;

	protected float elapsedDuration;

	public float DurationMin { get; set; }

	public float DurationMax { get; set; }

	public TimerAIEvent()
		: base(AIEventType.Timer)
	{
		base.Rate = ExecuteRate.Fast;
	}

	public override void Init(AIEventData data, BaseEntity owner)
	{
		base.Init(data, owner);
		TimerAIEventData timerData = data.timerData;
		DurationMin = timerData.duration;
		DurationMax = timerData.durationMax;
	}

	public override AIEventData ToProto()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		AIEventData obj = base.ToProto();
		obj.timerData = new TimerAIEventData();
		obj.timerData.duration = DurationMin;
		obj.timerData.durationMax = DurationMax;
		return obj;
	}

	public override void Reset()
	{
		base.Reset();
		currentDuration = Random.Range(DurationMin, DurationMax);
		elapsedDuration = 0f;
	}

	public override void Execute(AIMemory memory, AIBrainSenses senses, StateStatus stateStatus)
	{
		base.Result = base.Inverted;
		elapsedDuration += deltaTime;
		if (elapsedDuration >= currentDuration)
		{
			base.Result = !base.Inverted;
		}
	}
}
