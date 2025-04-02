using Network;

public class Flashbang : TimedExplosive
{
	public SoundDefinition deafLoopDef;

	public float flashReductionPerSecond = 1f;

	public float flashToAdd = 3f;

	public float flashMinRange = 5f;

	public float flashMaxRange = 10f;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("Flashbang.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void Explode()
	{
		ClientRPC(RpcTarget.NetworkGroup("Client_DoFlash"), base.transform.position);
		base.Explode();
	}

	public void DelayedDestroy()
	{
		Kill(DestroyMode.Gib);
	}
}
