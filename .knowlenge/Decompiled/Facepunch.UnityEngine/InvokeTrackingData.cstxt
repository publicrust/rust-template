using System;
using System.Runtime.CompilerServices;

public class InvokeTrackingData
{
	public InvokeTrackingKey Key;

	public string TypeName;

	public int InvokeCount;

	public int Calls;

	public TimeSpan ExecutionTime;

	public InvokeTrackingData(InvokeTrackingKey key)
	{
		Key = key;
		TypeName = key.Type.Name;
		Calls = 0;
		ExecutionTime = TimeSpan.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		ExecutionTime = TimeSpan.Zero;
		Calls = 0;
	}
}
