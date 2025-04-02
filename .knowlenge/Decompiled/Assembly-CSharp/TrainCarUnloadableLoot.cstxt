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
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		base.Spawn();
		if (Application.isLoadingSave)
		{
			return;
		}
		int num = Random.Range(0, lootLayouts.Length);
		for (int i = 0; i < lootLayouts[num].crates.Length; i++)
		{
			GameObjectRef gameObjectRef = lootLayouts[num].crates[i];
			BaseEntity baseEntity = GameManager.server.CreateEntity(gameObjectRef.resourcePath, lootPositions[i].localPosition, lootPositions[i].localRotation);
			if ((Object)(object)baseEntity != (Object)null)
			{
				baseEntity.Spawn();
				baseEntity.SetParent(this);
			}
		}
	}
}
