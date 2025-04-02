using UnityEngine;

public class ExplosionDemoReactivator : MonoBehaviour
{
	public float TimeDelayToReactivate = 3f;

	private void Start()
	{
		((MonoBehaviour)this).InvokeRepeating("Reactivate", 0f, TimeDelayToReactivate);
	}

	private void Reactivate()
	{
		Transform[] componentsInChildren = ((Component)this).GetComponentsInChildren<Transform>();
		foreach (Transform obj in componentsInChildren)
		{
			((Component)obj).gameObject.SetActive(false);
			((Component)obj).gameObject.SetActive(true);
		}
	}
}
