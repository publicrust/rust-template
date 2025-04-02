using UnityEngine;

public class RandomObjectEnableOnEnable : MonoBehaviour
{
	public GameObject[] objects;

	public void OnEnable()
	{
		objects[Random.Range(0, objects.Length)].SetActive(value: true);
	}
}
