using System;
using Network;
using Rust;
using UnityEngine;

public class NewYearGong : BaseCombatEntity
{
	public SoundDefinition gongSound;

	public float minTimeBetweenSounds = 0.25f;

	public GameObject soundRoot;

	public Transform gongCentre;

	public float gongRadius = 1f;

	public AnimationCurve pitchCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public Animator gongAnimator;

	private float lastSound;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		TimeWarning val = TimeWarning.New("NewYearGong.OnRpcMessage", 0);
		try
		{
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void Hurt(HitInfo info)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (!info.damageTypes.IsMeleeType() && !info.damageTypes.Has(DamageType.Bullet) && !info.damageTypes.Has(DamageType.Arrow))
		{
			base.Hurt(info);
			return;
		}
		Vector3 val = gongCentre.InverseTransformPoint(info.HitPositionWorld);
		val.z = 0f;
		float num = Vector3.Distance(val, Vector3.zero);
		if (num < gongRadius)
		{
			if (Time.time - lastSound > minTimeBetweenSounds)
			{
				lastSound = Time.time;
				ClientRPC(RpcTarget.NetworkGroup("PlaySound"), Mathf.Clamp01(num / gongRadius));
			}
		}
		else
		{
			base.Hurt(info);
		}
	}
}
