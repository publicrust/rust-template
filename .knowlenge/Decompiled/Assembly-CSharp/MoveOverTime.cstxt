using UnityEngine;

public class MoveOverTime : MonoBehaviour
{
	[Range(-10f, 10f)]
	public float speed = 1f;

	public Vector3 position;

	public Vector3 rotation;

	public Vector3 scale;

	private void Update()
	{
		base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles + rotation * speed * Time.deltaTime);
		base.transform.localScale += scale * speed * Time.deltaTime;
		base.transform.localPosition += position * speed * Time.deltaTime;
	}
}
