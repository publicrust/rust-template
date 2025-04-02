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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		lastPosition = ((Component)this).transform.position;
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		lastPosition = ((Component)this).transform.position;
	}

	private void UpdateForwardBackTilting()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Vector3 currentMoveDirection = GetCurrentMoveDirection();
		float num = Vector3.Angle(currentMoveDirection, ((Component)this).transform.forward);
		float num2 = Vector3.Angle(currentMoveDirection, -((Component)this).transform.forward);
		float num3 = 1f - Mathf.Clamp01(num / degreeMax);
		float num4 = 1f - Mathf.Clamp01(num2 / degreeMax);
		float num5 = num3 - num4;
		lastForwardBackScalar = Mathf.Lerp(lastForwardBackScalar, num5, Time.deltaTime * 2f);
	}

	private void UpdateStrafeTilting()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Vector3 currentMoveDirection = GetCurrentMoveDirection();
		float num = Vector3.Angle(currentMoveDirection, ((Component)this).transform.right);
		float num2 = Vector3.Angle(currentMoveDirection, -((Component)this).transform.right);
		float num3 = 1f - Mathf.Clamp01(num / degreeMax);
		float num4 = 1f - Mathf.Clamp01(num2 / degreeMax);
		float num5 = num3 - num4;
		lastStrafeScalar = Mathf.Lerp(lastStrafeScalar, num5, Time.deltaTime * 2f);
	}

	private void ModifyHelicopterAngles()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = ((Component)this).transform.position - lastPosition;
		return ((Vector3)(ref val)).normalized;
	}
}
