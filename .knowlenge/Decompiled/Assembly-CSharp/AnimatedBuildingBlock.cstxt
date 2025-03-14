using Rust;
using UnityEngine;

public class AnimatedBuildingBlock : StabilityEntity
{
	private bool animatorNeedsInitializing = true;

	private bool animatorIsOpen = true;

	private bool isAnimating;

	public override void ServerInit()
	{
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			UpdateAnimationParameters(init: true);
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		UpdateAnimationParameters(init: true);
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		UpdateAnimationParameters(init: false);
	}

	protected void UpdateAnimationParameters(bool init)
	{
		if (!model || !model.animator || !model.animator.isInitialized)
		{
			return;
		}
		bool num = animatorNeedsInitializing || animatorIsOpen != IsOpen() || (init && isAnimating);
		bool flag = animatorNeedsInitializing || init;
		if (num)
		{
			isAnimating = true;
			model.animator.enabled = true;
			model.animator.SetBool("open", animatorIsOpen = IsOpen());
			if (flag)
			{
				model.animator.fireEvents = false;
				if (model.animator.isActiveAndEnabled)
				{
					model.animator.Update(0f);
					model.animator.Update(20f);
				}
				PutAnimatorToSleep();
			}
			else
			{
				model.animator.fireEvents = base.isClient;
				if (base.isServer)
				{
					SetFlag(Flags.Busy, b: true);
				}
			}
		}
		else if (flag)
		{
			PutAnimatorToSleep();
		}
		animatorNeedsInitializing = false;
	}

	protected void OnAnimatorFinished()
	{
		if (!isAnimating)
		{
			PutAnimatorToSleep();
		}
		isAnimating = false;
	}

	private void PutAnimatorToSleep()
	{
		if (!model || !model.animator)
		{
			Debug.LogWarning(TransformEx.GetRecursiveName(base.transform) + " has missing model/animator", base.gameObject);
			return;
		}
		model.animator.enabled = false;
		if (base.isServer)
		{
			SetFlag(Flags.Busy, b: false);
		}
		OnAnimatorDisabled();
	}

	protected virtual void OnAnimatorDisabled()
	{
	}

	public override bool SupportsChildDeployables()
	{
		return false;
	}
}
