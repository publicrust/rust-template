using UnityEngine;

public class ParticleSystemPlayer : MonoBehaviour, IOnParentDestroying
{
	protected void OnEnable()
	{
		((Component)this).GetComponent<ParticleSystem>().enableEmission = true;
	}

	public void OnParentDestroying()
	{
		((Component)this).GetComponent<ParticleSystem>().enableEmission = false;
	}
}
