using UnityEngine;

public class FixedRateStepped
{
	public float rate = 0.1f;

	public int maxSteps = 3;

	internal float nextCall;

	public bool ShouldStep()
	{
		if (nextCall > Time.time)
		{
			return false;
		}
		if (nextCall == 0f)
		{
			nextCall = Time.time;
		}
		if (nextCall + rate * (float)maxSteps < Time.time)
		{
			nextCall = Time.time - rate * (float)maxSteps;
		}
		nextCall += rate;
		return true;
	}
}
