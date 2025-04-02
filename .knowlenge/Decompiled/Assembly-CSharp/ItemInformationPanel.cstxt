using UnityEngine;

public class ItemInformationPanel : MonoBehaviour
{
	public bool ForceHidden(ItemDefinition info)
	{
		if (info == null)
		{
			return false;
		}
		return info.GetComponent<ItemModHideInfoPanel>() != null;
	}

	public virtual bool EligableForDisplay(ItemDefinition info)
	{
		return false;
	}

	public virtual void SetupForItem(ItemDefinition info, Item item = null)
	{
	}
}
