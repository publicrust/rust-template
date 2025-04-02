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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = ((Component)this).transform;
		Quaternion val = ((Component)this).transform.rotation;
		transform.rotation = Quaternion.Euler(((Quaternion)(ref val)).eulerAngles + rotation * speed * Time.deltaTime);
		Transform transform2 = ((Component)this).transform;
		transform2.localScale += scale * speed * Time.deltaTime;
		Transform transform3 = ((Component)this).transform;
		transform3.localPosition += position * speed * Time.deltaTime;
	}
}
