using UnityEngine;

public class ItemModCookable : ItemMod
{
	[ItemSelector(ItemCategory.All)]
	public ItemDefinition becomeOnCooked;

	public float cookTime = 30f;

	public int amountOfBecome = 1;

	public int lowTemp;

	public int highTemp;

	public bool setCookingFlag;

	public void OnValidate()
	{
		if (amountOfBecome < 1)
		{
			amountOfBecome = 1;
		}
		if (becomeOnCooked == null)
		{
			Debug.LogWarning("[ItemModCookable] becomeOnCooked is unset! [" + base.name + "]", base.gameObject);
		}
	}

	public override void OnItemCreated(Item itemcreated)
	{
		float cooktimeLeft = cookTime;
		itemcreated.onCycle += delegate(Item item, float delta)
		{
			float temperature = item.temperature;
			if (temperature < (float)lowTemp || temperature > (float)highTemp || cooktimeLeft < 0f)
			{
				if (setCookingFlag && item.HasFlag(Item.Flag.Cooking))
				{
					item.SetFlag(Item.Flag.Cooking, b: false);
					item.MarkDirty();
				}
			}
			else
			{
				if (setCookingFlag && !item.HasFlag(Item.Flag.Cooking))
				{
					item.SetFlag(Item.Flag.Cooking, b: true);
					item.MarkDirty();
				}
				cooktimeLeft -= delta;
				if (!(cooktimeLeft > 0f))
				{
					int position = item.position;
					if (item.amount > 1)
					{
						cooktimeLeft = cookTime;
						item.amount--;
						item.MarkDirty();
					}
					else
					{
						item.Remove();
					}
					if (becomeOnCooked != null)
					{
						Item item2 = ItemManager.Create(becomeOnCooked, amountOfBecome, 0uL);
						if (item2 != null && !item2.MoveToContainer(item.parent, position) && !item2.MoveToContainer(item.parent))
						{
							item2.Drop(item.parent.dropPosition, item.parent.dropVelocity);
							if ((bool)item.parent.entityOwner)
							{
								BaseOven component = item.parent.entityOwner.GetComponent<BaseOven>();
								if (component != null)
								{
									component.OvenFull();
								}
							}
						}
					}
				}
			}
		};
	}
}
