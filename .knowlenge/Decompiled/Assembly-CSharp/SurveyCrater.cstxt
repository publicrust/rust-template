#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class SurveyCrater : BaseCombatEntity
{
	private ResourceDispenser resourceDispenser;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("SurveyCrater.OnRpcMessage"))
		{
			if (rpc == 3491246334u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - AnalysisComplete ");
				}
				using (TimeWarning.New("AnalysisComplete"))
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
							AnalysisComplete(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in AnalysisComplete");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(RemoveMe, 1800f);
	}

	public override void OnAttacked(HitInfo info)
	{
		_ = base.isServer;
		base.OnAttacked(info);
	}

	public void RemoveMe()
	{
		Kill();
	}

	[RPC_Server]
	public void AnalysisComplete(RPCMessage msg)
	{
		Interface.CallHook("OnAnalysisComplete", this, msg.player);
	}

	public override float BoundsPadding()
	{
		return 2f;
	}
}
