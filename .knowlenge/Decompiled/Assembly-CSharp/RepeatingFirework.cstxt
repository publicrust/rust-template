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
		InvokeRepeating(SendFire, 0f, timeBetweenRepeats);
		CancelInvoke(OnExhausted);
	}

	public void SendFire()
	{
		ClientRPC(RpcTarget.NetworkGroup("RPCFire"));
		numFired++;
		if (numFired >= maxRepeats)
		{
			CancelInvoke(SendFire);
			numFired = 0;
			OnExhausted();
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("RepeatingFirework.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}
}
