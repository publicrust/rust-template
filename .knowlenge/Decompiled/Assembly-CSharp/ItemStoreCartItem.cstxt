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
		((TMP_Text)Name).text = def.Name;
		((TMP_Text)Price).text = def.LocalPriceFormatted;
	}
}
