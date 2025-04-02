using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class HarborCraneContainerPickup : HarborCrane
{
	public struct ContainerStack
	{
		public Transform RootPoint;

		public int MaxStackSize;

		public int CurrentStackSize { get; set; }
	}

	private struct QueuedMove
	{
		public EntityRef<CargoShipContainer> TargetEntity;

		public Vector3 TargetWorldPosition;

		public Quaternion TargetWorldRotation;

		public bool HasTarget;
	}

	private enum PickupState
	{
		RotateToFace,
		Lift,
		RotateToTarget,
		Drop,
		Reset
	}

	public Transform ServerTowerGrab;

	public float LockTime = 5f;

	public float MaxMoveDistance = 32f;

	public float PickedUpObjectRotationSpeed = 30f;

	private List<ContainerStack> Stacks;

	public GameObjectRef ContainerPrefab;

	private const float ContainerSize = 3f;

	public int MaxContainerStackSize = 3;

	public bool DebugContainerSpawns;

	public bool DebugContainerDestinations;

	private Vector3 grabOffset = new Vector3(0f, 19f, 0f);

	public static ListHashSet<HarborCraneContainerPickup> AllCranes = new ListHashSet<HarborCraneContainerPickup>();

	private Vector3 startForward;

	private List<QueuedMove> movesToMake = new List<QueuedMove>();

	private QueuedMove? moveInProcess;

	private EntityRef<CargoShip> toParent;

	private float moveDelay;

	private PickupState currentPickupState;

	private float lockOnTime;

	private float maxTargetHeight;

	public override void ServerInit()
	{
		base.ServerInit();
		AllCranes.Add(this);
		List<HarborCraneContainerSpawnPoint> obj = Pool.Get<List<HarborCraneContainerSpawnPoint>>();
		FindNearbyContainerSpawns(obj);
		Stacks = new List<ContainerStack>();
		foreach (HarborCraneContainerSpawnPoint item in obj)
		{
			Stacks.Add(new ContainerStack
			{
				RootPoint = item.transform,
				MaxStackSize = item.MaxStackSize
			});
		}
		Pool.FreeUnmanaged(ref obj);
		UpdateArm();
		SendNetworkUpdate();
	}

	public override void PostMapEntitySpawn()
	{
		base.PostMapEntitySpawn();
		startForward = base.transform.forward;
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		AllCranes.Remove(this);
	}

	private void FindNearbyContainerSpawns(List<HarborCraneContainerSpawnPoint> foundPoints)
	{
		Vis.Components(base.transform.position, MaxMoveDistance, foundPoints, 1218652417);
	}

	private void ReplenishContainers(int totalContainers)
	{
		for (int i = 0; i < Stacks.Count; i++)
		{
			ContainerStack value = Stacks[i];
			value.CurrentStackSize = 0;
			Stacks[i] = value;
		}
		maxTargetHeight = 0f;
		int count = Stacks.Count;
		if (count == 0)
		{
			return;
		}
		int num = Random.Range(0, count);
		int num2 = 0;
		while (totalContainers > 0 && num2 < 50)
		{
			num2++;
			num++;
			if (num >= count)
			{
				num = 0;
			}
			ContainerStack containerStack = Stacks[num];
			if (SpawnContainerOnStack(containerStack))
			{
				containerStack.CurrentStackSize++;
				totalContainers--;
				Stacks[num] = containerStack;
			}
		}
		movesToMake.Reverse();
		bool SpawnContainerOnStack(ContainerStack stack)
		{
			if (stack.CurrentStackSize >= MaxContainerStackSize || stack.CurrentStackSize >= stack.MaxStackSize)
			{
				return false;
			}
			if (CargoShip.docking_debug)
			{
				Debug.Log($"Spawning container on stack {stack.RootPoint.position}");
			}
			Vector3 position = stack.RootPoint.position;
			position.y += (float)stack.CurrentStackSize * 3f;
			List<BaseEntity> obj = Pool.Get<List<BaseEntity>>();
			Vis.Entities(new OBB(position, stack.RootPoint.rotation, new Bounds(new Vector3(0f, 1.5f, 0f), new Vector3(4.5f, 1.5f, 1.5f) * 0.8f)), obj, 1218685185);
			bool num3 = obj.Count == 0;
			if (!num3 && CargoShip.docking_debug)
			{
				Debug.Log("Container spawn blocked by " + obj[0].gameObject.name, obj[0]);
			}
			Pool.FreeUnmanaged(ref obj);
			if (!num3)
			{
				return false;
			}
			CargoShipContainer cargoShipContainer = GameManager.server.CreateEntity(ContainerPrefab.resourcePath, position, stack.RootPoint.rotation) as CargoShipContainer;
			cargoShipContainer.Spawn();
			QueuedMove item = default(QueuedMove);
			item.TargetEntity.Set(cargoShipContainer);
			item.HasTarget = false;
			movesToMake.Add(item);
			return true;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.harborCrane = Pool.Get<ProtoBuf.HarborCrane>();
		info.msg.harborCrane.depth = ServerTowerGrab.localPosition.z;
		info.msg.harborCrane.height = ServerTowerGrab.localPosition.y;
		info.msg.harborCrane.time = GetNetworkTime();
		info.msg.harborCrane.maxMoveHeight = maxTargetHeight;
		info.msg.harborCrane.toParent = toParent.uid;
		info.msg.harborCrane.startForward = startForward;
		info.msg.harborCrane.moveDelay = moveDelay;
		if (moveInProcess.HasValue)
		{
			info.msg.harborCrane.currentMove = Pool.Get<ProtoBuf.HarborCrane.QueuedMove>();
			CreateMove(moveInProcess.Value, info.msg.harborCrane.currentMove);
		}
		if (movesToMake.Count > 0)
		{
			info.msg.harborCrane.queuedMoves = Pool.Get<List<ProtoBuf.HarborCrane.QueuedMove>>();
			foreach (QueuedMove item in movesToMake)
			{
				ProtoBuf.HarborCrane.QueuedMove queuedMove = Pool.Get<ProtoBuf.HarborCrane.QueuedMove>();
				CreateMove(item, queuedMove);
				info.msg.harborCrane.queuedMoves.Add(queuedMove);
			}
		}
		info.msg.harborCrane.currentPickupState = (int)currentPickupState;
	}

	private QueuedMove CreateMove(ProtoBuf.HarborCrane.QueuedMove from)
	{
		QueuedMove result = default(QueuedMove);
		result.TargetEntity = new EntityRef<CargoShipContainer>(from.targetEntity);
		result.TargetWorldPosition = from.targetWorldPosition;
		result.TargetWorldRotation = new Quaternion(from.targetWorldRotation.x, from.targetWorldRotation.y, from.targetWorldRotation.z, from.targetWorldRotation.w);
		result.HasTarget = from.hasTarget;
		return result;
	}

	private void CreateMove(QueuedMove move, ProtoBuf.HarborCrane.QueuedMove target)
	{
		target.hasTarget = move.HasTarget;
		target.targetEntity = move.TargetEntity.uid;
		target.targetWorldPosition = move.TargetWorldPosition;
		target.targetWorldRotation = new Vector4(move.TargetWorldRotation.x, move.TargetWorldRotation.y, move.TargetWorldRotation.z, move.TargetWorldRotation.w);
	}

	private void CountdownDelay()
	{
		moveDelay -= Time.deltaTime;
		if (moveDelay <= 0f)
		{
			moveDelay = 0f;
			CancelInvoke(CountdownDelay);
			CheckMoveQueue();
		}
	}

	private void CheckMoveQueue()
	{
		if (moveDelay > 0f && movesToMake.Count > 0 && !IsInvoking(CountdownDelay))
		{
			InvokeRepeating(CountdownDelay, 0f, 0f);
		}
		else if (movesToMake.Count > 0 && !IsBusy() && movesToMake[0].HasTarget)
		{
			moveInProcess = movesToMake[0];
			movesToMake.RemoveAt(0);
			currentPickupState = PickupState.RotateToFace;
			lockOnTime = 0f;
			SetFlag(Flags.Busy, b: true);
			InvokeRepeating(ProcessCraneMovement, 0f, 0f);
		}
	}

	private void ProcessCraneMovement()
	{
		if (!moveInProcess.HasValue)
		{
			return;
		}
		QueuedMove value = moveInProcess.Value;
		CargoShipContainer cargoShipContainer = value.TargetEntity.Get(serverside: true);
		if (cargoShipContainer == null)
		{
			return;
		}
		Vector3 position = base.transform.position;
		float num = Mathf.Max(15.585f, Mathf.Max(value.TargetWorldPosition.y, maxTargetHeight));
		float num2 = num;
		Vector3 v = cargoShipContainer.transform.position;
		Vector3 vector = v.WithY(position.y) - position;
		float num3 = Vector3.Angle(base.transform.forward, vector.normalized);
		Vector3 localPosition = ServerTowerGrab.localPosition;
		bool flag = false;
		float num4 = 0f;
		switch (currentPickupState)
		{
		case PickupState.RotateToFace:
			cargoShipContainer.SetTargeted(state: true);
			if (!(num3 < 2f))
			{
				break;
			}
			num2 = base.transform.InverseTransformPoint(new Vector3(0f, cargoShipContainer.transform.position.y + cargoShipContainer.bounds.max.y, 0f)).y;
			if (Mathf.Abs(num2 - localPosition.y) < 0.1f)
			{
				lockOnTime += Time.deltaTime;
				if (lockOnTime > LockTime)
				{
					currentPickupState = PickupState.Lift;
					lockOnTime = 0f;
				}
			}
			break;
		case PickupState.Lift:
			flag = true;
			if (Mathf.Abs(num2 - localPosition.y) < 0.1f)
			{
				currentPickupState = PickupState.RotateToTarget;
			}
			break;
		case PickupState.RotateToTarget:
			flag = true;
			v = value.TargetWorldPosition;
			vector = v.WithY(position.y) - position;
			num3 = Vector3.Angle(base.transform.forward, vector.normalized);
			cargoShipContainer.transform.rotation = Quaternion.RotateTowards(cargoShipContainer.transform.rotation, value.TargetWorldRotation, PickedUpObjectRotationSpeed * Time.deltaTime);
			if (num3 < 0.1f)
			{
				currentPickupState = PickupState.Drop;
			}
			break;
		case PickupState.Drop:
			flag = true;
			v = value.TargetWorldPosition;
			vector = v.WithY(position.y) - position;
			num2 = base.transform.InverseTransformPoint(value.TargetWorldPosition).y + cargoShipContainer.bounds.size.y;
			cargoShipContainer.transform.rotation = Quaternion.RotateTowards(cargoShipContainer.transform.rotation, value.TargetWorldRotation, PickedUpObjectRotationSpeed * Time.deltaTime);
			if (Mathf.Abs(num2 - localPosition.y) < 0.1f)
			{
				lockOnTime += Time.deltaTime;
				if (lockOnTime > LockTime)
				{
					currentPickupState = PickupState.Reset;
					cargoShipContainer.transform.SetPositionAndRotation(value.TargetWorldPosition, (PickedUpObjectRotationSpeed > 0f) ? value.TargetWorldRotation : cargoShipContainer.transform.rotation);
					cargoShipContainer.SetParent(toParent.Get(serverside: true), worldPositionStays: true);
					cargoShipContainer.SetTargeted(state: false);
					lockOnTime = 0f;
				}
			}
			break;
		case PickupState.Reset:
			num2 = num;
			v = base.transform.position + startForward * 26f;
			vector = v.WithY(position.y) - position;
			num3 = Vector3.Angle(base.transform.forward, vector.normalized);
			if (num3 < 0.1f)
			{
				lockOnTime += Time.deltaTime;
				if (lockOnTime > 5f)
				{
					lockOnTime = 0f;
					SetFlag(Flags.Busy, b: false);
					CancelInvoke(ProcessCraneMovement);
					CheckMoveQueue();
				}
			}
			break;
		}
		cargoShipContainer.ToggleHurtCollider(currentPickupState == PickupState.Drop);
		Quaternion to = Quaternion.LookRotation(vector.normalized, Vector3.up);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, 5f * Time.deltaTime);
		float z = ((num4 > 0f) ? num4 : Vector3.Distance(v.WithY(position.y), position));
		localPosition = Vector3.MoveTowards(target: new Vector3(0f, num2, z), current: localPosition, maxDistanceDelta: Time.deltaTime * 2f);
		ServerTowerGrab.localPosition = localPosition;
		CraneGrab.position = ServerTowerGrab.position + grabOffset;
		if (flag)
		{
			cargoShipContainer.transform.position = ServerTowerGrab.position - Vector3.up * cargoShipContainer.bounds.size.y;
		}
		UpdateArm();
		SendNetworkUpdate();
		CargoShip cargoShip = toParent.Get(serverside: true);
		if (!(cargoShip != null) || cargoShip.HasFlag(Flags.Reserved1))
		{
			return;
		}
		foreach (QueuedMove item in movesToMake)
		{
			item.TargetEntity.Get(serverside: true).Kill();
		}
		if (cargoShipContainer != null && currentPickupState != PickupState.Reset)
		{
			cargoShipContainer.Kill();
		}
		v = base.transform.position + startForward * 26f;
		vector = v.WithY(position.y) - position;
		num2 = num;
		z = Vector3.Distance(v.WithY(position.y), position);
		Vector3 localPosition2 = new Vector3(0f, num2, z);
		base.transform.rotation = Quaternion.LookRotation(vector.normalized, Vector3.up);
		ServerTowerGrab.localPosition = localPosition2;
		CraneGrab.position = ServerTowerGrab.position + grabOffset;
		UpdateArm();
		SendNetworkUpdate();
		SetFlag(Flags.Busy, b: false);
		CancelInvoke(ProcessCraneMovement);
	}

	public void ReplenishContainers()
	{
		ReplenishContainers(Random.Range(2, 4));
	}

	public void AssignDestination(List<Transform> destinations, CargoShip targetShip, float delay)
	{
		if (startForward == Vector3.zero)
		{
			startForward = targetShip.transform.forward;
		}
		toParent.Set(targetShip);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < movesToMake.Count; i++)
		{
			QueuedMove value = movesToMake[i];
			Transform transform = destinations[num];
			value.TargetWorldRotation = transform.rotation;
			value.TargetWorldPosition = transform.position + Vector3.up * ((float)num2 * 3f);
			maxTargetHeight = Mathf.Max(value.TargetWorldPosition.y, maxTargetHeight);
			value.HasTarget = true;
			movesToMake[i] = value;
			num++;
			if (num >= destinations.Count)
			{
				num = 0;
				num2++;
			}
		}
		moveDelay = delay;
		CheckMoveQueue();
	}

	public bool IsDestinationValidForCrane(CargoShipContainerDestination destination)
	{
		Vector3 position = base.transform.position;
		Vector3 a = destination.transform.position.WithY(position.y);
		Vector3 b = position;
		return Vector3.Distance(a, b) < MaxMoveDistance - 2f;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (!base.isServer)
		{
			return;
		}
		startForward = info.msg.harborCrane.startForward;
		ServerTowerGrab.localPosition = new Vector3(0f, info.msg.harborCrane.height, info.msg.harborCrane.depth);
		toParent.uid = info.msg.harborCrane.toParent;
		moveDelay = info.msg.harborCrane.moveDelay;
		if (moveDelay > 0f && !IsInvoking(CountdownDelay))
		{
			InvokeRepeating(CountdownDelay, 0f, 0f);
		}
		if (info.msg.harborCrane.currentMove != null)
		{
			moveInProcess = CreateMove(info.msg.harborCrane.currentMove);
		}
		movesToMake.Clear();
		if (info.msg.harborCrane.queuedMoves != null)
		{
			foreach (ProtoBuf.HarborCrane.QueuedMove queuedMove in info.msg.harborCrane.queuedMoves)
			{
				movesToMake.Add(CreateMove(queuedMove));
			}
			Pool.Free(ref info.msg.harborCrane.queuedMoves, freeElements: false);
		}
		currentPickupState = (PickupState)info.msg.harborCrane.currentPickupState;
		if (IsBusy() && !IsInvoking(ProcessCraneMovement))
		{
			InvokeRepeating(ProcessCraneMovement, 0f, 0f);
		}
		maxTargetHeight = info.msg.harborCrane.maxMoveHeight;
	}

	private void UpdateArm()
	{
		if (ArmRoot != null && CraneGrab != null)
		{
			Vector3 position = base.transform.position;
			Vector3 position2 = CraneGrab.position;
			float num = Vector3.Distance(position, position2.WithY(position.y));
			if (num < MaxMoveDistance + 2f)
			{
				float num2 = Mathf.Acos(num / (MaxMoveDistance + 3f));
				ArmRoot.localEulerAngles = new Vector3(0f - num2 * 57.29578f, 90f, 0f);
			}
		}
	}
}
