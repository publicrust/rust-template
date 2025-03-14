using UnityEngine;

public class AIHelicopterAnimation : MonoBehaviour
{
	public PatrolHelicopterAI _ai;

	public float swayAmount = 1f;

	public float lastStrafeScalar;

	public float lastForwardBackScalar;

	public float degreeMax = 90f;

	public Vector3 lastPosition = Vector3.zero;

	public float oldMoveSpeed;

	public float smoothRateOfChange;

	public float flareAmount;

	public void Awake()
	{
		lastPosition = base.transform.position;
	}

	public Vector3 GetMoveDirection()
	{
		return _ai.GetMoveDirection();
	}

	public float GetMoveSpeed()
	{
		return _ai.GetMoveSpeed();
	}

	public void Update()
	{
		lastPosition = base.transform.position;
		Vector3 moveDirection = GetMoveDirection();
		float moveSpeed = GetMoveSpeed();
		float num = 0.25f + Mathf.Clamp01(moveSpeed / _ai.maxSpeed) * 0.75f;
		smoothRateOfChange = Mathf.Lerp(smoothRateOfChange, moveSpeed - oldMoveSpeed, Time.deltaTime * 5f);
		oldMoveSpeed = moveSpeed;
		float num2 = Vector3.Angle(moveDirection, base.transform.forward);
		float num3 = Vector3.Angle(moveDirection, -base.transform.forward);
		float num4 = 1f - Mathf.Clamp01(num2 / degreeMax);
		float num5 = 1f - Mathf.Clamp01(num3 / degreeMax);
		float b = (num4 - num5) * num;
		float num6 = (lastForwardBackScalar = Mathf.Lerp(lastForwardBackScalar, b, Time.deltaTime * 2f));
		float num7 = Vector3.Angle(moveDirection, base.transform.right);
		float num8 = Vector3.Angle(moveDirection, -base.transform.right);
		float num9 = 1f - Mathf.Clamp01(num7 / degreeMax);
		float num10 = 1f - Mathf.Clamp01(num8 / degreeMax);
		float b2 = (num9 - num10) * num;
		float num11 = (lastStrafeScalar = Mathf.Lerp(lastStrafeScalar, b2, Time.deltaTime * 2f));
		Vector3 zero = Vector3.zero;
		zero.x += num6 * swayAmount;
		zero.z -= num11 * swayAmount;
		Quaternion identity = Quaternion.identity;
		identity = Quaternion.Euler(zero.x, zero.y, zero.z);
		_ai.helicopterBase.rotorPivot.transform.localRotation = identity;
	}
}
