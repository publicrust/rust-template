#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class WheelSwitch : IOEntity
{
	public Transform wheelObj;

	public float rotateSpeed = 90f;

	public Flags BeingRotated = Flags.Reserved1;

	public Flags RotatingLeft = Flags.Reserved2;

	public Flags RotatingRight = Flags.Reserved3;

	public float rotateProgress;

	public Animator animator;

	public float kineticEnergyPerSec = 1f;

	private BasePlayer rotatorPlayer;

	private float progressTickRate = 0.1f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("WheelSwitch.OnRpcMessage"))
		{
			if (rpc == 2223603322u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - BeginRotate ");
				}
				using (TimeWarning.New("BeginRotate"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(2223603322u, "BeginRotate", this, player, 3f))
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
							BeginRotate(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in BeginRotate");
					}
				}
				return true;
			}
			if (rpc == 434251040 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - CancelRotate ");
				}
				using (TimeWarning.New("CancelRotate"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(434251040u, "CancelRotate", this, player, 3f))
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
							CancelRotate(msg3);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						player.Kick("RPC Error in CancelRotate");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ResetIOState()
	{
		CancelPlayerRotation();
	}

	[RPC_Server.IsVisible(3f)]
	[RPC_Server]
	public void BeginRotate(RPCMessage msg)
	{
		if (!IsBeingRotated())
		{
			SetFlag(BeingRotated, b: true);
			rotatorPlayer = msg.player;
			InvokeRepeating(RotateProgress, 0f, progressTickRate);
		}
	}

	public void CancelPlayerRotation()
	{
		CancelInvoke(RotateProgress);
		SetFlag(BeingRotated, b: false);
		IOSlot[] array = outputs;
		foreach (IOSlot iOSlot in array)
		{
			if (iOSlot.connectedTo.Get() != null)
			{
				iOSlot.connectedTo.Get().IOInput(this, ioType, 0f, iOSlot.connectedToSlot);
			}
		}
		rotatorPlayer = null;
	}

	public void RotateProgress()
	{
		if (!rotatorPlayer || rotatorPlayer.IsDead() || rotatorPlayer.IsSleeping() || Vector3Ex.Distance2D(rotatorPlayer.transform.position, base.transform.position) > 2f)
		{
			CancelPlayerRotation();
			return;
		}
		float num = kineticEnergyPerSec * progressTickRate;
		IOSlot[] array = outputs;
		foreach (IOSlot iOSlot in array)
		{
			if (iOSlot.connectedTo.Get() != null)
			{
				num = iOSlot.connectedTo.Get().IOInput(this, ioType, num, iOSlot.connectedToSlot);
			}
		}
		if (num == 0f)
		{
			SetRotateProgress(rotateProgress + 0.1f);
		}
		SendNetworkUpdate();
	}

	public void SetRotateProgress(float newValue)
	{
		float num = rotateProgress;
		rotateProgress = newValue;
		SetFlag(Flags.Reserved4, num != newValue);
		SendNetworkUpdate();
		CancelInvoke(StoppedRotatingCheck);
		Invoke(StoppedRotatingCheck, 0.25f);
	}

	public void StoppedRotatingCheck()
	{
		SetFlag(Flags.Reserved4, b: false);
	}

	[RPC_Server.IsVisible(3f)]
	[RPC_Server]
	public void CancelRotate(RPCMessage msg)
	{
		CancelPlayerRotation();
	}

	public void Powered()
	{
		float inputAmount = kineticEnergyPerSec * progressTickRate;
		IOSlot[] array = outputs;
		foreach (IOSlot iOSlot in array)
		{
			if (iOSlot.connectedTo.Get() != null)
			{
				inputAmount = iOSlot.connectedTo.Get().IOInput(this, ioType, inputAmount, iOSlot.connectedToSlot);
			}
		}
		SetRotateProgress(rotateProgress + 0.1f);
	}

	public override float IOInput(IOEntity from, IOType inputType, float inputAmount, int slot = 0)
	{
		if (inputAmount < 0f)
		{
			SetRotateProgress(rotateProgress + inputAmount);
			SendNetworkUpdate();
		}
		if (inputType == IOType.Electric && slot == 1)
		{
			if (inputAmount == 0f)
			{
				CancelInvoke(Powered);
			}
			else
			{
				InvokeRepeating(Powered, 0f, progressTickRate);
			}
		}
		return Mathf.Clamp(inputAmount - 1f, 0f, inputAmount);
	}

	public bool IsBeingRotated()
	{
		return HasFlag(BeingRotated);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.sphereEntity != null)
		{
			rotateProgress = info.msg.sphereEntity.radius;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.sphereEntity = Facepunch.Pool.Get<ProtoBuf.SphereEntity>();
		info.msg.sphereEntity.radius = rotateProgress;
	}
}
