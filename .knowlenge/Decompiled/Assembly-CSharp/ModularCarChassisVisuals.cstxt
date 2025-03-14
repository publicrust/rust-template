using System;
using UnityEngine;

public class ModularCarChassisVisuals : VehicleChassisVisuals<ModularCar>, IClientComponent
{
	[Serializable]
	public class Steering
	{
		public Transform steerL;

		public Transform steerR;

		public LookAtTarget steerRodL;

		public LookAtTarget steerRodR;

		public LookAtTarget steeringArm;
	}

	[Serializable]
	public class LookAtTarget
	{
		public Transform aim;

		public Transform target;

		public Vector3 angleAdjust;
	}

	public Transform frontAxle;

	public Transform rearAxle;

	public Steering steering;

	public LookAtTarget transmission;
}
