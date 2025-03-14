using System;
using UnityEngine;

public class SwapRPG : MonoBehaviour
{
	public enum RPGType
	{
		One,
		Two,
		Three,
		Four
	}

	public GameObject[] rpgModels;

	[NonSerialized]
	private string curAmmoType = "";

	public void SelectRPGType(int iType)
	{
		GameObject[] array = rpgModels;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		rpgModels[iType].SetActive(value: true);
	}

	public void UpdateAmmoType(ItemDefinition ammoType)
	{
		if (!(curAmmoType == ammoType.shortname))
		{
			curAmmoType = ammoType.shortname;
			switch (curAmmoType)
			{
			default:
				SelectRPGType(0);
				break;
			case "ammo.rocket.fire":
				SelectRPGType(1);
				break;
			case "ammo.rocket.hv":
				SelectRPGType(2);
				break;
			case "ammo.rocket.smoke":
				SelectRPGType(3);
				break;
			}
		}
	}

	private void Start()
	{
	}
}
