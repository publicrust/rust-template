using System;
using UnityEngine;

public class BasicCar : BaseVehicle
{
	[Serializable]
	public class VehicleWheel
	{
		public Transform shock;

		public WheelCollider wheelCollider;

		public Transform wheel;

		public Transform axle;

		public bool steerWheel;

		public bool brakeWheel = true;

		public bool powerWheel = true;
	}

	public VehicleWheel[] wheels;

	public float brakePedal;

	public float gasPedal;

	public float steering;

	public Transform centerOfMass;

	public Transform steeringWheel;

	public float motorForceConstant = 150f;

	public float brakeForceConstant = 500f;

	public float GasLerpTime = 20f;

	public float SteeringLerpTime = 20f;

	public Transform driverEye;

	public GameObjectRef chairRef;

	public Transform chairAnchorTest;

	public SoundPlayer idleLoopPlayer;

	public Transform engineOffset;

	public SoundDefinition engineSoundDef;

	private static bool chairtest;

	public float throttle;

	public float brake;

	public bool lightsOn = true;

	public override float MaxVelocity()
	{
		return 50f;
	}

	public override Vector3 EyePositionForPlayer(BasePlayer player, Quaternion viewRot)
	{
		if (PlayerIsMounted(player))
		{
			return driverEye.transform.position;
		}
		return Vector3.zero;
	}

	public override void ServerInit()
	{
		if (!base.isClient)
		{
			base.ServerInit();
			rigidBody = GetComponent<Rigidbody>();
			rigidBody.centerOfMass = centerOfMass.localPosition;
			rigidBody.isKinematic = false;
			if (chairtest)
			{
				SpawnChairTest();
			}
		}
	}

	public void SpawnChairTest()
	{
		BaseEntity baseEntity = GameManager.server.CreateEntity(chairRef.resourcePath, chairAnchorTest.transform.localPosition);
		baseEntity.Spawn();
		DestroyOnGroundMissing component = baseEntity.GetComponent<DestroyOnGroundMissing>();
		if (component != null)
		{
			component.enabled = false;
		}
		MeshCollider component2 = baseEntity.GetComponent<MeshCollider>();
		if ((bool)component2)
		{
			component2.convex = true;
		}
		baseEntity.SetParent(this);
	}

	public override void VehicleFixedUpdate()
	{
		using (TimeWarning.New("BasicCar.VehicleFixedUpdate"))
		{
			base.VehicleFixedUpdate();
			if (!HasDriver())
			{
				NoDriverInput();
			}
			ConvertInputToThrottle();
			DoSteering();
			ApplyForceAtWheels();
			SetFlag(Flags.Reserved1, HasDriver());
			SetFlag(Flags.Reserved2, HasDriver() && lightsOn);
		}
	}

	public void DoSteering()
	{
		VehicleWheel[] array = wheels;
		foreach (VehicleWheel vehicleWheel in array)
		{
			if (vehicleWheel.steerWheel)
			{
				vehicleWheel.wheelCollider.steerAngle = steering;
			}
		}
		SetFlag(Flags.Reserved4, steering < -2f);
		SetFlag(Flags.Reserved5, steering > 2f);
	}

	public void ConvertInputToThrottle()
	{
	}

	public void ApplyForceAtWheels()
	{
		if (rigidBody == null)
		{
			return;
		}
		Vector3 velocity = rigidBody.velocity;
		float num = velocity.magnitude * Vector3.Dot(velocity.normalized, base.transform.forward);
		float num2 = brakePedal;
		float num3 = gasPedal;
		if (num > 0f && num3 < 0f)
		{
			num2 = 100f;
		}
		else if (num < 0f && num3 > 0f)
		{
			num2 = 100f;
		}
		VehicleWheel[] array = wheels;
		foreach (VehicleWheel vehicleWheel in array)
		{
			if (vehicleWheel.wheelCollider.isGrounded)
			{
				if (vehicleWheel.powerWheel)
				{
					vehicleWheel.wheelCollider.motorTorque = num3 * motorForceConstant;
				}
				if (vehicleWheel.brakeWheel)
				{
					vehicleWheel.wheelCollider.brakeTorque = num2 * brakeForceConstant;
				}
			}
		}
		SetFlag(Flags.Reserved3, num2 >= 100f && AnyMounted());
	}

	public void NoDriverInput()
	{
		if (chairtest)
		{
			gasPedal = Mathf.Sin(Time.time) * 50f;
			return;
		}
		gasPedal = 0f;
		brakePedal = Mathf.Lerp(brakePedal, 100f, Time.deltaTime * GasLerpTime / 5f);
	}

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		if (IsDriver(player))
		{
			DriverInput(inputState, player);
		}
	}

	public void DriverInput(InputState inputState, BasePlayer player)
	{
		if (inputState.IsDown(BUTTON.FORWARD))
		{
			gasPedal = 100f;
			brakePedal = 0f;
		}
		else if (inputState.IsDown(BUTTON.BACKWARD))
		{
			gasPedal = -30f;
			brakePedal = 0f;
		}
		else
		{
			gasPedal = 0f;
			brakePedal = 30f;
		}
		if (inputState.IsDown(BUTTON.LEFT))
		{
			steering = -60f;
		}
		else if (inputState.IsDown(BUTTON.RIGHT))
		{
			steering = 60f;
		}
		else
		{
			steering = 0f;
		}
	}

	public override void LightToggle(BasePlayer player)
	{
		if (IsDriver(player))
		{
			lightsOn = !lightsOn;
		}
	}
}
