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

	public Animator animator => GetComponent<Animator>();

	private void DoorOpenStart()
	{
		if (!Rust.Application.isLoading && openStart.isValid && !animator.IsInTransition(0) && !(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f) && (!checkAnimSpeed || !(animator.GetCurrentAnimatorStateInfo(0).speed < 0f)))
		{
			Effect.client.Run(openStart.resourcePath, (soundTarget == null) ? base.gameObject : soundTarget);
		}
	}

	private void DoorOpenEnd()
	{
		if (!Rust.Application.isLoading && openEnd.isValid && !animator.IsInTransition(0) && !(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f) && (!checkAnimSpeed || !(animator.GetCurrentAnimatorStateInfo(0).speed < 0f)))
		{
			Effect.client.Run(openEnd.resourcePath, (soundTarget == null) ? base.gameObject : soundTarget);
		}
	}

	private void DoorCloseStart()
	{
		if (!Rust.Application.isLoading && closeStart.isValid && !animator.IsInTransition(0) && !(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f) && (!checkAnimSpeed || !(animator.GetCurrentAnimatorStateInfo(0).speed > 0f)))
		{
			Effect.client.Run(closeStart.resourcePath, (soundTarget == null) ? base.gameObject : soundTarget);
		}
	}

	private void DoorCloseEnd()
	{
		if (!Rust.Application.isLoading && closeEnd.isValid && !animator.IsInTransition(0) && !(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f) && (!checkAnimSpeed || !(animator.GetCurrentAnimatorStateInfo(0).speed > 0f)))
		{
			Effect.client.Run(closeEnd.resourcePath, (soundTarget == null) ? base.gameObject : soundTarget);
		}
	}
}
