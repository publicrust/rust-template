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

	public static readonly Phrase RfOffTitle = new Phrase("rf_off", "Disable RF");

	public static readonly Phrase RfOffDesc = new Phrase("rf_off_desc", " Disable detonation via RF");

	public static readonly Phrase RfOnTitle = new Phrase("rf_on", "Enable RF");

	public static readonly Phrase RfOnDesc = new Phrase("rf_on_desc", " Enable detonation via RF");

	public GameObjectRef frequencyPanelPrefab;

	public bool allowArmDisarm;

	public bool onlyFrequency;

	public int defaultFrequency = -1;

	public bool loseConditionOnChange;

	private static List<ItemTime> itemsOnCooldown = new List<ItemTime>();

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		base.ServerCommand(item, command, player);
		if (command.Contains("SetFrequency"))
		{
			if (itemsOnCooldown.Count > 0 && onlyFrequency)
			{
				for (int num = itemsOnCooldown.Count - 1; num >= 0; num--)
				{
					if (itemsOnCooldown[num].TargetItem == item && TimeSince.op_Implicit(itemsOnCooldown[num].TimeSinceEdit) < 2f)
					{
						return;
					}
					if (TimeSince.op_Implicit(itemsOnCooldown[num].TimeSinceEdit) > 2f)
					{
						itemsOnCooldown.RemoveAt(num);
					}
				}
			}
			int result = 0;
			if (int.TryParse(command.Substring(command.IndexOf(":") + 1), out result))
			{
				BaseEntity heldEntity = item.GetHeldEntity();
				if ((Object)(object)heldEntity != (Object)null && heldEntity is Detonator detonator)
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
						TimeSinceEdit = TimeSince.op_Implicit(0f)
					});
				}
			}
			else
			{
				Debug.Log((object)"Parse fuckup");
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
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		if (item.instanceData == null)
		{
			item.instanceData = new InstanceData();
			item.instanceData.ShouldPool = false;
			item.instanceData.dataInt = defaultFrequency;
		}
	}
}
