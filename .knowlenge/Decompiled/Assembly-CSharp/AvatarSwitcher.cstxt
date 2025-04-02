using UnityEngine;

public class AvatarSwitcher : StateMachineBehaviour
{
	public Avatar ToApply;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		((StateMachineBehaviour)this).OnStateEnter(animator, stateInfo, layerIndex);
		if ((Object)(object)ToApply != (Object)null)
		{
			animator.avatar = ToApply;
			animator.Play(((AnimatorStateInfo)(ref stateInfo)).shortNameHash, layerIndex);
		}
	}
}
