#define UNITY_ASSERTIONS
using System;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class BowWeapon : BaseProjectile
{
	private Action _updateFireFlagAction;

	private Action UpdateFireFlagAction => UpdateFireFlag;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("BowWeapon.OnRpcMessage"))
		{
			if (rpc == 4228048190u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - BowReload ");
				}
				using (TimeWarning.New("BowReload"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsActiveItem.Test(4228048190u, "BowReload", this, player))
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
							BowReload(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in BowReload");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void OnHeldChanged()
	{
		using (TimeWarning.New("BowWeapon.OnHeldChanged"))
		{
			base.OnHeldChanged();
			if (!base.isServer)
			{
				return;
			}
			if (IsDeployed())
			{
				InvokeRepeating(UpdateFireFlagAction, 0.1f, 0.1f);
				return;
			}
			CancelInvoke(UpdateFireFlagAction);
			if (IsOnFire())
			{
				SetFlag(Flags.OnFire, b: false);
			}
		}
	}

	private void UpdateFireFlag()
	{
		using (TimeWarning.New("BowWeapon.UpdateFireFlag"))
		{
			BasePlayer ownerPlayer = GetOwnerPlayer();
			if (!IsOnFire() && ownerPlayer.modelState.aiming && primaryMagazine.ammoType == ArrowItemDefinitions.FireArrowItemDef)
			{
				SetFlag(Flags.OnFire, b: true);
			}
			else if (IsOnFire() && (!ownerPlayer.modelState.aiming || primaryMagazine.ammoType != ArrowItemDefinitions.FireArrowItemDef))
			{
				SetFlag(Flags.OnFire, b: false);
			}
			if (IsOnFire())
			{
				SingletonComponent<NpcFireManager>.Instance.Move(this);
			}
		}
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	private void BowReload(RPCMessage msg)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (ownerPlayer != null)
		{
			TryReloadMagazine(ownerPlayer.inventory);
		}
	}

	public override bool ForceSendMagazine(SaveInfo saveInfo)
	{
		return true;
	}
}
