#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class GestureDoor : Door
{
	public GestureConfig OpenGesture;

	public GestureConfig KickGesture;

	public float KickAnimationDelay = 1f;

	public float PushAnimationDelay = 0.25f;

	public float WeaponAdditiveDelay = 0.1f;

	private bool wasKick;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("GestureDoor.OnRpcMessage"))
		{
			if (rpc == 872065295 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - ServerKick ");
				}
				using (TimeWarning.New("ServerKick"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(872065295u, "ServerKick", this, player, 3f))
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
							RPCMessage msg2 = rPCMessage;
							ServerKick(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in ServerKick");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	protected override void OnPlayerOpenedDoor(BasePlayer p)
	{
		base.OnPlayerOpenedDoor(p);
		if (wasKick)
		{
			p.Server_StartGesture(KickGesture, BasePlayer.GestureStartSource.ServerAction);
		}
		else
		{
			p.Server_StartGesture(OpenGesture, BasePlayer.GestureStartSource.ServerAction);
		}
		wasKick = false;
	}

	protected override bool ShouldDelayOpen(BasePlayer player, out float delay)
	{
		delay = PushAnimationDelay;
		if (wasKick)
		{
			delay = KickAnimationDelay;
		}
		if (player.GetHeldEntity() != null)
		{
			delay += WeaponAdditiveDelay;
		}
		return delay > 0f;
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	private void ServerKick(RPCMessage msg)
	{
		wasKick = true;
		RPC_OpenDoor(msg);
	}
}
