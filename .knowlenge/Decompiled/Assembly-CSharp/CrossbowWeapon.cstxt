public class CrossbowWeapon : BaseProjectile
{
	public override bool ForceSendMagazine()
	{
		return true;
	}

	public override void DidAttackServerside()
	{
		SendNetworkUpdateImmediate();
	}
}
