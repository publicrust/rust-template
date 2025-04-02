using System;
using System.Collections.Generic;

public interface IPlayerItemDefinition : IEquatable<IPlayerItemDefinition>
{
	int DefinitionId { get; }

	string Name { get; }

	string Description { get; }

	string Type { get; }

	string IconUrl { get; }

	int LocalPrice { get; }

	string LocalPriceFormatted { get; }

	string PriceCategory { get; }

	bool IsGenerator { get; }

	bool IsTradable { get; }

	bool IsMarketable { get; }

	string StoreTags { get; }

	DateTime Created { get; }

	DateTime Modified { get; }

	string ItemShortName { get; }

	ulong WorkshopId { get; }

	ulong WorkshopDownload { get; }

	IEnumerable<PlayerItemRecipe> GetRecipesContainingThis();
}
