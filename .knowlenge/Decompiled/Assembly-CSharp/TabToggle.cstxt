using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabToggle : MonoBehaviour
{
	public Transform TabHolder;

	public Transform ContentHolder;

	public bool FadeIn;

	public bool FadeOut;

	public void Awake()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		if (!Object.op_Implicit((Object)(object)TabHolder))
		{
			return;
		}
		for (int i = 0; i < TabHolder.childCount; i++)
		{
			Button c = ((Component)TabHolder.GetChild(i)).GetComponent<Button>();
			if (Object.op_Implicit((Object)(object)c))
			{
				((UnityEvent)c.onClick).AddListener((UnityAction)delegate
				{
					SwitchTo(c);
				});
			}
		}
	}

	public void SwitchTo(Button sourceTab)
	{
		string name = ((Object)((Component)sourceTab).transform).name;
		if (Object.op_Implicit((Object)(object)TabHolder))
		{
			for (int i = 0; i < TabHolder.childCount; i++)
			{
				Button component = ((Component)TabHolder.GetChild(i)).GetComponent<Button>();
				if (Object.op_Implicit((Object)(object)component))
				{
					((Selectable)component).interactable = ((Object)component).name != name;
				}
			}
		}
		if (!Object.op_Implicit((Object)(object)ContentHolder))
		{
			return;
		}
		for (int j = 0; j < ContentHolder.childCount; j++)
		{
			Transform child = ContentHolder.GetChild(j);
			if (((Object)child).name == name)
			{
				Show(((Component)child).gameObject);
			}
			else
			{
				Hide(((Component)child).gameObject);
			}
		}
	}

	private void Hide(GameObject go)
	{
		if (!go.activeSelf)
		{
			return;
		}
		CanvasGroup val = default(CanvasGroup);
		if (FadeOut && go.TryGetComponent<CanvasGroup>(ref val))
		{
			LeanTween.alphaCanvas(val, 0f, 0.1f).setOnComplete((Action)delegate
			{
				go.SetActive(false);
			});
		}
		else
		{
			go.SetActive(false);
		}
	}

	private void Show(GameObject go)
	{
		if (!go.activeSelf)
		{
			CanvasGroup val = default(CanvasGroup);
			if (FadeIn && go.TryGetComponent<CanvasGroup>(ref val))
			{
				val.alpha = 0f;
				LeanTween.alphaCanvas(val, 1f, 0.1f);
			}
			go.SetActive(true);
		}
	}
}
