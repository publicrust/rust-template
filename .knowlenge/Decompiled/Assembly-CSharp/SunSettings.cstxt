using ConVar;
using UnityEngine;

public class SunSettings : MonoBehaviour, IClientComponent
{
	private Light light;

	private void OnEnable()
	{
		light = ((Component)this).GetComponent<Light>();
	}

	private void Update()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		LightShadows val = (LightShadows)Mathf.Clamp(Graphics.shadowmode, 1, 2);
		if (light.shadows != val)
		{
			light.shadows = val;
		}
	}
}
