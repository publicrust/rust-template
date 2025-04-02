public class CrossbowWeapon : BaseProjectile
{
	public override bool ForceSendMagazine(SaveInfo saveInfo)
	{
		return true;
	}

	public override void DidAttackServerside()
	{
		SendNetworkUpdateImmediate();
	}
}
