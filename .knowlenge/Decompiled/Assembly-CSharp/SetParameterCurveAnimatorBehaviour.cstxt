using UnityEngine;

public class SetParameterCurveAnimatorBehaviour : StateMachineBehaviour
{
	public string FloatParameterName;

	public AnimationCurve ParameterCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		((StateMachineBehaviour)this).OnStateUpdate(animator, stateInfo, layerIndex);
		animator.SetFloat(FloatParameterName, ParameterCurve.Evaluate(((AnimatorStateInfo)(ref stateInfo)).normalizedTime));
	}
}
