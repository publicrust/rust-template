using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class AtmosphereVolumeRenderer : MonoBehaviour
{
	public FogMode Mode = (FogMode)3;

	public bool DistanceFog = true;

	public bool HeightFog = true;

	public AtmosphereVolume Volume;

	private static bool isSupported
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)Application.platform != 0)
			{
				return (int)Application.platform != 1;
			}
			return false;
		}
	}
}
