using System.Collections.Generic;
using UnityEngine;

public class RuntimePathNode : IAIPathNode
{
	private HashSet<IAIPathNode> linked = new HashSet<IAIPathNode>();

	public Vector3 Position { get; set; }

	public bool Straightaway { get; set; }

	public IEnumerable<IAIPathNode> Linked => linked;

	public RuntimePathNode(Vector3 position)
	{
		Position = position;
	}

	public bool IsValid()
	{
		return true;
	}

	public void AddLink(IAIPathNode link)
	{
		linked.Add(link);
	}
}
