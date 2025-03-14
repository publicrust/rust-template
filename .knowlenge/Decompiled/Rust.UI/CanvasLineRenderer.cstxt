using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CanvasLineRenderer : Graphic
{
	public List<Vector2> Points = new List<Vector2>();

	public float Thickness = 10f;

	public float CurveOffset = 10f;

	public int CornerTesselation = 3;

	public float DistanceUvMultiplier = 0.05f;

	public Texture RepeatTexture;

	public override Texture mainTexture
	{
		get
		{
			if (!(RepeatTexture == null))
			{
				return RepeatTexture;
			}
			return Graphic.s_WhiteTexture;
		}
	}
}
