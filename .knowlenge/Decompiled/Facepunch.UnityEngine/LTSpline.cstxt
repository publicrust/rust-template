using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LTSpline
{
	public static int DISTANCE_COUNT = 3;

	public static int SUBLINE_COUNT = 20;

	public float distance;

	public bool constantSpeed = true;

	public Vector3[] pts;

	[NonSerialized]
	public Vector3[] ptsAdj;

	public int ptsAdjLength;

	public bool orientToPath;

	public bool orientToPath2d;

	private int numSections;

	private int currPt;

	public LTSpline(Vector3[] pts)
	{
		init(pts, constantSpeed: true);
	}

	public LTSpline(Vector3[] pts, bool constantSpeed)
	{
		this.constantSpeed = constantSpeed;
		init(pts, constantSpeed);
	}

	private void init(Vector3[] pts, bool constantSpeed)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		if (pts.Length < 4)
		{
			LeanTween.logError("LeanTween - When passing values for a spline path, you must pass four or more values!");
			return;
		}
		this.pts = (Vector3[])(object)new Vector3[pts.Length];
		Array.Copy(pts, this.pts, pts.Length);
		numSections = pts.Length - 3;
		float num = float.PositiveInfinity;
		Vector3 val = this.pts[1];
		float num2 = 0f;
		for (int i = 1; i < this.pts.Length - 1; i++)
		{
			float num3 = Vector3.Distance(this.pts[i], val);
			if (num3 < num)
			{
				num = num3;
			}
			num2 += num3;
		}
		if (!constantSpeed)
		{
			return;
		}
		num = num2 / (float)(numSections * SUBLINE_COUNT);
		float num4 = num / (float)SUBLINE_COUNT;
		int num5 = (int)Mathf.Ceil(num2 / num4) * DISTANCE_COUNT;
		if (num5 <= 1)
		{
			num5 = 2;
		}
		ptsAdj = (Vector3[])(object)new Vector3[num5];
		val = interp(0f);
		int num6 = 1;
		ptsAdj[0] = val;
		distance = 0f;
		for (int j = 0; j < num5 + 1; j++)
		{
			float num7 = (float)j / (float)num5;
			Vector3 val2 = interp(num7);
			float num8 = Vector3.Distance(val2, val);
			if (num8 >= num4 || num7 >= 1f)
			{
				ptsAdj[num6] = val2;
				distance += num8;
				val = val2;
				num6++;
			}
		}
		ptsAdjLength = num6;
	}

	public Vector3 map(float u)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		if (u >= 1f)
		{
			return pts[pts.Length - 2];
		}
		float num = u * (float)(ptsAdjLength - 1);
		int num2 = (int)Mathf.Floor(num);
		int num3 = (int)Mathf.Ceil(num);
		if (num2 < 0)
		{
			num2 = 0;
		}
		Vector3 val = ptsAdj[num2];
		Vector3 val2 = ptsAdj[num3];
		float num4 = num - (float)num2;
		return val + (val2 - val) * num4;
	}

	public Vector3 interp(float t)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
		float num = t * (float)numSections - (float)currPt;
		Vector3 val = pts[currPt];
		Vector3 val2 = pts[currPt + 1];
		Vector3 val3 = pts[currPt + 2];
		Vector3 val4 = pts[currPt + 3];
		return 0.5f * ((-val + 3f * val2 - 3f * val3 + val4) * (num * num * num) + (2f * val - 5f * val2 + 4f * val3 - val4) * (num * num) + (-val + val3) * num + 2f * val2);
	}

	public float ratioAtPoint(Vector3 pt)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		float num = float.MaxValue;
		int num2 = 0;
		for (int i = 0; i < ptsAdjLength; i++)
		{
			float num3 = Vector3.Distance(pt, ptsAdj[i]);
			if (num3 < num)
			{
				num = num3;
				num2 = i;
			}
		}
		return (float)num2 / (float)(ptsAdjLength - 1);
	}

	public Vector3 point(float ratio)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		float num = ((ratio > 1f) ? 1f : ratio);
		if (!constantSpeed)
		{
			return interp(num);
		}
		return map(num);
	}

	public void place2d(Transform transform, float ratio)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		transform.position = point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			Vector3 val = point(ratio) - transform.position;
			float num = Mathf.Atan2(val.y, val.x) * 57.29578f;
			transform.eulerAngles = new Vector3(0f, 0f, num);
		}
	}

	public void placeLocal2d(Transform transform, float ratio)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)transform.parent == (Object)null)
		{
			place2d(transform, ratio);
			return;
		}
		transform.localPosition = point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			Vector3 val = point(ratio) - transform.localPosition;
			float num = Mathf.Atan2(val.y, val.x) * 57.29578f;
			transform.localEulerAngles = new Vector3(0f, 0f, num);
		}
	}

	public void place(Transform transform, float ratio)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		place(transform, ratio, Vector3.up);
	}

	public void place(Transform transform, float ratio, Vector3 worldUp)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		transform.position = point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			transform.LookAt(point(ratio), worldUp);
		}
	}

	public void placeLocal(Transform transform, float ratio)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		placeLocal(transform, ratio, Vector3.up);
	}

	public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		transform.localPosition = point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			transform.LookAt(transform.parent.TransformPoint(point(ratio)), worldUp);
		}
	}

	public void gizmoDraw(float t = -1f)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (ptsAdj != null && ptsAdj.Length != 0)
		{
			Vector3 val = ptsAdj[0];
			for (int i = 0; i < ptsAdjLength; i++)
			{
				Vector3 val2 = ptsAdj[i];
				Gizmos.DrawLine(val, val2);
				val = val2;
			}
		}
	}

	public void drawGizmo(Color color)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (ptsAdjLength >= 4)
		{
			Vector3 val = ptsAdj[0];
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			for (int i = 0; i < ptsAdjLength; i++)
			{
				Vector3 val2 = ptsAdj[i];
				Gizmos.DrawLine(val, val2);
				val = val2;
			}
			Gizmos.color = color2;
		}
	}

	public static void drawGizmo(Transform[] arr, Color color)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (arr.Length >= 4)
		{
			Vector3[] array = (Vector3[])(object)new Vector3[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				array[i] = arr[i].position;
			}
			LTSpline lTSpline = new LTSpline(array);
			Vector3 val = lTSpline.ptsAdj[0];
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			for (int j = 0; j < lTSpline.ptsAdjLength; j++)
			{
				Vector3 val2 = lTSpline.ptsAdj[j];
				Gizmos.DrawLine(val, val2);
				val = val2;
			}
			Gizmos.color = color2;
		}
	}

	public static void drawLine(Transform[] arr, float width, Color color)
	{
		_ = arr.Length;
		_ = 4;
	}

	public void drawLinesGLLines(Material outlineMaterial, Color color, float width)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		GL.PushMatrix();
		outlineMaterial.SetPass(0);
		GL.LoadPixelMatrix();
		GL.Begin(1);
		GL.Color(color);
		if (constantSpeed)
		{
			if (ptsAdjLength >= 4)
			{
				Vector3 val = ptsAdj[0];
				for (int i = 0; i < ptsAdjLength; i++)
				{
					Vector3 val2 = ptsAdj[i];
					GL.Vertex(val);
					GL.Vertex(val2);
					val = val2;
				}
			}
		}
		else if (pts.Length >= 4)
		{
			Vector3 val3 = pts[0];
			float num = 1f / ((float)pts.Length * 10f);
			for (float num2 = 0f; num2 < 1f; num2 += num)
			{
				float t = num2 / 1f;
				Vector3 val4 = interp(t);
				GL.Vertex(val3);
				GL.Vertex(val4);
				val3 = val4;
			}
		}
		GL.End();
		GL.PopMatrix();
	}

	public Vector3[] generateVectors()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (pts.Length >= 4)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 item = pts[0];
			list.Add(item);
			float num = 1f / ((float)pts.Length * 10f);
			for (float num2 = 0f; num2 < 1f; num2 += num)
			{
				float t = num2 / 1f;
				Vector3 item2 = interp(t);
				list.Add(item2);
			}
			list.ToArray();
		}
		return null;
	}
}
