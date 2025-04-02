using UnityEngine;

public class sedanAnimation : MonoBehaviour
{
	public Transform[] frontAxles;

	public Transform FL_shock;

	public Transform FL_wheel;

	public Transform FR_shock;

	public Transform FR_wheel;

	public Transform RL_shock;

	public Transform RL_wheel;

	public Transform RR_shock;

	public Transform RR_wheel;

	public WheelCollider FL_wheelCollider;

	public WheelCollider FR_wheelCollider;

	public WheelCollider RL_wheelCollider;

	public WheelCollider RR_wheelCollider;

	public Transform steeringWheel;

	public float motorForceConstant = 150f;

	public float brakeForceConstant = 500f;

	public float brakePedal;

	public float gasPedal;

	public float steering;

	private Rigidbody myRigidbody;

	public float GasLerpTime = 20f;

	public float SteeringLerpTime = 20f;

	private float wheelSpinConstant = 120f;

	private float shockRestingPosY = -0.27f;

	private float shockDistance = 0.3f;

	private float traceDistanceNeutralPoint = 0.7f;

	private void Start()
	{
		myRigidbody = ((Component)this).GetComponent<Rigidbody>();
	}

	private void Update()
	{
		DoSteering();
		ApplyForceAtWheels();
		UpdateTireAnimation();
		InputPlayer();
	}

	private void InputPlayer()
	{
		if (Input.GetKey((KeyCode)119))
		{
			gasPedal = Mathf.Clamp(gasPedal + Time.deltaTime * GasLerpTime, -100f, 100f);
			brakePedal = Mathf.Lerp(brakePedal, 0f, Time.deltaTime * GasLerpTime);
		}
		else if (Input.GetKey((KeyCode)115))
		{
			gasPedal = Mathf.Clamp(gasPedal - Time.deltaTime * GasLerpTime, -100f, 100f);
			brakePedal = Mathf.Lerp(brakePedal, 0f, Time.deltaTime * GasLerpTime);
		}
		else
		{
			gasPedal = Mathf.Lerp(gasPedal, 0f, Time.deltaTime * GasLerpTime);
			brakePedal = Mathf.Lerp(brakePedal, 100f, Time.deltaTime * GasLerpTime / 5f);
		}
		if (Input.GetKey((KeyCode)97))
		{
			steering = Mathf.Clamp(steering - Time.deltaTime * SteeringLerpTime, -60f, 60f);
		}
		else if (Input.GetKey((KeyCode)100))
		{
			steering = Mathf.Clamp(steering + Time.deltaTime * SteeringLerpTime, -60f, 60f);
		}
		else
		{
			steering = Mathf.Lerp(steering, 0f, Time.deltaTime * SteeringLerpTime);
		}
	}

	private void DoSteering()
	{
		FL_wheelCollider.steerAngle = steering;
		FR_wheelCollider.steerAngle = steering;
	}

	private void ApplyForceAtWheels()
	{
		if (FL_wheelCollider.isGrounded)
		{
			FL_wheelCollider.motorTorque = gasPedal * motorForceConstant;
			FL_wheelCollider.brakeTorque = brakePedal * brakeForceConstant;
		}
		if (FR_wheelCollider.isGrounded)
		{
			FR_wheelCollider.motorTorque = gasPedal * motorForceConstant;
			FR_wheelCollider.brakeTorque = brakePedal * brakeForceConstant;
		}
		if (RL_wheelCollider.isGrounded)
		{
			RL_wheelCollider.motorTorque = gasPedal * motorForceConstant;
			RL_wheelCollider.brakeTorque = brakePedal * brakeForceConstant;
		}
		if (RR_wheelCollider.isGrounded)
		{
			RR_wheelCollider.motorTorque = gasPedal * motorForceConstant;
			RR_wheelCollider.brakeTorque = brakePedal * brakeForceConstant;
		}
	}

