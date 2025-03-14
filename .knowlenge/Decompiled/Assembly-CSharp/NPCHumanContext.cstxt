using System.Collections.Generic;
using Rust.Ai;
using UnityEngine;

public class NPCHumanContext : BaseNPCContext
{
	public struct TacticalCoverPoint
	{
		public NPCPlayerApex Human;

		public CoverPoint reservedCoverPoint;

		public CoverPoint.CoverType activeCoverType;

		public CoverPoint ReservedCoverPoint
		{
			get
			{
				return reservedCoverPoint;
			}
			set
			{
				if (reservedCoverPoint != null)
				{
					reservedCoverPoint.ReservedFor = null;
				}
				reservedCoverPoint = value;
				if (reservedCoverPoint != null)
				{
					reservedCoverPoint.ReservedFor = Human;
				}
			}
		}

		public CoverPoint.CoverType ActiveCoverType
		{
			get
			{
				return activeCoverType;
			}
			set
			{
				activeCoverType = value;
			}
		}
	}

	public class TacticalCoverPointSet
	{
		public TacticalCoverPoint Retreat;

		public TacticalCoverPoint Flank;

		public TacticalCoverPoint Advance;

		public TacticalCoverPoint Closest;

		public void Setup(NPCPlayerApex human)
		{
			Retreat.Human = human;
			Flank.Human = human;
			Advance.Human = human;
			Closest.Human = human;
		}

		public void Shutdown()
		{
			Reset();
		}

		public void Reset()
		{
			if (Retreat.ReservedCoverPoint != null)
			{
				Retreat.ReservedCoverPoint = null;
			}
			if (Flank.ReservedCoverPoint != null)
			{
				Flank.ReservedCoverPoint = null;
			}
			if (Advance.ReservedCoverPoint != null)
			{
				Advance.ReservedCoverPoint = null;
			}
			if (Closest.ReservedCoverPoint != null)
			{
				Closest.ReservedCoverPoint = null;
			}
		}

		public void Update(CoverPoint retreat, CoverPoint flank, CoverPoint advance)
		{
			Retreat.ReservedCoverPoint = retreat;
			Flank.ReservedCoverPoint = flank;
			Advance.ReservedCoverPoint = advance;
			Closest.ReservedCoverPoint = null;
			float num = float.MaxValue;
			if (retreat != null)
			{
				float sqrMagnitude = (retreat.Position - Retreat.Human.ServerPosition).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					Closest.ReservedCoverPoint = retreat;
					num = sqrMagnitude;
				}
			}
			if (flank != null)
			{
				float sqrMagnitude2 = (flank.Position - Flank.Human.ServerPosition).sqrMagnitude;
				if (sqrMagnitude2 < num)
				{
					Closest.ReservedCoverPoint = flank;
					num = sqrMagnitude2;
				}
			}
			if (advance != null)
			{
				float sqrMagnitude3 = (advance.Position - Advance.Human.ServerPosition).sqrMagnitude;
				if (sqrMagnitude3 < num)
				{
					Closest.ReservedCoverPoint = advance;
					num = sqrMagnitude3;
				}
			}
		}
	}

	public struct HideoutPoint
	{
		public CoverPoint Hideout;

		public float Time;
	}

	public List<BaseChair> Chairs = new List<BaseChair>();

	public BaseChair ChairTarget;

	public float LastNavigationTime;

	public TacticalCoverPointSet CoverSet = new TacticalCoverPointSet();

	public BaseEntity LastAttacker
	{
		get
		{
			return Human.lastAttacker;
		}
		set
		{
			Human.lastAttacker = value;
			Human.lastAttackedTime = Time.time;
			Human.LastAttackedDir = (Human.lastAttacker.ServerPosition - Human.ServerPosition).normalized;
		}
	}

	public CoverPointVolume CurrentCoverVolume { get; set; }

	public List<CoverPoint> sampledCoverPoints { get; private set; }

	public List<CoverPoint.CoverType> sampledCoverPointTypes { get; private set; }

	public List<CoverPoint> EnemyCoverPoints { get; private set; }

	public CoverPoint EnemyHideoutGuess { get; set; }

	public List<HideoutPoint> CheckedHideoutPoints { get; set; }

	public PathInterestNode CurrentPatrolPoint { get; set; }

	public NPCHumanContext(NPCPlayerApex human)
		: base(human)
	{
		sampledCoverPoints = new List<CoverPoint>();
		EnemyCoverPoints = new List<CoverPoint>();
		CheckedHideoutPoints = new List<HideoutPoint>();
		sampledCoverPointTypes = new List<CoverPoint.CoverType>();
		CoverSet.Setup(human);
	}

	~NPCHumanContext()
	{
		CoverSet.Shutdown();
	}

	public void ForgetCheckedHideouts(float forgetTime)
	{
		for (int i = 0; i < CheckedHideoutPoints.Count; i++)
		{
			HideoutPoint hideoutPoint = CheckedHideoutPoints[i];
			if (Time.time - hideoutPoint.Time > forgetTime)
			{
				CheckedHideoutPoints.RemoveAt(i);
				i--;
			}
		}
	}

	public bool HasCheckedHideout(CoverPoint hideout)
	{
		for (int i = 0; i < CheckedHideoutPoints.Count; i++)
		{
			if (CheckedHideoutPoints[i].Hideout == hideout)
			{
				return true;
			}
		}
		return false;
	}
}
