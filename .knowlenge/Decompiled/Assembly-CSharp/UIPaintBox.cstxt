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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		brush.brushSize = Vector2.one * (float)size;
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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
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
		((UnityEvent<Brush>)onBrushChanged).Invoke(brush);
	}
}
