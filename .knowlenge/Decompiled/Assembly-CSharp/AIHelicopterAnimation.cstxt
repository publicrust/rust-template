using UnityEngine;

public class AIHelicopterAnimation : MonoBehaviour
{
	public PatrolHelicopterAI _ai;

	public float swayAmount = 1f;

	public float impactSwayAmount = 1f;

	public float lastStrafeScalar;

	public float lastForwardBackScalar;

	public float degreeMax = 90f;

	public Vector3 lastPosition = Vector3.zero;

	public float oldMoveSpeed;

	public float smoothRateOfChange;

	public float flareAmount;

	public float swaySmoothingFactor = 0.1f;

	private float smoothedTime;

	private void Awake()
	{
		lastPosition = base.transform.position;
	}

	public void UpdateAnimation()
	{
		UpdateForwardBackTilting();
		UpdateStrafeTilting();
		ModifyHelicopterAngles();
		smoothedTime = Mathf.Lerp(smoothedTime, Time.time, swaySmoothingFactor * Time.deltaTime);
	}

	public void UpdateLastPosition()
	{
		lastPosition = base.transform.position;
	}

	private void UpdateForwardBackTilting()
	{
		Vector3 currentMoveDirection = GetCurrentMoveDirection();
		float num = Vector3.Angle(currentMoveDirection, base.transform.forward);
		float num2 = Vector3.Angle(currentMoveDirection, -base.transform.forward);
		float num3 = 1f - Mathf.Clamp01(num / degreeMax);
		float num4 = 1f - Mathf.Clamp01(num2 / degreeMax);
		float b = num3 - num4;
		lastForwardBackScalar = Mathf.Lerp(lastForwardBackScalar, b, Time.deltaTime * 2f);
	}

	private void UpdateStrafeTilting()
	{
		Vector3 currentMoveDirection = GetCurrentMoveDirection();
		float num = Vector3.Angle(currentMoveDirection, base.transform.right);
		float num2 = Vector3.Angle(currentMoveDirection, -base.transform.right);
		float num3 = 1f - Mathf.Clamp01(num / degreeMax);
		float num4 = 1f - Mathf.Clamp01(num2 / degreeMax);
		float b = num3 - num4;
		lastStrafeScalar = Mathf.Lerp(lastStrafeScalar, b, Time.deltaTime * 2f);
	}

	private void ModifyHelicopterAngles()
	{
		Vector3 zero = Vector3.zero;
		zero.x += lastForwardBackScalar * impactSwayAmount;
		zero.z -= lastStrafeScalar * impactSwayAmount;
		zero.x += Mathf.Sin(smoothedTime) * swayAmount;
		zero.z -= Mathf.Cos(smoothedTime) * swayAmount / 2f;
		Quaternion localRotation = Quaternion.Euler(zero.x, zero.y, zero.z);
		_ai.helicopterBase.rotorPivot.transform.localRotation = localRotation;
	}

	private Vector3 GetCurrentMoveDirection()
	{
		return (base.transform.position - lastPosition).normalized;
	}
}
