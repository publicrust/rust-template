using System.Collections.Generic;
using ProtoBuf;

public class AIStateContainer
{
	public List<BaseAIEvent> Events;

	public int ID { get; private set; }

	public AIState State { get; private set; }

	public int InputMemorySlot { get; private set; } = -1;

	public void Init(AIStateContainer container, BaseEntity owner)
	{
		ID = container.id;
		State = (AIState)container.state;
		InputMemorySlot = container.inputMemorySlot;
		Events = new List<BaseAIEvent>();
		if (container.events == null)
		{
			return;
		}
		foreach (AIEventData @event in container.events)
		{
			BaseAIEvent baseAIEvent = BaseAIEvent.CreateEvent((AIEventType)@event.eventType);
			baseAIEvent.Init(@event, owner);
			baseAIEvent.Reset();
			Events.Add(baseAIEvent);
		}
	}

	public AIStateContainer ToProto()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		AIStateContainer val = new AIStateContainer();
		val.id = ID;
		val.state = (int)State;
		val.events = new List<AIEventData>();
		val.inputMemorySlot = InputMemorySlot;
		foreach (BaseAIEvent @event in Events)
		{
			val.events.Add(@event.ToProto());
		}
		return val;
	}
}
