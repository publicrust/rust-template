using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class AtmosphereVolumeRenderer : MonoBehaviour
{
	public FogMode Mode = FogMode.ExponentialSquared;

	public bool DistanceFog = true;

	public bool HeightFog = true;

	public AtmosphereVolume Volume;

	private static bool isSupported
	{
		get
		{
			if (Application.platform != 0)
			{
				return Application.platform != RuntimePlatform.OSXPlayer;
			}
			return false;
		}
	}
}
