using TMPro;
using UnityEngine.UI;

public class TweakUISlider : TweakUIBase
{
	public Slider sliderControl;

	public TextMeshProUGUI textControl;

	public static string lastConVarChanged;

	public static TimeSince timeSinceLastConVarChange;

	protected override void Init()
	{
		base.Init();
		ResetToConvar();
	}

	protected void OnEnable()
	{
		ResetToConvar();
	}

	public void OnChanged()
	{
		RefreshSliderDisplay(sliderControl.value);
		if (ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
	}

	protected override void SetConvarValue()
	{
		base.SetConvarValue();
		if (conVar != null)
		{
			float value = sliderControl.value;
			if (conVar.AsFloat != value)
			{
				conVar.Set(value);
				RefreshSliderDisplay(conVar.AsFloat);
				lastConVarChanged = conVar.FullName;
				timeSinceLastConVarChange = 0f;
			}
		}
	}

	public override void ResetToConvar()
	{
		base.ResetToConvar();
		if (conVar != null)
		{
			RefreshSliderDisplay(conVar.AsFloat);
		}
	}

	private void RefreshSliderDisplay(float value)
	{
		sliderControl.value = value;
		if (sliderControl.wholeNumbers)
		{
			textControl.text = sliderControl.value.ToString("N0");
		}
		else
		{
			textControl.text = sliderControl.value.ToString("0.0");
		}
	}
}
