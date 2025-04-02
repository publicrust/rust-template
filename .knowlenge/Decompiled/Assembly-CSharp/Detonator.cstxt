#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Network;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class Detonator : HeldEntity, IRFObject
{
	public int frequency = 55;

	private float timeSinceDeploy;

	public GameObjectRef frequencyPanelPrefab;

	public GameObjectRef attackEffect;

	public GameObjectRef unAttackEffect;

	private float nextChangeTime;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("Detonator.OnRpcMessage"))
		{
			if (rpc == 2778616053u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - ServerSetFrequency ");
				}
				using (TimeWarning.New("ServerSetFrequency"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							ServerSetFrequency(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in ServerSetFrequency");
					}
				}
				return true;
			}
			if (rpc == 1106698135 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - SetPressed ");
				}
				using (TimeWarning.New("SetPressed"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage pressed = rPCMessage;
							SetPressed(pressed);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in SetPressed");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	[RPC_Server]
	public void SetPressed(RPCMessage msg)
	{
		if (!(msg.player == null) && !(msg.player != GetOwnerPlayer()))
		{
			bool num = HasFlag(Flags.On);
			bool flag = msg.read.Bit();
			InternalSetPressed(flag);
			if (num != flag)
			{
				Effect.server.Run(flag ? attackEffect.resourcePath : unAttackEffect.resourcePath, this, 0u, Vector3.zero, Vector3.zero);
			}
		}
	}

	internal void InternalSetPressed(bool pressed)
	{
		SetFlag(Flags.On, pressed);
		if (pressed)
		{
			RFManager.AddBroadcaster(frequency, this);
		}
		else
		{
			RFManager.RemoveBroadcaster(frequency, this);
		}
	}

	public Vector3 GetPosition()
	{
		return base.transform.position;
	}

	public float GetMaxRange()
	{
		return 100000f;
	}

	public void RFSignalUpdate(bool on)
	{
	}

	public override void SetHeld(bool bHeld)
	{
		if (!bHeld)
		{
			InternalSetPressed(pressed: false);
		}
		base.SetHeld(bHeld);
	}

	[RPC_Server]
	public void ServerSetFrequency(RPCMessage msg)
	{
		ServerSetFrequency(msg.player, msg.read.Int32());
	}

	public void ServerSetFrequency(BasePlayer player, int freq)
	{
		if (player == null || GetOwnerPlayer() != player || UnityEngine.Time.time < nextChangeTime)
		{
			return;
		}
		nextChangeTime = UnityEngine.Time.time + 2f;
		if (RFManager.IsReserved(freq))
		{
			RFManager.ReserveErrorPrint(player);
		}
		else
		{
			if (Interface.CallHook("OnRfFrequencyChange", this, freq, player) != null)
			{
				return;
			}
			Item ownerItem = GetOwnerItem();
			RFManager.ChangeFrequency(frequency, freq, this, isListener: false, IsOn());
			frequency = freq;
			SendNetworkUpdate();
			Item item = GetItem();
			if (item != null)
			{
				if (item.instanceData == null)
				{
					item.instanceData = new ProtoBuf.Item.InstanceData();
					item.instanceData.ShouldPool = false;
				}
				item.instanceData.dataInt = frequency;
				item.MarkDirty();
			}
			ownerItem?.LoseCondition(ownerItem.maxCondition * 0.01f);
			Interface.CallHook("OnRfFrequencyChanged", this, freq, player);
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.ioEntity == null)
		{
			info.msg.ioEntity = Facepunch.Pool.Get<ProtoBuf.IOEntity>();
		}
		info.msg.ioEntity.genericInt1 = frequency;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ioEntity != null)
		{
			frequency = info.msg.ioEntity.genericInt1;
		}
	}

	public int GetFrequency()
	{
		return frequency;
	}
}
