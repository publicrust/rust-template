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
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		base.Save(info);
		if (info.msg.ZiplineArrival == null)
		{
			info.msg.ZiplineArrival = Pool.Get<ZiplineArrivalPoint>();
		}
		info.msg.ZiplineArrival.linePoints = Pool.Get<List<VectorData>>();
		Vector3[] array = linePositions;
		foreach (Vector3 val in array)
		{
			info.msg.ZiplineArrival.linePoints.Add(VectorData.op_Implicit(val));
		}
	}

	public void SetPositions(List<Vector3> points)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		linePositions = (Vector3[])(object)new Vector3[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			linePositions[i] = points[i];
		}
	}

	public override void Load(LoadInfo info)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		base.Load(info);
		if (info.msg.ZiplineArrival != null && linePositions == null)
		{
			linePositions = (Vector3[])(object)new Vector3[info.msg.ZiplineArrival.linePoints.Count];
			for (int i = 0; i < info.msg.ZiplineArrival.linePoints.Count; i++)
			{
				linePositions[i] = VectorData.op_Implicit(info.msg.ZiplineArrival.linePoints[i]);
			}
		}
	}

	public override void ResetState()
	{
		base.ResetState();
		linePositions = null;
	}
}
