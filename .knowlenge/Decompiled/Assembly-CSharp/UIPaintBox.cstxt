using System;
using Painting;
using UnityEngine;
using UnityEngine.Events;

public class UIPaintBox : MonoBehaviour
{
	[Serializable]
	public class OnBrushChanged : UnityEvent<Brush>
	{
	}

	public OnBrushChanged onBrushChanged = new OnBrushChanged();

	public Brush brush;

	public void UpdateBrushSize(int size)
	{
		brush.brushSize = Vector2.one * size;
		brush.spacing = Mathf.Clamp((float)size * 0.1f, 1f, 3f);
		OnChanged();
	}

	public void UpdateBrushTexture(Texture2D tex)
	{
		brush.texture = tex;
		OnChanged();
	}

	public void UpdateBrushColor(Color col)
	{
		brush.color.r = col.r;
		brush.color.g = col.g;
		brush.color.b = col.b;
		OnChanged();
	}

	public void UpdateBrushAlpha(float a)
	{
		brush.color.a = a;
		OnChanged();
	}

	public void UpdateBrushEraser(bool b)
	{
		brush.erase = b;
	}

	private void OnChanged()
	{
		onBrushChanged.Invoke(brush);
	}
}
