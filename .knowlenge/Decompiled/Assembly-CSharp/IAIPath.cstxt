using System.Collections.Generic;
using UnityEngine;

public interface IAIPath
{
	IEnumerable<IAIPathSpeedZone> SpeedZones { get; }

	IEnumerable<IAIPathInterestNode> InterestNodes { get; }

	void GetNodesNear(Vector3 point, ref List<IAIPathNode> nearNodes, float dist = 10f);

	IAIPathInterestNode GetRandomInterestNodeAwayFrom(Vector3 from, float dist = 10f);

	IAIPathNode GetClosestToPoint(Vector3 point);

	void AddInterestNode(IAIPathInterestNode interestNode);

	void AddSpeedZone(IAIPathSpeedZone speedZone);
}
