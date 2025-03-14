using ConVar;
using UnityEngine;

public class SunSettings : MonoBehaviour, IClientComponent
{
	private Light light;

	private void OnEnable()
	{
		light = GetComponent<Light>();
	}

	private void Update()
	{
		LightShadows lightShadows = (LightShadows)Mathf.Clamp(ConVar.Graphics.shadowmode, 1, 2);
		if (light.shadows != lightShadows)
		{
			light.shadows = lightShadows;
		}
	}
}
