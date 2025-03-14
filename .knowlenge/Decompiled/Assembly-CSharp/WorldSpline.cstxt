using System.Collections.Generic;
using UnityEngine;

public class WorldSpline : MonoBehaviour
{
	public int dataIndex = -1;

	public Vector3[] points;

	public Vector3[] tangents;

	[Range(0.05f, 100f)]
	public float lutInterval = 0.25f;

	[SerializeField]
	private bool showGizmos = true;

	private static List<Vector3> visualSplineList = new List<Vector3>();

	private WorldSplineData privateData;

	public WorldSplineData GetData()
	{
		if (WorldSplineSharedData.TryGetDataFor(this, out var data))
		{
			return data;
		}
		if (Application.isPlaying && privateData == null)
		{
			privateData = new WorldSplineData(this);
		}
		return privateData;
	}

	public void SetAll(Vector3[] points, Vector3[] tangents, float lutInterval)
	{
		this.points = points;
		this.tangents = tangents;
		this.lutInterval = lutInterval;
	}

	public void CheckValidity()
	{
		lutInterval = Mathf.Clamp(lutInterval, 0.05f, 100f);
		if (points == null || points.Length < 2)
		{
			points = new Vector3[2];
			points[0] = Vector3.zero;
			points[1] = Vector3.zero;
		}
		if (tangents != null && points.Length == tangents.Length)
		{
			return;
		}
		Vector3[] array = new Vector3[points.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (tangents != null && i < tangents.Length)
			{
				array[i] = tangents[i];
			}
			else
			{
				array[i] = Vector3.forward;
			}
		}
		tangents = array;
	}

	protected virtual void OnDrawGizmosSelected()
	{
		if (showGizmos)
		{
			DrawSplineGizmo(this, Color.magenta);
		}
	}

	protected static void DrawSplineGizmo(WorldSpline ws, Color splineColour)
	{
		if (ws == null)
		{
			return;
		}
		WorldSplineData data = ws.GetData();
		if (data == null || ws.points.Length < 2 || ws.points.Length != ws.tangents.Length)
		{
			return;
		}
		Vector3[] pointsWorld = ws.GetPointsWorld();
		Vector3[] tangentsWorld = ws.GetTangentsWorld();
		for (int i = 0; i < pointsWorld.Length; i++)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawSphere(pointsWorld[i], 0.25f);
			if (tangentsWorld[i].magnitude > 0f)
			{
				Gizmos.color = Color.cyan;
				Vector3 to = pointsWorld[i] + tangentsWorld[i] + Vector3.up * 0.1f;
				Gizmos.DrawLine(pointsWorld[i] + Vector3.up * 0.1f, to);
			}
		}
		Gizmos.color = splineColour;
		Vector3[] visualSpline = GetVisualSpline(ws, data, 1f);
		for (int j = 0; j < visualSpline.Length - 1; j++)
		{
			Gizmos.color = Color.Lerp(Color.white, splineColour, (float)j / (float)(visualSpline.Length - 1));
			Gizmos.DrawLine(visualSpline[j], visualSpline[j + 1]);
			Gizmos.DrawLine(visualSpline[j], visualSpline[j] + Vector3.up * 0.25f);
		}
	}

	private static Vector3[] GetVisualSpline(WorldSpline ws, WorldSplineData data, float distBetweenPoints)
	{
		visualSplineList.Clear();
		if (ws != null && ws.points.Length > 1)
		{
			Vector3 startPointWorld = ws.GetStartPointWorld();
			Vector3 endPointWorld = ws.GetEndPointWorld();
			visualSplineList.Add(startPointWorld);
			for (float num = distBetweenPoints; num <= data.Length - distBetweenPoints; num += distBetweenPoints)
			{
				visualSplineList.Add(ws.GetPointCubicHermiteWorld(num, data));
			}
			visualSplineList.Add(endPointWorld);
		}
		return visualSplineList.ToArray();
	}

	public Vector3 GetStartPointWorld()
	{
		return base.transform.TransformPoint(points[0]);
	}

	public Vector3 GetEndPointWorld()
	{
		return base.transform.TransformPoint(points[points.Length - 1]);
	}

	public Vector3 GetStartTangentWorld()
	{
		return Vector3.Scale(base.transform.rotation * tangents[0], base.transform.localScale);
	}

	public Vector3 GetEndTangentWorld()
	{
		return Vector3.Scale(base.transform.rotation * tangents[tangents.Length - 1], base.transform.localScale);
	}

	public Vector3 GetTangentCubicHermiteWorld(float distance)
	{
		return Vector3.Scale(base.transform.rotation * GetData().GetTangentCubicHermite(distance), base.transform.localScale);
	}

	public Vector3 GetTangentCubicHermiteWorld(float distance, WorldSplineData data)
	{
		return Vector3.Scale(base.transform.rotation * data.GetTangentCubicHermite(distance), base.transform.localScale);
	}

	public Vector3 GetPointCubicHermiteWorld(float distance)
	{
		return base.transform.TransformPoint(GetData().GetPointCubicHermite(distance));
	}

	public Vector3 GetPointCubicHermiteWorld(float distance, WorldSplineData data)
	{
		return base.transform.TransformPoint(data.GetPointCubicHermite(distance));
	}

	public Vector3 GetPointAndTangentCubicHermiteWorld(float distance, out Vector3 tangent)
	{
		Vector3 pointAndTangentCubicHermite = GetData().GetPointAndTangentCubicHermite(distance, out tangent);
		tangent = base.transform.TransformVector(tangent);
		return base.transform.TransformPoint(pointAndTangentCubicHermite);
	}

	public Vector3 GetPointAndTangentCubicHermiteWorld(float distance, WorldSplineData data, out Vector3 tangent)
	{
		Vector3 pointAndTangentCubicHermite = data.GetPointAndTangentCubicHermite(distance, out tangent);
		tangent = base.transform.TransformVector(tangent);
		return base.transform.TransformPoint(pointAndTangentCubicHermite);
	}

	public Vector3[] GetPointsWorld()
	{
		return PointsToWorld(points, base.transform);
	}

	public Vector3[] GetTangentsWorld()
	{
		return TangentsToWorld(tangents, base.transform);
	}

	private static Vector3[] PointsToWorld(Vector3[] points, Transform tr)
	{
		Vector3[] array = new Vector3[points.Length];
		for (int i = 0; i < points.Length; i++)
		{
			array[i] = tr.TransformPoint(points[i]);
		}
		return array;
	}

	private static Vector3[] TangentsToWorld(Vector3[] tangents, Transform tr)
	{
		Vector3[] array = new Vector3[tangents.Length];
		for (int i = 0; i < tangents.Length; i++)
		{
			array[i] = Vector3.Scale(tr.rotation * tangents[i], tr.localScale);
		}
		return array;
	}
}
