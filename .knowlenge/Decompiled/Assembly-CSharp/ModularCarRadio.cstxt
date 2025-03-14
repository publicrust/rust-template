#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class ModularCarRadio : BaseCombatEntity
{
	public BoomBox CarRadio;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ModularCarRadio.OnRpcMessage"))
		{
			if (rpc == 1918716764 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_UpdateRadioIP ");
				}
				using (TimeWarning.New("Server_UpdateRadioIP"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(1918716764u, "Server_UpdateRadioIP", this, player, 2uL))
						{
							return true;
						}
						if (!RPC_Server.IsVisible.Test(1918716764u, "Server_UpdateRadioIP", this, player, 3f))
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
							Server_UpdateRadioIP(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Server_UpdateRadioIP");
					}
				}
				return true;
			}
			if (rpc == 1785864031 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - ServerTogglePlay ");
				}
				using (TimeWarning.New("ServerTogglePlay"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1785864031u, "ServerTogglePlay", this, player, 3f))
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
							RPCMessage msg3 = rPCMessage;
							ServerTogglePlay(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in ServerTogglePlay");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
	}

	public void TryForceOff()
	{
		if (CarRadio != null)
		{
			CarRadio.ServerTogglePlay(play: false);
		}
	}

	public BaseVehicleModule GetParentModule()
	{
		BaseEntity baseEntity = GetParentEntity();
		if (baseEntity != null && baseEntity is BaseVehicleModule result)
		{
			return result;
		}
		return null;
	}

	public ModularCar GetParentCar()
	{
		BaseVehicleModule parentModule = GetParentModule();
		if (parentModule != null && parentModule.Vehicle is ModularCar result)
		{
			return result;
		}
		return null;
	}

	private bool CanPickupRadio(BasePlayer player)
	{
		ModularCar parentCar = GetParentCar();
		if (parentCar != null)
		{
			return parentCar.PlayerHasUnlockPermission(player);
		}
		return false;
	}

	public override bool CanPickup(BasePlayer player)
	{
		if (base.CanPickup(player))
		{
			return CanPickupRadio(player);
		}
		return false;
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void ServerTogglePlay(RPCMessage msg)
	{
		CarRadio.ServerTogglePlay(msg, bypassPower: true);
	}

	[RPC_Server]
	[RPC_Server.CallsPerSecond(2uL)]
	[RPC_Server.IsVisible(3f)]
	private void Server_UpdateRadioIP(RPCMessage msg)
	{
		CarRadio.Server_UpdateRadioIP(msg);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		CarRadio.Save(info);
	}

	public override void Load(LoadInfo info)
	{
		CarRadio.Load(info);
		base.Load(info);
	}
}
