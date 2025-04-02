using UnityEngine;

public class ConstructionSocket_Elevator : ConstructionSocket
{
	public int MaxFloor = 5;

	protected override bool CanConnectToEntity(Construction.Target target)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (target.entity is Elevator elevator && elevator.Floor >= MaxFloor)
		{
			return false;
		}
		Vector3 val = target.GetWorldPosition();
		Quaternion val2 = target.GetWorldRotation(female: true);
		if (GamePhysics.CheckOBB(new OBB(val, new Vector3(2f, 0.5f, 2f), val2), 2097152, (QueryTriggerInteraction)0))
		{
			return false;
		}
		return base.CanConnectToEntity(target);
	}

	public override bool CanConnect(Vector3 position, Quaternion rotation, Socket_Base socket, Vector3 socketPosition, Quaternion socketRotation)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (!base.CanConnect(position, rotation, socket, socketPosition, socketRotation))
		{
			return false;
		}
		Matrix4x4 val = Matrix4x4.TRS(position, rotation, Vector3.one);
		Vector3 val2 = ((Matrix4x4)(ref val)).MultiplyPoint3x4(worldPosition);
		return !GamePhysics.CheckOBB(new OBB(val2, new Vector3(2f, 0.5f, 2f), rotation), 2097152, (QueryTriggerInteraction)0);
	}
}
