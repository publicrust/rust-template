using System;
using Facepunch;
using Facepunch.Rust;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;

public class MiningQuarry : BaseResourceExtractor
{
	[Serializable]
	public enum QuarryType
	{
		None,
		Basic,
		Sulfur,
		HQM
	}

	[Serializable]
	public class ChildPrefab
	{
		public GameObjectRef prefabToSpawn;

		public GameObject origin;

		public BaseEntity instance;

		public void DoSpawn(MiningQuarry owner)
		{
			if (prefabToSpawn.isValid)
			{
				instance = GameManager.server.CreateEntity(prefabToSpawn.resourcePath, origin.transform.localPosition, origin.transform.localRotation);
				instance.SetParent(owner);
				instance.Spawn();
			}
		}
	}

	public Animator beltAnimator;

	public Renderer beltScrollRenderer;

	public int scrollMatIndex = 3;

	public float animatorSpeedChange = 1f;

	public float beltScrollSpeedMultiplier = 1f;

	public SoundPlayer[] onSounds;

	public float processRate = 5f;

	public float workToAdd = 15f;

	public float workPerFuel = 1000f;

	public float pendingWork;

	public GameObjectRef bucketDropEffect;

	public GameObject bucketDropTransform;

	public ChildPrefab engineSwitchPrefab;

	public ChildPrefab hopperPrefab;

	public ChildPrefab fuelStoragePrefab;

	public QuarryType staticType;

	public bool isStatic;

	public ResourceDepositManager.ResourceDeposit _linkedDeposit;

	public bool IsEngineOn()
	{
		return HasFlag(Flags.On);
	}

	public void SetOn(bool isOn)
	{
		SetFlag(Flags.On, isOn);
		engineSwitchPrefab.instance.SetFlag(Flags.On, isOn);
		SendNetworkUpdate();
		engineSwitchPrefab.instance.SendNetworkUpdate();
		if (isOn)
		{
			InvokeRepeating(ProcessResources, processRate, processRate);
		}
		else
		{
			CancelInvoke(ProcessResources);
		}
	}

