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
			GameObject obj = Object.Instantiate(source);
			obj.transform.position = base.transform.position + Vector3Ex.Range(0f - radius, radius);
			obj.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
		}
	}
}
