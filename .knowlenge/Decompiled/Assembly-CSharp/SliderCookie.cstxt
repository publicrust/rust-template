using System.Globalization;
using Rust;
using Rust.UI;
using UnityEngine;
using UnityEngine.Events;

public class SliderCookie : MonoBehaviour
{
	public void OnEnable()
	{
		RustSlider val = default(RustSlider);
		if (((Component)this).TryGetComponent<RustSlider>(ref val))
		{
			float result;
			float num = (float.TryParse(PlayerPrefs.GetString("SliderCookie_" + ((Object)this).name), NumberStyles.Float, CultureInfo.InvariantCulture, out result) ? result : val.ValueInternal);
			val.ValueInternal = num + 1f;
			val.Value = num;
			((UnityEvent<float>)(object)val.OnChanged).AddListener((UnityAction<float>)OnSliderChanged);
		}
	}

	public void OnDisable()
	{
		RustSlider val = default(RustSlider);
		if (!Application.isQuitting && ((Component)this).TryGetComponent<RustSlider>(ref val))
		{
			((UnityEvent<float>)(object)val.OnChanged).RemoveListener((UnityAction<float>)OnSliderChanged);
		}
	}

	private void OnSliderChanged(float v)
	{
		PlayerPrefs.SetString("SliderCookie_" + ((Object)this).name, v.ToString(CultureInfo.InvariantCulture));
	}
}
