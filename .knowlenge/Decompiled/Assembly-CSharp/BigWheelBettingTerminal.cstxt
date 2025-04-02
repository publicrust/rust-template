using System;
using Network;
using UnityEngine;

public class BigWheelBettingTerminal : StorageContainer
{
	public BigWheelGame bigWheel;

	public Vector3 seatedPlayerOffset = Vector3.forward;

	public float offsetCheckRadius = 0.4f;

	public SoundDefinition winSound;

	public SoundDefinition loseSound;

	[NonSerialized]
	public BasePlayer lastPlayer;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("BigWheelBettingTerminal.OnRpcMessage", 0);
		try
		{
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool IsPlayerValid(BasePlayer player)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (!player.isMounted || !(player.GetMounted() is BaseChair))
		{
			return false;
		}
		Vector3 val = ((Component)this).transform.TransformPoint(seatedPlayerOffset);
		if (Vector3Ex.Distance2D(((Component)player).transform.position, val) > offsetCheckRadius)
		{
			return false;
		}
		return true;
	}

	public override bool PlayerOpenLoot(BasePlayer player, string panelToOpen = "", bool doPositionChecks = true)
	{
		if (!IsPlayerValid(player))
		{
			return false;
		}
		bool num = base.PlayerOpenLoot(player, panelToOpen);
		if (num)
		{
			lastPlayer = player;
		}
		return num;
	}

	public bool TrySetBigWheel(BigWheelGame newWheel)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (base.isClient)
		{
			return false;
		}
		if ((Object)(object)bigWheel != (Object)null && (Object)(object)bigWheel != (Object)(object)newWheel)
		{
			float num = Vector3.SqrMagnitude(((Component)bigWheel).transform.position - ((Component)this).transform.position);
			if (Vector3.SqrMagnitude(((Component)newWheel).transform.position - ((Component)this).transform.position) >= num)
			{
				return false;
			}
			bigWheel.RemoveTerminal(this);
		}
		bigWheel = newWheel;
		return true;
	}
}
