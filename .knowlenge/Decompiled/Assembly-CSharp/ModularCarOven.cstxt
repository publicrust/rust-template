#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class ModularCarOven : BaseOven
{
	private BaseVehicleModule moduleParent;

	private BaseVehicleModule ModuleParent
	{
		get
		{
			if (moduleParent != null)
			{
				return moduleParent;
			}
			moduleParent = GetParentEntity() as BaseVehicleModule;
			return moduleParent;
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ModularCarOven.OnRpcMessage"))
		{
			if (rpc == 4167839872u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - SVSwitch ");
				}
				using (TimeWarning.New("SVSwitch"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(4167839872u, "SVSwitch", this, player, 3f))
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
							SVSwitch(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SVSwitch");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ResetState()
	{
		base.ResetState();
		moduleParent = null;
	}

	protected override void SVSwitch(RPCMessage msg)
	{
		if (!(ModuleParent == null) && ModuleParent.CanBeLooted(msg.player) && !WaterLevel.Test(base.transform.position, waves: true, volumes: false))
		{
			base.SVSwitch(msg);
		}
	}

	public override bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true)
	{
		if (ModuleParent == null || !ModuleParent.CanBeLooted(player))
		{
			return false;
		}
		return base.PlayerOpenLoot(player, panelToOpen, doPositionChecks);
	}

	protected override void OnCooked()
	{
		base.OnCooked();
		if (WaterLevel.Test(base.transform.position, waves: true, volumes: false))
		{
			StopCooking();
		}
	}
}
