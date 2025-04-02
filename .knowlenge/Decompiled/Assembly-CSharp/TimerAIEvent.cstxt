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
		AIEventData aIEventData = base.ToProto();
		aIEventData.timerData = new TimerAIEventData();
		aIEventData.timerData.duration = DurationMin;
		aIEventData.timerData.durationMax = DurationMax;
		return aIEventData;
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
