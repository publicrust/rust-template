using System;
using Rust;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Barricade : DecayEntity
{
	public float reflectDamage = 5f;

	public GameObjectRef reflectEffect;

	public bool canNpcSmash = true;

	public NavMeshModifierVolume NavMeshVolumeAnimals;

	public NavMeshModifierVolume NavMeshVolumeHumanoids;

	[NonSerialized]
	public NPCBarricadeTriggerBox NpcTriggerBox;

	private static int nonWalkableArea = -1;

	private static int animalAgentTypeId = -1;

	private static int humanoidAgentTypeId = -1;

	public override void ServerInit()
	{
		base.ServerInit();
		if (nonWalkableArea < 0)
		{
			nonWalkableArea = NavMesh.GetAreaFromName("Not Walkable");
		}
		if (animalAgentTypeId < 0)
		{
			animalAgentTypeId = NavMesh.GetSettingsByIndex(1).agentTypeID;
		}
		if (NavMeshVolumeAnimals == null)
		{
			NavMeshVolumeAnimals = base.gameObject.AddComponent<NavMeshModifierVolume>();
			NavMeshVolumeAnimals.area = nonWalkableArea;
			NavMeshVolumeAnimals.AddAgentType(animalAgentTypeId);
			NavMeshVolumeAnimals.center = Vector3.zero;
			NavMeshVolumeAnimals.size = Vector3.one;
		}
		if (!canNpcSmash)
		{
			if (humanoidAgentTypeId < 0)
			{
				humanoidAgentTypeId = NavMesh.GetSettingsByIndex(0).agentTypeID;
			}
			if (NavMeshVolumeHumanoids == null)
			{
				NavMeshVolumeHumanoids = base.gameObject.AddComponent<NavMeshModifierVolume>();
				NavMeshVolumeHumanoids.area = nonWalkableArea;
				NavMeshVolumeHumanoids.AddAgentType(humanoidAgentTypeId);
				NavMeshVolumeHumanoids.center = Vector3.zero;
				NavMeshVolumeHumanoids.size = Vector3.one;
			}
		}
		else if (NpcTriggerBox == null)
		{
			NpcTriggerBox = new GameObject("NpcTriggerBox").AddComponent<NPCBarricadeTriggerBox>();
			NpcTriggerBox.Setup(this);
		}
	}

	public override void OnAttacked(HitInfo info)
	{
		if (base.isServer && info.WeaponPrefab is BaseMelee && !info.IsProjectile())
		{
			BasePlayer basePlayer = info.Initiator as BasePlayer;
			if ((bool)basePlayer && reflectDamage > 0f)
			{
				basePlayer.Hurt(reflectDamage * UnityEngine.Random.Range(0.75f, 1.25f), DamageType.Stab, this);
				if (reflectEffect.isValid)
				{
					Effect.server.Run(reflectEffect.resourcePath, basePlayer, StringPool.closest, base.transform.position, Vector3.up);
				}
			}
		}
		base.OnAttacked(info);
	}
}
