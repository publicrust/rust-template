using UnityEngine;

public abstract class TOD_Light : MonoBehaviour
{
	private Light lightComponent;

	protected float GetIntensity()
	{
		if ((bool)lightComponent)
		{
			return lightComponent.intensity;
		}
		return 0f;
	}

	protected void SetIntensity(float value)
	{
		if ((bool)lightComponent)
		{
			lightComponent.intensity = value;
			lightComponent.enabled = value > 0f;
		}
	}

	protected void Awake()
	{
		lightComponent = GetComponent<Light>();
	}
}
