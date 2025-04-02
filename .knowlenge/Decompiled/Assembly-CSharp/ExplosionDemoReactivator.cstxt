using UnityEngine;

public class ExplosionDemoReactivator : MonoBehaviour
{
	public float TimeDelayToReactivate = 3f;

	private void Start()
	{
		InvokeRepeating("Reactivate", 0f, TimeDelayToReactivate);
	}

	private void Reactivate()
	{
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
		foreach (Transform obj in componentsInChildren)
		{
			obj.gameObject.SetActive(value: false);
			obj.gameObject.SetActive(value: true);
		}
	}
}
