using UnityEngine;

public class ScaleByIntensity : MonoBehaviour
{
	public Vector3 initialScale = Vector3.zero;

	public Light intensitySource;

	public float maxIntensity = 1f;

	private void Start()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		initialScale = ((Component)this).transform.localScale;
	}

	private void Update()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.localScale = (((Behaviour)intensitySource).enabled ? (initialScale * intensitySource.intensity / maxIntensity) : Vector3.zero);
	}
}
