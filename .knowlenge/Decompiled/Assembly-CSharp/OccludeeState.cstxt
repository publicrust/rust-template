using System.Runtime.InteropServices;
using UnityEngine;

public class OccludeeState : OcclusionCulling.SmartListValue
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 32)]
	public struct State
	{
		[FieldOffset(0)]
		public Vector4 sphereBounds;

		[FieldOffset(16)]
		public float minTimeVisible;

		[FieldOffset(20)]
		public float waitTime;

		[FieldOffset(24)]
		public uint waitFrame;

		[FieldOffset(28)]
		public byte isVisible;

		[FieldOffset(29)]
		public byte active;

		[FieldOffset(30)]
		public byte callback;

		[FieldOffset(31)]
		public byte pad1;

		public static State Unused = new State
		{
			active = 0
		};
	}

	public int slot;

	public bool isStatic;

	public int layer;

	public OcclusionCulling.OnVisibilityChanged onVisibilityChanged;

	public OcclusionCulling.Cell cell;

	public OcclusionCulling.SimpleList<State> states;

	public bool isVisible => states[slot].isVisible != 0;

	public OccludeeState Initialize(OcclusionCulling.SimpleList<State> states, OcclusionCulling.BufferSet set, int slot, Vector4 sphereBounds, bool isVisible, float minTimeVisible, bool isStatic, int layer, OcclusionCulling.OnVisibilityChanged onVisibilityChanged)
	{
		states[slot] = new State
		{
			sphereBounds = sphereBounds,
			minTimeVisible = minTimeVisible,
			waitTime = (isVisible ? (Time.time + minTimeVisible) : 0f),
			waitFrame = (uint)(Time.frameCount + 1),
			isVisible = (byte)(isVisible ? 1 : 0),
			active = 1,
			callback = ((onVisibilityChanged != null) ? ((byte)1) : ((byte)0))
		};
		this.slot = slot;
		this.isStatic = isStatic;
		this.layer = layer;
		this.onVisibilityChanged = onVisibilityChanged;
		cell = null;
		this.states = states;
		return this;
	}

	public void Invalidate()
	{
		states[slot] = State.Unused;
		slot = -1;
		onVisibilityChanged = null;
		cell = null;
	}

	public void MakeVisible()
	{
		states.array[slot].waitTime = Time.time + states[slot].minTimeVisible;
		states.array[slot].isVisible = 1;
		if (onVisibilityChanged != null)
		{
			onVisibilityChanged(visible: true);
		}
	}
}
