using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class NPCShopKeeper : NPCPlayer
{
	public EntityRef invisibleVendingMachineRef;

	public InvisibleVendingMachine machine;

	public bool canBeHurt;

	public float greetDir;

	public Vector3 initialFacingDir;

	public BasePlayer lastWavedAtPlayer;

	protected override string OverrideCorpseName => "Shopkeeper";

	public InvisibleVendingMachine GetVendingMachine()
	{
		if (!invisibleVendingMachineRef.IsValid(base.isServer))
		{
			return null;
		}
		return invisibleVendingMachineRef.Get(base.isServer).GetComponent<InvisibleVendingMachine>();
	}

	public override void UpdateProtectionFromClothing()
	{
	}

	protected override bool AllowRagdoll()
	{
		return canBeHurt;
	}

	public override void OnDied(HitInfo info)
	{
		base.OnDied(info);
		if (invisibleVendingMachineRef.Get(base.isServer) != null && invisibleVendingMachineRef.Get(base.isServer) is InvisibleVendingMachine invisibleVendingMachine)
		{
			invisibleVendingMachine.SetAttachedNPC(null);
		}
	}

	public override void Hurt(HitInfo info)
	{
		if (canBeHurt)
		{
			base.Hurt(info);
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Quaternion rotation = base.transform.rotation;
		initialFacingDir = rotation * Vector3.forward;
		Invoke(DelayedSleepEnd, 3f);
		SetAimDirection(rotation * Vector3.forward);
		InvokeRandomized(Greeting, Random.Range(5f, 10f), 5f, Random.Range(0f, 2f));
	}

	public override void PostInitShared()
	{
		base.PostInitShared();
		if (base.isServer)
		{
			if (machine == null)
			{
				machine = InvisibleVendingMachine.GetMachineAtPosition(1f, base.transform.position);
			}
			if (invisibleVendingMachineRef.IsValid(serverside: true) && machine == null)
			{
				machine = GetVendingMachine();
				machine.SetAttachedNPC(this);
			}
			else if (machine != null && !invisibleVendingMachineRef.IsValid(serverside: true))
			{
				invisibleVendingMachineRef.Set(machine);
				machine.SetAttachedNPC(this);
			}
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.shopKeeper = Pool.Get<ShopKeeper>();
		info.msg.shopKeeper.vendingRef = invisibleVendingMachineRef.uid;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.shopKeeper != null)
		{
			invisibleVendingMachineRef.uid = info.msg.shopKeeper.vendingRef;
		}
	}

	public void DelayedSleepEnd()
	{
		EndSleeping();
	}

	public virtual void GreetPlayer(BasePlayer player)
	{
		if (player != null)
		{
			SignalBroadcast(Signal.Gesture, "wave");
			SetAimDirection(Vector3Ex.Direction2D(player.eyes.position, base.eyes.position));
			lastWavedAtPlayer = player;
		}
		else
		{
			SetAimDirection(initialFacingDir);
		}
	}

	public virtual void Greeting()
	{
		List<BasePlayer> obj = Pool.Get<List<BasePlayer>>();
		Vis.Entities(base.transform.position, 10f, obj, 131072);
		BasePlayer basePlayer = null;
		foreach (BasePlayer item in obj)
		{
			if (!item.isClient && !item.IsNpc && !(item == this) && item.IsVisible(base.eyes.position) && !(item == lastWavedAtPlayer) && !(Vector3.Dot(Vector3Ex.Direction2D(item.eyes.position, base.eyes.position), initialFacingDir) < 0.2f))
			{
				basePlayer = item;
				break;
			}
		}
		if (basePlayer == null && !obj.Contains(lastWavedAtPlayer))
		{
			lastWavedAtPlayer = null;
		}
		if (basePlayer != null)
		{
			SignalBroadcast(Signal.Gesture, "wave");
			SetAimDirection(Vector3Ex.Direction2D(basePlayer.eyes.position, base.eyes.position));
			lastWavedAtPlayer = basePlayer;
		}
		else
		{
			SetAimDirection(initialFacingDir);
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
