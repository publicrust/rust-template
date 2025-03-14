using System;
using ConVar;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraUpdateHook : MonoBehaviour
{
	public static Action PreCull;

	public static Action PreRender;

	public static Action PostRender;

	public static Action RustCamera_PreRender;

	public static float LastFrameFOV = ConVar.Graphics.fov;

	private void Awake()
	{
		CameraUpdateHook[] components = GetComponents<CameraUpdateHook>();
		foreach (CameraUpdateHook cameraUpdateHook in components)
		{
			if (cameraUpdateHook != this)
			{
				UnityEngine.Object.DestroyImmediate(cameraUpdateHook);
			}
		}
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, (Camera.CameraCallback)delegate
		{
			LastFrameFOV = MainCamera.mainCamera?.fieldOfView ?? ConVar.Graphics.fov;
			PreRender?.Invoke();
		});
		Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, (Camera.CameraCallback)delegate
		{
			PostRender?.Invoke();
		});
		Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, (Camera.CameraCallback)delegate
		{
			PreCull?.Invoke();
		});
	}
}
