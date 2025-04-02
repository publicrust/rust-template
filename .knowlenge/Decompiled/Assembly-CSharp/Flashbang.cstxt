using System;
using Network;
using UnityEngine;

public class Flashbang : TimedExplosive
{
	public SoundDefinition deafLoopDef;

	public float flashReductionPerSecond = 1f;

	public float flashToAdd = 3f;

	public float flashMinRange = 5f;

	public float flashMaxRange = 10f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("Flashbang.OnRpcMessage", 0);
		try
		{
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void Explode()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		ClientRPC<Vector3>(RpcTarget.NetworkGroup("Client_DoFlash"), ((Component)this).transform.position);
		base.Explode();
	}

	public void DelayedDestroy()
	{
		Kill(DestroyMode.Gib);
	}
}
