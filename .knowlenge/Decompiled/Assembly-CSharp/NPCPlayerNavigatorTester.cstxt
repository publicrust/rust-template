using UnityEngine;

public class NPCPlayerNavigatorTester : BaseMonoBehaviour
{
	public BasePathNode TargetNode;

	private BasePathNode currentNode;

	private void Update()
	{
		if ((Object)(object)TargetNode != (Object)(object)currentNode)
		{
			((Component)this).GetComponent<BaseNavigator>().SetDestination(TargetNode.Path, TargetNode, 0.5f);
			currentNode = TargetNode;
		}
	}
}
