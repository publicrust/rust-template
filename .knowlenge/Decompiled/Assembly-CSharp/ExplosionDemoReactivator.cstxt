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
		Transform[] array = componentsInChildren;
		foreach (Transform transform in array)
		{
			transform.gameObject.SetActive(value: false);
			transform.gameObject.SetActive(value: true);
		}
	}
}
