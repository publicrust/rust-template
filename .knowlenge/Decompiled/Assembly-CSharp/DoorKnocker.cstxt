using Network;
using Oxide.Core;
using UnityEngine;

public class DoorKnocker : BaseCombatEntity
{
	public Animator knocker1;

	public Animator knocker2;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("DoorKnocker.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public void Knock(BasePlayer player)
	{
		ClientRPC(RpcTarget.NetworkGroup("ClientKnock"), player.transform.position);
		Interface.CallHook("OnDoorKnocked", this, player);
	}
}
