using UnityEngine;

public class DestroyArcadeEntity : BaseMonoBehaviour
{
	public ArcadeEntity ent;

	public float TimeToDie = 1f;

	public float TimeToDieVariance;

	private void Start()
	{
		Invoke(DestroyAction, TimeToDie + Random.Range(TimeToDieVariance * -0.5f, TimeToDieVariance * 0.5f));
	}

	private void DestroyAction()
	{
		if ((ent != null) & ent.host)
		{
			Object.Destroy(ent.gameObject);
		}
	}
}
