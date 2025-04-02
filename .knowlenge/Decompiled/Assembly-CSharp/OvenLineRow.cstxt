using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenLineRow : MonoBehaviour
{
	public LootGrid Above;

	public LootGrid Below;

	public Transform Container;

	public Color Color = Color.white;

	public Sprite TriangleSprite;

	public int LineWidth = 2;

	public int ArrowWidth = 6;

	public int ArrowHeight = 4;

	public int Padding = 2;

	private int _topCount;

	private int _bottomCount;

	private List<GameObject> images = new List<GameObject>();

	private void Update()
	{
		int num = Above?.transform.childCount ?? 0;
		int num2 = Below?.transform.childCount ?? 0;
		if (num2 == _bottomCount && num == _topCount)
		{
			return;
		}
		_bottomCount = num2;
		_topCount = num;
		foreach (GameObject image in images)
		{
			Object.Destroy(image);
		}
		CreateRow(above: true);
		CreateRow(above: false);
	}

	private void CreateRow(bool above)
	{
		LootGrid lootGrid = (above ? Above : Below);
		int num = (above ? _topCount : _bottomCount);
		if (num == 0)
		{
			return;
		}
		int num2 = num;
		GridLayoutGroup component = lootGrid.GetComponent<GridLayoutGroup>();
		float x = component.cellSize.x;
		float x2 = component.spacing.x;
		float num3 = x + x2;
		float num4 = num3 * (float)(num - 1) / 2f;
		if (above)
		{
			for (int i = 0; i < num; i++)
			{
				if (i == 0 || i == num - 1)
				{
					Image image = CreateImage();
					image.rectTransform.anchorMin = new Vector2(0.5f, above ? 0.5f : 0f);
					image.rectTransform.anchorMax = new Vector2(0.5f, above ? 1f : 0.5f);
					image.rectTransform.offsetMin = new Vector2(0f - num4 + (float)i * num3 - (float)(LineWidth / 2), above ? (LineWidth / 2) : Padding);
					image.rectTransform.offsetMax = new Vector2(0f - num4 + (float)i * num3 + (float)(LineWidth / 2), above ? (-Padding) : (-LineWidth / 2));
				}
			}
		}
		else
		{
			Image image2 = CreateImage();
			image2.rectTransform.anchorMin = new Vector2(0.5f, 0f);
			image2.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			image2.rectTransform.offsetMin = new Vector2(-LineWidth / 2, Padding);
			image2.rectTransform.offsetMax = new Vector2(LineWidth / 2, -LineWidth / 2);
			Image image3 = CreateImage();
			image3.sprite = TriangleSprite;
			image3.gameObject.name = "triangle";
			image3.useSpriteMesh = true;
			image3.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
			image3.rectTransform.anchorMin = new Vector2(0.5f, 0f);
			image3.rectTransform.anchorMax = new Vector2(0.5f, 0f);
			image3.rectTransform.pivot = new Vector2(0.5f, 0f);
			image3.rectTransform.offsetMin = new Vector2(-ArrowWidth / 2, 0f);
			image3.rectTransform.offsetMax = new Vector2(ArrowWidth / 2, ArrowHeight);
		}
		if (above && num2 >= 1)
		{
			float num5 = num3 * (float)(num2 - 1) + (float)LineWidth;
			Image image4 = CreateImage();
			image4.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			image4.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			image4.rectTransform.offsetMin = new Vector2(num5 / -2f, -LineWidth / 2);
			image4.rectTransform.offsetMax = new Vector2(num5 / 2f, LineWidth / 2);
		}
	}

	private Image CreateImage()
	{
		GameObject gameObject = new GameObject("Line");
		Image image = gameObject.AddComponent<Image>();
		images.Add(gameObject);
		image.rectTransform.SetParent(Container ?? base.transform);
		image.transform.localScale = Vector3.one;
		image.color = Color;
		return image;
	}
}
