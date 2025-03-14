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
			arrowModels[iType].SetActive(value: true);
		}
	}

	public void HideAllArrowHeads()
	{
		GameObject[] array = arrowModels;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	public void UpdateAmmoType(ItemDefinition ammoType, bool hidden = false)
	{
		if (hidden)
		{
			wasHidden = hidden;
			HideAllArrowHeads();
		}
		else if (!(curAmmoType == ammoType) || hidden != wasHidden)
		{
			curAmmoType = ammoType;
			wasHidden = hidden;
			if (ammoType == ArrowItemDefinitions.WoodenArrowItemDef)
			{
				HideAllArrowHeads();
			}
			else if (ammoType == ArrowItemDefinitions.BoneArrowItemDef)
			{
				SelectArrowType(0);
			}
			else if (ammoType == ArrowItemDefinitions.FireArrowItemDef)
			{
				SelectArrowType(1);
			}
			else if (ammoType == ArrowItemDefinitions.HvArrowItemDef)
			{
				SelectArrowType(2);
			}
			else if (ammoType == ArrowItemDefinitions.PoisonArrowItemDef)
			{
				SelectArrowType(3);
			}
			else if (ammoType == ArrowItemDefinitions.StoneArrowItemDef)
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
		if (!Rust.Application.isQuitting)
		{
			Cleanup();
		}
	}

	public void OnEnable()
	{
		Cleanup();
	}
}
