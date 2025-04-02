using System;
using System.Linq;
using UnityEngine;

public class ItemSkinDirectory : ScriptableObject
{
	[Serializable]
	public struct Skin
	{
		public int id;

		public int itemid;

		public string name;

		public bool isSkin;

		private SteamInventoryItem _invItem;

		public SteamInventoryItem invItem
		{
			get
			{
				if (_invItem == null && !string.IsNullOrEmpty(name))
				{
					_invItem = FileSystem.Load<SteamInventoryItem>(name);
				}
				return _invItem;
			}
		}
	}

	private static ItemSkinDirectory _Instance;

	public Skin[] skins;

	public static ItemSkinDirectory Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = FileSystem.Load<ItemSkinDirectory>("assets/skins.asset");
				if (_Instance == null)
				{
					throw new Exception("Couldn't load assets/skins.asset");
				}
				if (_Instance.skins == null || _Instance.skins.Length == 0)
				{
					throw new Exception("Loaded assets/skins.asset but something is wrong");
				}
			}
			return _Instance;
		}
	}

	public static Skin[] ForItem(ItemDefinition item)
	{
		return Instance.skins.Where((Skin x) => x.isSkin && x.itemid == item.itemid).ToArray();
	}

	public static Skin FindByInventoryDefinitionId(int id)
	{
		return Instance.skins.Where((Skin x) => x.id == id).FirstOrDefault();
	}

	public static bool TryGetItemFromDefinitionID(int id, out ItemDefinition result)
	{
		result = null;
		Skin skin = FindByInventoryDefinitionId(id);
		if (skin.invItem != null)
		{
			result = skin.invItem.itemDefinition;
			if (skin.invItem is ItemSkin itemSkin && itemSkin.Redirect != null)
			{
				result = itemSkin.Redirect;
			}
		}
		return result != null;
	}
}
