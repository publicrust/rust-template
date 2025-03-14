using UnityEngine;

public class ParticleSystemPlayer : MonoBehaviour, IOnParentDestroying
{
	protected void OnEnable()
	{
		GetComponent<ParticleSystem>().enableEmission = true;
	}

	public void OnParentDestroying()
	{
		GetComponent<ParticleSystem>().enableEmission = false;
	}
}
