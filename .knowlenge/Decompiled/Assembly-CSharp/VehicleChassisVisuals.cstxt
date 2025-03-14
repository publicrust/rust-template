using UnityEngine;

public abstract class VehicleChassisVisuals<T> : MonoBehaviour where T : BaseEntity, VehicleChassisVisuals<T>.IClientWheelUser
{
	public interface IClientWheelUser
	{
		Vector3 Velocity { get; }

		float DriveWheelVelocity { get; }

		float SteerAngle { get; }

		float MaxSteerAngle { get; }

		float GetThrottleInput();
	}
}
