using System;
using UnityEngine;

public class WearableHolsterOffset : MonoBehaviour
{
	[Serializable]
	public class offsetInfo
	{
		public enum OverrideBone
		{
			None,
			Spine4
		}

		public HeldEntity.HolsterInfo.HolsterSlot type;

		public Vector3 offset;

		public Vector3 rotationOffset;

		public int priority;

		public Vector3 rightBackpackSlotOffset;

		public Vector3 rightBackpackSlotRotationOffset;

		public OverrideBone overrideBone;
	}

	public offsetInfo[] Offsets;
}
