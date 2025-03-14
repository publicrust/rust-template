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
		rigidBody.centerOfMass = com.localPosition;
	}

	public HelicopterInputState_t GetHelicopterInputState()
	{
		HelicopterInputState_t result = default(HelicopterInputState_t);
		result.throttle = (Input.GetKey(KeyCode.W) ? 1f : 0f);
		result.throttle -= (Input.GetKey(KeyCode.S) ? 1f : 0f);
		result.pitch = Input.GetAxis("Mouse Y");
		result.roll = 0f - Input.GetAxis("Mouse X");
		result.yaw = (Input.GetKey(KeyCode.D) ? 1f : 0f);
		result.yaw -= (Input.GetKey(KeyCode.A) ? 1f : 0f);
		result.pitch = Mathf.RoundToInt(result.pitch);
		result.roll = Mathf.RoundToInt(result.roll);
		return result;
	}

	public HelicopterInputState_t GetAIInputState()
	{
		HelicopterInputState_t result = default(HelicopterInputState_t);
		Vector3 vector = Vector3.Cross(Vector3.up, base.transform.right);
		float num = Vector3.Dot(Vector3.Cross(Vector3.up, vector), Vector3Ex.Direction2D(AIMoveTarget.position, base.transform.position));
		result.yaw = ((num < 0f) ? 1f : 0f);
		result.yaw -= ((num > 0f) ? 1f : 0f);
		float num2 = Vector3.Dot(Vector3.up, base.transform.right);
		result.roll = ((num2 < 0f) ? 1f : 0f);
		result.roll -= ((num2 > 0f) ? 1f : 0f);
		float num3 = Vector3Ex.Distance2D(base.transform.position, AIMoveTarget.position);
		float num4 = Vector3.Dot(vector, Vector3Ex.Direction2D(AIMoveTarget.position, base.transform.position));
		float num5 = Vector3.Dot(Vector3.up, base.transform.forward);
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
		float y = base.transform.position.y;
		float num6 = 0f;
		num6 = ((y > idealAltitude + altitudeTolerance) ? (-1f) : ((y < idealAltitude - altitudeTolerance) ? 1f : ((!(num3 > 20f)) ? 0f : Mathf.Lerp(0f, 1f, num3 / 20f))));
		Debug.Log("desiredThrottle : " + num6);
		result.throttle = num6 * 1f;
		return result;
	}

	public float GetIdealAltitude()
	{
		return AIMoveTarget.transform.position.y;
	}

	public void FixedUpdate()
	{
		HelicopterInputState_t aIInputState = GetAIInputState();
		currentThrottle = Mathf.Lerp(currentThrottle, aIInputState.throttle, 2f * Time.fixedDeltaTime);
		currentThrottle = Mathf.Clamp(currentThrottle, -0.2f, 1f);
		rigidBody.AddRelativeTorque(new Vector3(aIInputState.pitch * torqueScale.x, aIInputState.yaw * torqueScale.y, aIInputState.roll * torqueScale.z) * Time.fixedDeltaTime, ForceMode.Force);
		avgThrust = Mathf.Lerp(avgThrust, engineThrustMax * currentThrottle, Time.fixedDeltaTime);
		float value = Mathf.Clamp01(Vector3.Dot(base.transform.up, Vector3.up));
		float num = Mathf.InverseLerp(liftDotMax, 1f, value);
		Vector3 force = Vector3.up * engineThrustMax * 0.5f * currentThrottle * num;
		Vector3 force2 = (base.transform.up - Vector3.up).normalized * engineThrustMax * currentThrottle * (1f - num);
		float num2 = rigidBody.mass * (0f - Physics.gravity.y);
		rigidBody.AddForce(base.transform.up * num2 * num * 0.99f, ForceMode.Force);
		rigidBody.AddForce(force, ForceMode.Force);
		rigidBody.AddForce(force2, ForceMode.Force);
		for (int i = 0; i < GroundEffects.Length; i++)
		{
			Transform obj = GroundPoints[i];
			Transform transform = GroundEffects[i];
			if (Physics.Raycast(obj.transform.position, Vector3.down, out var hitInfo, 50f, 8388608))
			{
				transform.gameObject.SetActive(value: true);
				transform.transform.position = hitInfo.point + new Vector3(0f, 1f, 0f);
			}
			else
			{
				transform.gameObject.SetActive(value: false);
			}
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(AIMoveTarget.transform.position, 1f);
		Vector3 vector = Vector3.Cross(base.transform.right, Vector3.up);
		Vector3 vector2 = Vector3.Cross(vector, Vector3.up);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(base.transform.position, base.transform.position + vector * 10f);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + vector2 * 10f);
	}
}
