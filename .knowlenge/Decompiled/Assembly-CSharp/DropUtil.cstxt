using ConVar;
using Oxide.Core;
using UnityEngine;

public class DropUtil
{
	public static void DropItems(ItemContainer container, Vector3 position)
	{
		if (!Server.dropitems || container == null || container.itemList == null || Interface.CallHook("OnContainerDropItems", container) != null)
		{
			return;
		}
		float num = 0.25f;
		Item[] array = container.itemList.ToArray();
		foreach (Item item in array)
		{
			float num2 = UnityEngine.Random.Range(0f, 2f);
			item.RemoveFromContainer();
			BaseEntity baseEntity = item.CreateWorldObject(position + new Vector3(UnityEngine.Random.Range(0f - num, num), 1f, UnityEngine.Random.Range(0f - num, num)));
			if (baseEntity == null)
			{
				item.Remove();
				continue;
			}
			if (baseEntity is DroppedItem droppedItem && container.entityOwner is LootContainer)
			{
				droppedItem.DropReason = DroppedItem.DropReasonEnum.Loot;
			}
			if (num2 > 0f)
			{
				baseEntity.SetVelocity(new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(-1f, 1f)) * num2);
				baseEntity.SetAngularVelocity(new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f)) * num2);
			}
		}
	}
}
