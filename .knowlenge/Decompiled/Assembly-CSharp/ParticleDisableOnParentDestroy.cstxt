using UnityEngine;

public class ParticleDisableOnParentDestroy : MonoBehaviour, IOnParentDestroying
{
	public float destroyAfterSeconds;

	public void OnParentDestroying()
	{
		base.transform.parent = null;
		ParticleSystem component = GetComponent<ParticleSystem>();
		if ((bool)component)
		{
			component.enableEmission = false;
		}
		if (destroyAfterSeconds > 0f)
		{
			GameManager.Destroy(base.gameObject, destroyAfterSeconds);
		}
	}
}
