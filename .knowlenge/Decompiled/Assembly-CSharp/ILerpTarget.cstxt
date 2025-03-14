using System.Collections.Generic;
using UnityEngine;

public interface ILerpTarget
{
	float GetExtrapolationTime();

	float GetInterpolationDelay();

	float GetInterpolationSmoothing();

	float GetInterpolationInertia();

	Vector3 GetNetworkPosition();

	Quaternion GetNetworkRotation();

	void SetNetworkPosition(Vector3 pos);

	void SetNetworkRotation(Quaternion rot);

	void DrawInterpolationState(TransformInterpolator.Segment segment, List<TransformInterpolator.Entry> entries);

	void LerpIdleDisable();
}
