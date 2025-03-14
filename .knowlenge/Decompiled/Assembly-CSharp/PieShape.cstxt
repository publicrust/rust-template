using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PieShape : Graphic
{
	[Range(0f, 1f)]
	public float outerSize = 1f;

	[Range(0f, 1f)]
	public float innerSize = 0.5f;

	public float startRadius = -45f;

	public float endRadius = 45f;

	public float border;

	public bool debugDrawing;

	public bool calculateAverage;

	public Rect drawRect { get; private set; }

	public Vector2 centrePosition { get; private set; }

	public Vector2 firstPosition { get; private set; }

	public Vector2 lastPosition { get; private set; }

	public Vector3 averagePosition { get; private set; } = default(Vector2);

	protected override void OnPopulateMesh(VertexHelper vbo)
	{
		drawRect = default(Rect);
		vbo.Clear();
		UIVertex simpleVert = UIVertex.simpleVert;
		float num = startRadius;
		float num2 = endRadius;
		if (startRadius > endRadius)
		{
			num2 = endRadius + 360f;
		}
		float num3 = Mathf.Floor((num2 - num) / 6f);
		if (num3 <= 1f)
		{
			return;
		}
		float num4 = (num2 - num) / num3;
		float num5 = num + (num2 - num) * 0.5f;
		averagePosition = default(Vector3);
		Color color = this.color;
		float num6 = base.rectTransform.rect.height * 0.5f;
		Vector2 vector = new Vector2(Mathf.Sin(num5 * (MathF.PI / 180f)), Mathf.Cos(num5 * (MathF.PI / 180f))) * border;
		int num7 = 0;
		firstPosition = Vector2.zero;
		lastPosition = Vector2.zero;
		for (float num8 = num; num8 < num2; num8 += num4)
		{
			if (debugDrawing)
			{
				color = ((!(color == Color.red)) ? Color.red : Color.white);
			}
			simpleVert.color = color;
			float num9 = Mathf.Sin(num8 * (MathF.PI / 180f));
			float num10 = Mathf.Cos(num8 * (MathF.PI / 180f));
			float num11 = num8 + num4;
			if (num11 > num2)
			{
				num11 = num2;
			}
			float num12 = Mathf.Sin(num11 * (MathF.PI / 180f));
			float num13 = Mathf.Cos(num11 * (MathF.PI / 180f));
			simpleVert.position = new Vector2(num9 * outerSize * num6, num10 * outerSize * num6) + vector;
			if (vbo.currentVertCount == 0)
			{
				firstPosition = simpleVert.position;
				if (calculateAverage)
				{
					averagePosition = simpleVert.position;
				}
			}
			else if (calculateAverage)
			{
				averagePosition += simpleVert.position;
			}
			vbo.AddVert(simpleVert);
			simpleVert.position = new Vector2(num12 * outerSize * num6, num13 * outerSize * num6) + vector;
			if (calculateAverage)
			{
				averagePosition += simpleVert.position;
			}
			vbo.AddVert(simpleVert);
			simpleVert.position = new Vector2(num12 * innerSize * num6, num13 * innerSize * num6) + vector;
			if (calculateAverage)
			{
				averagePosition += simpleVert.position;
			}
			lastPosition = simpleVert.position;
			vbo.AddVert(simpleVert);
			simpleVert.position = new Vector2(num9 * innerSize * num6, num10 * innerSize * num6) + vector;
			if (calculateAverage)
			{
				averagePosition += simpleVert.position;
			}
			vbo.AddVert(simpleVert);
			vbo.AddTriangle(num7, num7 + 1, num7 + 2);
			vbo.AddTriangle(num7 + 2, num7 + 3, num7);
			num7 += 4;
		}
		if (calculateAverage)
		{
			averagePosition = new Vector3(averagePosition.x / (float)vbo.currentVertCount, averagePosition.y / (float)vbo.currentVertCount, averagePosition.z / (float)vbo.currentVertCount);
		}
		drawRect = new Rect(Mathf.Min(firstPosition.x, lastPosition.x), Mathf.Min(firstPosition.y, lastPosition.y), Mathf.Abs(firstPosition.x - lastPosition.x), Mathf.Abs(firstPosition.y - lastPosition.y));
		centrePosition = Vector2.Lerp(firstPosition, lastPosition, 0.5f);
	}
}
