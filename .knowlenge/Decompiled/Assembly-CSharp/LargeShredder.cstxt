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

	public bool isShredding;

	public float shredStartTime;

	public virtual void OnEntityEnteredTrigger(BaseEntity ent)
	{
		if (!ent.IsDestroyed)
		{
			Rigidbody component = ent.GetComponent<Rigidbody>();
			if (isShredding || currentlyShredding != null)
			{
				component.velocity = -component.velocity * 3f;
				return;
			}
			shredRail.transform.position = shredRailStartPos.position;
			shredRail.transform.rotation = Quaternion.LookRotation(shredRailStartRotation);
			entryRotation = ent.transform.rotation;
			Quaternion rotation = ent.transform.rotation;
			component.isKinematic = true;
			currentlyShredding = ent;
			ent.transform.rotation = rotation;
			isShredding = true;
			SetShredding(isShredding: true);
			shredStartTime = Time.realtimeSinceStartup;
		}
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
		ItemAmount[] shredResources = component.shredResources;
		foreach (ItemAmount itemAmount in shredResources)
		{
			Item item = ItemManager.Create(itemAmount.itemDef, (int)itemAmount.amount, 0uL);
			float num = 0.5f;
			if (item.CreateWorldObject(resourceSpawnPoint.transform.position + new Vector3(Random.Range(0f - num, num), 1f, Random.Range(0f - num, num))) == null)
			{
				item.Remove();
			}
		}
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
			foreach (ItemAmount ingredient in attachedModuleEntity.AssociatedItemDef.Blueprint.ingredients)
			{
				int num2 = Mathf.FloorToInt(ingredient.amount * 0.5f);
				if (num2 != 0)
				{
					Item item2 = ItemManager.Create(ingredient.itemDef, num2, 0uL);
					float num3 = 0.5f;
					if (item2.CreateWorldObject(resourceSpawnPoint.transform.position + new Vector3(Random.Range(0f - num3, num3), 1f, Random.Range(0f - num3, num3))) == null)
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
		if (isShredding)
		{
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
			b *= Quaternion.Euler(z: Mathf.PerlinNoise(0f, num2 + 150f) * shredSwayAmount, x: num3 * shredSwayAmount, y: 0f);
			currentlyShredding.transform.rotation = Quaternion.Lerp(entryRotation, b, t2);
			if (num > 5f)
			{
				CreateShredResources();
				currentlyShredding.Kill();
				currentlyShredding = null;
				isShredding = false;
				SetShredding(isShredding: false);
			}
		}
	}

	private void Update()
	{
		ServerUpdate();
	}
}
