using System;
using UnityEngine;

public class CameraUpdateHook : MonoBehaviour
{
	public static Action PreCull;

	public static Action PreRender;

	public static Action PostRender;

	public static Action RustCamera_PreRender;

	private void Awake()
	{
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, (Camera.CameraCallback)delegate
		{
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
