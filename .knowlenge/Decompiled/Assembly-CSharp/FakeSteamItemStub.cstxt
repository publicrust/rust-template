using System;
using System.Collections.Generic;

public class FakeSteamItemStub : IPlayerItemDefinition, IEquatable<IPlayerItemDefinition>
{
	private SteamInventoryItem _source;

	public int DefinitionId => _source.id;

	public string Name => _source.displayName.translated;

	public string Description => _source.displayDescription.translated;

	public string Type => "Type";

	public string IconUrl => string.Empty;

	public int LocalPrice => 0;

	public string LocalPriceFormatted => "$0.00";

	public string PriceCategory => "PriceCategory";

	public bool IsGenerator => false;

	public bool IsTradable => false;

	public bool IsMarketable => false;

	public string StoreTags => "StoreTags";

	public DateTime Created { get; }

	public DateTime Modified { get; }

	public string ItemShortName => _source.itemname;

	public ulong WorkshopId
	{
		get
		{
			if (!(_source is ItemSkin itemSkin))
			{
				return 0uL;
			}
			return itemSkin.workshopID;
		}
	}

	public ulong WorkshopDownload { get; }

	public FakeSteamItemStub(SteamInventoryItem itemBacking)
	{
		_source = itemBacking;
	}

	public bool Equals(IPlayerItemDefinition other)
	{
		return other.DefinitionId == DefinitionId;
	}

	public IEnumerable<PlayerItemRecipe> GetRecipesContainingThis()
	{
		return null;
	}
}
