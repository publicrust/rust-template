using System;
using UnityEngine;

public class HarborProximityManager : MonoBehaviour, IServerComponent
{
	[Serializable]
	public class MoveToMake
	{
		public Transform EntityReferencePoint;

		public Transform MinimumPoint;

		public Transform MaximumPoint;

		public AnimationCurve Animation = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public bool UseToggleMode;

		public float ToggleSpeed = 1f;

		private float toggleState;

		private BaseEntity cachedEntity;

		public void Apply(float normalisedTime)
		{
			if (cachedEntity == null)
			{
				cachedEntity = HarborProximityEntity.GetEntity(EntityReferencePoint.position);
			}
			if (!(cachedEntity == null))
			{
				EvaluatePositionRotation(normalisedTime, out var rotToApply, out var posToApply);
				cachedEntity.transform.SetPositionAndRotation(posToApply, rotToApply);
			}
		}

		public void EvaluatePositionRotation(float normalisedTime, out Quaternion rotToApply, out Vector3 posToApply)
		{
			float num = Animation.Evaluate(normalisedTime);
			if (UseToggleMode)
			{
				if (Application.isPlaying)
				{
					toggleState = Mathf.MoveTowards(toggleState, num, Time.deltaTime * ToggleSpeed);
				}
				else
				{
					toggleState = num;
				}
				num = toggleState;
			}
			rotToApply = Quaternion.Lerp(MinimumPoint.rotation, MaximumPoint.rotation, num);
			posToApply = Vector3.Lerp(MinimumPoint.position, MaximumPoint.position, num);
		}
	}

	public MoveToMake[] Moves;

	public bool DebugCargo;

	[Range(0f, 1f)]
	public float DebugVisPoint;

	private float localNormalisedState;

	public void StartMovement()
	{
		localNormalisedState = 0f;
		Apply(0f);
	}

	public void UpdateNormalisedState(float f)
	{
		localNormalisedState = Mathf.Max(localNormalisedState, f);
		localNormalisedState = f;
		Apply(localNormalisedState);
	}

	public void EndMovement()
	{
		Apply(0f);
	}

	private void Apply(float f)
	{
		MoveToMake[] moves = Moves;
		for (int i = 0; i < moves.Length; i++)
		{
			moves[i].Apply(f);
		}
	}
}
