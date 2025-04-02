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
		using (TimeWarning.New("BigWheelBettingTerminal.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public bool IsPlayerValid(BasePlayer player)
	{
		if (!player.isMounted || !(player.GetMounted() is BaseChair))
		{
			return false;
		}
		Vector3 b = base.transform.TransformPoint(seatedPlayerOffset);
		if (Vector3Ex.Distance2D(player.transform.position, b) > offsetCheckRadius)
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
		if (base.isClient)
		{
			return false;
		}
		if (bigWheel != null && bigWheel != newWheel)
		{
			float num = Vector3.SqrMagnitude(bigWheel.transform.position - base.transform.position);
			if (Vector3.SqrMagnitude(newWheel.transform.position - base.transform.position) >= num)
			{
				return false;
			}
			bigWheel.RemoveTerminal(this);
		}
		bigWheel = newWheel;
		return true;
	}
}
