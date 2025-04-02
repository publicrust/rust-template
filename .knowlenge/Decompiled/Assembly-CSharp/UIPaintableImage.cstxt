using UnityEngine;
using UnityEngine.UI;

public class UIPaintableImage : MonoBehaviour
{
	public enum DrawMode
	{
		AlphaBlended,
		Additive,
		Lighten,
		Erase
	}

	public RawImage image;

	public int texSize = 64;

	public Color clearColor = Color.clear;

	public FilterMode filterMode = FilterMode.Bilinear;

	public bool mipmaps;

	public RectTransform rectTransform => base.transform as RectTransform;
}
