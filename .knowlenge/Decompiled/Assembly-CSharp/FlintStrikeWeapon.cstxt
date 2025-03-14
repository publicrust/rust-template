using UnityEngine;

public class FlintStrikeWeapon : BaseProjectile
{
	public float successFraction = 0.5f;

	[Tooltip("By how much do we increase the chance of firing after each failed strike")]
	public float successIncrease = 0.075f;

	public RecoilProperties strikeRecoil;

	public override RecoilProperties GetRecoil()
	{
		return strikeRecoil;
	}
}
