using System.Collections.Generic;
using ProtoBuf;

public class AIStateContainer
{
	public List<BaseAIEvent> Events;

	public int ID { get; private set; }

	public AIState State { get; private set; }

	public int InputMemorySlot { get; private set; } = -1;

	public void Init(ProtoBuf.AIStateContainer container, BaseEntity owner)
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

	public ProtoBuf.AIStateContainer ToProto()
	{
		ProtoBuf.AIStateContainer aIStateContainer = new ProtoBuf.AIStateContainer();
		aIStateContainer.id = ID;
		aIStateContainer.state = (int)State;
		aIStateContainer.events = new List<AIEventData>();
		aIStateContainer.inputMemorySlot = InputMemorySlot;
		foreach (BaseAIEvent @event in Events)
		{
			aIStateContainer.events.Add(@event.ToProto());
		}
		return aIStateContainer;
	}
}
