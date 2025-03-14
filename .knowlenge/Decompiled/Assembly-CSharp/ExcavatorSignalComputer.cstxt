#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Network;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ExcavatorSignalComputer : BaseCombatEntity
{
	public float chargePower;

	public const Flags Flag_Ready = Flags.Reserved7;

	public const Flags Flag_HasPower = Flags.Reserved8;

	public GameObjectRef supplyPlanePrefab;

	public Transform[] dropPoints;

	public Text statusText;

	public Text timerText;

	public static readonly Translate.Phrase readyphrase = new Translate.Phrase("excavator.signal.ready", "READY");

	public static readonly Translate.Phrase chargephrase = new Translate.Phrase("excavator.signal.charging", "COMSYS CHARGING");

	[ServerVar]
	public static float chargeNeededForSupplies = 600f;

	private float lastChargeTime;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ExcavatorSignalComputer.OnRpcMessage"))
		{
			if (rpc == 1824723998 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - RequestSupplies ");
				}
				using (TimeWarning.New("RequestSupplies"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(1824723998u, "RequestSupplies", this, player, 5uL))
						{
							return true;
						}
						if (!RPC_Server.IsVisible.Test(1824723998u, "RequestSupplies", this, player, 3f))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage rpc2 = rPCMessage;
							RequestSupplies(rpc2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RequestSupplies");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity = Facepunch.Pool.Get<ProtoBuf.IOEntity>();
		info.msg.ioEntity.genericFloat1 = chargePower;
		info.msg.ioEntity.genericFloat2 = chargeNeededForSupplies;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		lastChargeTime = UnityEngine.Time.time;
		InvokeRepeating(ChargeThink, 0f, 1f);
	}

	public override void PostServerLoad()
	{
		SetFlag(Flags.Reserved8, b: false);
		SetFlag(Flags.Reserved7, b: false);
	}

	public void ChargeThink()
	{
		float num = chargePower;
		float num2 = UnityEngine.Time.time - lastChargeTime;
		lastChargeTime = UnityEngine.Time.time;
		if (IsPowered())
		{
			chargePower += num2;
		}
		chargePower = Mathf.Clamp(chargePower, 0f, chargeNeededForSupplies);
		SetFlag(Flags.Reserved7, chargePower >= chargeNeededForSupplies);
		if (num != chargePower)
		{
			SendNetworkUpdate();
		}
	}

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		base.OnEntityMessage(from, msg);
		if (msg == "DieselEngineOn")
		{
			SetFlag(Flags.Reserved8, b: true);
		}
		else if (msg == "DieselEngineOff")
		{
			SetFlag(Flags.Reserved8, b: false);
		}
	}

	[RPC_Server.CallsPerSecond(5uL)]
	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RequestSupplies(RPCMessage rpc)
	{
		if (HasFlag(Flags.Reserved7) && IsPowered() && chargePower >= chargeNeededForSupplies && Interface.CallHook("OnExcavatorSuppliesRequest", this, rpc.player) == null)
		{
			BaseEntity baseEntity = GameManager.server.CreateEntity(supplyPlanePrefab.resourcePath);
			if ((bool)baseEntity)
			{
				Vector3 position = dropPoints[UnityEngine.Random.Range(0, dropPoints.Length)].position;
				Vector3 vector = new Vector3(UnityEngine.Random.Range(-3f, 3f), 0f, UnityEngine.Random.Range(-3f, 3f));
				baseEntity.SendMessage("InitDropPosition", position + vector, SendMessageOptions.DontRequireReceiver);
				baseEntity.Spawn();
			}
			Interface.CallHook("OnExcavatorSuppliesRequested", this, rpc.player, baseEntity);
			chargePower -= chargeNeededForSupplies;
			SetFlag(Flags.Reserved7, b: false);
			SendNetworkUpdate();
		}
	}

	public bool IsPowered()
	{
		return HasFlag(Flags.Reserved8);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			chargePower = info.msg.ioEntity.genericFloat1;
		}
	}
}
