using Oxide.Core;
using UnityEngine;

public class SupplyDrop : LootContainer
{
	public GameObjectRef parachutePrefab;

	public BaseEntity parachute;

	public override void ServerInit()
	{
		base.ServerInit();
		if (parachutePrefab.isValid)
		{
			parachute = GameManager.server.CreateEntity(parachutePrefab.resourcePath);
		}
		if ((bool)parachute)
		{
			parachute.SetParent(this, "parachute_attach");
			parachute.Spawn();
		}
		isLootable = false;
		Invoke(MakeLootable, 300f);
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		RemoveParachute();
	}

	public void RemoveParachute()
	{
		if ((bool)parachute)
		{
			parachute.Kill();
			parachute = null;
		}
	}

	public void MakeLootable()
	{
		isLootable = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (((1 << collision.collider.gameObject.layer) & 0x40A10111) > 0)
		{
			RemoveParachute();
			MakeLootable();
		}
		Interface.CallHook("OnSupplyDropLanded", this);
	}
}
