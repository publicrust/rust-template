using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainSignal : BaseEntity
{
	public enum LightState
	{
		None,
		Green,
		Yellow,
		Red
	}

	private class SplineSection
	{
		public readonly TrainTrackSpline spline;

		public readonly float startDist;

		public readonly float endDist;

		public SplineSection(TrainTrackSpline spline, float startDist, float endDist)
		{
			this.spline = spline;
			this.startDist = startDist;
			this.endDist = endDist;
		}
	}

	[SerializeField]
	private bool testFX;

	[SerializeField]
	private VehicleLight redLight;

	[SerializeField]
	private VehicleLight yellowLight;

	[SerializeField]
	private VehicleLight greenLight;

	private const Flags Flag_Red = Flags.Reserved1;

	private const Flags Flag_Yellow = Flags.Reserved2;

	private const Flags Flag_Green = Flags.Reserved3;

	private LightState lightState;

	[NonSerialized]
	public TrainSignal nextSignal;

	private TrainTrackSpline ourSpline;

	private float ourSplineDist;

	private readonly List<SplineSection> ourSplines = new List<SplineSection>();

	private LightState prevTargetLightState;

	public float SplineDist => ourSplineDist;

	public bool HasNextSignal => (Object)(object)nextSignal != (Object)null;

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (base.isClient)
		{
			if ((next & Flags.Reserved1) == Flags.Reserved1)
			{
				SetLightState(LightState.Red);
			}
			else if ((next & Flags.Reserved2) == Flags.Reserved2)
			{
				SetLightState(LightState.Yellow);
			}
			else if ((next & Flags.Reserved3) == Flags.Reserved3)
			{
				SetLightState(LightState.Green);
			}
		}
	}

	private void SetLightState(LightState newState)
	{
		if (lightState != newState)
		{
			lightState = newState;
			if (base.isServer)
			{
				SetFlag(Flags.Reserved1, newState == LightState.Red, recursive: false, networkupdate: false);
				SetFlag(Flags.Reserved2, newState == LightState.Yellow, recursive: false, networkupdate: false);
				SetFlag(Flags.Reserved3, newState == LightState.Green, recursive: false, networkupdate: false);
				SendNetworkUpdate_Flags();
			}
		}
	}

	public override void ServerInit()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		base.ServerInit();
		if (TrainTrackSpline.TryFindTrackNear(((Component)this).transform.position, 10f, out ourSpline, out ourSplineDist))
		{
			ourSpline.RegisterSignal(this);
			((FacepunchBehaviour)this).Invoke((Action)SetUpSignal, 0f);
		}
		else
		{
			Debug.LogWarning((object)"TrainSignal found no nearby track. Disabling lights.");
			SetLightState(LightState.None);
		}
	}

	private void SetUpSignal()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)ourSpline != (Object)null)
		{
			TrainTrackSpline trainTrackSpline = ourSpline;
			float prevSplineDist = ourSplineDist;
			Vector3 askerForward = -((Component)this).transform.forward;
			TrainTrackSpline.MoveRequest.SplineAction onSpline = ProcessSplineSection;
			TrainTrackSpline.MoveResult moveResult = trainTrackSpline.MoveAlongSpline(prevSplineDist, askerForward, 500f, default(TrainTrackSpline.TrackRequest), onSpline);
			if (!testFX)
			{
				RefreshLightState();
				((FacepunchBehaviour)this).InvokeRandomized((Action)RefreshLightState, 1f, 1f, 0.1f);
			}
			Debug.DrawLine(((Component)this).transform.position, moveResult.spline.GetPosition(moveResult.distAlongSpline), IsForward() ? Color.blue : Color.cyan, 1000f);
		}
		if (testFX)
		{
			((FacepunchBehaviour)this).InvokeRepeating((Action)TestLights, 1f, 1f);
		}
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		if (ourSplines.Count > 0)
		{
			ourSplines[0].spline.DeregisterSignal(this);
		}
	}

	public void RefreshLightState()
	{
		LightState lightState = (HasOccupant() ? LightState.Red : ((!HasNextSignal) ? LightState.Green : ((nextSignal.lightState != LightState.Red) ? LightState.Green : LightState.Yellow)));
		if (lightState == LightState.Green)
		{
			if (prevTargetLightState == LightState.Green)
			{
				SetLightState(lightState);
			}
		}
		else
		{
			SetLightState(lightState);
		}
		prevTargetLightState = lightState;
	}

	private bool HasOccupant()
	{
		foreach (SplineSection ourSpline in ourSplines)
		{
			foreach (TrainTrackSpline.ITrainTrackUser trackUser in ourSpline.spline.trackUsers)
			{
				float frontWheelSplineDist = trackUser.FrontWheelSplineDist;
				if (frontWheelSplineDist >= ourSpline.startDist && frontWheelSplineDist <= ourSpline.endDist)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsForward()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return ourSpline.IsForward(-((Component)this).transform.forward, ourSplineDist);
	}

	private void TestLights()
	{
		SetLightState((LightState)Random.Range(1, 4));
	}

	private TrainTrackSpline.MoveResult ProcessSplineSection(TrainTrackSpline.MoveResult result, TrainTrackSpline.MoveRequest request, TrainTrackSpline spline, float splineLength)
	{
		float num = request.distAlongSpline;
		float num2 = result.distAlongSpline;
		bool flag = true;
		float num3 = num;
		if (num2 < num)
		{
			flag = false;
			num = num2;
			num2 = num3;
		}
		TrainSignal trainSignal = null;
		float num4 = float.MaxValue;
		foreach (TrainSignal signal in spline.signals)
		{
			if (!((Object)(object)signal == (Object)(object)this) && signal.IsValid() && signal.IsForward() == flag && signal.SplineDist >= num && signal.SplineDist <= num2)
			{
				float num5 = Mathf.Abs(signal.SplineDist - num3);
				if (result.totalDistMoved + num5 >= 5f && num5 < num4)
				{
					trainSignal = signal;
					num4 = num5;
				}
			}
		}
		if ((Object)(object)trainSignal != (Object)null)
		{
			result.distAlongSpline = trainSignal.SplineDist;
			if ((Object)(object)trainSignal != (Object)null)
			{
				nextSignal = trainSignal;
			}
		}
		float num6 = Mathf.Clamp(request.distAlongSpline, 0f, splineLength);
		float num7 = Mathf.Clamp(result.distAlongSpline, 0f, splineLength);
		if (num7 < num6)
		{
			SplineSection item = new SplineSection(spline, num7, num6);
			ourSplines.Add(item);
		}
		else if (num7 > num6)
		{
			SplineSection item2 = new SplineSection(spline, num6, num7);
			ourSplines.Add(item2);
		}
		return result;
	}
}
