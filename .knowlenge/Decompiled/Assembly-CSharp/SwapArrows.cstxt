using System;
using Rust;
using UnityEngine;

public class SwapArrows : MonoBehaviour, IClientComponent
{
	public enum ArrowType
	{
		One,
		Two,
		Three,
		Four
	}

	public GameObject[] arrowModels;

	[NonSerialized]
	private ItemDefinition curAmmoType;

	private bool wasHidden;

	public ItemDefinition CurrentAmmoType
	{
		get
		{
			return curAmmoType;
		}
		set
		{
			curAmmoType = value;
		}
	}

	public bool WasHidden
	{
		get
		{
			return wasHidden;
		}
		set
		{
			wasHidden = value;
		}
	}

	public void SelectArrowType(int iType)
	{
		HideAllArrowHeads();
		if (iType < arrowModels.Length)
		{
			arrowModels[iType].SetActive(true);
		}
	}

	public void HideAllArrowHeads()
	{
		GameObject[] array = arrowModels;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
	}

	public void UpdateAmmoType(ItemDefinition ammoType, bool hidden = false)
	{
		if (hidden)
		{
			wasHidden = hidden;
			HideAllArrowHeads();
		}
		else if (!((Object)(object)curAmmoType == (Object)(object)ammoType) || hidden != wasHidden)
		{
			curAmmoType = ammoType;
			wasHidden = hidden;
			if ((Object)(object)ammoType == (Object)(object)ArrowItemDefinitions.WoodenArrowItemDef)
			{
				HideAllArrowHeads();
			}
			else if ((Object)(object)ammoType == (Object)(object)ArrowItemDefinitions.BoneArrowItemDef)
			{
				SelectArrowType(0);
			}
			else if ((Object)(object)ammoType == (Object)(object)ArrowItemDefinitions.FireArrowItemDef)
			{
				SelectArrowType(1);
			}
			else if ((Object)(object)ammoType == (Object)(object)ArrowItemDefinitions.HvArrowItemDef)
			{
				SelectArrowType(2);
			}
			else if ((Object)(object)ammoType == (Object)(object)ArrowItemDefinitions.PoisonArrowItemDef)
			{
				SelectArrowType(3);
			}
			else if ((Object)(object)ammoType == (Object)(object)ArrowItemDefinitions.StoneArrowItemDef)
			{
				SelectArrowType(4);
			}
			else
			{
				HideAllArrowHeads();
			}
		}
	}

	private void Cleanup()
	{
		HideAllArrowHeads();
		curAmmoType = null;
	}

	public void OnDisable()
	{
		if (!Application.isQuitting)
		{
			Cleanup();
		}
	}

	public void OnEnable()
	{
		Cleanup();
	}
}
