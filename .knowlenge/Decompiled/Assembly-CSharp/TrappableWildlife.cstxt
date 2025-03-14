using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Rust/TrappableWildlife")]
public class TrappableWildlife : ScriptableObject
{
	[Serializable]
	public class BaitType
	{
		public float successRate = 1f;

		public ItemDefinition bait;

		public int minForInterest = 1;

		public int maxToConsume = 1;
	}

	public GameObjectRef worldObject;

	public ItemDefinition inventoryObject;

	public int minToCatch;

	public int maxToCatch;

	public List<BaitType> baitTypes;

	public int caloriesForInterest = 20;

	public float successRate = 1f;

	public float xpScale = 1f;
}
