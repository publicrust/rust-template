using System.Collections.Generic;
using Facepunch;
using Facepunch.Rust;
using Rust;
using UnityEngine;

public class LargeShredder : BaseEntity
{
	public Transform shredRail;

	public Transform shredRailStartPos;

	public Transform shredRailEndPos;

	public Vector3 shredRailStartRotation;

	public Vector3 shredRailEndRotation;

	public LargeShredderTrigger trigger;

	public float shredDurationRotation = 2f;

	public float shredDurationPosition = 5f;

	public float shredSwayAmount = 1f;

	public float shredSwaySpeed = 3f;

	public BaseEntity currentlyShredding;

	public GameObject[] shreddingWheels;

	public float shredRotorSpeed = 1f;

	public GameObjectRef shredSoundEffect;

	public Transform resourceSpawnPoint;

	private Quaternion entryRotation;

	public const string SHRED_STAT = "cars_shredded";

	public const Flags IsShreddingFlag = Flags.Reserved10;

	public bool isShredding;

	private float shreddingEntityNormalizedHealth = 1f;

	public float shredStartTime;

	private float prevDelta;

	public virtual void OnEntityEnteredTrigger(BaseEntity ent)
	{
		if (ent.IsDestroyed)
		{
			return;
		}
		Rigidbody component = ent.GetComponent<Rigidbody>();
		if (isShredding || currentlyShredding != null)
		{
			if (!component.isKinematic)
			{
				component.velocity = -component.velocity * 3f;
			}
			return;
		}
		shreddingEntityNormalizedHealth = 1f;
		if (ent.TryGetComponent<MagnetLiftable>(out var component2))
		{
			if (component2.requireObjectOff && ent.IsOn())
			{
				return;
			}
			if (component2.scaleScrapResourcesByHealth && ent is BaseCombatEntity baseCombatEntity)
			{
				shreddingEntityNormalizedHealth = baseCombatEntity.healthFraction;
			}
		}
		shredRail.transform.position = shredRailStartPos.position;
		shredRail.transform.rotation = Quaternion.LookRotation(shredRailStartRotation);
		entryRotation = ent.transform.rotation;
		Quaternion rotation = ent.transform.rotation;
		using (PooledList<Collider> pooledList = Pool.Get<PooledList<Collider>>())
		{
			ent.GetComponentsInChildren(pooledList);
			foreach (Collider item in pooledList)
			{
				item.enabled = false;
			}
		}
		component.isKinematic = true;
		currentlyShredding = ent;
		ent.transform.rotation = rotation;
		isShredding = true;
		SetShredding(isShredding: true);
		prevDelta = 0f;
		shredStartTime = Time.realtimeSinceStartup;
	}

	public void CreateShredResources()
	{
		if (currentlyShredding == null)
		{
			return;
		}
		MagnetLiftable component = currentlyShredding.GetComponent<MagnetLiftable>();
		if (component == null)
		{
			return;
		}
		if (component.associatedPlayer != null && Rust.GameInfo.HasAchievements)
		{
			component.associatedPlayer.stats.Add("cars_shredded", 1);
			component.associatedPlayer.stats.Save(forceSteamSave: true);
		}
		List<Item> obj = Pool.Get<List<Item>>();
		if (component.shredResources.Length > obj.Capacity)
		{
			obj.Capacity = component.shredResources.Length;
		}
		ItemAmount[] shredResources = component.shredResources;
		foreach (ItemAmount itemAmount in shredResources)
		{
			int num = Mathf.RoundToInt(itemAmount.amount * shreddingEntityNormalizedHealth);
			if (num > 0)
			{
				Item item = ItemManager.Create(itemAmount.itemDef, num, 0uL);
				if (component.associatedPlayer != null)
				{
					item.SetItemOwnership(component.associatedPlayer, ItemOwnershipPhrases.Shredded);
				}
				float num2 = 0.5f;
				if (item.CreateWorldObject(resourceSpawnPoint.transform.position + new Vector3(Random.Range(0f - num2, num2), 1f, Random.Range(0f - num2, num2))) == null)
				{
					item.Remove();
					continue;
				}
				obj.Add(item);
				Analytics.Azure.AddPendingItems(currentlyShredding, item.info.shortname, item.amount, "car_shred", consumed: false);
			}
		}
		Analytics.Azure.OnCarShredded(component, obj);
		Pool.Free(ref obj, freeElements: false);
		BaseModularVehicle component2 = currentlyShredding.GetComponent<BaseModularVehicle>();
		if (!component2)
		{
			return;
		}
		foreach (BaseVehicleModule attachedModuleEntity in component2.AttachedModuleEntities)
		{
			if (!attachedModuleEntity.AssociatedItemDef || !attachedModuleEntity.AssociatedItemDef.Blueprint)
			{
				continue;
			}
			foreach (ItemAmount ingredient in attachedModuleEntity.AssociatedItemDef.Blueprint.GetIngredients())
			{
				int num3 = Mathf.FloorToInt(ingredient.amount * 0.5f);
				if (num3 != 0)
				{
					Item item2 = ItemManager.Create(ingredient.itemDef, num3, 0uL);
					float num4 = 0.5f;
					if (item2.CreateWorldObject(resourceSpawnPoint.transform.position + new Vector3(Random.Range(0f - num4, num4), 1f, Random.Range(0f - num4, num4))) == null)
					{
						item2.Remove();
					}
				}
			}
		}
	}

