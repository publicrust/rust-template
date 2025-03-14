using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class ZiplineArrivalPoint : BaseEntity
{
	public LineRenderer Line;

	private Vector3[] linePositions;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.ZiplineArrival == null)
		{
			info.msg.ZiplineArrival = Pool.Get<ProtoBuf.ZiplineArrivalPoint>();
		}
		info.msg.ZiplineArrival.linePoints = Pool.Get<List<VectorData>>();
		Vector3[] array = linePositions;
		foreach (Vector3 vector in array)
		{
			info.msg.ZiplineArrival.linePoints.Add(vector);
		}
	}

	public void SetPositions(List<Vector3> points)
	{
		linePositions = new Vector3[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			linePositions[i] = points[i];
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.ZiplineArrival != null && linePositions == null)
		{
			linePositions = new Vector3[info.msg.ZiplineArrival.linePoints.Count];
			for (int i = 0; i < info.msg.ZiplineArrival.linePoints.Count; i++)
			{
				linePositions[i] = info.msg.ZiplineArrival.linePoints[i];
			}
		}
	}

	public override void ResetState()
	{
		base.ResetState();
		linePositions = null;
	}
}
