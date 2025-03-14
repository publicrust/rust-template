#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class RidableHorse : BaseRidableAnimal
{
	public Translate.Phrase SwapToSingleTitle;

	public Translate.Phrase SwapToSingleDescription;

	public Sprite SwapToSingleIcon;

	public Translate.Phrase SwapToDoubleTitle;

	public Translate.Phrase SwapToDoubleDescription;

	public Sprite SwapToDoubleIcon;

	public ItemDefinition WildSaddleItem;

	[ServerVar(Help = "Population active on the server, per square km", ShowInAdminUI = true)]
	public static float Population = 2f;

	public string distanceStatName = "";

	public HorseBreed[] breeds;

	public SkinnedMeshRenderer[] bodyRenderers;

	public SkinnedMeshRenderer[] hairRenderers;

	public int currentBreed = -1;

	public ProtectionProperties riderProtection;

	public ProtectionProperties baseHorseProtection;

	public const Flags Flag_HideHair = Flags.Reserved4;

	public const Flags Flag_WoodArmor = Flags.Reserved5;

	public const Flags Flag_RoadsignArmor = Flags.Reserved6;

	public const Flags Flag_HasSingleSaddle = Flags.Reserved9;

	public const Flags Flag_HasDoubleSaddle = Flags.Reserved10;

	public float equipmentSpeedMod;

	public int numStorageSlots;

	private int prevBreed;

	private int prevSlots;

	private static Material[] breedAssignmentArray = new Material[2];

	private float distanceRecordingSpacing = 5f;

	public HitchTrough currentHitch;

	public float totalDistance;

	public float kmDistance;

	public float tempDistanceTravelled;

	public int numEquipmentSlots = 4;

	public override float RealisticMass => 550f;

	public override float PositionTickRate
	{
		protected get
		{
			return 0.05f;
		}
	}

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("RidableHorse.OnRpcMessage"))
		{
			if (rpc == 1765203204 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - RPC_ReqSwapSaddleType "));
				}
				using (TimeWarning.New("RPC_ReqSwapSaddleType"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsVisible.Test(1765203204u, "RPC_ReqSwapSaddleType", this, player, 3f))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							RPC_ReqSwapSaddleType(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in RPC_ReqSwapSaddleType");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public int GetStorageSlotCount()
	{
		return numStorageSlots;
	}

	public void ApplyBreed(int index)
	{
		if (currentBreed != index)
		{
			if (index >= breeds.Length || index < 0)
			{
				Debug.LogError("ApplyBreed issue! index is " + index + " breed length is : " + breeds.Length);
			}
			else
			{
				ApplyBreedInternal(breeds[index]);
				currentBreed = index;
			}
		}
	}

	protected void ApplyBreedInternal(HorseBreed breed)
	{
		if (base.isServer)
		{
			SetMaxHealth(StartHealth() * breed.maxHealth);
			base.health = MaxHealth();
		}
	}

	public HorseBreed GetBreed()
	{
		if (currentBreed == -1 || currentBreed >= breeds.Length)
		{
			return null;
		}
		return breeds[currentBreed];
	}

	public override float GetTrotSpeed()
	{
		float num = equipmentSpeedMod / (base.GetRunSpeed() * GetBreed().maxSpeed);
		return base.GetTrotSpeed() * GetBreed().maxSpeed * (1f + num);
	}

	public override float GetRunSpeed()
	{
		float num = base.GetRunSpeed();
		HorseBreed breed = GetBreed();
		return num * breed.maxSpeed + equipmentSpeedMod;
	}

	public override void OnInventoryFirstCreated(ItemContainer container)
	{
		base.OnInventoryFirstCreated(container);
		SpawnWildSaddle();
	}

	private void SpawnWildSaddle()
	{
		SetSeatCount(1);
	}

	public void SetForSale()
	{
		SetFlag(Flags.Reserved2, b: true);
		SetSeatCount(0);
	}

	public override bool IsStandCollisionClear()
	{
		List<Collider> obj = Facepunch.Pool.GetList<Collider>();
		bool flag = false;
		if (HasSingleSaddle())
		{
			Vis.Colliders(mountPoints[0].mountable.eyePositionOverride.transform.position - base.transform.forward * 1f, 2f, obj, 2162689);
			flag = obj.Count > 0;
		}
		else if (HasDoubleSaddle())
		{
			Vis.Colliders(mountPoints[1].mountable.eyePositionOverride.transform.position - base.transform.forward * 1f, 2f, obj, 2162689);
			flag = obj.Count > 0;
			if (!flag)
			{
				Vis.Colliders(mountPoints[2].mountable.eyePositionOverride.transform.position - base.transform.forward * 1f, 2f, obj, 2162689);
				flag = obj.Count > 0;
			}
		}
		Facepunch.Pool.FreeList(ref obj);
		return !flag;
	}

	public override bool IsPlayerSeatSwapValid(BasePlayer player, int fromIndex, int toIndex)
	{
		if (!HasSaddle())
		{
			return false;
		}
		if (HasSingleSaddle())
		{
			return false;
		}
		if (HasDoubleSaddle() && toIndex == 0)
		{
			return false;
		}
		return true;
	}

	public override int NumSwappableSeats()
	{
		return mountPoints.Count;
	}

	public override void AttemptMount(BasePlayer player, bool doMountChecks = true)
	{
		if (IsForSale() || !MountEligable(player))
		{
			return;
		}
		BaseMountable baseMountable;
		if (HasSingleSaddle())
		{
			baseMountable = mountPoints[0].mountable;
		}
		else
		{
			if (!HasDoubleSaddle())
			{
				return;
			}
			baseMountable = (HasDriver() ? mountPoints[2].mountable : mountPoints[1].mountable);
		}
		if (baseMountable != null)
		{
			baseMountable.AttemptMount(player, doMountChecks);
		}
		if (PlayerIsMounted(player))
		{
			PlayerMounted(player, baseMountable);
		}
	}

	public override void SetupCorpse(BaseCorpse corpse)
	{
		base.SetupCorpse(corpse);
		HorseCorpse component = corpse.GetComponent<HorseCorpse>();
		if ((bool)component)
		{
			component.breedIndex = currentBreed;
		}
		else
		{
			Debug.Log("no horse corpse");
		}
	}

	public override void ScaleDamageForPlayer(BasePlayer player, HitInfo info)
	{
		base.ScaleDamageForPlayer(player, info);
		riderProtection.Scale(info.damageTypes);
	}

	public override void OnKilled(HitInfo hitInfo = null)
	{
		TryLeaveHitch();
		base.OnKilled(hitInfo);
	}

	public void SetBreed(int index)
	{
		ApplyBreed(index);
		SendNetworkUpdate();
	}

	public override void LeadingChanged()
	{
		if (!IsLeading())
		{
			TryHitch();
		}
	}

	public override void ServerInit()
	{
		SetBreed(UnityEngine.Random.Range(0, breeds.Length));
		baseHorseProtection = baseProtection;
		riderProtection = ScriptableObject.CreateInstance<ProtectionProperties>();
		baseProtection = ScriptableObject.CreateInstance<ProtectionProperties>();
		baseProtection.Add(baseHorseProtection, 1f);
		base.ServerInit();
		EquipmentUpdate();
	}

	public override void PlayerMounted(BasePlayer player, BaseMountable seat)
	{
		base.PlayerMounted(player, seat);
		InvokeRepeating(RecordDistance, distanceRecordingSpacing, distanceRecordingSpacing);
		TryLeaveHitch();
	}

	public override void PlayerDismounted(BasePlayer player, BaseMountable seat)
	{
		base.PlayerDismounted(player, seat);
		CancelInvoke(RecordDistance);
		if (NumMounted() == 0)
		{
			TryHitch();
		}
	}

	public bool IsHitched()
	{
		return currentHitch != null;
	}

	public void SetHitch(HitchTrough Hitch)
	{
		currentHitch = Hitch;
		SetFlag(Flags.Reserved3, currentHitch != null);
	}

	public override float ReplenishRatio()
	{
		return 1f;
	}

	public override void EatNearbyFood()
	{
		if (UnityEngine.Time.time < nextEatTime || (StaminaCoreFraction() >= 1f && base.healthFraction >= 1f))
		{
			return;
		}
		if (IsHitched())
		{
			Item foodItem = currentHitch.GetFoodItem();
			if (foodItem != null && foodItem.amount > 0)
			{
				ItemModConsumable component = foodItem.info.GetComponent<ItemModConsumable>();
				if ((bool)component)
				{
					float amount = component.GetIfType(MetabolismAttribute.Type.Calories) * currentHitch.caloriesToDecaySeconds;
					AddDecayDelay(amount);
					ReplenishFromFood(component);
					foodItem.UseItem();
					nextEatTime = UnityEngine.Time.time + UnityEngine.Random.Range(2f, 3f) + Mathf.InverseLerp(0.5f, 1f, StaminaCoreFraction()) * 4f;
					return;
				}
			}
		}
		base.EatNearbyFood();
	}

	public void TryLeaveHitch()
	{
		if ((bool)currentHitch)
		{
			currentHitch.Unhitch(this);
		}
	}

	public void TryHitch()
	{
		List<HitchTrough> obj = Facepunch.Pool.GetList<HitchTrough>();
		Vis.Entities(base.transform.position, 2.5f, obj, 256, QueryTriggerInteraction.Ignore);
		foreach (HitchTrough item in obj)
		{
			if (!(Vector3.Dot(Vector3Ex.Direction2D(item.transform.position, base.transform.position), base.transform.forward) < 0.4f) && !item.isClient && item.HasSpace() && item.ValidHitchPosition(base.transform.position) && item.AttemptToHitch(this))
			{
				break;
			}
		}
		Facepunch.Pool.FreeList(ref obj);
	}

	public void RecordDistance()
	{
		BasePlayer driver = GetDriver();
		if (driver == null)
		{
			tempDistanceTravelled = 0f;
			return;
		}
		kmDistance += tempDistanceTravelled / 1000f;
		if (kmDistance >= 1f)
		{
			driver.stats.Add(distanceStatName + "_km", 1, (Stats)5);
			kmDistance -= 1f;
		}
		driver.stats.Add(distanceStatName, Mathf.FloorToInt(tempDistanceTravelled));
		driver.stats.Save();
		totalDistance += tempDistanceTravelled;
		tempDistanceTravelled = 0f;
	}

	public override void MarkDistanceTravelled(float amount)
	{
		tempDistanceTravelled += amount;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.horse = Facepunch.Pool.Get<ProtoBuf.Horse>();
		info.msg.horse.staminaSeconds = staminaSeconds;
		info.msg.horse.currentMaxStaminaSeconds = currentMaxStaminaSeconds;
		info.msg.horse.breedIndex = currentBreed;
		info.msg.horse.numStorageSlots = numStorageSlots;
		if (!info.forDisk)
		{
			info.msg.horse.runState = (int)currentRunState;
			info.msg.horse.maxSpeed = GetRunSpeed();
		}
	}

	public override void OnClaimedWithToken(Item tokenItem)
	{
		base.OnClaimedWithToken(tokenItem);
		SetSeatCount(GetSaddleItemSeatCount(tokenItem));
	}

	public override void OnItemAddedOrRemoved(Item item, bool added)
	{
		base.OnItemAddedOrRemoved(item, added);
	}

	public override void OnInventoryDirty()
	{
		EquipmentUpdate();
	}

	public override bool CanAnimalAcceptItem(Item item, int targetSlot)
	{
		ItemModAnimalEquipment component = item.info.GetComponent<ItemModAnimalEquipment>();
		if (IsForSale() && ItemIsSaddle(item) && targetSlot >= 0 && targetSlot < numEquipmentSlots)
		{
			return false;
		}
		if (targetSlot >= 0 && targetSlot < numEquipmentSlots && !component)
		{
			return false;
		}
		if (ItemIsSaddle(item) && HasSaddle())
		{
			return false;
		}
		if (targetSlot < numEquipmentSlots)
		{
			if (component.slot == ItemModAnimalEquipment.SlotType.Basic)
			{
				return true;
			}
			for (int i = 0; i < numEquipmentSlots; i++)
			{
				Item slot = inventory.GetSlot(i);
				if (slot != null)
				{
					ItemModAnimalEquipment component2 = slot.info.GetComponent<ItemModAnimalEquipment>();
					if (!(component2 == null) && component2.slot == component.slot)
					{
						Debug.Log("rejecting because slot same, found : " + (int)component2.slot + " new : " + (int)component.slot);
						return false;
					}
				}
			}
		}
		return true;
	}

	public int GetStorageStartIndex()
	{
		return numEquipmentSlots;
	}

	public void EquipmentUpdate()
	{
		SetFlag(Flags.Reserved4, b: false, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved5, b: false, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved6, b: false, recursive: false, networkupdate: false);
		riderProtection.Clear();
		baseProtection.Clear();
		equipmentSpeedMod = 0f;
		numStorageSlots = 0;
		for (int i = 0; i < numEquipmentSlots; i++)
		{
			Item slot = inventory.GetSlot(i);
			if (slot == null)
			{
				continue;
			}
			ItemModAnimalEquipment component = slot.info.GetComponent<ItemModAnimalEquipment>();
			if ((bool)component)
			{
				SetFlag(component.WearableFlag, b: true, recursive: false, networkupdate: false);
				if (component.hideHair)
				{
					SetFlag(Flags.Reserved4, b: true);
				}
				if ((bool)component.riderProtection)
				{
					riderProtection.Add(component.riderProtection, 1f);
				}
				if ((bool)component.animalProtection)
				{
					baseProtection.Add(component.animalProtection, 1f);
				}
				equipmentSpeedMod += component.speedModifier;
				numStorageSlots += component.additionalInventorySlots;
			}
		}
		for (int j = GetStorageStartIndex(); j < inventory.capacity; j++)
		{
			if (j >= GetStorageStartIndex() + numStorageSlots)
			{
				Item slot2 = inventory.GetSlot(j);
				if (slot2 != null)
				{
					slot2.RemoveFromContainer();
					slot2.Drop(base.transform.position + Vector3.up + UnityEngine.Random.insideUnitSphere * 0.25f, Vector3.zero);
				}
			}
		}
		inventory.capacity = GetStorageStartIndex() + numStorageSlots;
		SendNetworkUpdate();
	}

	private void SetSeatCount(int count)
	{
		SetFlag(Flags.Reserved9, b: false, recursive: false, networkupdate: false);
		SetFlag(Flags.Reserved10, b: false, recursive: false, networkupdate: false);
		switch (count)
		{
		case 1:
			SetFlag(Flags.Reserved9, b: true, recursive: false, networkupdate: false);
			break;
		case 2:
			SetFlag(Flags.Reserved10, b: true, recursive: false, networkupdate: false);
			break;
		}
		UpdateMountFlags();
	}

	public override void DoNetworkUpdate()
	{
		bool num = false || prevStamina != staminaSeconds || prevMaxStamina != currentMaxStaminaSeconds || prevBreed != currentBreed || prevSlots != numStorageSlots || prevRunState != (int)currentRunState || prevMaxSpeed != GetRunSpeed();
		prevStamina = staminaSeconds;
		prevMaxStamina = currentMaxStaminaSeconds;
		prevRunState = (int)currentRunState;
		prevMaxSpeed = GetRunSpeed();
		prevBreed = currentBreed;
		prevSlots = numStorageSlots;
		if (num)
		{
			SendNetworkUpdate();
		}
	}

	public int GetSaddleItemSeatCount(Item item)
	{
		if (!ItemIsSaddle(item))
		{
			return 0;
		}
		ItemModAnimalEquipment component = item.info.GetComponent<ItemModAnimalEquipment>();
		if (component.slot == ItemModAnimalEquipment.SlotType.Saddle)
		{
			return 1;
		}
		if (component.slot == ItemModAnimalEquipment.SlotType.SaddleDouble)
		{
			return 2;
		}
		return 0;
	}

	public bool HasSaddle()
	{
		if (!HasSingleSaddle())
		{
			return HasDoubleSaddle();
		}
		return true;
	}

	public bool HasSingleSaddle()
	{
		return HasFlag(Flags.Reserved9);
	}

	public bool HasDoubleSaddle()
	{
		return HasFlag(Flags.Reserved10);
	}

	private bool ItemIsSaddle(Item item)
	{
		if (item == null)
		{
			return false;
		}
		ItemModAnimalEquipment component = item.info.GetComponent<ItemModAnimalEquipment>();
		if (component == null)
		{
			return false;
		}
		if (component.slot == ItemModAnimalEquipment.SlotType.Saddle || component.slot == ItemModAnimalEquipment.SlotType.SaddleDouble)
		{
			return true;
		}
		return false;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.horse != null)
		{
			staminaSeconds = info.msg.horse.staminaSeconds;
			currentMaxStaminaSeconds = info.msg.horse.currentMaxStaminaSeconds;
			numStorageSlots = info.msg.horse.numStorageSlots;
			ApplyBreed(info.msg.horse.breedIndex);
		}
	}

	public override bool HasValidSaddle()
	{
		return HasSaddle();
	}

	public override bool HasSeatAvailable()
	{
		if (!HasValidSaddle())
		{
			return false;
		}
		if (HasFlag(Flags.Reserved11))
		{
			return false;
		}
		return true;
	}

	public int GetSeatCapacity()
	{
		if (HasDoubleSaddle())
		{
			return 2;
		}
		if (HasSingleSaddle())
		{
			return 1;
		}
		return 0;
	}

	protected override bool CanPushNow(BasePlayer pusher)
	{
		return false;
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	public void RPC_ReqSwapSaddleType(RPCMessage msg)
	{
		BasePlayer player = msg.player;
		if (!(player == null) && !IsForSale() && HasSaddle() && !AnyMounted())
		{
			int tokenItemID = msg.read.Int32();
			Item item = GetPurchaseToken(player, tokenItemID);
			if (item != null)
			{
				ItemDefinition template = (HasSingleSaddle() ? PurchaseOptions[0].TokenItem : PurchaseOptions[1].TokenItem);
				OnClaimedWithToken(item);
				item.UseItem();
				Item item2 = ItemManager.Create(template, 1, 0uL);
				player.GiveItem(item2);
				SendNetworkUpdateImmediate();
			}
		}
	}

	public override int MaxMounted()
	{
		return GetSeatCapacity();
	}

	[ServerVar]
	public static void setHorseBreed(ConsoleSystem.Arg arg)
	{
		BasePlayer basePlayer = ArgEx.Player(arg);
		if (basePlayer == null)
		{
			return;
		}
		int @int = arg.GetInt(0);
		List<RidableHorse> obj = Facepunch.Pool.GetList<RidableHorse>();
		Vis.Entities(basePlayer.eyes.position, basePlayer.eyes.position + basePlayer.eyes.HeadForward() * 5f, 0f, obj);
		foreach (RidableHorse item in obj)
		{
			item.SetBreed(@int);
		}
		Facepunch.Pool.FreeList(ref obj);
	}
}
