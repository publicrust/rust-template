using Facepunch;
using ProtoBuf;
using UnityEngine;

public class BaseAnimalRagdoll : BaseCombatEntity
{
	[SerializeField]
	private Ragdoll Ragdoll;

	private EntityRef<BaseCombatEntity> linkedEntity;

	public override float PositionTickRate
	{
		protected get
		{
			return 0.05f;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.temporaryRagdoll = Pool.Get<TemporaryRagdoll>();
		if (linkedEntity.IsValid(base.isServer))
		{
			info.msg.temporaryRagdoll.parentID = linkedEntity.uid;
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.temporaryRagdoll != null)
		{
			Load(info.msg.temporaryRagdoll);
		}
	}

	private void Load(TemporaryRagdoll tempRagdoll)
	{
	}

	private void LateUpdate()
	{
		BaseCombatEntity baseCombatEntity = linkedEntity.Get(base.isServer);
		if (base.isServer)
		{
			if (baseCombatEntity == null || baseCombatEntity.IsDead())
			{
				Kill();
				return;
			}
			baseCombatEntity.transform.position = base.transform.position;
			baseCombatEntity.transform.rotation = base.transform.rotation;
			SendNetworkUpdateImmediate();
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.mass = 10f;
			rigidbody.drag = 0f;
			rigidbody.angularDrag = 0f;
		}
		rigidbody.useGravity = true;
		rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
		rigidbody.sleepThreshold = Mathf.Max(0.05f, Physics.sleepThreshold);
	}

	public void InitFromEnt(BaseCombatEntity ent)
	{
		linkedEntity.Set(ent);
		ent.model.skeleton.CopyTo(model.skeleton);
		base.transform.SetPositionAndRotation(ent.transform.position, ent.transform.rotation);
		Ragdoll.ServerInit();
		Vector3 worldVelocity = ent.GetWorldVelocity();
		foreach (Rigidbody rigidbody in Ragdoll.rigidbodies)
		{
			rigidbody.AddForce(worldVelocity, ForceMode.VelocityChange);
			rigidbody.drag = 0f;
		}
		Invoke(StopRagdolling, 5f);
	}

	private void StopRagdolling()
	{
		linkedEntity.Get(serverside: true)?.SetFlag(Flags.Reserved12, b: false);
		Kill();
	}

	public override void OnCollision(Collision collision, BaseEntity hitEntity)
	{
		ProcessCollision(collision);
	}

	protected void OnCollisionEnter(Collision collision)
	{
		ProcessCollision(collision);
	}

	protected void ProcessCollision(Collision collision)
	{
		if (!base.isClient && collision != null && !(collision.gameObject == null) && !(collision.gameObject == null) && linkedEntity.Get(serverside: true) is IAnimalRagdollCollisionReceiver animalRagdollCollisionReceiver)
		{
			animalRagdollCollisionReceiver.OnRagdollCollisionEnter(collision);
		}
	}
}
