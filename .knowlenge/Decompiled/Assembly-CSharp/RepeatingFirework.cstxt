using System;
using Network;

public class RepeatingFirework : BaseFirework
{
	public float timeBetweenRepeats = 1f;

	public int maxRepeats = 12;

	public SoundPlayer launchSound;

	private int numFired;

	public override void Begin()
	{
		base.Begin();
		((FacepunchBehaviour)this).InvokeRepeating((Action)SendFire, 0f, timeBetweenRepeats);
		((FacepunchBehaviour)this).CancelInvoke((Action)OnExhausted);
	}

	public void SendFire()
	{
		ClientRPC(RpcTarget.NetworkGroup("RPCFire"));
		numFired++;
		if (numFired >= maxRepeats)
		{
			((FacepunchBehaviour)this).CancelInvoke((Action)SendFire);
			numFired = 0;
			OnExhausted();
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("RepeatingFirework.OnRpcMessage", 0);
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
