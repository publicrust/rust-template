using System.Collections.Generic;
using ConVar;
using Network;
using Oxide.Core;
using Rust;
using UnityEngine;

public class Effect : EffectData
{
	public enum Type : uint
	{
		Generic,
		Projectile,
		GenericGlobal
	}

	public static class client
	{
		public static void Run(Type fxtype, BaseEntity ent, uint boneID = 0u, Vector3 posLocal = default(Vector3), Vector3 normLocal = default(Vector3))
		{
		}

		public static void Run(string strName, BaseEntity ent, uint boneID = 0u, Vector3 posLocal = default(Vector3), Vector3 normLocal = default(Vector3))
		{
			string.IsNullOrEmpty(strName);
		}

		public static void Run(Type fxtype, Vector3 posWorld = default(Vector3), Vector3 normWorld = default(Vector3), Vector3 up = default(Vector3))
		{
		}

		public static void Run(string strName, Vector3 posWorld = default(Vector3), Vector3 normWorld = default(Vector3), Vector3 up = default(Vector3), Type overrideType = Type.Generic)
		{
			string.IsNullOrEmpty(strName);
		}

		public static void Run(string strName, GameObject obj)
		{
			string.IsNullOrEmpty(strName);
		}

		public static void DoAdditiveImpactEffect(HitInfo info, string effectName)
		{
			if (info.HitEntity.IsValid())
			{
				Run(effectName, info.HitEntity, info.HitBone, info.HitPositionLocal + info.HitNormalLocal * 0.1f, info.HitNormalLocal);
			}
			else
			{
				Run(effectName, info.HitPositionWorld + info.HitNormalWorld * 0.1f, info.HitNormalWorld);
			}
		}

		private static bool CanPlayImpactEffect(HitInfo info)
		{
			if (TerrainMeta.WaterMap != null && info.HitMaterial != Projectile.WaterMaterialID() && info.HitMaterial != Projectile.FleshMaterialID() && WaterLevel.Test(info.HitPositionWorld, waves: false, volumes: false))
			{
				return false;
			}
			return true;
		}

		private static Type GetOverrideType(HitInfo info)
		{
			return Type.Generic;
		}

		private static void HandleAdditiveEffects(HitInfo info)
		{
			if (info.damageTypes.Has(DamageType.Explosion))
			{
				DoAdditiveImpactEffect(info, "assets/bundled/prefabs/fx/impacts/additive/explosion.prefab");
			}
			if (info.damageTypes.Has(DamageType.Heat))
			{
				DoAdditiveImpactEffect(info, "assets/bundled/prefabs/fx/impacts/additive/fire.prefab");
			}
		}

		public static void ImpactEffect(HitInfo info, string customEffect = null)
		{
			if (!info.DoHitEffects)
			{
				return;
			}
			string materialName = StringPool.Get(info.HitMaterial);
			string strName = customEffect ?? EffectDictionary.GetParticle(info.damageTypes.GetMajorityDamageType(), materialName);
			string decal = EffectDictionary.GetDecal(info.damageTypes.GetMajorityDamageType(), materialName);
			if (!CanPlayImpactEffect(info))
			{
				return;
			}
			if (info.HitEntity.IsValid())
			{
				if (customEffect == null)
				{
					GameObjectRef impactEffect = info.HitEntity.GetImpactEffect(info);
					if (impactEffect.isValid)
					{
						strName = impactEffect.resourcePath;
					}
				}
				Run(strName, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal);
				if (info.DoDecals)
				{
					Run(decal, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal);
				}
			}
			else
			{
				Type overrideType = GetOverrideType(info);
				Run(strName, info.HitPositionWorld, info.HitNormalWorld, default(Vector3), overrideType);
				Run(decal, info.HitPositionWorld, info.HitNormalWorld, default(Vector3), overrideType);
			}
			if (info.WeaponPrefab is BaseMelee baseMelee)
			{
				string strikeEffectPath = baseMelee.GetStrikeEffectPath(materialName);
				if (info.HitEntity.IsValid())
				{
					Run(strikeEffectPath, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal);
				}
				else
				{
					Run(strikeEffectPath, info.HitPositionWorld, info.HitNormalWorld);
				}
			}
			HandleAdditiveEffects(info);
		}
	}

