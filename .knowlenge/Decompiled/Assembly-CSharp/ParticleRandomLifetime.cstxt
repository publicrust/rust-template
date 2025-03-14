using UnityEngine;

public class ParticleRandomLifetime : MonoBehaviour
{
	public ParticleSystem mySystem;

	public float minScale = 0.5f;

	public float maxScale = 1f;

	public void Awake()
	{
		if ((bool)mySystem)
		{
			float startLifetime = Random.Range(minScale, maxScale);
			mySystem.startLifetime = startLifetime;
		}
	}
}
