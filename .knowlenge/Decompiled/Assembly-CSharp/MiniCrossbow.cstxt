using System.Collections.Generic;

public class MiniCrossbow : BaseProjectile
{
	public List<LODGroupRenderers> ArrowRenderers;

	public override bool ForceSendMagazine(SaveInfo saveInfo)
	{
		return true;
	}

	public override void DidAttackServerside()
	{
		base.DidAttackServerside();
		SendNetworkUpdateImmediate();
	}
}