	public static class server
	{
		public static void Run(Type fxtype, BaseEntity ent, uint boneID = 0u, Vector3 posLocal = default(Vector3), Vector3 normLocal = default(Vector3), Connection sourceConnection = null, bool broadcast = false, List<Connection> targets = null)
		{
			reusableInstace.Init(fxtype, ent, boneID, posLocal, normLocal, sourceConnection);
			reusableInstace.broadcast = broadcast;
			reusableInstace.targets = targets;
			EffectNetwork.Send(reusableInstace);
		}

		public static void Run(string strName, BaseEntity ent, uint boneID = 0u, Vector3 posLocal = default(Vector3), Vector3 normLocal = default(Vector3), Connection sourceConnection = null, bool broadcast = false, List<Connection> targets = null)
		{
			if (!string.IsNullOrEmpty(strName))
			{
				reusableInstace.Init(Type.Generic, ent, boneID, posLocal, normLocal, sourceConnection);
				reusableInstace.pooledString = strName;
				reusableInstace.broadcast = broadcast;
				reusableInstace.targets = targets;
				EffectNetwork.Send(reusableInstace);
			}
		}

		public static void Run(Type fxtype, Vector3 posWorld = default(Vector3), Vector3 normWorld = default(Vector3), Connection sourceConnection = null, bool broadcast = false, List<Connection> targets = null)
		{
			reusableInstace.Init(fxtype, posWorld, normWorld, sourceConnection);
			reusableInstace.broadcast = broadcast;
			reusableInstace.targets = targets;
			EffectNetwork.Send(reusableInstace);
		}

		public static void Run(string strName, Vector3 posWorld = default(Vector3), Vector3 normWorld = default(Vector3), Connection sourceConnection = null, bool broadcast = false, List<Connection> targets = null)
		{
			if (!string.IsNullOrEmpty(strName))
			{
				reusableInstace.Init(Type.Generic, posWorld, normWorld, sourceConnection);
				reusableInstace.pooledString = strName;
				reusableInstace.broadcast = broadcast;
				reusableInstace.targets = targets;
				EffectNetwork.Send(reusableInstace);
			}
		}

		public static void DoAdditiveImpactEffect(HitInfo info, string effectName)
		{
			if (info.HitEntity.IsValid())
			{
				Run(effectName, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal, info.Predicted);
			}
			else
			{
				Run(effectName, info.HitPositionWorld, info.HitNormalWorld, info.Predicted);
			}
		}

		private static bool CanPlayImpactEffect(HitInfo info)
		{
			if (TerrainMeta.WaterMap != null && info.HitMaterial != Projectile.WaterMaterialID() && info.HitMaterial != Projectile.FleshMaterialID() && WaterLevel.Test(info.HitPositionWorld, waves: false, volumes: false))
			{
				return false;
			}
			return true;
		}

		private static void HandleAdditiveEffects(HitInfo info)
		{
			if (info.damageTypes.Has(DamageType.Explosion))
			{
				DoAdditiveImpactEffect(info, "assets/bundled/prefabs/fx/impacts/additive/explosion.prefab");
			}
			if (info.damageTypes.Has(DamageType.Heat))
			{
				DoAdditiveImpactEffect(info, "assets/bundled/prefabs/fx/impacts/additive/fire.prefab");
			}
		}

		private static void HandleWeaponEffects(HitInfo info, string materialName)
		{
			if (!info.WeaponPrefab)
			{
				return;
			}
			BaseMelee baseMelee = info.WeaponPrefab as BaseMelee;
			if (baseMelee != null)
			{
				string strikeEffectPath = baseMelee.GetStrikeEffectPath(materialName);
				if (info.HitEntity.IsValid())
				{
					Run(strikeEffectPath, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal, info.Predicted);
				}
				else
				{
					Run(strikeEffectPath, info.HitPositionWorld, info.HitNormalWorld, info.Predicted);
				}
			}
		}

