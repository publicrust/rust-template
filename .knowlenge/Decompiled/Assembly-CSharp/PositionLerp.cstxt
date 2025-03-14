using System;
using Facepunch;
using Rust.Interpolation;
using UnityEngine;

public class PositionLerp : Pool.IPooled
{
	private static readonly ListHashSet<PositionLerp> InstanceList = new ListHashSet<PositionLerp>();

	public static bool DebugLog = false;

	public static bool DebugDraw = false;

	public static int TimeOffsetInterval = 16;

	public static float TimeOffset = 0f;

	public const int TimeOffsetIntervalMin = 4;

	public const int TimeOffsetIntervalMax = 64;

	private bool enabled = true;

	private Action idleDisable;

	private readonly Interpolator<TransformSnapshot> interpolator = new Interpolator<TransformSnapshot>(32);

	private IPosLerpTarget target;

	private static TransformSnapshot snapshotPrototype = default(TransformSnapshot);

	private float timeOffset0 = float.MaxValue;

	private float timeOffset1 = float.MaxValue;

	private float timeOffset2 = float.MaxValue;

	private float timeOffset3 = float.MaxValue;

	private int timeOffsetCount;

	private float lastClientTime;

	private float lastServerTime;

	private float extrapolatedTime;

	private float enabledTime;

	public bool Enabled
	{
		get
		{
			return enabled;
		}
		set
		{
			enabled = value;
			if (enabled)
			{
				OnEnable();
			}
			else
			{
				OnDisable();
			}
		}
	}

	public static float LerpTime => Time.time;

	private void OnEnable()
	{
		InstanceList.Add(this);
		enabledTime = LerpTime;
	}

	private void OnDisable()
	{
		InstanceList.Remove(this);
	}

	public void Initialize(IPosLerpTarget target)
	{
		this.target = target;
		Enabled = true;
	}

	public void Snapshot(Vector3 position, Quaternion rotation, float serverTime)
	{
		float interpolationDelay = target.GetInterpolationDelay(ILerpInfo.LerpType.Position);
		float interpolationSmoothing = target.GetInterpolationSmoothing();
		float num = interpolationDelay + interpolationSmoothing + 1f;
		float lerpTime = LerpTime;
		timeOffset0 = Mathf.Min(timeOffset0, lerpTime - serverTime);
		timeOffsetCount++;
		if (timeOffsetCount >= TimeOffsetInterval / 4)
		{
			timeOffset3 = timeOffset2;
			timeOffset2 = timeOffset1;
			timeOffset1 = timeOffset0;
			timeOffset0 = float.MaxValue;
			timeOffsetCount = 0;
		}
		TimeOffset = Mathx.Min(timeOffset0, timeOffset1, timeOffset2, timeOffset3);
		lerpTime = serverTime + TimeOffset;
		if (DebugLog && interpolator.list.Count > 0 && serverTime < lastServerTime)
		{
			Debug.LogWarning(target.ToString() + " adding tick from the past: server time " + serverTime + " < " + lastServerTime);
		}
		else if (DebugLog && interpolator.list.Count > 0 && lerpTime < lastClientTime)
		{
			Debug.LogWarning(target.ToString() + " adding tick from the past: client time " + lerpTime + " < " + lastClientTime);
		}
		else
		{
			lastClientTime = lerpTime;
			lastServerTime = serverTime;
			interpolator.Add(new TransformSnapshot(lerpTime, position, rotation));
		}
		interpolator.Cull(lerpTime - num);
	}

	public void Snapshot(Vector3 position, Quaternion rotation)
	{
		Snapshot(position, rotation, LerpTime - TimeOffset);
	}

	public void SnapTo(Vector3 position, Quaternion rotation, float serverTime)
	{
		interpolator.Clear();
		Snapshot(position, rotation, serverTime);
		target.SetNetworkPosition(position);
		target.SetNetworkRotation(rotation);
	}

	public void SnapTo(Vector3 position, Quaternion rotation)
	{
		interpolator.last = new TransformSnapshot(LerpTime, position, rotation);
		Wipe();
	}

	public void SnapToEnd()
	{
		float interpolationDelay = target.GetInterpolationDelay(ILerpInfo.LerpType.Position);
		Interpolator<TransformSnapshot>.Segment segment = interpolator.Query(LerpTime, interpolationDelay, 0f, 0f, ref snapshotPrototype);
		target.SetNetworkPosition(segment.tick.pos);
		target.SetNetworkRotation(segment.tick.rot);
		Wipe();
	}

	public void Wipe()
	{
		interpolator.Clear();
		timeOffsetCount = 0;
		timeOffset0 = float.MaxValue;
		timeOffset1 = float.MaxValue;
		timeOffset2 = float.MaxValue;
		timeOffset3 = float.MaxValue;
	}

	public static void WipeAll()
	{
		foreach (PositionLerp instance in InstanceList)
		{
			instance.Wipe();
		}
	}

