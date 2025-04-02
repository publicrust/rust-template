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
		base.PopulateLoot();
		for (int i = 0; i < inventorySlots; i++)
		{
			Item slot = base.inventory.GetSlot(i);
			if (slot == null)
			{
				continue;
			}
			DroppedItem component = slot.Drop(displayNodes[i].transform.position + new Vector3(0f, 0.25f, 0f), Vector3.zero, displayNodes[i].transform.rotation).GetComponent<DroppedItem>();
			if ((bool)component)
			{
				ReceiveCollisionMessages(b: false);
				CancelInvoke(component.IdleDestroy);
				Rigidbody componentInChildren = component.GetComponentInChildren<Rigidbody>();
				if ((bool)componentInChildren)
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
				UnityEngine.Object.Destroy(displayModel.displayModel.GetComponentInChildren<Rigidbody>());
			}
		}
	}

	public void SetItemsVisible(bool vis)
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
				LODGroup componentInChildren = displayModel.displayModel.GetComponentInChildren<LODGroup>();
				if ((bool)componentInChildren)
				{
					componentInChildren.localReferencePoint = (vis ? Vector3.zero : new Vector3(10000f, 10000f, 10000f));
				}
				else
				{
					Debug.Log("VisualStorageContainer item missing LODGroup" + displayModel.displayModel.gameObject.name);
				}
			}
		}
	}

	public void ItemUpdateComplete()
	{
		ClearRigidBodies();
		SetItemsVisible(vis: true);
	}

	public void UpdateVisibleItems(ProtoBuf.ItemContainer msg)
	{
		for (int i = 0; i < displayModels.Length; i++)
		{
			DisplayModel displayModel = displayModels[i];
			if (displayModel != null)
			{
				UnityEngine.Object.Destroy(displayModel.displayModel);
				displayModels[i] = null;
			}
		}
		if (msg == null)
		{
			return;
		}
		foreach (ProtoBuf.Item content in msg.contents)
		{
			ItemDefinition itemDefinition = ItemManager.FindItemDefinition(content.itemid);
			GameObject gameObject = null;
			gameObject = ((itemDefinition.GetWorldModel(content.amount) == null || !itemDefinition.GetWorldModel(content.amount).isValid) ? UnityEngine.Object.Instantiate(defaultDisplayModel) : itemDefinition.GetWorldModel(content.amount).Instantiate());
			if ((bool)gameObject)
			{
				gameObject.transform.SetPositionAndRotation(displayNodes[content.slot].transform.position + new Vector3(0f, 0.25f, 0f), displayNodes[content.slot].transform.rotation);
				Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
				rigidbody.mass = 1f;
				rigidbody.drag = 0.1f;
				rigidbody.angularDrag = 0.1f;
				rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
				rigidbody.constraints = (RigidbodyConstraints)10;
				displayModels[content.slot].displayModel = gameObject;
				displayModels[content.slot].slot = content.slot;
				displayModels[content.slot].def = itemDefinition;
				gameObject.SetActive(value: true);
			}
		}
		SetItemsVisible(vis: false);
		CancelInvoke(ItemUpdateComplete);
		Invoke(ItemUpdateComplete, 1f);
	}
}
