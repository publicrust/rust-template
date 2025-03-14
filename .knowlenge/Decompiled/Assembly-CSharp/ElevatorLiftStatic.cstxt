using Rust;
using UnityEngine;

public class ElevatorLiftStatic : ElevatorLift
{
	public GameObjectRef ElevatorDoorRef;

	public Transform ElevatorDoorLocation;

	public bool BlockPerFloorMovement;

	private const Flags CanGoUp = Flags.Reserved3;

	private const Flags CanGoDown = Flags.Reserved4;

	public override void ServerInit()
	{
		base.ServerInit();
		if (ElevatorDoorRef.isValid && ElevatorDoorLocation != null && !Rust.Application.isLoadingSave)
		{
			foreach (BaseEntity child in children)
			{
				if (child is Door)
				{
					return;
				}
			}
			BaseEntity baseEntity = GameManager.server.CreateEntity(ElevatorDoorRef.resourcePath, ElevatorDoorLocation.localPosition, ElevatorDoorLocation.localRotation);
			baseEntity.SetParent(this);
			baseEntity.Spawn();
		}
		SetFlag(Flags.Reserved3, b: false, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved4, b: true);
	}

	public override void NotifyNewFloor(int newFloor, int totalFloors)
	{
		base.NotifyNewFloor(newFloor, totalFloors);
		SetFlag(Flags.Reserved3, newFloor < totalFloors);
		SetFlag(Flags.Reserved4, newFloor > 0);
	}
}
