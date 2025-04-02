using ConVar;
using Oxide.Core;
using Rust;
using UnityEngine;

public class SupplyDrop : LootContainer
{
	public const Flags FlagNightLight = Flags.Reserved1;

	private const Flags ShowParachute = Flags.Reserved2;

	public GameObject ParachuteRoot;

	public override void ServerInit()
	{
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			SetFlag(Flags.Reserved2, b: true);
		}
		isLootable = false;
		Invoke(MakeLootable, 300f);
		InvokeRepeating(CheckNightLight, 0f, 30f);
	}

	public void RemoveParachute()
	{
		SetFlag(Flags.Reserved2, b: false);
	}

	public void MakeLootable()
	{
		isLootable = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		bool flag = ((1 << collision.collider.gameObject.layer) & 0x40A10111) > 0;
		if (((1 << collision.collider.gameObject.layer) & 0x8000000) > 0 && CollisionEx.GetEntity(collision) is Tugboat)
		{
			flag = true;
		}
		if (flag)
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

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (ParachuteRoot != null)
		{
			ParachuteRoot.SetActive(next.HasFlag(Flags.Reserved2));
		}
	}
}
