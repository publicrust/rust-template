using System.Collections.Generic;
using ProtoBuf;

public class AIDesign
{
	public List<AIState> AvailableStates = new List<AIState>();

	public int DefaultStateContainerID;

	private Dictionary<int, AIStateContainer> stateContainers = new Dictionary<int, AIStateContainer>();

	public AIDesignScope Scope { get; private set; }

	public string Description { get; private set; }

	public void SetAvailableStates(List<AIState> states)
	{
		AvailableStates = new List<AIState>();
		AvailableStates.AddRange(states);
	}

	public void Load(ProtoBuf.AIDesign design, BaseEntity owner)
	{
		Scope = (AIDesignScope)design.scope;
		DefaultStateContainerID = design.defaultStateContainer;
		Description = design.description;
		InitStateContainers(design, owner);
	}

	private void InitStateContainers(ProtoBuf.AIDesign design, BaseEntity owner)
	{
		stateContainers = new Dictionary<int, AIStateContainer>();
		if (design.stateContainers == null)
		{
			return;
		}
		foreach (ProtoBuf.AIStateContainer stateContainer in design.stateContainers)
		{
			AIStateContainer aIStateContainer = new AIStateContainer();
			aIStateContainer.Init(stateContainer, owner);
			stateContainers.Add(aIStateContainer.ID, aIStateContainer);
		}
	}

	public AIStateContainer GetDefaultStateContainer()
	{
		return GetStateContainerByID(DefaultStateContainerID);
	}

	public AIStateContainer GetStateContainerByID(int id)
	{
		if (!stateContainers.ContainsKey(id))
		{
			return null;
		}
		return stateContainers[id];
	}

	public AIStateContainer GetFirstStateContainerOfType(AIState stateType)
	{
		foreach (AIStateContainer value in stateContainers.Values)
		{
			if (value.State == stateType)
			{
				return value;
			}
		}
		return null;
	}

	public ProtoBuf.AIDesign ToProto(int currentStateID)
	{
		ProtoBuf.AIDesign aIDesign = new ProtoBuf.AIDesign();
		aIDesign.description = Description;
		aIDesign.scope = (int)Scope;
		aIDesign.defaultStateContainer = DefaultStateContainerID;
		aIDesign.availableStates = new List<int>();
		foreach (AIState availableState in AvailableStates)
		{
			aIDesign.availableStates.Add((int)availableState);
		}
		aIDesign.stateContainers = new List<ProtoBuf.AIStateContainer>();
		foreach (AIStateContainer value in stateContainers.Values)
		{
			aIDesign.stateContainers.Add(value.ToProto());
		}
		aIDesign.intialViewStateID = currentStateID;
		return aIDesign;
	}
}
