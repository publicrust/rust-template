using ConVar;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;

public class GingerbreadNPC : HumanNPC, global::IClientBrainStateListener
{
	public GameObjectRef OverrideCorpseMale;

	public GameObjectRef OverrideCorpseFemale;

	public PhysicMaterial HitMaterial;

	public bool RoamAroundHomePoint;

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
				UnityEngine.Random.State state = UnityEngine.Random.state;
				UnityEngine.Random.InitState((int)(seed + steamid));
				float result = UnityEngine.Random.Range(0f, 1f);
				UnityEngine.Random.state = state;
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

	public override BaseCorpse CreateCorpse()
	{
		using (TimeWarning.New("Create corpse"))
		{
			string corpseResourcePath = CorpseResourcePath;
			NPCPlayerCorpse nPCPlayerCorpse = DropCorpse(corpseResourcePath) as NPCPlayerCorpse;
			if ((bool)nPCPlayerCorpse)
			{
				nPCPlayerCorpse.transform.position = nPCPlayerCorpse.transform.position + Vector3.down * NavAgent.baseOffset;
				nPCPlayerCorpse.SetLootableIn(2f);
				nPCPlayerCorpse.SetFlag(Flags.Reserved5, HasPlayerFlag(PlayerFlags.DisplaySash));
				nPCPlayerCorpse.SetFlag(Flags.Reserved2, b: true);
				nPCPlayerCorpse.TakeFrom(inventory.containerMain);
				nPCPlayerCorpse.playerName = "Gingerbread";
				nPCPlayerCorpse.playerSteamID = userID;
				nPCPlayerCorpse.Spawn();
				ItemContainer[] containers = nPCPlayerCorpse.containers;
				for (int i = 0; i < containers.Length; i++)
				{
					containers[i].Clear();
				}
				if (LootSpawnSlots.Length != 0)
				{
					object obj = Interface.CallHook("OnCorpsePopulate", this, nPCPlayerCorpse);
					if (obj is BaseCorpse)
					{
						return (BaseCorpse)obj;
					}
					LootContainer.LootSpawnSlot[] lootSpawnSlots = LootSpawnSlots;
					for (int i = 0; i < lootSpawnSlots.Length; i++)
					{
						LootContainer.LootSpawnSlot lootSpawnSlot = lootSpawnSlots[i];
						for (int j = 0; j < lootSpawnSlot.numberToSpawn; j++)
						{
							if (UnityEngine.Random.Range(0f, 1f) <= lootSpawnSlot.probability)
							{
								lootSpawnSlot.definition.SpawnIntoContainer(nPCPlayerCorpse.containers[0]);
							}
						}
					}
				}
			}
			return nPCPlayerCorpse;
		}
	}

	public override void AttackerInfo(PlayerLifeStory.DeathInfo info)
	{
		base.AttackerInfo(info);
		info.inflictorName = inventory.containerBelt.GetSlot(0).info.shortname;
		info.attackerName = base.ShortPrefabName;
	}

	public void OnClientStateChanged(AIState state)
	{
	}
}
