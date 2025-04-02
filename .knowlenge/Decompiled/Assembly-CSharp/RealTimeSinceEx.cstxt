using Network;

public struct RealTimeSinceEx
{
	private double time;

	public static implicit operator double(RealTimeSinceEx ts)
	{
		return TimeEx.realtimeSinceStartup - ts.time;
	}

	public static implicit operator RealTimeSinceEx(double ts)
	{
		RealTimeSinceEx result = default(RealTimeSinceEx);
		result.time = TimeEx.realtimeSinceStartup - ts;
		return result;
	}

	public override string ToString()
	{
		return (TimeEx.realtimeSinceStartup - time).ToString();
	}
}
