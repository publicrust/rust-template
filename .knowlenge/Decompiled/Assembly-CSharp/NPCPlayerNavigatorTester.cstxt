public class NPCPlayerNavigatorTester : BaseMonoBehaviour
{
	public BasePathNode TargetNode;

	private BasePathNode currentNode;

	private void Update()
	{
		if (TargetNode != currentNode)
		{
			GetComponent<BaseNavigator>().SetDestination(TargetNode.Path, TargetNode, 0.5f);
			currentNode = TargetNode;
		}
	}
}
