using ConVar;
using Oxide.Core;
using Rust;
using UnityEngine;

public class SupplyDrop : LootContainer
{
	public GameObjectRef parachutePrefab;

	public const Flags FlagNightLight = Flags.Reserved1;

	public BaseEntity parachute;

	public override void ServerInit()
	{
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			if (parachutePrefab.isValid)
			{
				parachute = GameManager.server.CreateEntity(parachutePrefab.resourcePath);
			}
			if ((bool)parachute)
			{
				parachute.SetParent(this, "parachute_attach");
				parachute.Spawn();
			}
		}
		isLootable = false;
		Invoke(MakeLootable, 300f);
		InvokeRepeating(CheckNightLight, 0f, 30f);
	}

	protected override void OnChildAdded(BaseEntity child)
	{
		base.OnChildAdded(child);
		if (base.isServer && Rust.Application.isLoadingSave)
		{
			if (parachute != null)
			{
				Debug.LogWarning("More than one child entity was added to SupplyDrop! Expected only the parachute.", this);
			}
			parachute = child;
		}
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

	public void CheckNightLight()
	{
		SetFlag(Flags.Reserved1, Env.time > 20f || Env.time < 7f);
	}
}