	private void UpdateTireAnimation()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		float num = Vector3.Dot(myRigidbody.velocity, ((Component)myRigidbody).transform.forward);
		if (FL_wheelCollider.isGrounded)
		{
			FL_shock.localPosition = new Vector3(FL_shock.localPosition.x, shockRestingPosY + GetShockHeightDelta(FL_wheelCollider), FL_shock.localPosition.z);
			FL_wheel.localEulerAngles = new Vector3(FL_wheel.localEulerAngles.x, FL_wheel.localEulerAngles.y, FL_wheel.localEulerAngles.z - num * Time.deltaTime * wheelSpinConstant);
		}
		else
		{
			FL_shock.localPosition = Vector3.Lerp(FL_shock.localPosition, new Vector3(FL_shock.localPosition.x, shockRestingPosY, FL_shock.localPosition.z), Time.deltaTime * 2f);
		}
		if (FR_wheelCollider.isGrounded)
		{
			FR_shock.localPosition = new Vector3(FR_shock.localPosition.x, shockRestingPosY + GetShockHeightDelta(FR_wheelCollider), FR_shock.localPosition.z);
			FR_wheel.localEulerAngles = new Vector3(FR_wheel.localEulerAngles.x, FR_wheel.localEulerAngles.y, FR_wheel.localEulerAngles.z - num * Time.deltaTime * wheelSpinConstant);
		}
		else
		{
			FR_shock.localPosition = Vector3.Lerp(FR_shock.localPosition, new Vector3(FR_shock.localPosition.x, shockRestingPosY, FR_shock.localPosition.z), Time.deltaTime * 2f);
		}
		if (RL_wheelCollider.isGrounded)
		{
			RL_shock.localPosition = new Vector3(RL_shock.localPosition.x, shockRestingPosY + GetShockHeightDelta(RL_wheelCollider), RL_shock.localPosition.z);
			RL_wheel.localEulerAngles = new Vector3(RL_wheel.localEulerAngles.x, RL_wheel.localEulerAngles.y, RL_wheel.localEulerAngles.z - num * Time.deltaTime * wheelSpinConstant);
		}
		else
		{
			RL_shock.localPosition = Vector3.Lerp(RL_shock.localPosition, new Vector3(RL_shock.localPosition.x, shockRestingPosY, RL_shock.localPosition.z), Time.deltaTime * 2f);
		}
		if (RR_wheelCollider.isGrounded)
		{
			RR_shock.localPosition = new Vector3(RR_shock.localPosition.x, shockRestingPosY + GetShockHeightDelta(RR_wheelCollider), RR_shock.localPosition.z);
			RR_wheel.localEulerAngles = new Vector3(RR_wheel.localEulerAngles.x, RR_wheel.localEulerAngles.y, RR_wheel.localEulerAngles.z - num * Time.deltaTime * wheelSpinConstant);
		}
		else
		{
			RR_shock.localPosition = Vector3.Lerp(RR_shock.localPosition, new Vector3(RR_shock.localPosition.x, shockRestingPosY, RR_shock.localPosition.z), Time.deltaTime * 2f);
		}
		Transform[] array = frontAxles;
		foreach (Transform val in array)
		{
			val.localEulerAngles = new Vector3(steering, val.localEulerAngles.y, val.localEulerAngles.z);
		}
	}

	private float GetShockHeightDelta(WheelCollider wheel)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		int mask = LayerMask.GetMask(new string[3] { "Terrain", "World", "Construction" });
		RaycastHit val = default(RaycastHit);
		Physics.Linecast(((Component)wheel).transform.position, ((Component)wheel).transform.position - Vector3.up * 10f, ref val, mask);
		return Mathx.RemapValClamped(((RaycastHit)(ref val)).distance, traceDistanceNeutralPoint - shockDistance, traceDistanceNeutralPoint + shockDistance, shockDistance * 0.75f, -0.75f * shockDistance);
	}
}
