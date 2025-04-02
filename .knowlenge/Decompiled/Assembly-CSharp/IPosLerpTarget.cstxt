using System.Collections.Generic;
using Rust.Interpolation;
using UnityEngine;

public interface IPosLerpTarget : ILerpInfo
{
	float GetInterpolationInertia();

	Vector3 GetNetworkPosition();

	Quaternion GetNetworkRotation();

	void SetNetworkPosition(Vector3 pos);

	void SetNetworkRotation(Quaternion rot);

	void DrawInterpolationState(Interpolator<TransformSnapshot>.Segment segment, List<TransformSnapshot> entries);

	void LerpIdleDisable();
}
