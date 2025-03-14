#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class RHIB : MotorRowboat
{
	public Transform steeringWheelLeftHandTarget;

	public Transform steeringWheelRightHandTarget;

	[ServerVar(Help = "Population active on the server", ShowInAdminUI = true)]
	public static float rhibpopulation;

	private float targetGasPedal;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("RHIB.OnRpcMessage"))
		{
			if (rpc == 1382282393 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - Server_Release ");
				}
				using (TimeWarning.New("Server_Release"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1382282393u, "Server_Release", this, player, 6f))
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
							Server_Release(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in Server_Release");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	[RPC_Server]
	[RPC_Server.IsVisible(6f)]
	public void Server_Release(RPCMessage msg)
	{
		if (!(GetParentEntity() == null))
		{
			SetParent(null, worldPositionStays: true, sendImmediate: true);
			SetToNonKinematic();
		}
	}

	public override void VehicleFixedUpdate()
	{
		using (TimeWarning.New("RHIB.VehicleFixedUpdate"))
		{
			gasPedal = Mathf.MoveTowards(gasPedal, targetGasPedal, UnityEngine.Time.fixedDeltaTime * 1f);
			base.VehicleFixedUpdate();
		}
	}

	public override bool EngineOn()
	{
		return base.EngineOn();
	}

	public override void DriverInput(InputState inputState, BasePlayer player)
	{
		base.DriverInput(inputState, player);
		if (inputState.IsDown(BUTTON.FORWARD))
		{
			targetGasPedal = 1f;
		}
		else if (inputState.IsDown(BUTTON.BACKWARD))
		{
			targetGasPedal = -0.5f;
		}
		else
		{
			targetGasPedal = 0f;
		}
		if (inputState.IsDown(BUTTON.LEFT))
		{
			steering = 1f;
		}
		else if (inputState.IsDown(BUTTON.RIGHT))
		{
			steering = -1f;
		}
		else
		{
			steering = 0f;
		}
	}

	public void AddFuel(int amount)
	{
		fuelSystem.AddFuel(amount);
	}
}