		private static bool IsLegalPlacement(HitInfo info)
		{
			Bounds bounds = info.HitEntity.bounds;
			float num = info.HitEntity.BoundsPadding();
			bounds.extents += new Vector3(num, num, num);
			if (!bounds.Contains(info.HitPositionLocal))
			{
				BasePlayer initiatorPlayer = info.InitiatorPlayer;
				if (initiatorPlayer != null && initiatorPlayer.GetType() == typeof(BasePlayer))
				{
					float num2 = Mathf.Sqrt(bounds.SqrDistance(info.HitPositionLocal));
					if (num2 > ConVar.AntiHack.impact_effect_distance_forgiveness)
					{
						AntiHack.Log(initiatorPlayer, AntiHackType.EffectHack, $"Tried to run an impact effect outside of entity '{info.HitEntity.ShortPrefabName}' bounds by {num2}m");
					}
				}
				return false;
			}
			return true;
		}

		public static void ImpactEffect(HitInfo info, string customEffect = null)
		{
			if (Interface.CallHook("OnImpactEffectCreate", info, customEffect) != null || ((bool)info.InitiatorPlayer && info.InitiatorPlayer.limitNetworking) || !info.DoHitEffects)
			{
				return;
			}
			string materialName = StringPool.Get(info.HitMaterial);
			if (!CanPlayImpactEffect(info))
			{
				return;
			}
			string strName = customEffect ?? EffectDictionary.GetParticle(info.damageTypes.GetMajorityDamageType(), materialName);
			string decal = EffectDictionary.GetDecal(info.damageTypes.GetMajorityDamageType(), materialName);
			if (info.HitEntity.IsValid())
			{
				if (customEffect == null)
				{
					GameObjectRef impactEffect = info.HitEntity.GetImpactEffect(info);
					if (impactEffect.isValid)
					{
						strName = impactEffect.resourcePath;
					}
				}
				if (!IsLegalPlacement(info))
				{
					return;
				}
				Run(strName, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal, info.Predicted);
				Run(decal, info.HitEntity, info.HitBone, info.HitPositionLocal, info.HitNormalLocal, info.Predicted);
			}
			else
			{
				Run(strName, info.HitPositionWorld, info.HitNormalWorld, info.Predicted);
				Run(decal, info.HitPositionWorld, info.HitNormalWorld, info.Predicted);
			}
			HandleWeaponEffects(info, materialName);
			HandleAdditiveEffects(info);
		}
	}

	public Vector3 upDir;

	public Vector3 worldPos;

	public Vector3 worldNrm;

	public bool attached;

	public Transform transform;

	public GameObject gameObject;

	public string pooledString;

	public bool broadcast;

	public List<Connection> targets;

	private static Effect reusableInstace = new Effect();

	public Effect()
	{
	}

	public Effect(string effectName, Vector3 posWorld, Vector3 normWorld, Connection sourceConnection = null)
	{
		Init(Type.Generic, posWorld, normWorld, sourceConnection);
		pooledString = effectName;
	}

	public Effect(string effectName, BaseEntity ent, uint boneID, Vector3 posLocal, Vector3 normLocal, Connection sourceConnection = null)
	{
		Init(Type.Generic, ent, boneID, posLocal, normLocal, sourceConnection);
		pooledString = effectName;
	}

	public void Init(Type fxtype, BaseEntity ent, uint boneID, Vector3 posLocal, Vector3 normLocal, Connection sourceConnection = null)
	{
		Clear();
		type = (uint)fxtype;
		attached = true;
		origin = posLocal;
		normal = normLocal;
		if (ent != null && !ent.IsValid())
		{
			Debug.LogWarning("Effect.Init - invalid entity");
		}
		entity = (ent.IsValid() ? ent.net.ID : default(NetworkableId));
		source = sourceConnection?.userid ?? 0;
		bone = boneID;
	}

	public void Init(Type fxtype, Vector3 posWorld, Vector3 normWorld, Connection sourceConnection = null)
	{
		Clear();
		type = (uint)fxtype;
		attached = false;
		origin = (worldPos = posWorld);
		normal = (worldNrm = normWorld);
		source = sourceConnection?.userid ?? 0;
	}

	public void Clear()
	{
		type = 0u;
		pooledstringid = 0u;
		number = 0;
		origin = default(Vector3);
		normal = default(Vector3);
		scale = 0f;
		entity = default(NetworkableId);
		bone = 0u;
		source = 0uL;
		distanceOverride = 0f;
		upDir = Vector3.zero;
		worldPos = Vector3.zero;
		worldNrm = Vector3.zero;
		attached = false;
		transform = null;
		gameObject = null;
		pooledString = null;
		broadcast = false;
		targets = null;
	}
}
