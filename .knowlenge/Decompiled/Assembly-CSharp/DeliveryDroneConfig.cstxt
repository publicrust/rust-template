using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Delivery Drone Config")]
public class DeliveryDroneConfig : BaseScriptableObject
{
	public Vector3 vendingMachineOffset = new Vector3(0f, 1f, 1f);

	public float maxDistanceFromVendingMachine = 1f;

	public Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

	public float testHeight = 200f;

	public LayerMask layerMask = LayerMask.op_Implicit(161546496);

	public void FindDescentPoints(VendingMachine vendingMachine, float currentY, out Vector3 waitPosition, out Vector3 descendPosition)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		float num = maxDistanceFromVendingMachine / 4f;
		RaycastHit val4 = default(RaycastHit);
		for (int i = 0; i <= 4; i++)
		{
			Vector3 val = Vector3.forward * (num * (float)i);
			Vector3 val2 = ((Component)vendingMachine).transform.TransformPoint(vendingMachineOffset + val);
			Vector3 val3 = val2 + Vector3.up * testHeight;
			if (!Physics.BoxCast(val3, halfExtents, Vector3.down, ref val4, ((Component)vendingMachine).transform.rotation, testHeight, LayerMask.op_Implicit(layerMask)))
			{
				waitPosition = val2;
				descendPosition = Vector3Ex.WithY(val3, currentY);
				return;
			}
			if (i == 4)
			{
				waitPosition = val3 + Vector3.down * (((RaycastHit)(ref val4)).distance - halfExtents.y * 2f);
				descendPosition = Vector3Ex.WithY(val3, currentY);
				return;
			}
		}
		throw new Exception("Bug: FindDescentPoint didn't return a fallback value");
	}

	public bool IsVendingMachineAccessible(VendingMachine vendingMachine, Vector3 offset, out RaycastHit hitInfo)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = ((Component)vendingMachine).transform.TransformPoint(offset);
		if (Physics.BoxCast(val + Vector3.up * testHeight, halfExtents, Vector3.down, ref hitInfo, ((Component)vendingMachine).transform.rotation, testHeight, LayerMask.op_Implicit(layerMask)))
		{
			return false;
		}
		return vendingMachine.IsVisible(val, 2f);
	}
}
