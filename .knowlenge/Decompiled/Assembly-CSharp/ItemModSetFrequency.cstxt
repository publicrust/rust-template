using ProtoBuf;
using UnityEngine;

public class ItemModSetFrequency : ItemMod
{
	public GameObjectRef frequencyPanelPrefab;

	public bool allowArmDisarm;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		base.ServerCommand(item, command, player);
		if (command.Contains("SetFrequency"))
		{
			int result = 0;
			if (int.TryParse(command.Substring(command.IndexOf(":") + 1), out result))
			{
				item.instanceData.dataInt = result;
				item.MarkDirty();
			}
			else
			{
				Debug.Log("Parse fuckup");
			}
		}
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

	public override void OnItemCreated(Item item)
	{
		if (item.instanceData == null)
		{
			item.instanceData = new ProtoBuf.Item.InstanceData();
			item.instanceData.ShouldPool = false;
			item.instanceData.dataInt = -1;
		}
	}
}
