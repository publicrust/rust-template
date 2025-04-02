using UnityEngine;

public class TriggerResetter : StateMachineBehaviour
{
	public string triggerName;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		AnimatorControllerParameter[] parameters = animator.parameters;
		foreach (AnimatorControllerParameter val in parameters)
		{
			if ((int)val.type == 9 && val.name == triggerName)
			{
				animator.ResetTrigger(val.name);
			}
		}
	}
}
