using UnityEngine;

public class MuzzleFlash_Flamelet : MonoBehaviour
{
	public ParticleSystem flameletParticle;

	private void OnEnable()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		ShapeModule shape = flameletParticle.shape;
		((ShapeModule)(ref shape)).angle = Random.Range(6, 13);
		float num = Random.Range(7f, 9f);
		flameletParticle.startSpeed = Random.Range(2.5f, num);
		flameletParticle.startSize = Random.Range(0.05f, num * 0.015f);
	}
}
