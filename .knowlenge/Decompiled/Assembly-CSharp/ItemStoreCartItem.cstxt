using TMPro;
using UnityEngine;

public class ItemStoreCartItem : MonoBehaviour
{
	public int Index;

	public TextMeshProUGUI Name;

	public TextMeshProUGUI Price;

	public void Init(int index, IPlayerItemDefinition def)
	{
		Index = index;
		Name.text = def.Name;
		Price.text = def.LocalPriceFormatted;
	}
}
