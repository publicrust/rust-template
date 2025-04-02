using ConVar;
using Facepunch;
using ProtoBuf;
using Rust;
using UnityEngine;

public class HittableByTrains : EntityComponent<BaseCombatEntity>, ITrainCollidable, TrainTrackSpline.ITrainTrackUser, IOnParentDestroying, IOnParentSpawning
{
	[SerializeField]
	private float trainDamagePerMPS = 10f;

	[SerializeField]
	private float barricadeDamageMultiplier = 0.002f;

	[SerializeField]
	private float minVelToDestroy = 6f;

	[SerializeField]
	private float velReduction = 10f;

	[SerializeField]
	private GameObjectRef barricadeDamageEffect;

	private TrainCar hitTrain;

	private TriggerTrainCollisions hitTrainTrigger;

	private TrainTrackSpline track;

	public Vector3 Position => base.transform.position;

	public float FrontWheelSplineDist { get; private set; }

	public TrainCar.TrainCarType CarType => TrainCar.TrainCarType.Other;

	public bool CustomCollision(TrainCar train, TriggerTrainCollisions trainTrigger)
	{
		bool result = false;
		if (base.baseEntity.isServer)
		{
			float num = Mathf.Abs(train.GetTrackSpeed());
			SetHitTrain(train, trainTrigger);
			if (num < minVelToDestroy && !vehicle.cinematictrains)
			{
				InvokeRandomized(PushForceTick, 0f, 0.25f, 0.025f);
			}
			else
			{
				result = true;
				Invoke(DestroyThisBarrier, 0f);
			}
		}
		return result;
	}

	public bool EqualNetID(BaseNetworkable other)
	{
		return base.baseEntity.EqualNetID(other);
	}

	public Vector3 GetWorldVelocity()
	{
		return base.baseEntity.GetWorldVelocity();
	}

	public void OnParentSpawning()
	{
		if (TrainTrackSpline.TryFindTrackNear(base.transform.position, 5f, out var splineResult, out var distResult))
		{
			track = splineResult;
			FrontWheelSplineDist = distResult;
			track.RegisterTrackUser(this);
		}
	}

	public void OnParentDestroying()
	{
		if (track != null)
		{
			track.DeregisterTrackUser(this);
		}
	}

	private void SetHitTrain(TrainCar train, TriggerTrainCollisions trainTrigger)
	{
		hitTrain = train;
		hitTrainTrigger = trainTrigger;
	}

	private void ClearHitTrain()
	{
		SetHitTrain(null, null);
	}

	private void DestroyThisBarrier()
	{
		if (base.baseEntity.IsDead() || base.baseEntity.IsDestroyed)
		{
			return;
		}
		if (hitTrain != null)
		{
			hitTrain.completeTrain.ReduceSpeedBy(velReduction);
			if (vehicle.cinematictrains)
			{
				hitTrain.Hurt(9999f, DamageType.Collision, base.baseEntity, useProtection: false);
			}
			else
			{
				float amount = Mathf.Abs(hitTrain.GetTrackSpeed()) * trainDamagePerMPS;
				hitTrain.Hurt(amount, DamageType.Collision, base.baseEntity, useProtection: false);
			}
		}
		ClearHitTrain();
		base.baseEntity.Kill(BaseNetworkable.DestroyMode.Gib);
	}

	private void PushForceTick()
	{
		if (hitTrain == null || hitTrainTrigger == null || hitTrain.IsDead() || hitTrain.IsDestroyed || base.baseEntity.IsDead() || !hitTrain.IsOn())
		{
			ClearHitTrain();
			CancelInvoke(PushForceTick);
			return;
		}
		bool flag = true;
		if (!hitTrainTrigger.triggerCollider.bounds.Intersects(base.baseEntity.bounds))
		{
			Vector3 vector = ((hitTrainTrigger.location != 0) ? hitTrainTrigger.owner.GetRearOfTrainPos() : hitTrainTrigger.owner.GetFrontOfTrainPos());
			flag = Vector3.SqrMagnitude(base.transform.position + base.baseEntity.bounds.ClosestPoint(vector - base.transform.position) - vector) < 2f;
		}
		if (flag)
		{
			float num = hitTrainTrigger.owner.completeTrain.TotalForces;
			if (hitTrainTrigger.location == TriggerTrainCollisions.Location.Rear)
			{
				num *= -1f;
			}
			num = Mathf.Max(0f, num);
			base.baseEntity.Hurt(num * barricadeDamageMultiplier, DamageType.Generic, hitTrain);
			if (base.baseEntity.IsDead())
			{
				hitTrain.completeTrain.FreeStaticCollision();
			}
		}
		else
		{
			ClearHitTrain();
			CancelInvoke(PushForceTick);
		}
	}

	public override void SaveComponent(BaseNetworkable.SaveInfo info)
	{
		bool flag = base.baseEntity.lastAttacker is TrainCar;
		info.msg.simpleInt = Facepunch.Pool.Get<SimpleInt>();
		info.msg.simpleInt.value = (flag ? 1 : 0);
	}
}
