using UnityEngine;

public class UnparentOnDestroy : MonoBehaviour, IOnParentDestroying
{
	public float destroyAfterSeconds = 1f;

	public void OnParentDestroying()
	{
		base.transform.parent = null;
		GameManager.Destroy(base.gameObject, (destroyAfterSeconds <= 0f) ? 1f : destroyAfterSeconds);
	}

	protected void OnValidate()
	{
		if (destroyAfterSeconds <= 0f)
		{
			destroyAfterSeconds = 1f;
		}
	}
}
