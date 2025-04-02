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
		TimeWarning val = TimeWarning.New("GestureDoor.OnRpcMessage", 0);
		try
		{
			if (rpc == 872065295 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - ServerKick "));
				}
				TimeWarning val2 = TimeWarning.New("ServerKick", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.MaxDistance.Test(872065295u, "ServerKick", this, player, 3f))
						{
							return true;
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					try
					{
						val3 = TimeWarning.New("Call", 0);
						try
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							ServerKick(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in ServerKick");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
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
		if ((Object)(object)player.GetHeldEntity() != (Object)null)
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
