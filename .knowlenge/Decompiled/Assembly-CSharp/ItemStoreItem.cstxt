using Rust.UI;
using TMPro;
using UnityEngine;

public class ItemStoreItem : MonoBehaviour
{
	public HttpImage Icon;

	public TextMeshProUGUI Name;

	public TextMeshProUGUI Price;

	private IPlayerItemDefinition item;

	internal void Init(IPlayerItemDefinition item)
	{
		this.item = item;
		Icon.Load(item.IconUrl);
		Name.text = item.Name;
		Price.text = item.LocalPriceFormatted;
	}
}
