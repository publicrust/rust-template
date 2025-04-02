using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class RustigeEgg : BaseCombatEntity
{
	public const Flags Flag_Spin = Flags.Reserved1;

	public Transform eggRotationTransform;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("RustigeEgg.OnRpcMessage", 0);
		try
		{
			if (rpc == 4254195175u && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - RPC_Open "));
				}
				TimeWarning val2 = TimeWarning.New("RPC_Open", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(4254195175u, "RPC_Open", this, player, 3f))
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
							RPC_Open(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in RPC_Open");
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return true;
			}
			if (rpc == 1455840454 && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - RPC_Spin "));
				}
				TimeWarning val2 = TimeWarning.New("RPC_Spin", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.IsVisible.Test(1455840454u, "RPC_Spin", this, player, 3f))
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
							RPCMessage msg3 = rPCMessage;
							RPC_Spin(msg3);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex2)
					{
						Debug.LogException(ex2);
						player.Kick("RPC Error in RPC_Spin");
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

	public bool IsSpinning()
	{
		return HasFlag(Flags.Reserved1);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RPC_Spin(RPCMessage msg)
	{
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RPC_Open(RPCMessage msg)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)msg.player == (Object)null)
		{
			return;
		}
		bool flag = msg.read.Bit();
		if (flag != IsOpen())
		{
			if (flag)
			{
				ClientRPC<Vector3>(RpcTarget.NetworkGroup("FaceEggPosition"), msg.player.eyes.position);
				((FacepunchBehaviour)this).Invoke((Action)CloseEgg, 60f);
			}
			else
			{
				((FacepunchBehaviour)this).CancelInvoke((Action)CloseEgg);
			}
			SetFlag(Flags.Open, flag, recursive: false, networkupdate: false);
			if (IsSpinning() && flag)
			{
				SetFlag(Flags.Reserved1, b: false, recursive: false, networkupdate: false);
			}
			SendNetworkUpdateImmediate();
		}
	}

	public void CloseEgg()
	{
		SetFlag(Flags.Open, b: false);
	}
}
