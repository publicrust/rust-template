using ProtoBuf;
using UnityEngine;

public class MapMarkerCH47 : MapMarker
{
	public bool IsCargoShip;

	public bool AutomaticallySetRotationToParent = true;

	public bool UseEntityRotation;

	private float GetRotation(BaseEntity forEntity)
	{
		if (forEntity == null)
		{
			return 0f;
		}
		Vector3 forward = forEntity.transform.forward;
		forward.y = 0f;
		forward.Normalize();
		return Mathf.Atan2(forward.x, 0f - forward.z) * 57.29578f + 180f;
	}

	public override AppMarker GetAppMarkerData()
	{
		AppMarker appMarkerData = base.GetAppMarkerData();
		appMarkerData.rotation = GetRotation(GetParentEntity());
		return appMarkerData;
	}
}
