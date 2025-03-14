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
		using (TimeWarning.New("NewYearGong.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void Hurt(HitInfo info)
	{
		if (!info.damageTypes.IsMeleeType() && !info.damageTypes.Has(DamageType.Bullet) && !info.damageTypes.Has(DamageType.Arrow))
		{
			base.Hurt(info);
			return;
		}
		Vector3 a = gongCentre.InverseTransformPoint(info.HitPositionWorld);
		a.z = 0f;
		float num = Vector3.Distance(a, Vector3.zero);
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
