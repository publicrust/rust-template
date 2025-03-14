using System.Collections.Generic;
using UnityEngine;

public interface IAIPathNode
{
	Vector3 Position { get; }

	bool Straightaway { get; }

	IEnumerable<IAIPathNode> Linked { get; }

	bool IsValid();

	void AddLink(IAIPathNode link);
}
