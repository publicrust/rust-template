using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Delivery Drone Config")]
public class DeliveryDroneConfig : BaseScriptableObject
{
	public Vector3 vendingMachineOffset = new Vector3(0f, 1f, 1f);

	public float maxDistanceFromVendingMachine = 1f;

	public Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

	public float testHeight = 200f;

	public LayerMask layerMask = 161546496;

	public void FindDescentPoints(VendingMachine vendingMachine, float currentY, out Vector3 waitPosition, out Vector3 descendPosition)
	{
		float num = maxDistanceFromVendingMachine / 4f;
		for (int i = 0; i <= 4; i++)
		{
			Vector3 vector = Vector3.forward * (num * (float)i);
			Vector3 vector2 = vendingMachine.transform.TransformPoint(vendingMachineOffset + vector);
			Vector3 vector3 = vector2 + Vector3.up * testHeight;
			if (!Physics.BoxCast(vector3, halfExtents, Vector3.down, out var hitInfo, vendingMachine.transform.rotation, testHeight, layerMask))
			{
				waitPosition = vector2;
				descendPosition = vector3.WithY(currentY);
				return;
			}
			if (i == 4)
			{
				waitPosition = vector3 + Vector3.down * (hitInfo.distance - halfExtents.y * 2f);
				descendPosition = vector3.WithY(currentY);
				return;
			}
		}
		throw new Exception("Bug: FindDescentPoint didn't return a fallback value");
	}

	public bool IsVendingMachineAccessible(VendingMachine vendingMachine, Vector3 offset, out RaycastHit hitInfo)
	{
		Vector3 vector = vendingMachine.transform.TransformPoint(offset);
		if (Physics.BoxCast(vector + Vector3.up * testHeight, halfExtents, Vector3.down, out hitInfo, vendingMachine.transform.rotation, testHeight, layerMask))
		{
			return false;
		}
		return vendingMachine.IsVisible(vector, 2f);
	}
}
