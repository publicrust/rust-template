using UnityEngine;

public class ObjectSpam : MonoBehaviour
{
	public GameObject source;

	public int amount = 1000;

	public float radius;

	private void Start()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < amount; i++)
		{
			GameObject obj = Object.Instantiate<GameObject>(source);
			obj.transform.position = ((Component)this).transform.position + Vector3Ex.Range(0f - radius, radius);
			((Object)obj).hideFlags = (HideFlags)3;
		}
	}
}
