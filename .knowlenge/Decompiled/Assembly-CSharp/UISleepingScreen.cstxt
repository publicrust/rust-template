using TMPro;
using UnityEngine;

public class UISleepingScreen : SingletonComponent<UISleepingScreen>, IUIScreen
{
	protected CanvasGroup canvasGroup;

	private bool visible;

	protected override void Awake()
	{
		((SingletonComponent)this).Awake();
		canvasGroup = ((Component)this).GetComponent<CanvasGroup>();
		visible = true;
	}

	public void SetVisible(bool b)
	{
		if (visible != b)
		{
			visible = b;
			canvasGroup.alpha = (visible ? 1f : 0f);
			((Component)SingletonComponent<UISleepingScreen>.Instance).gameObject.SetChildComponentsEnabled<TMP_Text>(visible);
		}
	}
}
