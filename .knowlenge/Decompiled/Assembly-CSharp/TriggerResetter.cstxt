using UnityEngine;

public class TriggerResetter : StateMachineBehaviour
{
	public string triggerName;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		AnimatorControllerParameter[] parameters = animator.parameters;
		foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
		{
			if (animatorControllerParameter.type == AnimatorControllerParameterType.Trigger && animatorControllerParameter.name == triggerName)
			{
				animator.ResetTrigger(animatorControllerParameter.name);
			}
		}
	}
}
