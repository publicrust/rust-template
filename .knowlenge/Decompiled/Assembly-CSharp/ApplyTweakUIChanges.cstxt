using UnityEngine;
using UnityEngine.UI;

public class ApplyTweakUIChanges : MonoBehaviour
{
	public Button ApplyButton;

	public TweakUIBase[] Options;

	private void OnEnable()
	{
		SetClean();
	}

	public void Apply()
	{
		if (Options == null)
		{
			return;
		}
		TweakUIBase[] options = Options;
		foreach (TweakUIBase tweakUIBase in options)
		{
			if (!(tweakUIBase == null))
			{
				tweakUIBase.OnApplyClicked();
			}
		}
		SetClean();
	}

	public void SetDirty()
	{
		if (ApplyButton != null)
		{
			ApplyButton.interactable = true;
		}
	}

	public void SetClean()
	{
		if (ApplyButton != null)
		{
			ApplyButton.interactable = false;
		}
	}
}
