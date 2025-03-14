using UnityEngine;

public class ScaleBySpeed : MonoBehaviour
{
	public float minScale = 0.001f;

	public float maxScale = 1f;

	public float minSpeed;

	public float maxSpeed = 1f;

	public MonoBehaviour component;

	public bool toggleComponent = true;

	public bool onlyWhenSubmerged;

	public float submergedThickness = 0.33f;

	private Vector3 prevPosition = Vector3.zero;

	private void Start()
	{
		prevPosition = base.transform.position;
	}

	private void Update()
	{
		Vector3 position = base.transform.position;
		float sqrMagnitude = (position - prevPosition).sqrMagnitude;
		float num = minScale;
		bool flag = WaterSystem.GetHeight(position) > position.y - submergedThickness;
		if (sqrMagnitude > 0.0001f)
		{
			sqrMagnitude = Mathf.Sqrt(sqrMagnitude);
			float value = Mathf.Clamp(sqrMagnitude, minSpeed, maxSpeed) / (maxSpeed - minSpeed);
			num = Mathf.Lerp(minScale, maxScale, Mathf.Clamp01(value));
			if (component != null && toggleComponent)
			{
				component.enabled = flag;
			}
		}
		else if (component != null && toggleComponent)
		{
			component.enabled = false;
		}
		base.transform.localScale = new Vector3(num, num, num);
		prevPosition = position;
	}
}
