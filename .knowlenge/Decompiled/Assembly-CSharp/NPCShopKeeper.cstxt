using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class NPCShopKeeper : NPCPlayer
{
	public EntityRef invisibleVendingMachineRef;

	public InvisibleVendingMachine machine;

	public float greetDir;

	public Vector3 initialFacingDir;

	public BasePlayer lastWavedAtPlayer;

	public InvisibleVendingMachine GetVendingMachine()
	{
		if (!invisibleVendingMachineRef.IsValid(base.isServer))
		{
			return null;
		}
		return invisibleVendingMachineRef.Get(base.isServer).GetComponent<InvisibleVendingMachine>();
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(base.transform.position + Vector3.up * 1f, new Vector3(0.5f, 1f, 0.5f));
	}

	public override void UpdateProtectionFromClothing()
	{
	}

	public override void Hurt(HitInfo info)
	{
	}

	public override void ServerInit()
	{
		base.ServerInit();
		initialFacingDir = base.transform.rotation * Vector3.forward;
		Invoke(DelayedSleepEnd, 3f);
		SetAimDirection(base.transform.rotation * Vector3.forward);
		InvokeRandomized(Greeting, Random.Range(5f, 10f), 5f, Random.Range(0f, 2f));
		if (invisibleVendingMachineRef.IsValid(serverside: true) && machine == null)
		{
			machine = GetVendingMachine();
		}
		else if (machine != null && !invisibleVendingMachineRef.IsValid(serverside: true))
		{
			invisibleVendingMachineRef.Set(machine);
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

	public override void PostServerLoad()
	{
		base.PostServerLoad();
	}

	public void DelayedSleepEnd()
	{
		EndSleeping();
	}

	public void GreetPlayer(BasePlayer player)
	{
		if (player != null)
		{
			SignalBroadcast(Signal.Gesture, "wave");
			SetAimDirection(Vector3Ex.Direction2D(player.eyes.position, eyes.position));
			lastWavedAtPlayer = player;
		}
		else
		{
			SetAimDirection(initialFacingDir);
		}
	}

	public void Greeting()
	{
		List<BasePlayer> obj = Pool.GetList<BasePlayer>();
		Vis.Entities(base.transform.position, 10f, obj, 131072);
		_ = base.transform.position;
		BasePlayer basePlayer = null;
		foreach (BasePlayer item in obj)
		{
			if (!item.isClient && !item.IsNpc && !(item == this) && item.IsVisible(eyes.position) && !(item == lastWavedAtPlayer) && !(Vector3.Dot(Vector3Ex.Direction2D(item.eyes.position, eyes.position), initialFacingDir) < 0.2f))
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
			SetAimDirection(Vector3Ex.Direction2D(basePlayer.eyes.position, eyes.position));
			lastWavedAtPlayer = basePlayer;
		}
		else
		{
			SetAimDirection(initialFacingDir);
		}
		Pool.FreeList(ref obj);
	}
}
