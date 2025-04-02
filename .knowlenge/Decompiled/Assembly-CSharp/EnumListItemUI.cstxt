using Rust.UI;
using TMPro;
using UnityEngine;

public class EnumListItemUI : MonoBehaviour
{
	public object Value;

	public RustText TextValue;

	private EnumListUI list;

	public void Init(object value, string valueText, EnumListUI list)
	{
		Value = value;
		this.list = list;
		((TMP_Text)TextValue).text = valueText;
	}

	public void Clicked()
	{
		list.ItemClicked(Value);
	}
}
