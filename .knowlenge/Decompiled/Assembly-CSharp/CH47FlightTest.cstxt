using UnityEngine;

public class CH47FlightTest : MonoBehaviour
{
	public struct HelicopterInputState_t
	{
		public float throttle;

		public float roll;

		public float yaw;

		public float pitch;
	}

	public Rigidbody rigidBody;

	public float engineThrustMax;

	public Vector3 torqueScale;

	public Transform com;

	public Transform[] GroundPoints;

	public Transform[] GroundEffects;

	public float currentThrottle;

	public float avgThrust;

	public float liftDotMax = 0.75f;

	public Transform AIMoveTarget;

	private static float altitudeTolerance = 1f;

	public void Awake()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		rigidBody.centerOfMass = com.localPosition;
	}

	public HelicopterInputState_t GetHelicopterInputState()
	{
		HelicopterInputState_t result = default(HelicopterInputState_t);
		result.throttle = (Input.GetKey((KeyCode)119) ? 1f : 0f);
		result.throttle -= (Input.GetKey((KeyCode)115) ? 1f : 0f);
		result.pitch = Input.GetAxis("Mouse Y");
		result.roll = 0f - Input.GetAxis("Mouse X");
		result.yaw = (Input.GetKey((KeyCode)100) ? 1f : 0f);
		result.yaw -= (Input.GetKey((KeyCode)97) ? 1f : 0f);
		result.pitch = Mathf.RoundToInt(result.pitch);
		result.roll = Mathf.RoundToInt(result.roll);
		return result;
	}

	public HelicopterInputState_t GetAIInputState()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		HelicopterInputState_t result = default(HelicopterInputState_t);
		Vector3 val = Vector3.Cross(Vector3.up, ((Component)this).transform.right);
		float num = Vector3.Dot(Vector3.Cross(Vector3.up, val), Vector3Ex.Direction2D(AIMoveTarget.position, ((Component)this).transform.position));
		result.yaw = ((num < 0f) ? 1f : 0f);
		result.yaw -= ((num > 0f) ? 1f : 0f);
		float num2 = Vector3.Dot(Vector3.up, ((Component)this).transform.right);
		result.roll = ((num2 < 0f) ? 1f : 0f);
		result.roll -= ((num2 > 0f) ? 1f : 0f);
		float num3 = Vector3Ex.Distance2D(((Component)this).transform.position, AIMoveTarget.position);
		float num4 = Vector3.Dot(val, Vector3Ex.Direction2D(AIMoveTarget.position, ((Component)this).transform.position));
		float num5 = Vector3.Dot(Vector3.up, ((Component)this).transform.forward);
		if (num3 > 10f)
		{
			result.pitch = ((num4 > 0.8f) ? (-0.25f) : 0f);
			result.pitch -= ((num4 < -0.8f) ? (-0.25f) : 0f);
			if (num5 < -0.35f)
			{
				result.pitch = -1f;
			}
			else if (num5 > 0.35f)
			{
				result.pitch = 1f;
			}
		}
		else if (num5 < -0f)
		{
			result.pitch = -1f;
		}
		else if (num5 > 0f)
		{
			result.pitch = 1f;
		}
		float idealAltitude = GetIdealAltitude();
		float y = ((Component)this).transform.position.y;
		float num6 = 0f;
		num6 = ((y > idealAltitude + altitudeTolerance) ? (-1f) : ((y < idealAltitude - altitudeTolerance) ? 1f : ((!(num3 > 20f)) ? 0f : Mathf.Lerp(0f, 1f, num3 / 20f))));
		Debug.Log((object)("desiredThrottle : " + num6));
		result.throttle = num6 * 1f;
		return result;
	}

	public float GetIdealAltitude()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return ((Component)AIMoveTarget).transform.position.y;
	}

	public void FixedUpdate()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		HelicopterInputState_t aIInputState = GetAIInputState();
		currentThrottle = Mathf.Lerp(currentThrottle, aIInputState.throttle, 2f * Time.fixedDeltaTime);
		currentThrottle = Mathf.Clamp(currentThrottle, -0.2f, 1f);
		rigidBody.AddRelativeTorque(new Vector3(aIInputState.pitch * torqueScale.x, aIInputState.yaw * torqueScale.y, aIInputState.roll * torqueScale.z) * Time.fixedDeltaTime, (ForceMode)0);
		avgThrust = Mathf.Lerp(avgThrust, engineThrustMax * currentThrottle, Time.fixedDeltaTime);
		float num = Mathf.Clamp01(Vector3.Dot(((Component)this).transform.up, Vector3.up));
		float num2 = Mathf.InverseLerp(liftDotMax, 1f, num);
		Vector3 val = Vector3.up * engineThrustMax * 0.5f * currentThrottle * num2;
		Vector3 val2 = ((Component)this).transform.up - Vector3.up;
		Vector3 val3 = ((Vector3)(ref val2)).normalized * engineThrustMax * currentThrottle * (1f - num2);
		float num3 = rigidBody.mass * (0f - Physics.gravity.y);
		rigidBody.AddForce(((Component)this).transform.up * num3 * num2 * 0.99f, (ForceMode)0);
		rigidBody.AddForce(val, (ForceMode)0);
		rigidBody.AddForce(val3, (ForceMode)0);
		RaycastHit val5 = default(RaycastHit);
		for (int i = 0; i < GroundEffects.Length; i++)
		{
			Transform obj = GroundPoints[i];
			Transform val4 = GroundEffects[i];
			if (Physics.Raycast(((Component)obj).transform.position, Vector3.down, ref val5, 50f, 8388608))
			{
				((Component)val4).gameObject.SetActive(true);
				((Component)val4).transform.position = ((RaycastHit)(ref val5)).point + new Vector3(0f, 1f, 0f);
			}
			else
			{
				((Component)val4).gameObject.SetActive(false);
			}
		}
	}

	public void OnDrawGizmos()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(((Component)AIMoveTarget).transform.position, 1f);
		Vector3 val = Vector3.Cross(((Component)this).transform.right, Vector3.up);
		Vector3 val2 = Vector3.Cross(val, Vector3.up);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(((Component)this).transform.position, ((Component)this).transform.position + val * 10f);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(((Component)this).transform.position, ((Component)this).transform.position + val2 * 10f);
	}
}
