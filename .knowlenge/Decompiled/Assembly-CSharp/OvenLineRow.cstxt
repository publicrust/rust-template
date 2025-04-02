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
		LootGrid above = Above;
		int num = ((above != null) ? ((Component)above).transform.childCount : 0);
		LootGrid below = Below;
		int num2 = ((below != null) ? ((Component)below).transform.childCount : 0);
		if (num2 == _bottomCount && num == _topCount)
		{
			return;
		}
		_bottomCount = num2;
		_topCount = num;
		foreach (GameObject image in images)
		{
			Object.Destroy((Object)(object)image);
		}
		CreateRow(above: true);
		CreateRow(above: false);
	}

	private void CreateRow(bool above)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		LootGrid lootGrid = (above ? Above : Below);
		int num = (above ? _topCount : _bottomCount);
		if (num == 0)
		{
			return;
		}
		int num2 = num;
		GridLayoutGroup component = ((Component)lootGrid).GetComponent<GridLayoutGroup>();
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
					Image obj = CreateImage();
					((Graphic)obj).rectTransform.anchorMin = new Vector2(0.5f, above ? 0.5f : 0f);
					((Graphic)obj).rectTransform.anchorMax = new Vector2(0.5f, above ? 1f : 0.5f);
					((Graphic)obj).rectTransform.offsetMin = new Vector2(0f - num4 + (float)i * num3 - (float)(LineWidth / 2), (float)(above ? (LineWidth / 2) : Padding));
					((Graphic)obj).rectTransform.offsetMax = new Vector2(0f - num4 + (float)i * num3 + (float)(LineWidth / 2), (float)(above ? (-Padding) : (-LineWidth / 2)));
				}
			}
		}
		else
		{
			Image obj2 = CreateImage();
			((Graphic)obj2).rectTransform.anchorMin = new Vector2(0.5f, 0f);
			((Graphic)obj2).rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			((Graphic)obj2).rectTransform.offsetMin = new Vector2((float)(-LineWidth / 2), (float)Padding);
			((Graphic)obj2).rectTransform.offsetMax = new Vector2((float)(LineWidth / 2), (float)(-LineWidth / 2));
			Image obj3 = CreateImage();
			obj3.sprite = TriangleSprite;
			((Object)((Component)obj3).gameObject).name = "triangle";
			obj3.useSpriteMesh = true;
			((Transform)((Graphic)obj3).rectTransform).localRotation = Quaternion.Euler(0f, 0f, 180f);
			((Graphic)obj3).rectTransform.anchorMin = new Vector2(0.5f, 0f);
			((Graphic)obj3).rectTransform.anchorMax = new Vector2(0.5f, 0f);
			((Graphic)obj3).rectTransform.pivot = new Vector2(0.5f, 0f);
			((Graphic)obj3).rectTransform.offsetMin = new Vector2((float)(-ArrowWidth / 2), 0f);
			((Graphic)obj3).rectTransform.offsetMax = new Vector2((float)(ArrowWidth / 2), (float)ArrowHeight);
		}
		if (above && num2 >= 1)
		{
			float num5 = num3 * (float)(num2 - 1) + (float)LineWidth;
			Image obj4 = CreateImage();
			((Graphic)obj4).rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			((Graphic)obj4).rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			((Graphic)obj4).rectTransform.offsetMin = new Vector2(num5 / -2f, (float)(-LineWidth / 2));
			((Graphic)obj4).rectTransform.offsetMax = new Vector2(num5 / 2f, (float)(LineWidth / 2));
		}
	}

	private Image CreateImage()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("Line");
		Image obj = val.AddComponent<Image>();
		images.Add(val);
		((Transform)((Graphic)obj).rectTransform).SetParent(Container ?? ((Component)this).transform);
		((Component)obj).transform.localScale = Vector3.one;
		((Graphic)obj).color = Color;
		return obj;
	}
}
