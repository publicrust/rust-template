using System.Globalization;
using Rust;
using Rust.UI;
using UnityEngine;

public class SliderCookie : MonoBehaviour
{
	public void OnEnable()
	{
		if (TryGetComponent<RustSlider>(out var component))
		{
			float result;
			float num = (float.TryParse(PlayerPrefs.GetString("SliderCookie_" + base.name), NumberStyles.Float, CultureInfo.InvariantCulture, out result) ? result : component.ValueInternal);
			component.ValueInternal = num + 1f;
			component.Value = num;
			component.OnChanged.AddListener(OnSliderChanged);
		}
	}

	public void OnDisable()
	{
		if (!Rust.Application.isQuitting && TryGetComponent<RustSlider>(out var component))
		{
			component.OnChanged.RemoveListener(OnSliderChanged);
		}
	}

	private void OnSliderChanged(float v)
	{
		PlayerPrefs.SetString("SliderCookie_" + base.name, v.ToString(CultureInfo.InvariantCulture));
	}
}
