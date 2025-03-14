using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DungeonBaseFloor
{
	public List<DungeonBaseLink> Links = new List<DungeonBaseLink>();

	public float Distance(Vector3 position)
	{
		return Mathf.Abs(Links[0].transform.position.y - position.y);
	}

	public float SignedDistance(Vector3 position)
	{
		return Links[0].transform.position.y - position.y;
	}
}
