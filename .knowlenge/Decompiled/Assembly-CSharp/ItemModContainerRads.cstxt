using System;

public class ItemModContainerRads : ItemModContainer
{
	public override void OnItemCreated(Item item)
	{
		base.OnItemCreated(item);
		if (item != null && item.contents != null)
		{
			CountRads(item.contents);
			ItemContainer contents = item.contents;
			contents.onItemParentChanged = (Action<Item, Item>)Delegate.Combine(contents.onItemParentChanged, new Action<Item, Item>(OnItemParentChanged));
			ItemContainer contents2 = item.contents;
			contents2.onItemRadiationChanged = (Action<Item, float>)Delegate.Combine(contents2.onItemRadiationChanged, new Action<Item, float>(OnItemRadiationChanged));
			ItemContainer contents3 = item.contents;
			contents3.onItemAddedRemoved = (Action<Item, bool>)Delegate.Combine(contents3.onItemAddedRemoved, new Action<Item, bool>(OnItemAddedRemoved));
			ItemContainer contents4 = item.contents;
			contents4.onItemAddedToStack = (Action<Item, int>)Delegate.Combine(contents4.onItemAddedToStack, new Action<Item, int>(OnItemAddedToStack));
			ItemContainer contents5 = item.contents;
			contents5.onItemRemovedFromStack = (Action<Item, int>)Delegate.Combine(contents5.onItemRemovedFromStack, new Action<Item, int>(OnItemRemovedFromStack));
		}
	}

	public override void OnRemove(Item item)
	{
		base.OnRemove(item);
		if (item != null && item.contents != null)
		{
			ItemContainer contents = item.contents;
			contents.onItemParentChanged = (Action<Item, Item>)Delegate.Remove(contents.onItemParentChanged, new Action<Item, Item>(OnItemParentChanged));
			ItemContainer contents2 = item.contents;
			contents2.onItemRadiationChanged = (Action<Item, float>)Delegate.Remove(contents2.onItemRadiationChanged, new Action<Item, float>(OnItemRadiationChanged));
			ItemContainer contents3 = item.contents;
			contents3.onItemAddedRemoved = (Action<Item, bool>)Delegate.Remove(contents3.onItemAddedRemoved, new Action<Item, bool>(OnItemAddedRemoved));
			ItemContainer contents4 = item.contents;
			contents4.onItemAddedToStack = (Action<Item, int>)Delegate.Remove(contents4.onItemAddedToStack, new Action<Item, int>(OnItemAddedToStack));
			ItemContainer contents5 = item.contents;
			contents5.onItemRemovedFromStack = (Action<Item, int>)Delegate.Remove(contents5.onItemRemovedFromStack, new Action<Item, int>(OnItemRemovedFromStack));
		}
	}

	public override void OnParentChanged(Item item)
	{
		ProcessRadCountFromParent(item);
	}

	private void OnItemParentChanged(Item parent, Item child)
	{
		ProcessRadCountFromParent(parent);
	}

	private void OnItemRadiationChanged(Item item, float rads)
	{
		ProcessRadCountFromChild(item);
	}

	private void OnItemAddedRemoved(Item childItem, bool added)
	{
		if (childItem != null)
		{
			ProcessRadCountFromChild(childItem);
		}
	}

	private void OnItemRemovedFromStack(Item childItem, int amount)
	{
		ProcessRadCountFromChild(childItem);
	}

	private void OnItemAddedToStack(Item childItem, int amount)
	{
		ProcessRadCountFromChild(childItem);
	}

	private void ProcessRadCountFromChild(Item childItem)
	{
		ItemContainer parent = childItem.parent;
		if (parent != null)
		{
			CountRads(parent);
		}
	}

	private void ProcessRadCountFromParent(Item item, bool skipEvent = false)
	{
		ItemContainer contents = item.contents;
		if (contents != null)
		{
			CountRads(contents, skipEvent);
		}
	}

	private void CountRads(ItemContainer container, bool skipEvent = false)
	{
		Item parent = container.parent;
		if (container?.itemList == null)
		{
			return;
		}
		if (container.itemList.Count == 0)
		{
			parent.radioactivity = 0f;
			if (!skipEvent)
			{
				parent.parent?.onItemRadiationChanged?.Invoke(parent, 0f);
			}
		}
		else
		{
			if (container.itemList[0] == null)
			{
				return;
			}
			float num = 0f;
			foreach (Item item in container.itemList)
			{
				num += (float)item.amount * item.radioactivity;
			}
			if (parent == null)
			{
				return;
			}
			if (num > 0f)
			{
				if (!parent.HasFlag(Item.Flag.Radioactive))
				{
					parent.SetFlag(Item.Flag.Radioactive, b: true);
				}
			}
			else if (parent.HasFlag(Item.Flag.Radioactive))
			{
				parent.SetFlag(Item.Flag.Radioactive, b: false);
			}
			parent.radioactivity = num;
			if (parent.parent != null && !skipEvent)
			{
				parent.parent.onItemRadiationChanged?.Invoke(parent, num);
			}
		}
	}
}
