using UnityEngine;

public class ObjectSpam : MonoBehaviour
{
	public GameObject source;

	public int amount = 1000;

	public float radius;

	private void Start()
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject gameObject = Object.Instantiate(source);
			gameObject.transform.position = base.transform.position + Vector3Ex.Range(0f - radius, radius);
			gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
		}
	}
}
