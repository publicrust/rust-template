using System;
using UnityEngine;
using UnityEngine.Animations;

public class SetParameterAnimatorBehaviour : StateMachineBehaviour
{
	public enum ParamType
	{
		Float,
		Bool,
		Int
	}

	public enum Timing
	{
		OnStateEnter,
		OnStateExit,
		PassThreshold
	}

	public string ParameterName;

	public ParamType ParameterType;

	public float FloatValue;

	public bool BoolValue;

	public int IntValue;

	public Timing SetParameterTiming;

	[Tooltip("Normalised time of animation")]
	[Range(0f, 1f)]
	public float ThresholdTiming;

	private float lastNormalisedTime;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		((StateMachineBehaviour)this).OnStateEnter(animator, stateInfo, layerIndex);
		if (SetParameterTiming == Timing.OnStateEnter)
		{
			SetParameter(animator);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		((StateMachineBehaviour)this).OnStateExit(animator, stateInfo, layerIndex, controller);
		if (SetParameterTiming == Timing.OnStateExit)
		{
			SetParameter(animator);
		}
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		((StateMachineBehaviour)this).OnStateUpdate(animator, stateInfo, layerIndex);
		if (SetParameterTiming == Timing.PassThreshold)
		{
			if (((AnimatorStateInfo)(ref stateInfo)).normalizedTime > ThresholdTiming && lastNormalisedTime < ThresholdTiming)
			{
				SetParameter(animator);
			}
			lastNormalisedTime = ((AnimatorStateInfo)(ref stateInfo)).normalizedTime;
		}
	}

	private void SetParameter(Animator animator)
	{
		switch (ParameterType)
		{
		case ParamType.Float:
			animator.SetFloat(ParameterName, FloatValue);
			break;
		case ParamType.Bool:
			animator.SetBool(ParameterName, BoolValue);
			break;
		case ParamType.Int:
			animator.SetInteger(ParameterName, IntValue);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}
}
