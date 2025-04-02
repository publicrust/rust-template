using UnityEngine;

public class AvatarSwitcher : StateMachineBehaviour
{
	public Avatar ToApply;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		if (ToApply != null)
		{
			animator.avatar = ToApply;
			animator.Play(stateInfo.shortNameHash, layerIndex);
		}
	}
}
