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
		using (TimeWarning.New("HudElement.SetValue"))
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
