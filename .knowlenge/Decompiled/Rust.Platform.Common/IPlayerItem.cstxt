using System;
using System.Threading.Tasks;

public interface IPlayerItem
{
	ulong Id { get; }

	int DefinitionId { get; }

	int Quantity { get; }

	DateTimeOffset Acquired { get; }

	ulong WorkshopId { get; }

	string ItemShortName { get; }

	Task Consume();
}
