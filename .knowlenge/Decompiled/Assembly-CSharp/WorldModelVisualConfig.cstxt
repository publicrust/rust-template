using UnityEngine;

public class WorldModelVisualConfig : MonoBehaviour, IClientComponent
{
	public FoodViewModel.FoodVisualConfig VisualConfig;

	public void Init(ItemDefinition itemDef)
	{
		if (VisualConfig != null && !(itemDef == null))
		{
			VisualConfig.InitForItemDef(itemDef);
		}
	}
}
