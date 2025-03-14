using System;
using Rust.UI;
using TMPro;
using UnityEngine;

public class ItemStoreItemInfoModal : MonoBehaviour
{
	public HttpImage Icon;

	public TextMeshProUGUI Name;

	public TextMeshProUGUI Price;

	public TextMeshProUGUI Description;

	private IPlayerItemDefinition item;

	public void Show(IPlayerItemDefinition item)
	{
		this.item = item;
		Icon.Load(item.IconUrl);
		Name.text = item.Name;
		Description.text = item.Description.BBCodeToUnity();
		Price.text = item.LocalPriceFormatted;
		base.gameObject.SetActive(value: true);
		GetComponent<CanvasGroup>().alpha = 0f;
		LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 1f, 0.1f);
	}

	public void Hide()
	{
		LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0f, 0.2f).setOnComplete((Action)delegate
		{
			base.gameObject.SetActive(value: false);
		});
	}
}
