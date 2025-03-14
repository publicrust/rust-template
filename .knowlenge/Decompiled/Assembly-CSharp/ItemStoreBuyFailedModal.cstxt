using System;
using UnityEngine;

public class ItemStoreBuyFailedModal : MonoBehaviour
{
	public void Show(ulong orderid)
	{
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
