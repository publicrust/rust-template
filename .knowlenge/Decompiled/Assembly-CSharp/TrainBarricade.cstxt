using ConVar;
using Rust;
using UnityEngine;
using UnityEngine.Serialization;

public class TrainBarricade : BaseCombatEntity, ITrainCollidable, TrainTrackSpline.ITrainTrackUser
{
	[FormerlySerializedAs("damagePerMPS")]
	[SerializeField]
	private float trainDamagePerMPS = 10f;

	[SerializeField]
	private float minVelToDestroy = 6f;

	[SerializeField]
	private float velReduction = 2f;

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
		if (base.isServer)
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

	public override void ServerInit()
	{
		base.ServerInit();
		if (TrainTrackSpline.TryFindTrackNear(base.transform.position, 3f, out var splineResult, out var distResult))
		{
			track = splineResult;
			FrontWheelSplineDist = distResult;
			track.RegisterTrackUser(this);
		}
	}

	internal override void DoServerDestroy()
	{
		if (track != null)
		{
			track.DeregisterTrackUser(this);
		}
		base.DoServerDestroy();
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
		if (IsDead() || base.IsDestroyed)
		{
			return;
		}
		if (hitTrain != null)
		{
			hitTrain.completeTrain.ReduceSpeedBy(velReduction);
			if (vehicle.cinematictrains)
			{
				hitTrain.Hurt(9999f, DamageType.Collision, this, useProtection: false);
			}
			else
			{
				float amount = Mathf.Abs(hitTrain.GetTrackSpeed()) * trainDamagePerMPS;
				hitTrain.Hurt(amount, DamageType.Collision, this, useProtection: false);
			}
		}
		ClearHitTrain();
		Kill(DestroyMode.Gib);
	}

	private void PushForceTick()
	{
		if (hitTrain == null || hitTrainTrigger == null || hitTrain.IsDead() || hitTrain.IsDestroyed || IsDead())
		{
			ClearHitTrain();
			CancelInvoke(PushForceTick);
			return;
		}
		bool flag = true;
		if (!hitTrainTrigger.triggerCollider.bounds.Intersects(bounds))
		{
			Vector3 vector = ((hitTrainTrigger.location != 0) ? hitTrainTrigger.owner.GetRearOfTrainPos() : hitTrainTrigger.owner.GetFrontOfTrainPos());
			Vector3 vector2 = base.transform.position + bounds.ClosestPoint(vector - base.transform.position);
			Debug.DrawRay(vector2, Vector3.up, Color.red, 10f);
			flag = Vector3.SqrMagnitude(vector2 - vector) < 1f;
		}
		if (flag)
		{
			float num = hitTrainTrigger.owner.completeTrain.TotalForces;
			if (hitTrainTrigger.location == TriggerTrainCollisions.Location.Rear)
			{
				num *= -1f;
			}
			num = Mathf.Max(0f, num);
			Hurt(0.002f * num);
			if (IsDead())
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
}
