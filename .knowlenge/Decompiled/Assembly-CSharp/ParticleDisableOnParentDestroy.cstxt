using UnityEngine;

public class ParticleDisableOnParentDestroy : MonoBehaviour, IOnParentDestroying
{
	public float destroyAfterSeconds;

	public void OnParentDestroying()
	{
		((Component)this).transform.parent = null;
		ParticleSystem component = ((Component)this).GetComponent<ParticleSystem>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.enableEmission = false;
		}
		if (destroyAfterSeconds > 0f)
		{
			GameManager.Destroy(((Component)this).gameObject, destroyAfterSeconds);
		}
	}
}
