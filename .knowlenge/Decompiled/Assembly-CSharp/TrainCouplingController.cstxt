using System.Collections.Generic;
using UnityEngine;

public class TrainCouplingController
{
	public const BaseEntity.Flags Flag_CouplingFront = BaseEntity.Flags.Reserved2;

	public const BaseEntity.Flags Flag_CouplingRear = BaseEntity.Flags.Reserved3;

	public readonly TrainCoupling frontCoupling;

	public readonly TrainCoupling rearCoupling;

	private readonly TrainCar owner;

	[ServerVar(Help = "Maximum difference in velocity for train cars to couple")]
	public static float max_couple_speed = 9f;

	public bool IsCoupled
	{
		get
		{
			if (!IsFrontCoupled)
			{
				return IsRearCoupled;
			}
			return true;
		}
	}

	public bool IsFrontCoupled => owner.HasFlag(BaseEntity.Flags.Reserved2);

	public bool IsRearCoupled => owner.HasFlag(BaseEntity.Flags.Reserved3);

	public TrainCouplingController(TrainCar owner)
	{
		this.owner = owner;
		frontCoupling = new TrainCoupling(owner, isFrontCoupling: true, this, owner.frontCoupling, owner.frontCouplingPivot, BaseEntity.Flags.Reserved2);
		rearCoupling = new TrainCoupling(owner, isFrontCoupling: false, this, owner.rearCoupling, owner.rearCouplingPivot, BaseEntity.Flags.Reserved3);
	}

	public bool IsCoupledTo(TrainCar them)
	{
		if (!frontCoupling.IsCoupledTo(them))
		{
			return rearCoupling.IsCoupledTo(them);
		}
		return true;
	}

	public bool TryCouple(TrainCar them, TriggerTrainCollisions.Location ourLocation)
	{
		TrainCoupling trainCoupling = ((ourLocation == TriggerTrainCollisions.Location.Front) ? frontCoupling : rearCoupling);
		if (!trainCoupling.isValid)
		{
			return false;
		}
		if (trainCoupling.IsCoupled)
		{
			return false;
		}
		if ((float)trainCoupling.timeSinceCouplingBlock < 1.5f)
		{
			return false;
		}
		float num = Vector3.Angle(owner.transform.forward, them.transform.forward);
		if (num > 25f && num < 155f)
		{
			return false;
		}
		bool num2 = num < 90f;
		TrainCoupling trainCoupling2 = ((!num2) ? ((ourLocation == TriggerTrainCollisions.Location.Front) ? them.coupling.frontCoupling : them.coupling.rearCoupling) : ((ourLocation == TriggerTrainCollisions.Location.Front) ? them.coupling.rearCoupling : them.coupling.frontCoupling));
		float num3 = them.GetTrackSpeed();
		if (!num2)
		{
			num3 = 0f - num3;
		}
		if (Mathf.Abs(num3 - owner.GetTrackSpeed()) > max_couple_speed)
		{
			trainCoupling.timeSinceCouplingBlock = 0f;
			trainCoupling2.timeSinceCouplingBlock = 0f;
			return false;
		}
		if (!trainCoupling2.isValid)
		{
			return false;
		}
		if (Vector3.SqrMagnitude(trainCoupling.couplingPoint.position - trainCoupling2.couplingPoint.position) > 0.5f)
		{
			return false;
		}
		TrainTrackSpline frontTrackSection = owner.FrontTrackSection;
		TrainTrackSpline frontTrackSection2 = them.FrontTrackSection;
		if (frontTrackSection2 != frontTrackSection && !frontTrackSection.HasConnectedTrack(frontTrackSection2))
		{
			return false;
		}
		return trainCoupling.TryCouple(trainCoupling2, reflect: true);
	}

	public void Uncouple(bool front)
	{
		if (front)
		{
			frontCoupling.Uncouple(reflect: true);
		}
		else
		{
			rearCoupling.Uncouple(reflect: true);
		}
	}

	public void GetAll(ref List<TrainCar> result)
	{
		result.Add(owner);
		TrainCoupling coupledTo = rearCoupling.CoupledTo;
		while (coupledTo != null && coupledTo.IsCoupled && !result.Contains(coupledTo.owner))
		{
			result.Insert(0, coupledTo.owner);
			coupledTo = coupledTo.GetOppositeCoupling();
			coupledTo = coupledTo.CoupledTo;
		}
		TrainCoupling coupledTo2 = frontCoupling.CoupledTo;
		while (coupledTo2 != null && coupledTo2.IsCoupled && !result.Contains(coupledTo2.owner))
		{
			result.Add(coupledTo2.owner);
			coupledTo2 = coupledTo2.GetOppositeCoupling();
			coupledTo2 = coupledTo2.CoupledTo;
		}
	}
}
