using UnityEngine;

public class SendMessageToEntityOnAnimationFinish : StateMachineBehaviour
{
	public string messageToSendToEntity;

	public float repeatRate = 0.1f;

	private const float lastMessageSent = 0f;

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (0f + repeatRate > Time.time || animator.IsInTransition(layerIndex) || ((AnimatorStateInfo)(ref stateInfo)).normalizedTime < 1f)
		{
			return;
		}
		for (int i = 0; i < animator.layerCount; i++)
		{
			if (i != layerIndex)
			{
				if (animator.IsInTransition(i))
				{
					return;
				}
				AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(i);
				if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).speed > 0f && ((AnimatorStateInfo)(ref currentAnimatorStateInfo)).normalizedTime < 1f)
				{
					return;
				}
			}
		}
		BaseEntity baseEntity = ((Component)animator).gameObject.ToBaseEntity();
		if (Object.op_Implicit((Object)(object)baseEntity))
		{
			((Component)baseEntity).SendMessage(messageToSendToEntity, (SendMessageOptions)1);
		}
	}
}
