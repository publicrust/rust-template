using System;
using UnityEngine;

public class DirectionProperties : PrefabAttribute
{
	private const float radius = 200f;

	public Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

	public ProtectionProperties extraProtection;

	protected override Type GetIndexedType()
	{
		return typeof(DirectionProperties);
	}

	public bool IsWeakspot(Transform tx, HitInfo info)
	{
		if (bounds.size == Vector3.zero)
		{
			return false;
		}
		BasePlayer initiatorPlayer = info.InitiatorPlayer;
		if (initiatorPlayer == null)
		{
			return false;
		}
		BaseEntity hitEntity = info.HitEntity;
		if (hitEntity == null)
		{
			return false;
		}
		Matrix4x4 worldToLocalMatrix = tx.worldToLocalMatrix;
		Vector3 b = worldToLocalMatrix.MultiplyPoint3x4(info.PointStart) - worldPosition;
		float num = worldForward.DotDegrees(b);
		Vector3 target = worldToLocalMatrix.MultiplyPoint3x4(info.HitPositionWorld);
		OBB oBB = new OBB(worldPosition, worldRotation, bounds);
		Vector3 position = initiatorPlayer.eyes.position;
		Vector3 target2 = tx.TransformPoint(oBB.position);
		if (!hitEntity.IsVisible(position, target2))
		{
			return false;
		}
		if (num > 100f)
		{
			return oBB.Contains(target);
		}
		return false;
	}
}
