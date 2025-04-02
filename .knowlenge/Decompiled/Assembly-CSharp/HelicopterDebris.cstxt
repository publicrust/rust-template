using System.Collections.Generic;
using Rust;
using UnityEngine;

public class HelicopterDebris : ServerGib
{
	public ItemDefinition metalFragments;

	public ItemDefinition hqMetal;

	public ItemDefinition charcoal;

	[Tooltip("Divide mass by this amount to produce a scalar of resources, default = 5")]
	public float massReductionScalar = 5f;

	private ResourceDispenser resourceDispenser;

	public float tooHotUntil;

	public override void ServerInit()
	{
		base.ServerInit();
		tooHotUntil = Time.realtimeSinceStartup + 480f;
	}

	public override void PhysicsInit(Mesh mesh)
	{
		base.PhysicsInit(mesh);
		if (!base.isServer)
		{
			return;
		}
		resourceDispenser = GetComponent<ResourceDispenser>();
		float num = Mathf.Clamp01(GetComponent<Rigidbody>().mass / massReductionScalar);
		resourceDispenser.containedItems = new List<ItemAmount>();
		if (num > 0.75f && hqMetal != null)
		{
			resourceDispenser.containedItems.Add(new ItemAmount(hqMetal, Mathf.CeilToInt(7f * num)));
		}
		if (num > 0f)
		{
			if (metalFragments != null)
			{
				resourceDispenser.containedItems.Add(new ItemAmount(metalFragments, Mathf.CeilToInt(150f * num)));
			}
			if (charcoal != null)
			{
				resourceDispenser.containedItems.Add(new ItemAmount(charcoal, Mathf.CeilToInt(80f * num)));
			}
		}
		resourceDispenser.Initialize();
	}

	public bool IsTooHot()
	{
		return tooHotUntil > Time.realtimeSinceStartup;
	}

	public override void OnAttacked(HitInfo info)
	{
		if (IsTooHot() && info.WeaponPrefab is BaseMelee)
		{
			if (info.Initiator is BasePlayer)
			{
				HitInfo hitInfo = new HitInfo();
				hitInfo.damageTypes.Add(DamageType.Heat, 5f);
				hitInfo.DoHitEffects = true;
				hitInfo.DidHit = true;
				hitInfo.HitBone = 0u;
				hitInfo.Initiator = this;
				hitInfo.PointStart = base.transform.position;
				Effect.server.Run("assets/bundled/prefabs/fx/impacts/additive/fire.prefab", info.Initiator, 0u, new Vector3(0f, 1f, 0f), Vector3.up);
			}
		}
		else
		{
			if ((bool)resourceDispenser)
			{
				resourceDispenser.OnAttacked(info);
			}
			base.OnAttacked(info);
		}
	}
}
