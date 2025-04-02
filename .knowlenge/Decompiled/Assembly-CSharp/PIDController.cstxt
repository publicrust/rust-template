using System;
using UnityEngine;

[Serializable]
public class PIDController
{
	[SerializeField]
	public float p;

	[SerializeField]
	public float i;

	[SerializeField]
	public float d;

	private float oldError;

	private float integralSum;

	public float Update(float dt, float current, float target)
	{
		float num = target - current;
		float num2 = p * num;
		float num3 = (num - oldError) / dt;
		oldError = num;
		float num4 = d * num3;
		integralSum += num * dt;
		float num5 = i * integralSum;
		return num2 + num5 + num4;
	}
}
