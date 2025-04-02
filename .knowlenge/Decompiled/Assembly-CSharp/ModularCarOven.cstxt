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
			if ((Object)(object)moduleParent != (Object)null)
			{
				return moduleParent;
			}
			moduleParent = GetParentEntity() as BaseVehicleModule;
			return moduleParent;
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("ModularCarOven.OnRpcMessage", 0);
		try
		{
			if (rpc == 4167839872u && (Object)(object)player != (Object)null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log((object)("SV_RPCMessage: " + ((object)player)?.ToString() + " - SVSwitch "));
				}
				TimeWarning val2 = TimeWarning.New("SVSwitch", 0);
				try
				{
					TimeWarning val3 = TimeWarning.New("Conditions", 0);
					try
					{
						if (!RPC_Server.MaxDistance.Test(4167839872u, "SVSwitch", this, player, 3f))
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
							SVSwitch(msg2);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
						player.Kick("RPC Error in SVSwitch");
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

	public override void ResetState()
	{
		base.ResetState();
		moduleParent = null;
	}

	protected override void SVSwitch(RPCMessage msg)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)ModuleParent == (Object)null) && ModuleParent.CanBeLooted(msg.player) && !WaterLevel.Test(((Component)this).transform.position, waves: true, volumes: false))
		{
			base.SVSwitch(msg);
		}
	}

	public override bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true)
	{
		if ((Object)(object)ModuleParent == (Object)null || !ModuleParent.CanBeLooted(player))
		{
			return false;
		}
		return base.PlayerOpenLoot(player, panelToOpen, doPositionChecks);
	}

	protected override void OnCooked()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		base.OnCooked();
		if (WaterLevel.Test(((Component)this).transform.position, waves: true, volumes: false))
		{
			StopCooking();
		}
	}
}
