using ConVar;
using ProtoBuf;
using UnityEngine;

public class GingerbreadNPC : HumanNPC, global::IClientBrainStateListener
{
	public GameObjectRef OverrideCorpseMale;

	public GameObjectRef OverrideCorpseFemale;

	public PhysicMaterial HitMaterial;

	public bool RoamAroundHomePoint;

	protected override string CorpsePath => CorpseResourcePath;

	protected override string OverrideCorpseName => "Gingerbread";

	protected override bool ShouldCorpseTakeChildren => false;

	protected override bool KeepCorpseClothingIntact => false;

	protected override bool CopyInventoryToCorpse => false;

	protected string CorpseResourcePath
	{
		get
		{
			bool flag = GetFloatBasedOnUserID(userID, 4332uL) > 0.5f;
			if (OverrideCorpseMale.isValid && !flag)
			{
				return OverrideCorpseMale.resourcePath;
			}
			if (OverrideCorpseFemale.isValid && flag)
			{
				return OverrideCorpseFemale.resourcePath;
			}
			return "assets/prefabs/npc/murderer/murderer_corpse.prefab";
			static float GetFloatBasedOnUserID(ulong steamid, ulong seed)
			{
				Random.State state = Random.state;
				Random.InitState((int)(seed + steamid));
				float result = Random.Range(0f, 1f);
				Random.state = state;
				return result;
			}
		}
	}

	public override void OnAttacked(HitInfo info)
	{
		base.OnAttacked(info);
		info.HitMaterial = Global.GingerbreadMaterialID();
	}

	public override string Categorize()
	{
		return "Gingerbread";
	}

	public override bool ShouldDropActiveItem()
	{
		return false;
	}

	public override void AttackerInfo(PlayerLifeStory.DeathInfo info)
	{
		base.AttackerInfo(info);
		info.inflictorName = base.inventory.containerBelt.GetSlot(0).info.shortname;
		info.attackerName = base.ShortPrefabName;
	}

	public void OnClientStateChanged(AIState state)
	{
	}
}
