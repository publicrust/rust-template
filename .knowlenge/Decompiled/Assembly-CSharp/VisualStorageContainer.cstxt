using System;
using ProtoBuf;
using UnityEngine;

public class VisualStorageContainer : LootContainer
{
	[Serializable]
	public class DisplayModel
	{
		public GameObject displayModel;

		public ItemDefinition def;

		public int slot;
	}

	public VisualStorageContainerNode[] displayNodes;

	public DisplayModel[] displayModels;

	public Transform nodeParent;

	public GameObject defaultDisplayModel;

	public override void ServerInit()
	{
		base.ServerInit();
	}

	public override void OnItemAddedOrRemoved(Item item, bool added)
	{
		base.OnItemAddedOrRemoved(item, added);
	}

	public override void PopulateLoot()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		base.PopulateLoot();
		for (int i = 0; i < inventorySlots; i++)
		{
			Item slot = base.inventory.GetSlot(i);
			if (slot == null)
			{
				continue;
			}
			DroppedItem component = ((Component)slot.Drop(((Component)displayNodes[i]).transform.position + new Vector3(0f, 0.25f, 0f), Vector3.zero, ((Component)displayNodes[i]).transform.rotation)).GetComponent<DroppedItem>();
			if (Object.op_Implicit((Object)(object)component))
			{
				ReceiveCollisionMessages(b: false);
				((FacepunchBehaviour)this).CancelInvoke((Action)component.IdleDestroy);
				Rigidbody componentInChildren = ((Component)component).GetComponentInChildren<Rigidbody>();
				if (Object.op_Implicit((Object)(object)componentInChildren))
				{
					componentInChildren.constraints = (RigidbodyConstraints)10;
				}
			}
		}
	}

	public void ClearRigidBodies()
	{
		if (displayModels == null)
		{
			return;
		}
		DisplayModel[] array = displayModels;
		foreach (DisplayModel displayModel in array)
		{
			if (displayModel != null)
			{
				Object.Destroy((Object)(object)displayModel.displayModel.GetComponentInChildren<Rigidbody>());
			}
		}
	}

	public void SetItemsVisible(bool vis)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (displayModels == null)
		{
			return;
		}
		DisplayModel[] array = displayModels;
		foreach (DisplayModel displayModel in array)
		{
			if (displayModel != null)
			{
				LODGroup componentInChildren = displayModel.displayModel.GetComponentInChildren<LODGroup>();
				if (Object.op_Implicit((Object)(object)componentInChildren))
				{
					componentInChildren.localReferencePoint = (Vector3)(vis ? Vector3.zero : new Vector3(10000f, 10000f, 10000f));
				}
				else
				{
					Debug.Log((object)("VisualStorageContainer item missing LODGroup" + ((Object)displayModel.displayModel.gameObject).name));
				}
			}
		}
	}

	public void ItemUpdateComplete()
	{
		ClearRigidBodies();
		SetItemsVisible(vis: true);
	}

	public void UpdateVisibleItems(ItemContainer msg)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < displayModels.Length; i++)
		{
			DisplayModel displayModel = displayModels[i];
			if (displayModel != null)
			{
				Object.Destroy((Object)(object)displayModel.displayModel);
				displayModels[i] = null;
			}
		}
		if (msg == null)
		{
			return;
		}
		foreach (Item content in msg.contents)
		{
			ItemDefinition itemDefinition = ItemManager.FindItemDefinition(content.itemid);
			GameObject val = null;
			val = ((itemDefinition.GetWorldModel(content.amount) == null || !itemDefinition.GetWorldModel(content.amount).isValid) ? Object.Instantiate<GameObject>(defaultDisplayModel) : itemDefinition.GetWorldModel(content.amount).Instantiate());
			if (Object.op_Implicit((Object)(object)val))
			{
				val.transform.SetPositionAndRotation(((Component)displayNodes[content.slot]).transform.position + new Vector3(0f, 0.25f, 0f), ((Component)displayNodes[content.slot]).transform.rotation);
				Rigidbody obj = val.AddComponent<Rigidbody>();
				obj.mass = 1f;
				obj.drag = 0.1f;
				obj.angularDrag = 0.1f;
				obj.interpolation = (RigidbodyInterpolation)1;
				obj.constraints = (RigidbodyConstraints)10;
				displayModels[content.slot].displayModel = val;
				displayModels[content.slot].slot = content.slot;
				displayModels[content.slot].def = itemDefinition;
				val.SetActive(true);
			}
		}
		SetItemsVisible(vis: false);
		((FacepunchBehaviour)this).CancelInvoke((Action)ItemUpdateComplete);
		((FacepunchBehaviour)this).Invoke((Action)ItemUpdateComplete, 1f);
	}
}
