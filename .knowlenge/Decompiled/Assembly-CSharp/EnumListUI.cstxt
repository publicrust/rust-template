using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnumListUI : MonoBehaviour
{
	public Transform PrefabItem;

	public Transform Container;

	private Action<object> clickedAction;

	private CanvasScaler canvasScaler;

	private void Awake()
	{
		Hide();
	}

	public void Show(List<object> values, Action<object> clicked)
	{
		base.gameObject.SetActive(value: true);
		clickedAction = clicked;
		foreach (Transform item in Container)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		foreach (object value in values)
		{
			Transform obj = UnityEngine.Object.Instantiate(PrefabItem);
			obj.SetParent(Container, worldPositionStays: false);
			obj.GetComponent<EnumListItemUI>().Init(value, value.ToString(), this);
		}
	}

	public void ItemClicked(object value)
	{
		clickedAction?.Invoke(value);
		Hide();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
