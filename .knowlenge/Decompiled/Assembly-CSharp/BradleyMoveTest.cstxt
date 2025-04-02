using UnityEngine;

public class BradleyMoveTest : MonoBehaviour
{
	public WheelCollider[] leftWheels;

	public WheelCollider[] rightWheels;

	public float moveForceMax = 2000f;

	public float brakeForce = 100f;

	public float throttle = 1f;

	public float turnForce = 2000f;

	public float sideStiffnessMax = 1f;

	public float sideStiffnessMin = 0.5f;

	public Transform centerOfMass;

	public float turning;

	public bool brake;

	public Rigidbody myRigidBody;

	public Vector3 destination;

	public float stoppingDist = 5f;

	public GameObject followTest;

	public void Awake()
	{
		Initialize();
	}

	public void Initialize()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		myRigidBody.centerOfMass = centerOfMass.localPosition;
		destination = ((Component)this).transform.position;
	}

	public void SetDestination(Vector3 dest)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		destination = dest;
	}

	public void FixedUpdate()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		Vector3 velocity = myRigidBody.velocity;
		SetDestination(followTest.transform.position);
		float num = Vector3.Distance(((Component)this).transform.position, destination);
		if (num > stoppingDist)
		{
			Vector3 zero = Vector3.zero;
			float num2 = Vector3.Dot(zero, ((Component)this).transform.right);
			float num3 = Vector3.Dot(zero, -((Component)this).transform.right);
			float num4 = Vector3.Dot(zero, ((Component)this).transform.right);
			if (Vector3.Dot(zero, -((Component)this).transform.forward) > num4)
			{
				if (num2 >= num3)
				{
					turning = 1f;
				}
				else
				{
					turning = -1f;
				}
			}
			else
			{
				turning = num4;
			}
			throttle = Mathf.InverseLerp(stoppingDist, 30f, num);
		}
		throttle = Mathf.Clamp(throttle, -1f, 1f);
		float num5 = throttle;
		float num6 = throttle;
		if (turning > 0f)
		{
			num6 = 0f - turning;
			num5 = turning;
		}
		else if (turning < 0f)
		{
			num5 = turning;
			num6 = turning * -1f;
		}
		ApplyBrakes(brake ? 1f : 0f);
		float num7 = throttle;
		num5 = Mathf.Clamp(num5 + num7, -1f, 1f);
		num6 = Mathf.Clamp(num6 + num7, -1f, 1f);
		AdjustFriction();
		float num8 = Mathf.InverseLerp(3f, 1f, ((Vector3)(ref velocity)).magnitude * Mathf.Abs(Vector3.Dot(((Vector3)(ref velocity)).normalized, ((Component)this).transform.forward)));
		float torqueAmount = Mathf.Lerp(moveForceMax, turnForce, num8);
		SetMotorTorque(num5, rightSide: false, torqueAmount);
		SetMotorTorque(num6, rightSide: true, torqueAmount);
	}

	public void ApplyBrakes(float amount)
	{
		ApplyBrakeTorque(amount, rightSide: true);
		ApplyBrakeTorque(amount, rightSide: false);
	}

	public float GetMotorTorque(bool rightSide)
	{
		float num = 0f;
		WheelCollider[] array = (rightSide ? rightWheels : leftWheels);
		foreach (WheelCollider val in array)
		{
			num += val.motorTorque;
		}
		return num / (float)rightWheels.Length;
	}

	public void SetMotorTorque(float newThrottle, bool rightSide, float torqueAmount)
	{
		newThrottle = Mathf.Clamp(newThrottle, -1f, 1f);
		float motorTorque = torqueAmount * newThrottle;
		WheelCollider[] array = (rightSide ? rightWheels : leftWheels);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].motorTorque = motorTorque;
		}
	}

	public void ApplyBrakeTorque(float amount, bool rightSide)
	{
		WheelCollider[] array = (rightSide ? rightWheels : leftWheels);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].brakeTorque = brakeForce * amount;
		}
	}

	public void AdjustFriction()
	{
	}
}
