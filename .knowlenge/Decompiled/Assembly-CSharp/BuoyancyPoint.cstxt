using UnityEngine;

public class BuoyancyPoint : MonoBehaviour
{
	public float buoyancyForce = 10f;

	public float size = 0.1f;

	public float randomOffset;

	public float waveScale = 0.2f;

	public float waveFrequency = 1f;

	public bool wasSubmergedLastFrame;

	public float nexSplashTime;

	public bool doSplashEffects = true;

	public void Start()
	{
		randomOffset = Random.Range(0f, 20f);
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(base.transform.position, size * 0.5f);
	}
}
