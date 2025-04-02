using System.Collections.Generic;
using Rust;
using UnityEngine;

public class MultiSwapArrows : MonoBehaviour, IClientComponent
{
	public List<SwapArrows> arrowSlots;

	public void UpdateAmmoType(ItemDefinition ammoType, bool hidden = false, int? slotIndex = null)
	{
		if (slotIndex.HasValue)
		{
			int value = slotIndex.Value;
			if (value >= 0 && value < arrowSlots.Count)
			{
				if ((Object)(object)arrowSlots[value] != (Object)null)
				{
					arrowSlots[value].UpdateAmmoType(ammoType, hidden);
				}
			}
			else
			{
				Debug.Log((object)"Error in MultiSwapArrows: Slot index out of range");
			}
			return;
		}
		int num = 0;
		foreach (SwapArrows arrowSlot in arrowSlots)
		{
			if ((Object)(object)arrowSlot != (Object)null)
			{
				arrowSlot.UpdateAmmoType(ammoType, hidden);
			}
			num++;
		}
	}

	private void Cleanup()
	{
		foreach (SwapArrows arrowSlot in arrowSlots)
		{
			if ((Object)(object)arrowSlot != (Object)null)
			{
				arrowSlot.HideAllArrowHeads();
			}
		}
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
