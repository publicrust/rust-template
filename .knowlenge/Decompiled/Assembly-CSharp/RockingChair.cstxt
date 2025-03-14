using System;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class RockingChair : BaseChair
{
	[Header("Rocking Settings")]
	public float Acceleration = 0.8f;

	public float MaxRockingAngle = 9f;

	public float MaxRockVelocity = 4f;

	[Tooltip("Preserve and apply some existing velocity when swinging back and forth.")]
	public bool ApplyVelocityBetweenSwings = true;

	[Range(0f, 2f)]
	public float AppliedVelocity = 1f;

	[Range(0f, 2f)]
	public float WeaponFireImpact = 3f;

	[Header("Audio")]
	public SoundDefinition creakForwardSoundDef;

	public SoundDefinition creakBackwardSoundDef;

	public float creakForwardAngle = 0.1f;

	public float creakBackwardAngle = -0.1f;

	public float creakVelocityThreshold = 0.02f;

	public AnimationCurve creakGainCurve;

	private float initLocalY;

	private Vector3 initLocalRot;

	private float velocity;

	private float oppositePotentialVelocity;

	private TimeSince timeSinceInput;

	private float sineTime;

	private float timeUntilStartSine = 0.4f;

	private float t;

	private float angle;

	private Quaternion max;

	private Quaternion min;

	public override void ServerInit()
	{
		base.ServerInit();
		SaveBaseLocalPos();
		ResetChair();
	}

	public override void OnParentChanging(BaseEntity oldParent, BaseEntity newParent)
	{
		Invoke(SaveBaseLocalPos, 0f);
	}

	private void SaveBaseLocalPos()
	{
		initLocalRot = base.transform.localRotation.eulerAngles;
		initLocalY = base.transform.localPosition.y;
		max = Quaternion.Euler(initLocalRot) * Quaternion.AngleAxis(MaxRockingAngle, Vector3.right);
		min = Quaternion.Euler(initLocalRot) * Quaternion.AngleAxis(0f - MaxRockingAngle, Vector3.right);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.rockingChair = Pool.Get<ProtoBuf.RockingChair>();
		info.msg.rockingChair.initEuler = initLocalRot;
		info.msg.rockingChair.initY = initLocalY;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.rockingChair != null && base.isServer)
		{
			initLocalRot = info.msg.rockingChair.initEuler;
			base.transform.localRotation = Quaternion.Euler(initLocalRot);
			initLocalY = info.msg.rockingChair.initY;
			if (initLocalY == 0f)
			{
				initLocalY = base.transform.localPosition.y;
			}
		}
	}

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		float timeSinceLastTick = player.timeSinceLastTick;
		Vector2 inputVector = GetInputVector(inputState);
		CalculateVelocity(inputVector);
		bool flag = !Mathf.Approximately(inputVector.y, 0f);
		if (flag)
		{
			timeSinceInput = 0f;
			sineTime = 0f;
		}
		else if ((float)timeSinceInput > timeUntilStartSine)
		{
			angle = Mathf.Lerp(0f - MaxRockingAngle, MaxRockingAngle, t);
		}
		sineTime += player.timeSinceLastTick * 180f;
		PreventClipping(flag);
		ApplyVelocity(timeSinceLastTick, flag);
	}

	public override void OnWeaponFired(BaseProjectile weapon)
	{
		if (!(weapon == null))
		{
			if (weapon.recoil != null)
			{
				velocity += weapon.recoil.recoilPitchMax * WeaponFireImpact;
			}
			timeSinceInput = 0f;
			sineTime = 0f;
		}
	}

	public override void OnPlayerDismounted(BasePlayer player)
	{
		base.OnPlayerDismounted(player);
		ResetChair();
	}

	private void PreventClipping(bool hasInput)
	{
		float y = initLocalY + 0.06f;
		float num = Mathx.RemapValClamped(Mathf.Abs(angle), 0f, MaxRockingAngle, 0f, 1f);
		if (num > 0.7f)
		{
			base.transform.localPosition = Mathx.Lerp(new Vector3(base.transform.localPosition.x, initLocalY, base.transform.localPosition.z), new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z), 1.5f, num);
		}
		else
		{
			base.transform.localPosition = Mathx.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, initLocalY, base.transform.localPosition.z), 1.5f, Time.deltaTime);
		}
	}

	private void CalculateVelocity(Vector2 currentInput)
	{
		velocity += currentInput.y * Acceleration;
		velocity = Mathf.Clamp(velocity, 0f - MaxRockVelocity, MaxRockVelocity);
		oppositePotentialVelocity = (0f - velocity) * AppliedVelocity;
		int signZero = Mathx.GetSignZero(currentInput.y);
		int signZero2 = Mathx.GetSignZero(velocity);
		if (ApplyVelocityBetweenSwings && Mathf.Abs(velocity) > 0.3f && Mathx.HasSignFlipped(signZero, signZero2))
		{
			velocity += oppositePotentialVelocity;
		}
	}

	private void ApplyVelocity(float delta, bool hasInput)
	{
		t = Mathf.Sin(sineTime * (MathF.PI / 180f));
		t = Mathx.RemapValClamped(t, -1f, 1f, 0f, 1f);
		t = EaseOutCubicOvershoot(t, 0.2f);
		t = Mathf.Lerp(t, 0.5f, Mathf.Clamp01((float)timeSinceInput / 10f));
		angle += velocity;
		angle = Mathf.Clamp(angle, 0f - MaxRockingAngle, MaxRockingAngle);
		Quaternion a = Quaternion.Euler(initLocalRot) * Quaternion.AngleAxis(angle, Vector3.right);
		Quaternion b = Quaternion.Slerp(min, max, t);
		float num = ((!hasInput && (float)timeSinceInput > timeUntilStartSine) ? 1 : 0);
		Quaternion b2 = Quaternion.Slerp(a, b, num);
		base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, b2, delta * 3f);
	}

	private void ResetChair()
	{
		base.transform.localRotation = Quaternion.Euler(initLocalRot);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, initLocalY, base.transform.localPosition.z);
	}

	private Vector2 GetInputVector(InputState inputState)
	{
		bool rightDown = false;
		bool forwardDown = inputState.IsDown(BUTTON.FORWARD);
		bool backDown = inputState.IsDown(BUTTON.BACKWARD);
		return ProcessInputVector(leftDown: false, rightDown, forwardDown, backDown);
	}

	private static Vector2 ProcessInputVector(bool leftDown, bool rightDown, bool forwardDown, bool backDown)
	{
		Vector2 zero = Vector2.zero;
		if (leftDown && rightDown)
		{
			leftDown = (rightDown = false);
		}
		if (forwardDown && backDown)
		{
			forwardDown = (backDown = false);
		}
		if (forwardDown)
		{
			zero.y = 1f;
		}
		else if (backDown)
		{
			zero.y = -1f;
		}
		if (rightDown)
		{
			zero.x = 1f;
		}
		else if (leftDown)
		{
			zero.x = -1f;
		}
		return zero;
	}

	private float EaseOutCubic(float value)
	{
		return 1f - Mathf.Pow(1f - Mathf.Clamp01(value), 3f);
	}

	private float EaseOutCubicOvershoot(float value, float overshoot)
	{
		return 1f - Mathf.Pow(1f - Mathf.Clamp01(value), 3f) * (1f + overshoot * (Mathf.Clamp01(value) - 1f));
	}
}
