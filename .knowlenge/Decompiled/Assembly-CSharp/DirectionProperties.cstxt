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
		WeakpointProperties[] array = PrefabAttribute.server.FindAll<WeakpointProperties>(hitEntity.prefabID);
		if (array != null && array.Length != 0)
		{
			bool flag = false;
			WeakpointProperties[] array2 = array;
			foreach (WeakpointProperties weakpointProperties in array2)
			{
				if ((!weakpointProperties.BlockWhenRoofAttached || CheckWeakpointRoof(hitEntity)) && IsWeakspotVisible(hitEntity, position, tx.TransformPoint(weakpointProperties.worldPosition)))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		else if (!IsWeakspotVisible(hitEntity, position, tx.TransformPoint(oBB.position)))
		{
			return false;
		}
		if (num > 100f)
		{
			return oBB.Contains(target);
		}
		return false;
	}

	private bool CheckWeakpointRoof(BaseEntity hitEntity)
	{
		foreach (EntityLink entityLink in hitEntity.GetEntityLinks())
		{
			if (!(entityLink.socket is NeighbourSocket))
			{
				continue;
			}
			foreach (EntityLink connection in entityLink.connections)
			{
				if (connection.owner is BuildingBlock buildingBlock && (buildingBlock.ShortPrefabName == "roof" || buildingBlock.ShortPrefabName == "roof.triangle"))
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool IsWeakspotVisible(BaseEntity hitEntity, Vector3 playerEyes, Vector3 weakspotPos)
	{
		if (!hitEntity.IsVisible(playerEyes, weakspotPos))
		{
			return false;
		}
		return true;
	}
}
