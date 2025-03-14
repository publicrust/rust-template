using System;
using UnityEngine;
using UnityEngine.UI;

public class TabToggle : MonoBehaviour
{
	public Transform TabHolder;

	public Transform ContentHolder;

	public bool FadeIn;

	public bool FadeOut;

	public void Awake()
	{
		if (!TabHolder)
		{
			return;
		}
		for (int i = 0; i < TabHolder.childCount; i++)
		{
			Button c = TabHolder.GetChild(i).GetComponent<Button>();
			if ((bool)c)
			{
				c.onClick.AddListener(delegate
				{
					SwitchTo(c);
				});
			}
		}
	}

	public void SwitchTo(Button sourceTab)
	{
		string text = sourceTab.transform.name;
		if ((bool)TabHolder)
		{
			for (int i = 0; i < TabHolder.childCount; i++)
			{
				Button component = TabHolder.GetChild(i).GetComponent<Button>();
				if ((bool)component)
				{
					component.interactable = component.name != text;
				}
			}
		}
		if (!ContentHolder)
		{
			return;
		}
		for (int j = 0; j < ContentHolder.childCount; j++)
		{
			Transform child = ContentHolder.GetChild(j);
			if (child.name == text)
			{
				Show(child.gameObject);
			}
			else
			{
				Hide(child.gameObject);
			}
		}
	}

	private void Hide(GameObject go)
	{
		if (!go.activeSelf)
		{
			return;
		}
		if (FadeOut && go.TryGetComponent<CanvasGroup>(out var component))
		{
			LeanTween.alphaCanvas(component, 0f, 0.1f).setOnComplete((Action)delegate
			{
				go.SetActive(value: false);
			});
		}
		else
		{
			go.SetActive(value: false);
		}
	}

	private void Show(GameObject go)
	{
		if (!go.activeSelf)
		{
			if (FadeIn && go.TryGetComponent<CanvasGroup>(out var component))
			{
				component.alpha = 0f;
				LeanTween.alphaCanvas(component, 1f, 0.1f);
			}
			go.SetActive(value: true);
		}
	}
}
