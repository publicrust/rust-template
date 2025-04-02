using Rust;
using UnityEngine;

public class DoorAnimEvents : MonoBehaviour, IClientComponent
{
	public GameObjectRef openStart;

	public GameObjectRef openEnd;

	public GameObjectRef closeStart;

	public GameObjectRef closeEnd;

	public GameObject soundTarget;

	public bool checkAnimSpeed;

	public Animator animator => ((Component)this).GetComponent<Animator>();

	public void DoorOpenStart()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (Application.isLoading || !openStart.isValid || animator.IsInTransition(0))
		{
			return;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).normalizedTime > 0.5f)
		{
			return;
		}
		if (checkAnimSpeed)
		{
			currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).speed < 0f)
			{
				return;
			}
		}
		Effect.client.Run(openStart.resourcePath, ((Object)(object)soundTarget == (Object)null) ? ((Component)this).gameObject : soundTarget);
	}

	public void DoorOpenEnd()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (Application.isLoading || !openEnd.isValid || animator.IsInTransition(0))
		{
			return;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).normalizedTime < 0.5f)
		{
			return;
		}
		if (checkAnimSpeed)
		{
			currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).speed < 0f)
			{
				return;
			}
		}
		Effect.client.Run(openEnd.resourcePath, ((Object)(object)soundTarget == (Object)null) ? ((Component)this).gameObject : soundTarget);
	}

	public void DoorCloseStart()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (Application.isLoading || !closeStart.isValid || animator.IsInTransition(0))
		{
			return;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).normalizedTime > 0.5f)
		{
			return;
		}
		if (checkAnimSpeed)
		{
			currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).speed > 0f)
			{
				return;
			}
		}
		Effect.client.Run(closeStart.resourcePath, ((Object)(object)soundTarget == (Object)null) ? ((Component)this).gameObject : soundTarget);
	}

	public void DoorCloseEnd()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (Application.isLoading || !closeEnd.isValid || animator.IsInTransition(0))
		{
			return;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).normalizedTime < 0.5f)
		{
			return;
		}
		if (checkAnimSpeed)
		{
			currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).speed > 0f)
			{
				return;
			}
		}
		Effect.client.Run(closeEnd.resourcePath, ((Object)(object)soundTarget == (Object)null) ? ((Component)this).gameObject : soundTarget);
	}
}
