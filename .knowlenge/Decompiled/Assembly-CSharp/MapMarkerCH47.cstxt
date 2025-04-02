using ProtoBuf;
using UnityEngine;

public class MapMarkerCH47 : MapMarker
{
	public bool IsCargoShip;

	public bool AutomaticallySetRotationToParent = true;

	public bool UseEntityRotation;

	private float GetRotation(BaseEntity forEntity)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)forEntity == (Object)null)
		{
			return 0f;
		}
		Vector3 forward = ((Component)forEntity).transform.forward;
		forward.y = 0f;
		((Vector3)(ref forward)).Normalize();
		return Mathf.Atan2(forward.x, 0f - forward.z) * 57.29578f + 180f;
	}

	public override AppMarker GetAppMarkerData()
	{
		AppMarker appMarkerData = base.GetAppMarkerData();
		appMarkerData.rotation = GetRotation(GetParentEntity());
		return appMarkerData;
	}
}
