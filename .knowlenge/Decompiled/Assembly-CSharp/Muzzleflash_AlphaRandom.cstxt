using UnityEngine;

public class Muzzleflash_AlphaRandom : MonoBehaviour
{
	public ParticleSystem[] muzzleflashParticles;

	private Gradient grad = new Gradient();

	private GradientColorKey[] gck = (GradientColorKey[])(object)new GradientColorKey[3];

	private GradientAlphaKey[] gak = (GradientAlphaKey[])(object)new GradientAlphaKey[3];

	private void Start()
	{
	}

	private void OnEnable()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		gck[0].color = Color.white;
		gck[0].time = 0f;
		gck[1].color = Color.white;
		gck[1].time = 0.6f;
		gck[2].color = Color.black;
		gck[2].time = 0.75f;
		float alpha = Random.Range(0.2f, 0.85f);
		gak[0].alpha = alpha;
		gak[0].time = 0f;
		gak[1].alpha = alpha;
		gak[1].time = 0.45f;
		gak[2].alpha = 0f;
		gak[2].time = 0.5f;
		grad.SetKeys(gck, gak);
		ParticleSystem[] array = muzzleflashParticles;
		foreach (ParticleSystem val in array)
		{
			if ((Object)(object)val == (Object)null)
			{
				Debug.LogWarning((object)("Muzzleflash_AlphaRandom : null particle system in " + ((Object)((Component)this).gameObject).name));
				continue;
			}
			ColorOverLifetimeModule colorOverLifetime = val.colorOverLifetime;
			((ColorOverLifetimeModule)(ref colorOverLifetime)).color = MinMaxGradient.op_Implicit(grad);
		}
	}
}
