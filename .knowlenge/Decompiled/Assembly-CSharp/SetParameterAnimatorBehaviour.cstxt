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
		base.OnStateEnter(animator, stateInfo, layerIndex);
		if (SetParameterTiming == Timing.OnStateEnter)
		{
			SetParameter(animator);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
	{
		base.OnStateExit(animator, stateInfo, layerIndex, controller);
		if (SetParameterTiming == Timing.OnStateExit)
		{
			SetParameter(animator);
		}
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator, stateInfo, layerIndex);
		if (SetParameterTiming == Timing.PassThreshold)
		{
			if (stateInfo.normalizedTime > ThresholdTiming && lastNormalisedTime < ThresholdTiming)
			{
				SetParameter(animator);
			}
			lastNormalisedTime = stateInfo.normalizedTime;
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
