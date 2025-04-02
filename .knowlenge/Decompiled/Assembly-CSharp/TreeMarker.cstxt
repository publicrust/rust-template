using System;
using Network;
using UnityEngine;

public class TreeMarker : BaseEntity
{
	public GameObjectRef hitEffect;

	public SoundDefinition hitEffectSound;

	public GameObjectRef spawnEffect;

	private Vector3 initialPosition;

	public bool SpherecastOnInit = true;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("TreeMarker.OnRpcMessage", 0);
		try
		{
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return base.OnRpcMessage(player, rpc, msg);
	}
}