	protected void DoCycle()
	{
		if (target == null)
		{
			return;
		}
		float interpolationInertia = target.GetInterpolationInertia();
		float num = ((interpolationInertia > 0f) ? Mathf.InverseLerp(0f, interpolationInertia, LerpTime - enabledTime) : 1f);
		float extrapolationTime = target.GetExtrapolationTime();
		float interpolation = target.GetInterpolationDelay(ILerpInfo.LerpType.Position) * num;
		float num2 = target.GetInterpolationSmoothing() * num;
		Interpolator<TransformSnapshot>.Segment segment = interpolator.Query(LerpTime, interpolation, extrapolationTime, num2, ref snapshotPrototype);
		if (segment.next.Time >= interpolator.last.Time)
		{
			extrapolatedTime = Mathf.Min(extrapolatedTime + Time.deltaTime, extrapolationTime);
		}
		else
		{
			extrapolatedTime = Mathf.Max(extrapolatedTime - Time.deltaTime, 0f);
		}
		if (extrapolatedTime > 0f && extrapolationTime > 0f && num2 > 0f)
		{
			float t = Time.deltaTime / (extrapolatedTime / extrapolationTime * num2);
			segment.tick.pos = Vector3.Lerp(target.GetNetworkPosition(), segment.tick.pos, t);
			segment.tick.rot = Quaternion.Slerp(target.GetNetworkRotation(), segment.tick.rot, t);
		}
		target.SetNetworkPosition(segment.tick.pos);
		target.SetNetworkRotation(segment.tick.rot);
		if (DebugDraw)
		{
			target.DrawInterpolationState(segment, interpolator.list);
		}
		if (LerpTime - lastClientTime > 10f)
		{
			if (idleDisable == null)
			{
				idleDisable = target.LerpIdleDisable;
			}
			InvokeHandler.Invoke(target as Behaviour, idleDisable, 0f);
		}
	}

	public void TransformEntries(Matrix4x4 matrix)
	{
		Quaternion rotation = matrix.rotation;
		for (int i = 0; i < interpolator.list.Count; i++)
		{
			TransformSnapshot value = interpolator.list[i];
			value.pos = matrix.MultiplyPoint3x4(value.pos);
			value.rot = rotation * value.rot;
			interpolator.list[i] = value;
		}
		interpolator.last.pos = matrix.MultiplyPoint3x4(interpolator.last.pos);
		interpolator.last.rot = rotation * interpolator.last.rot;
	}

	public Quaternion GetEstimatedAngularVelocity()
	{
		if (target == null)
		{
			return Quaternion.identity;
		}
		float extrapolationTime = target.GetExtrapolationTime();
		float interpolationDelay = target.GetInterpolationDelay(ILerpInfo.LerpType.Position);
		float interpolationSmoothing = target.GetInterpolationSmoothing();
		Interpolator<TransformSnapshot>.Segment segment = interpolator.Query(LerpTime, interpolationDelay, extrapolationTime, interpolationSmoothing, ref snapshotPrototype);
		TransformSnapshot next = segment.next;
		TransformSnapshot prev = segment.prev;
		if (next.Time == prev.Time)
		{
			return Quaternion.identity;
		}
		return Quaternion.Euler((prev.rot.eulerAngles - next.rot.eulerAngles) / (prev.Time - next.Time));
	}

	public Vector3 GetEstimatedVelocity()
	{
		if (target == null)
		{
			return Vector3.zero;
		}
		float extrapolationTime = target.GetExtrapolationTime();
		float interpolationDelay = target.GetInterpolationDelay(ILerpInfo.LerpType.Position);
		float interpolationSmoothing = target.GetInterpolationSmoothing();
		Interpolator<TransformSnapshot>.Segment segment = interpolator.Query(LerpTime, interpolationDelay, extrapolationTime, interpolationSmoothing, ref snapshotPrototype);
		TransformSnapshot next = segment.next;
		TransformSnapshot prev = segment.prev;
		if (next.Time == prev.Time)
		{
			return Vector3.zero;
		}
		return (prev.pos - next.pos) / (prev.Time - next.Time);
	}

	void Pool.IPooled.EnterPool()
	{
		target = null;
		idleDisable = null;
		interpolator.Clear();
		timeOffset0 = float.MaxValue;
		timeOffset1 = float.MaxValue;
		timeOffset2 = float.MaxValue;
		timeOffset3 = float.MaxValue;
		lastClientTime = 0f;
		lastServerTime = 0f;
		extrapolatedTime = 0f;
		timeOffsetCount = 0;
		Enabled = false;
	}

	void Pool.IPooled.LeavePool()
	{
	}

	public static void Clear()
	{
		InstanceList.Clear();
	}

	public static void Cycle()
	{
		PositionLerp[] buffer = InstanceList.Values.Buffer;
		int count = InstanceList.Count;
		for (int i = 0; i < count; i++)
		{
			buffer[i].DoCycle();
		}
	}
}
