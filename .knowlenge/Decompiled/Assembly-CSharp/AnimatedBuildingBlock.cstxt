using Rust;
using UnityEngine;

public class AnimatedBuildingBlock : StabilityEntity
{
	private bool animatorNeedsInitializing = true;

	private bool animatorIsOpen = true;

	[HideInInspector]
	public bool isAnimating;

	[HideInInspector]
	public float lastAnimationStateChange;

	private static readonly int Open = Animator.StringToHash("open");

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

	public override bool ShouldUseCastNoClipChecks()
	{
		if (!isAnimating)
		{
			return Time.time - lastAnimationStateChange <= 10f;
		}
		return true;
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		UpdateAnimationParameters(init: false);
	}

	protected virtual void ApplySubAnimationParameters(bool init, Animator toAnimator)
	{
	}

	protected void UpdateAnimationParameters(bool init)
	{
		if (!model || !model.animator || !model.animator.isInitialized)
		{
			return;
		}
		bool num = animatorNeedsInitializing || animatorIsOpen != IsOpen() || (init && isAnimating);
		bool flag = animatorNeedsInitializing || init;
		lastAnimationStateChange = GetNetworkTime();
		if (num)
		{
			isAnimating = true;
			model.animator.enabled = true;
			model.animator.SetBool(Open, animatorIsOpen = IsOpen());
			ApplySubAnimationParameters(init, model.animator);
			if (flag)
			{
				model.animator.fireEvents = false;
				if (model.animator.isActiveAndEnabled)
				{
					model.animator.Update(0f);
					model.animator.Update(20f);
				}
				PutAnimatorToSleep();
				isAnimating = false;
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

	protected virtual void OnAnimatorFinished()
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
}
