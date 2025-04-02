using Facepunch;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class MonumentMarker : MonoBehaviour
{
	public RustText text;

	public Image imageBackground;

	public Image image;

	public Color dayColor;

	public Color nightColor;

	public void Setup(LandmarkInfo info)
	{
		text.SetText(info.displayPhrase.IsValid() ? info.displayPhrase.translated : info.transform.root.name, localized: true);
		if (info.mapIcon != null)
		{
			image.sprite = info.mapIcon;
			text.SetActive(active: false);
			imageBackground.SetActive(active: true);
		}
		else
		{
			text.SetActive(active: true);
			imageBackground.SetActive(active: false);
		}
		SetNightMode(nightMode: false);
	}

	public void SetNightMode(bool nightMode)
	{
		Color color = (nightMode ? nightColor : dayColor);
		Color color2 = (nightMode ? dayColor : nightColor);
		if (text != null)
		{
			text.color = color;
		}
		if (image != null)
		{
			image.color = color;
		}
		if (imageBackground != null)
		{
			imageBackground.color = color2;
		}
	}
}
