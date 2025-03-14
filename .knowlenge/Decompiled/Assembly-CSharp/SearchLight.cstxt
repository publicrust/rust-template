#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class SearchLight : IOEntity
{
	public static class SearchLightFlags
	{
		public const Flags PlayerUsing = Flags.Reserved5;
	}

	public GameObject pitchObject;

	public GameObject yawObject;

	public GameObject eyePoint;

	public SoundPlayer turnLoop;

	public bool needsBuildingPrivilegeToUse = true;

	public Vector3 aimDir = Vector3.zero;

	public BasePlayer mountedPlayer;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("SearchLight.OnRpcMessage"))
		{
			if (rpc == 3611615802u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_UseLight "));
				}
				using (TimeWarning.New("RPC_UseLight"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.MaxDistance.Test(3611615802u, "RPC_UseLight", this, player, 3f))
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
							RPC_UseLight(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_UseLight");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ResetState()
	{
		aimDir = Vector3.zero;
	}

	public override int ConsumptionAmount()
	{
		return 10;
	}

	public bool IsMounted()
	{
		return mountedPlayer != null;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.autoturret = Facepunch.Pool.Get<ProtoBuf.AutoTurret>();
		info.msg.autoturret.aimDir = aimDir;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.autoturret != null)
		{
			aimDir = info.msg.autoturret.aimDir;
		}
	}

	public void PlayerEnter(BasePlayer player)
	{
		if (!IsMounted() || !(player != mountedPlayer))
		{
			PlayerExit();
			if (player != null)
			{
				mountedPlayer = player;
				SetFlag(Flags.Reserved5, b: true);
			}
		}
	}

	public void PlayerExit()
	{
		if ((bool)mountedPlayer)
		{
			mountedPlayer = null;
		}
		SetFlag(Flags.Reserved5, b: false);
	}

	public void MountedUpdate()
	{
		if (mountedPlayer == null || mountedPlayer.IsSleeping() || !mountedPlayer.IsAlive() || mountedPlayer.IsWounded() || Vector3.Distance(mountedPlayer.transform.position, base.transform.position) > 2f)
		{
			PlayerExit();
			return;
		}
		Vector3 targetAimpoint = eyePoint.transform.position + mountedPlayer.eyes.BodyForward() * 100f;
		SetTargetAimpoint(targetAimpoint);
		SendNetworkUpdate();
	}

	public void SetTargetAimpoint(Vector3 worldPos)
	{
		aimDir = (worldPos - eyePoint.transform.position).normalized;
	}

	public override int GetCurrentEnergy()
	{
		if (currentEnergy >= ConsumptionAmount())
		{
			return base.GetCurrentEnergy();
		}
		return Mathf.Clamp(currentEnergy - base.ConsumptionAmount(), 0, currentEnergy);
	}

	[RPC_Server]
	[RPC_Server.MaxDistance(3f)]
	public void RPC_UseLight(RPCMessage msg)
	{
		BasePlayer player = msg.player;
		bool flag = msg.read.Bit();
		if ((!flag || !IsMounted()) && (!needsBuildingPrivilegeToUse || msg.player.CanBuild()))
		{
			if (flag)
			{
				PlayerEnter(player);
			}
			else
			{
				PlayerExit();
			}
		}
	}

	public override void OnKilled(HitInfo info)
	{
		SetFlag(Flags.On, b: false);
		base.OnKilled(info);
	}

	public void Update()
	{
		if (base.isServer && IsMounted())
		{
			MountedUpdate();
		}
	}
}
