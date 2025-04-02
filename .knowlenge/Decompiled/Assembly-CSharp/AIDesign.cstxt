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

	public void Load(AIDesign design, BaseEntity owner)
	{
		Scope = (AIDesignScope)design.scope;
		DefaultStateContainerID = design.defaultStateContainer;
		Description = design.description;
		InitStateContainers(design, owner);
	}

	private void InitStateContainers(AIDesign design, BaseEntity owner)
	{
		stateContainers = new Dictionary<int, AIStateContainer>();
		if (design.stateContainers == null)
		{
			return;
		}
		foreach (AIStateContainer stateContainer in design.stateContainers)
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

	public AIDesign ToProto(int currentStateID)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		AIDesign val = new AIDesign();
		val.description = Description;
		val.scope = (int)Scope;
		val.defaultStateContainer = DefaultStateContainerID;
		val.availableStates = new List<int>();
		foreach (AIState availableState in AvailableStates)
		{
			val.availableStates.Add((int)availableState);
		}
		val.stateContainers = new List<AIStateContainer>();
		foreach (AIStateContainer value in stateContainers.Values)
		{
			val.stateContainers.Add(value.ToProto());
		}
		val.intialViewStateID = currentStateID;
		return val;
	}
}
