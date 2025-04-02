using System;
using Rust.UI;
using UnityEngine;

public class ItemStoreBuySuccessModal : MonoBehaviour
{
	public void Show(ulong orderId)
	{
		((Component)this).gameObject.SetActive(true);
		((Component)this).GetComponent<CanvasGroup>().alpha = 0f;
		LeanTween.alphaCanvas(((Component)this).GetComponent<CanvasGroup>(), 1f, 0.1f);
		_ = (Object)(object)SingletonComponent<SteamInventoryManager>.Instance != (Object)null;
	}

	public void Hide()
	{
		LeanTween.alphaCanvas(((Component)this).GetComponent<CanvasGroup>(), 0f, 0.2f).setOnComplete((Action)delegate
		{
			((Component)this).gameObject.SetActive(false);
		});
	}
}