	public void EngineSwitch(bool isOn)
	{
		if (isOn && FuelCheck())
		{
			SetOn(isOn: true);
		}
		else
		{
			SetOn(isOn: false);
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (isStatic)
		{
			UpdateStaticDeposit();
		}
		else
		{
			ResourceDepositManager.ResourceDeposit orCreate = ResourceDepositManager.GetOrCreate(base.transform.position);
			_linkedDeposit = orCreate;
		}
		SpawnChildEntities();
		engineSwitchPrefab.instance.SetFlag(Flags.On, HasFlag(Flags.On));
		if (base.isServer)
		{
			ItemContainer inventory = fuelStoragePrefab.instance.GetComponent<StorageContainer>().inventory;
			inventory.canAcceptItem = (Func<Item, int, bool>)Delegate.Combine(inventory.canAcceptItem, new Func<Item, int, bool>(CanAcceptItem));
		}
	}

	public bool CanAcceptItem(Item item, int targetSlot)
	{
		return item.info.shortname == "diesel_barrel";
	}

	public void UpdateStaticDeposit()
	{
		if (isStatic)
		{
			if (_linkedDeposit == null)
			{
				_linkedDeposit = new ResourceDepositManager.ResourceDeposit();
			}
			else
			{
				_linkedDeposit._resources.Clear();
			}
			if (staticType == QuarryType.None)
			{
				_linkedDeposit.Add(ItemManager.FindItemDefinition("stones"), 1f, 1000, 0.3f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
				_linkedDeposit.Add(ItemManager.FindItemDefinition("metal.ore"), 1f, 1000, 5f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
				_linkedDeposit.Add(ItemManager.FindItemDefinition("sulfur.ore"), 1f, 1000, 7.5f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
				_linkedDeposit.Add(ItemManager.FindItemDefinition("hq.metal.ore"), 1f, 1000, 75f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
			}
			else if (staticType == QuarryType.Basic)
			{
				_linkedDeposit.Add(ItemManager.FindItemDefinition("metal.ore"), 1f, 1000, 1f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
				_linkedDeposit.Add(ItemManager.FindItemDefinition("stones"), 1f, 1000, 0.2f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
			}
			else if (staticType == QuarryType.Sulfur)
			{
				_linkedDeposit.Add(ItemManager.FindItemDefinition("sulfur.ore"), 1f, 1000, 1f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
			}
			else if (staticType == QuarryType.HQM)
			{
				_linkedDeposit.Add(ItemManager.FindItemDefinition("hq.metal.ore"), 1f, 1000, 20f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM);
			}
			_linkedDeposit.Add(ItemManager.FindItemDefinition("crude.oil"), 1f, 1000, 16.666666f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM, liquid: true);
			_linkedDeposit.Add(ItemManager.FindItemDefinition("lowgradefuel"), 1f, 1000, 5.882353f, ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM, liquid: true);
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		EngineSwitch(HasFlag(Flags.On));
		UpdateStaticDeposit();
	}

	public void SpawnChildEntities()
	{
		engineSwitchPrefab.DoSpawn(this);
		hopperPrefab.DoSpawn(this);
		fuelStoragePrefab.DoSpawn(this);
	}

	public void ProcessResources()
	{
		if (_linkedDeposit == null || hopperPrefab.instance == null)
		{
			return;
		}
		if (!FuelCheck())
		{
			SetOn(isOn: false);
		}
		float num = Mathf.Min(workToAdd, pendingWork);
		pendingWork -= num;
		foreach (ResourceDepositManager.ResourceDeposit.ResourceDepositEntry resource in _linkedDeposit._resources)
		{
			if ((!canExtractLiquid && resource.isLiquid) || (!canExtractSolid && !resource.isLiquid))
			{
				continue;
			}
			float workNeeded = resource.workNeeded;
			int num2 = Mathf.FloorToInt(resource.workDone / workNeeded);
			resource.workDone += num;
			int num3 = Mathf.FloorToInt(resource.workDone / workNeeded);
			if (resource.workDone > workNeeded)
			{
				resource.workDone %= workNeeded;
			}
			if (num2 != num3)
			{
				int iAmount = num3 - num2;
				Item item = ItemManager.Create(resource.type, iAmount, 0uL);
				Facepunch.Rust.Analytics.Azure.OnQuarryItem(Facepunch.Rust.Analytics.Azure.ResourceMode.Produced, item.info.shortname, item.amount, this);
				if (Interface.CallHook("OnQuarryGather", this, item) != null)
				{
					item.Remove();
				}
				else if (!item.MoveToContainer(hopperPrefab.instance.GetComponent<StorageContainer>().inventory))
				{
					item.Remove();
					SetOn(isOn: false);
				}
			}
		}
	}

	public bool FuelCheck()
	{
		if (pendingWork > 0f)
		{
			return true;
		}
		Item item = fuelStoragePrefab.instance.GetComponent<StorageContainer>().inventory.FindItemByItemName("diesel_barrel");
		object obj = Interface.CallHook("OnQuarryConsumeFuel", this, item);
		if (obj is Item)
		{
			item = (Item)obj;
		}
		if (item != null && item.amount >= 1)
		{
			pendingWork += workPerFuel;
			Facepunch.Rust.Analytics.Azure.OnQuarryItem(Facepunch.Rust.Analytics.Azure.ResourceMode.Consumed, item.info.shortname, 1, this);
			item.UseItem();
			return true;
		}
		return false;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.forDisk)
		{
			if (fuelStoragePrefab.instance == null || hopperPrefab.instance == null)
			{
				Debug.Log("Cannot save mining quary because children were null");
				return;
			}
			info.msg.miningQuarry = Pool.Get<ProtoBuf.MiningQuarry>();
			info.msg.miningQuarry.extractor = Pool.Get<ResourceExtractor>();
			info.msg.miningQuarry.extractor.fuelContents = fuelStoragePrefab.instance.GetComponent<StorageContainer>().inventory.Save();
			info.msg.miningQuarry.extractor.outputContents = hopperPrefab.instance.GetComponent<StorageContainer>().inventory.Save();
			info.msg.miningQuarry.staticType = (int)staticType;
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.fromDisk && info.msg.miningQuarry != null)
		{
			if (fuelStoragePrefab.instance == null || hopperPrefab.instance == null)
			{
				Debug.Log("Cannot load mining quary because children were null");
				return;
			}
			fuelStoragePrefab.instance.GetComponent<StorageContainer>().inventory.Load(info.msg.miningQuarry.extractor.fuelContents);
			hopperPrefab.instance.GetComponent<StorageContainer>().inventory.Load(info.msg.miningQuarry.extractor.outputContents);
			staticType = (QuarryType)info.msg.miningQuarry.staticType;
		}
	}
}
