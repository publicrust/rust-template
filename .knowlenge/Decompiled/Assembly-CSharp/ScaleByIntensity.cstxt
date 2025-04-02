using UnityEngine;

public class ScaleByIntensity : MonoBehaviour
{
	public Vector3 initialScale = Vector3.zero;

	public Light intensitySource;

	public float maxIntensity = 1f;

	private void Start()
	{
		initialScale = base.transform.localScale;
	}

	private void Update()
	{
		base.transform.localScale = (intensitySource.enabled ? (initialScale * intensitySource.intensity / maxIntensity) : Vector3.zero);
	}
}
