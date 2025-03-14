using Network;
using Rust;
using UnityEngine;

public class PetBrain : BaseAIBrain
{
	[Header("Audio")]
	public SoundDefinition CommandGivenVocalSFX;

	[ServerVar]
	public static bool DrownInDeepWater = true;

	[ServerVar]
	public static bool IdleWhenOwnerOfflineOrDead = true;

	[ServerVar]
	public static bool IdleWhenOwnerMounted = true;

	[ServerVar]
	public static float DrownTimer = 15f;

	[ReplicatedVar]
	public static float ControlDistance = 100f;

	public static int Count;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("PetBrain.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void AddStates()
	{
		base.AddStates();
	}

	public override void InitializeAI()
	{
		base.InitializeAI();
		base.ThinkMode = AIThinkMode.Interval;
		thinkRate = 0.25f;
		base.PathFinder = new HumanPathFinder();
		((HumanPathFinder)base.PathFinder).Init(GetBaseEntity());
		Count++;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		Count--;
	}

	public override void Think(float delta)
	{
		base.Think(delta);
		if (DrownInDeepWater)
		{
			BaseCombatEntity baseCombatEntity = GetBaseEntity() as BaseCombatEntity;
			if (baseCombatEntity != null && baseCombatEntity.WaterFactor() > 0.85f && !baseCombatEntity.IsDestroyed)
			{
				baseCombatEntity.Hurt(delta * (baseCombatEntity.MaxHealth() / DrownTimer), DamageType.Drowned);
			}
		}
		EvaluateLoadDefaultDesignTriggers();
	}

	private bool EvaluateLoadDefaultDesignTriggers()
	{
		if (loadedDesignIndex == 0)
		{
			return true;
		}
		bool flag = false;
		if (IdleWhenOwnerOfflineOrDead)
		{
			flag = (IdleWhenOwnerOfflineOrDead && base.OwningPlayer == null) || base.OwningPlayer.IsSleeping() || base.OwningPlayer.IsDead();
		}
		if (IdleWhenOwnerMounted && !flag)
		{
			flag = base.OwningPlayer != null && base.OwningPlayer.isMounted;
		}
		if (base.OwningPlayer != null && Vector3.Distance(base.transform.position, base.OwningPlayer.transform.position) > ControlDistance)
		{
			flag = true;
		}
		if (flag)
		{
			LoadDefaultAIDesign();
			return true;
		}
		return false;
	}

	public override void OnAIDesignLoadedAtIndex(int index)
	{
		base.OnAIDesignLoadedAtIndex(index);
		BaseEntity baseEntity = GetBaseEntity();
		if (baseEntity != null)
		{
			BasePlayer basePlayer = BasePlayer.FindByID(baseEntity.OwnerID);
			if (basePlayer != null)
			{
				basePlayer.SendClientPetStateIndex();
			}
			baseEntity.ClientRPC(RpcTarget.NetworkGroup("OnCommandGiven"));
		}
	}
}
