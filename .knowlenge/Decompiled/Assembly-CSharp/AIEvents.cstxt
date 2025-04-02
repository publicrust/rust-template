using System.Collections.Generic;
using UnityEngine;

public class AIEvents
{
	public AIMemory Memory = new AIMemory();

	public List<BaseAIEvent> events = new List<BaseAIEvent>();

	private IAIEventListener eventListener;

	public AIBrainSenses senses;

	private int currentEventIndex;

	private bool inBlock;

	public int CurrentInputMemorySlot { get; private set; } = -1;

	public void Init(IAIEventListener listener, AIStateContainer stateContainer, BaseEntity owner, AIBrainSenses senses)
	{
		CurrentInputMemorySlot = stateContainer.InputMemorySlot;
		eventListener = listener;
		RemoveAll();
		AddStateEvents(stateContainer.Events, owner);
		Memory.Entity.Set(owner, 4);
		this.senses = senses;
	}

	public void RemoveAll()
	{
		events.Clear();
	}

	public void AddStateEvents(List<BaseAIEvent> events, BaseEntity owner)
	{
		foreach (BaseAIEvent @event in events)
		{
			Add(@event);
		}
	}

	public void Add(BaseAIEvent aiEvent)
	{
		if (events.Contains(aiEvent))
		{
			Debug.LogWarning("Attempting to add duplicate AI event: " + aiEvent.EventType);
			return;
		}
		aiEvent.Reset();
		events.Add(aiEvent);
	}

	public void Tick(float deltaTime, StateStatus stateStatus)
	{
		foreach (BaseAIEvent @event in events)
		{
			@event.Tick(deltaTime, eventListener);
		}
		inBlock = false;
		currentEventIndex = 0;
		for (currentEventIndex = 0; currentEventIndex < events.Count; currentEventIndex++)
		{
			BaseAIEvent baseAIEvent = events[currentEventIndex];
			BaseAIEvent baseAIEvent2 = ((currentEventIndex < events.Count - 1) ? events[currentEventIndex + 1] : null);
			if (baseAIEvent2 != null && baseAIEvent2.EventType == AIEventType.And && !inBlock)
			{
				inBlock = true;
			}
			if (baseAIEvent.EventType != AIEventType.And)
			{
				if (baseAIEvent.ShouldExecute)
				{
					baseAIEvent.Execute(Memory, senses, stateStatus);
					baseAIEvent.PostExecute();
				}
				bool result = baseAIEvent.Result;
				if (inBlock)
				{
					if (result)
					{
						if ((baseAIEvent2 != null && baseAIEvent2.EventType != AIEventType.And) || baseAIEvent2 == null)
						{
							inBlock = false;
							if (baseAIEvent.HasValidTriggerState)
							{
								baseAIEvent.TriggerStateChange(eventListener, baseAIEvent.ID);
								break;
							}
						}
					}
					else
					{
						inBlock = false;
						currentEventIndex = FindNextEventBlock() - 1;
					}
				}
				else if (result && baseAIEvent.HasValidTriggerState)
				{
					baseAIEvent.TriggerStateChange(eventListener, baseAIEvent.ID);
					break;
				}
			}
		}
	}

	private int FindNextEventBlock()
	{
		for (int i = currentEventIndex; i < events.Count; i++)
		{
			BaseAIEvent baseAIEvent = events[i];
			BaseAIEvent baseAIEvent2 = ((i < events.Count - 1) ? events[i + 1] : null);
			if (baseAIEvent2 != null && baseAIEvent2.EventType != AIEventType.And && baseAIEvent.EventType != AIEventType.And)
			{
				return i + 1;
			}
		}
		return events.Count + 1;
	}
}