	public void UpdateBonePosition(float delta)
	{
		float t = delta / shredDurationPosition;
		float t2 = delta / shredDurationRotation;
		shredRail.transform.localPosition = Vector3.Lerp(shredRailStartPos.localPosition, shredRailEndPos.localPosition, t);
		shredRail.transform.rotation = Quaternion.LookRotation(Vector3.Lerp(shredRailStartRotation, shredRailEndRotation, t2));
	}

	public void SetShredding(bool isShredding)
	{
		if (isShredding)
		{
			InvokeRandomized(FireShredEffect, 0.25f, 0.75f, 0.25f);
		}
		else
		{
			CancelInvoke(FireShredEffect);
		}
	}

	public void FireShredEffect()
	{
		Effect.server.Run(shredSoundEffect.resourcePath, base.transform.position + Vector3.up * 3f, Vector3.up);
	}

	public void ServerUpdate()
	{
		if (base.isClient)
		{
			return;
		}
		SetFlag(Flags.Reserved10, isShredding);
		if (!isShredding)
		{
			return;
		}
		float num = Time.realtimeSinceStartup - shredStartTime;
		float t = num / shredDurationPosition;
		float t2 = num / shredDurationRotation;
		shredRail.transform.localPosition = Vector3.Lerp(shredRailStartPos.localPosition, shredRailEndPos.localPosition, t);
		shredRail.transform.rotation = Quaternion.LookRotation(Vector3.Lerp(shredRailStartRotation, shredRailEndRotation, t2));
		MagnetLiftable component = currentlyShredding.GetComponent<MagnetLiftable>();
		currentlyShredding.transform.position = shredRail.transform.position;
		Vector3 vector = base.transform.TransformDirection(component.shredDirection);
		if (Vector3.Dot(-vector, currentlyShredding.transform.forward) > Vector3.Dot(vector, currentlyShredding.transform.forward))
		{
			vector = base.transform.TransformDirection(-component.shredDirection);
		}
		bool flag = Vector3.Dot(component.transform.up, Vector3.up) >= -0.95f;
		Quaternion b = QuaternionEx.LookRotationForcedUp(vector, flag ? (-base.transform.right) : base.transform.right);
		float num2 = Time.time * shredSwaySpeed;
		float num3 = Mathf.PerlinNoise(num2, 0f);
		float num4 = Mathf.PerlinNoise(0f, num2 + 150f);
		b *= Quaternion.Euler(num3 * shredSwayAmount, 0f, num4 * shredSwayAmount);
		currentlyShredding.transform.rotation = Quaternion.Lerp(entryRotation, b, t2);
		if (prevDelta < 1.5f && num > 1.5f)
		{
			if (currentlyShredding is BaseVehicle baseVehicle)
			{
				foreach (BaseVehicle.MountPointInfo mountPoint in baseVehicle.mountPoints)
				{
					if (mountPoint.mountable != null && mountPoint.mountable.GetMounted() != null)
					{
						mountPoint.mountable.GetMounted().Hurt(999f, DamageType.Blunt, this, useProtection: false);
					}
				}
			}
			if (currentlyShredding is ScrapTransportHelicopter)
			{
				using PooledList<BasePlayer> pooledList = Pool.Get<PooledList<BasePlayer>>();
				foreach (BaseEntity child in currentlyShredding.children)
				{
					if (child is BasePlayer { isMounted: false } basePlayer)
					{
						pooledList.Add(basePlayer);
					}
				}
				foreach (BasePlayer item in pooledList)
				{
					item.Hurt(999f, DamageType.Blunt, this, useProtection: false);
				}
			}
		}
		prevDelta = num;
		if (num > 5f)
		{
			CreateShredResources();
			currentlyShredding.Kill();
			currentlyShredding = null;
			isShredding = false;
			SetShredding(isShredding: false);
		}
	}

	private void Update()
	{
		ServerUpdate();
	}
}
