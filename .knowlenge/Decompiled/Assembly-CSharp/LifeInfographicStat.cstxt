using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeInfographicStat : MonoBehaviour
{
	public enum DataType
	{
		None,
		AliveTime_Short,
		SleepingTime_Short,
		KillerName,
		KillerWeapon,
		AliveTime_Long,
		KillerDistance,
		GenericStat,
		DistanceTravelledWalk,
		DistanceTravelledRun,
		DamageTaken,
		DamageHealed,
		WeaponInfo,
		SecondsWilderness,
		SecondsSwimming,
		SecondsInBase,
		SecondsInMonument,
		SecondsFlying,
		SecondsBoating,
		PlayersKilled,
		ScientistsKilled,
		AnimalsKilled,
		SecondsDriving
	}

	public enum WeaponInfoType
	{
		TotalShots,
		ShotsHit,
		ShotsMissed,
		AccuracyPercentage
	}

	public DataType dataSource;

	[Header("Generic Stats")]
	public string genericStatKey;

	[Header("Weapon Info")]
	public string targetWeaponName;

	public WeaponInfoType weaponInfoType;

	public TextMeshProUGUI targetText;

	public Image StatImage;
}
