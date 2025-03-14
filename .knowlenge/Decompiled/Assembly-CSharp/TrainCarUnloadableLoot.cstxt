using System;
using Rust;
using UnityEngine;

public class TrainCarUnloadableLoot : TrainCarUnloadable
{
	[Serializable]
	public class LootCrateSet
	{
		public GameObjectRef[] crates;
	}

	[SerializeField]
	private LootCrateSet[] lootLayouts;

	[SerializeField]
	private Transform[] lootPositions;

	public override void Spawn()
	{
		base.Spawn();
		if (Rust.Application.isLoadingSave)
		{
			return;
		}
		int num = UnityEngine.Random.Range(0, lootLayouts.Length);
		for (int i = 0; i < lootLayouts[num].crates.Length; i++)
		{
			GameObjectRef gameObjectRef = lootLayouts[num].crates[i];
			BaseEntity baseEntity = GameManager.server.CreateEntity(gameObjectRef.resourcePath, lootPositions[i].localPosition, lootPositions[i].localRotation);
			if (baseEntity != null)
			{
				baseEntity.Spawn();
				baseEntity.SetParent(this);
			}
		}
	}
}
