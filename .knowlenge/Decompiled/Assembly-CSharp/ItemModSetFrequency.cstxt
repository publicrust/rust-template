using System.Collections.Generic;
using ProtoBuf;
using UnityEngine;

public class ItemModSetFrequency : ItemMod
{
	private struct ItemTime
	{
		public Item TargetItem;

		public TimeSince TimeSinceEdit;
	}

	public static readonly Translate.Phrase RfOffTitle = new Translate.Phrase("rf_off", "Disable RF");

	public static readonly Translate.Phrase RfOffDesc = new Translate.Phrase("rf_off_desc", " Disable detonation via RF");

	public static readonly Translate.Phrase RfOnTitle = new Translate.Phrase("rf_on", "Enable RF");

	public static readonly Translate.Phrase RfOnDesc = new Translate.Phrase("rf_on_desc", " Enable detonation via RF");

	public GameObjectRef frequencyPanelPrefab;

	public bool allowArmDisarm;

	public bool onlyFrequency;

	public int defaultFrequency = -1;

	public bool loseConditionOnChange;

	private static List<ItemTime> itemsOnCooldown = new List<ItemTime>();

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		base.ServerCommand(item, command, player);
		if (command.Contains("SetFrequency"))
		{
			if (itemsOnCooldown.Count > 0 && onlyFrequency)
			{
				for (int num = itemsOnCooldown.Count - 1; num >= 0; num--)
				{
					if (itemsOnCooldown[num].TargetItem == item && (float)itemsOnCooldown[num].TimeSinceEdit < 2f)
					{
						return;
					}
					if ((float)itemsOnCooldown[num].TimeSinceEdit > 2f)
					{
						itemsOnCooldown.RemoveAt(num);
					}
				}
			}
			int result = 0;
			if (int.TryParse(command.Substring(command.IndexOf(":") + 1), out result))
			{
				BaseEntity heldEntity = item.GetHeldEntity();
				if (heldEntity != null && heldEntity is Detonator detonator)
				{
					detonator.ServerSetFrequency(player, result);
				}
				else
				{
					item.instanceData.dataInt = result;
					if (loseConditionOnChange)
					{
						item.LoseCondition(item.maxCondition * 0.01f);
					}
					item.MarkDirty();
				}
				if (onlyFrequency)
				{
					itemsOnCooldown.Add(new ItemTime
					{
						TargetItem = item,
						TimeSinceEdit = 0f
					});
				}
			}
			else
			{
				Debug.Log("Parse fuckup");
			}
		}
		if (!onlyFrequency)
		{
			if (command == "rf_on")
			{
				item.SetFlag(Item.Flag.IsOn, b: true);
				item.MarkDirty();
			}
			else if (command == "rf_off")
			{
				item.SetFlag(Item.Flag.IsOn, b: false);
				item.MarkDirty();
			}
		}
	}

	public override void OnItemCreated(Item item)
	{
		if (item.instanceData == null)
		{
			item.instanceData = new ProtoBuf.Item.InstanceData();
			item.instanceData.ShouldPool = false;
			item.instanceData.dataInt = defaultFrequency;
		}
	}
}
