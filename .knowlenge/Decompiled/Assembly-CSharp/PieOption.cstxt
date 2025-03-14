using System;
using UnityEngine;
using UnityEngine.UI;

public class PieOption : MonoBehaviour
{
	public PieShape background;

	public Image imageIcon;

	internal float midRadius => (background.startRadius + background.endRadius) * 0.5f;

	internal float sliceSize => background.endRadius - background.startRadius;

	public void UpdateOption(float startSlice, float sliceSize, float border, string optionTitle, float outerSize, float innerSize, float imageSize, Sprite sprite)
	{
		if (!(background == null))
		{
			float num = background.rectTransform.rect.height * 0.5f;
			float num2 = num * (innerSize + (outerSize - innerSize) * 0.5f);
			float num3 = num * (outerSize - innerSize);
			background.startRadius = startSlice;
			background.endRadius = startSlice + sliceSize;
			background.border = border;
			background.outerSize = outerSize;
			background.innerSize = innerSize;
			background.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 0f);
			float num4 = startSlice + sliceSize * 0.5f;
			float x = Mathf.Sin(num4 * ((float)Math.PI / 180f)) * num2;
			float y = Mathf.Cos(num4 * ((float)Math.PI / 180f)) * num2;
			imageIcon.rectTransform.localPosition = new Vector3(x, y);
			imageIcon.rectTransform.sizeDelta = new Vector2(num3 * imageSize, num3 * imageSize);
			imageIcon.sprite = sprite;
		}
	}
}
