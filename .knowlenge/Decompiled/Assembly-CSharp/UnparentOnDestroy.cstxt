using UnityEngine;

public class UnparentOnDestroy : MonoBehaviour, IOnParentDestroying
{
	public float destroyAfterSeconds = 1f;

	public void OnParentDestroying()
	{
		((Component)this).transform.parent = null;
		GameManager.Destroy(((Component)this).gameObject, (destroyAfterSeconds <= 0f) ? 1f : destroyAfterSeconds);
	}

	protected void OnValidate()
	{
		if (destroyAfterSeconds <= 0f)
		{
			destroyAfterSeconds = 1f;
		}
	}
}
