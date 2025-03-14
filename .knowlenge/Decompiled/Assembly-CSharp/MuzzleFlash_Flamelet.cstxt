using UnityEngine;

public class MuzzleFlash_Flamelet : MonoBehaviour
{
	public ParticleSystem flameletParticle;

	private void OnEnable()
	{
		ParticleSystem.ShapeModule shape = flameletParticle.shape;
		shape.angle = Random.Range(6, 13);
		float num = Random.Range(7f, 9f);
		flameletParticle.startSpeed = Random.Range(2.5f, num);
		flameletParticle.startSize = Random.Range(0.05f, num * 0.015f);
	}
}
