using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DungeonBaseFloor
{
	public List<DungeonBaseLink> Links = new List<DungeonBaseLink>();

	public float Distance(Vector3 position)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		return Mathf.Abs(((Component)Links[0]).transform.position.y - position.y);
	}

	public float SignedDistance(Vector3 position)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		return ((Component)Links[0]).transform.position.y - position.y;
	}
}
