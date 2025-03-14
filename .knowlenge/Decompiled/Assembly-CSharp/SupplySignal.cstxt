using System;
using Oxide.Core;
using UnityEngine;

public class SupplySignal : TimedExplosive
{
	public GameObjectRef smokeEffectPrefab;

	public GameObjectRef EntityToCreate;

	[NonSerialized]
	public GameObject smokeEffect;

	public override void Explode()
	{
		BaseEntity baseEntity = GameManager.server.CreateEntity(EntityToCreate.resourcePath);
		if ((bool)baseEntity)
		{
			Vector3 vector = new Vector3(UnityEngine.Random.Range(-20f, 20f), 0f, UnityEngine.Random.Range(-20f, 20f));
			baseEntity.SendMessage("InitDropPosition", base.transform.position + vector, SendMessageOptions.DontRequireReceiver);
			baseEntity.Spawn();
			Interface.CallHook("OnCargoPlaneSignaled", baseEntity, this);
		}
		Invoke(FinishUp, 210f);
		SetFlag(Flags.On, b: true);
		SendNetworkUpdateImmediate();
	}

	public void FinishUp()
	{
		Kill();
	}
}
