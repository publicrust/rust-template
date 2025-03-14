using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Slot Machine Payouts")]
public class SlotMachinePayoutSettings : ScriptableObject
{
	[Serializable]
	public struct PayoutInfo
	{
		public ItemAmount Item;

		[Range(0f, 15f)]
		public int Result1;

		[Range(0f, 15f)]
		public int Result2;

		[Range(0f, 15f)]
		public int Result3;

		public GameObjectRef OverrideWinEffect;
	}

	[Serializable]
	public struct IndividualPayouts
	{
		public ItemAmount Item;

		[Range(0f, 15f)]
		public int Result;
	}

	public ItemAmount SpinCost;

	public PayoutInfo[] Payouts;

	public int[] VirtualFaces = new int[16];

	public IndividualPayouts[] FacePayouts = new IndividualPayouts[0];

	public int TotalStops;

	public GameObjectRef DefaultWinEffect;
}
