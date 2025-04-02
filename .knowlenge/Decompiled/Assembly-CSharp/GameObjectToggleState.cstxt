using UnityEngine;

public class GameObjectToggleState : StateMachineBehaviour
{
	public bool UseCurve;

	[MinMax(0f, 1f)]
	[Tooltip("The normalised range in the animation in which to apply the TargetState")]
	public Vector2 ValidNormalisedRange;

	public AnimationCurve CurveRange = AnimationCurve.Linear(0f, 0f, 1f, 0f);

	[Tooltip("What state to set the target object to, true = enabled, false = disabled")]
	public bool TargetState;

	[Tooltip("What gameObject to toggle (ensure it's a unique name in the hierarchy)")]
	public string GameObjectName;

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		((StateMachineBehaviour)this).OnStateUpdate(animator, stateInfo, layerIndex);
		bool flag = (UseCurve ? (CurveRange.Evaluate(((AnimatorStateInfo)(ref stateInfo)).normalizedTime) > 0f) : (((AnimatorStateInfo)(ref stateInfo)).normalizedTime > ValidNormalisedRange.x && ((AnimatorStateInfo)(ref stateInfo)).normalizedTime < ValidNormalisedRange.y));
		Model model = ((Component)animator).gameObject.GetComponent<Model>();
		if ((Object)(object)model == (Object)null)
		{
			model = ((Component)animator).gameObject.GetComponentInParent<Model>();
		}
		if ((Object)(object)model != (Object)null)
		{
			Transform val = model.FindBone(GameObjectName);
			if ((Object)(object)val != (Object)null)
			{
				((Component)val).gameObject.SetActive(flag ? TargetState : (!TargetState));
			}
		}
	}
}
