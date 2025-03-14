using System;
using UnityEngine;

[ExecuteInEditMode]
public class MainCamera : RustCamera<MainCamera>
{
	public static Camera mainCamera;

	public static Transform mainCameraTransform;

	public static Action PreCullCallback;

	public static bool isValid
	{
		get
		{
			if (mainCamera != null && mainCameraTransform != null)
			{
				return mainCamera.enabled;
			}
			return false;
		}
	}

	public static Vector3 velocity { get; private set; }

	public static Vector3 position
	{
		get
		{
			return mainCameraTransform.position;
		}
		set
		{
			mainCameraTransform.position = value;
		}
	}

	public static Vector3 forward
	{
		get
		{
			return mainCameraTransform.forward;
		}
		set
		{
			if (value.sqrMagnitude > 0f)
			{
				mainCameraTransform.forward = value;
			}
		}
	}

	public static Vector3 right
	{
		get
		{
			return mainCameraTransform.right;
		}
		set
		{
			if (value.sqrMagnitude > 0f)
			{
				mainCameraTransform.right = value;
			}
		}
	}

	public static Vector3 up
	{
		get
		{
			return mainCameraTransform.up;
		}
		set
		{
			if (value.sqrMagnitude > 0f)
			{
				mainCamera.transform.up = value;
			}
		}
	}

	public static Quaternion rotation
	{
		get
		{
			return mainCameraTransform.rotation;
		}
		set
		{
			mainCameraTransform.rotation = value;
		}
	}

	public static Ray Ray => new Ray(position, forward);
}
