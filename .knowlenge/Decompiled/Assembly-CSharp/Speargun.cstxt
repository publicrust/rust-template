using UnityEngine;

public class Speargun : CrossbowWeapon
{
	public GameObject worldAmmoModel;

	public override bool ForceSendMagazine(SaveInfo saveInfo)
	{
		return true;
	}

	protected override bool VerifyClientAttack(BasePlayer player)
	{
		if (player.WaterFactor() < 1f)
		{
			return false;
		}
		return base.VerifyClientAttack(player);
	}

	public override bool CanBeUsedInWater()
	{
		return true;
	}
}
