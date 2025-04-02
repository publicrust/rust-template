using System;
using UnityEngine;
using UnityEngine.UI;

public class HudElement : MonoBehaviour
{
	public Text[] ValueText;

	public Image[] FilledImage;

	public float lastValue;

	private float lastMax;

	public void SetValue(float value, float max = 1f)
	{
		TimeWarning val = TimeWarning.New("HudElement.SetValue", 0);
		try
		{
			value = Mathf.CeilToInt(value);
			if (value != lastValue || max != lastMax)
			{
				lastValue = value;
				lastMax = max;
				float image = value / max;
				SetText(value.ToString("0"));
				SetImage(image);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void SetText(string v)
	{
		for (int i = 0; i < ValueText.Length; i++)
		{
			ValueText[i].text = v;
		}
	}

	private void SetImage(float f)
	{
		for (int i = 0; i < FilledImage.Length; i++)
		{
			FilledImage[i].fillAmount = f;
		}
	}
}
