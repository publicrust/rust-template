using UnityEngine;

public class TOD_Billboard : MonoBehaviour
{
	public float Altitude;

	public float Azimuth;

	public float Distance = 1f;

	public float Size = 1f;

	private T GetComponentInParents<T>() where T : Component
	{
		Transform parent = base.transform;
		T component = parent.GetComponent<T>();
		while (component == null && parent.parent != null)
		{
			parent = parent.parent;
			component = parent.GetComponent<T>();
		}
		return component;
	}
}
